using CrosswordAssistant.Entities;
using CrosswordAssistant.Services;

namespace CrosswordAssistant
{
    public partial class MainForm : Form
    {
        private readonly DictionaryService _dictionaryService;
        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            KeyPreview = true;

            _dictionaryService = new DictionaryService();
            if (_dictionaryService.DictionaryLoadError())
            {
                Load += (s, e) => Close();
                return;
            }

            InitControls();
        }

        #region events handlers
        private void SearchPattern_Click(object sender, EventArgs e)
        {
            SetMode();
            string pattern = textBoxPattern.Text.Trim().ToLower();
            if (!ValidatePattern(pattern)) return;
            textBoxPattern.ReadOnly = true;
            List<string> matches = [];
            switch (_dictionaryService.Mode)
            {
                case SearchMode.Pattern:
                    matches = _dictionaryService.SearchByPattern(pattern);
                    break;
                case SearchMode.Anagram:
                    matches = _dictionaryService.SearchForAnagrams(pattern);
                    break;
                case SearchMode.Length:
                    int min, max;
                    bool minOk = int.TryParse(textBoxMinLen.Text, out min);
                    bool maxOk = int.TryParse(textBoxMaxLen.Text, out max);
                    if (minOk && maxOk)
                    {
                        matches = _dictionaryService.SearchWithGivenLength(min, max);
                    }
                    else
                    {
                        MessageBox.Show("Podaj poprawny zakres dla iloœci znaków", "B³¹d danych",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case SearchMode.Metagram:
                    matches = _dictionaryService.SearchForMetagrams(pattern);
                    break;
            }
            matches = ApplyFilters(matches);
            matches = BoundTo500(matches);
            FillTextBoxResults(matches, textBoxPatternResults);
            textBoxPattern.ReadOnly = false;
        }
        private void UluzSamSearch_Click(object sender, EventArgs e)
        {
            textBoxPatternUls.ReadOnly = true;
            _dictionaryService.Mode = SearchMode.UluzSam;
            int result = ValidateUluzSamPattern(textBoxPatternUls.Text);
            if(result == -1)
            {
                MessageBox.Show("Wzorzec zawiera niedozwolone znaki, powinien zawieraæ tylko cyfry 1-8.",
                    "B³¹d wzorca",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            if(!ValidateUluzSamGroups())
            {
                MessageBox.Show("Grupy zawieraj¹ niedozwolone znaki, powinnny zawieraæ tylko litery polsiego alfabetu.",
                    "B³¹d grup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            List<int> digits = ConvertIntToList(result);
            string[] groups = ConvertGroupsToArray();
            List<string> matches = _dictionaryService.SearchUluzSam(digits, groups);
            matches = BoundTo500(matches);
            FillTextBoxResults(matches, textBoxResultsUls);
            textBoxPatternUls.ReadOnly = false;
        }
        private void RadioPattern_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPatternMode.Checked)
            {
                _dictionaryService.Mode = SearchMode.Pattern;
                textBoxPatternResults.Text = Messages.PatternModeMessage;
            }
        }
        private void RadioAnagram_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAnagramMode.Checked)
            {
                _dictionaryService.Mode = SearchMode.Anagram;
                textBoxPatternResults.Text = Messages.AnagramModeMessage;
            }
        }
        private void RadioLength_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLengthMode.Checked)
            {
                groupBoxMode.Size = new Size(groupBoxMode.Size.Width, 160);
                _dictionaryService.Mode = SearchMode.Length;
                textBoxPatternResults.Text = Messages.LengthModeMessage;
                textBoxPattern.Enabled = false;
                textBoxPattern.Text = "";
            }
            else
            {
                groupBoxMode.Size = new Size(groupBoxMode.Size.Width, 110);
                textBoxPattern.Enabled = true;
            }
        }
        private void RadioMetagram_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMetagramMode.Checked)
            {
                _dictionaryService.Mode = SearchMode.Metagram;
                textBoxPatternResults.Text = Messages.MetagramModeMessage;
            }
        }
        private void CheckBoxStartWith_CheckedChanged(object sender, EventArgs e)
        {
            FormService.FilterChecked(checkBoxBeginWith, textBoxBeginsWith);
        }
        private void CheckBoxEndsWith_CheckedChanged(object sender, EventArgs e)
        {
            FormService.FilterChecked(checkBoxEndsWith, textBoxEndsWith);
        }
        private void CheckBoxContains_CheckedChanged(object sender, EventArgs e)
        {
            FormService.FilterChecked(checkBoxContains, textBoxContains);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SearchPattern_Click(sender, e);
                    break;
                case Keys.F6:
                    textBoxPattern.SelectAll();
                    textBoxPattern.Focus();
                    break;

            }
        }
        #endregion

        #region private methods
        private void InitControls()
        {
            textBoxPatternResults.Text = Messages.PatternModeMessage + Environment.NewLine;
            SetHelpLabels();
        }
        private void FillTextBoxResults(List<string> results, TextBox textBox)
        {
            textBox.Text = "";
            if (results.Count == 0)
            {
                switch (_dictionaryService.Mode)
                {
                    case SearchMode.Pattern:
                    case SearchMode.Length:
                    case SearchMode.UluzSam:
                        textBox.Text = "BRAK DOPASOWAÑ";
                        break;
                    case SearchMode.Anagram:
                        textBox.Text = "BRAK ANAGRAMÓW";
                        break;
                    case SearchMode.Metagram:
                        textBox.Text = "BRAK METAGRAMÓW";
                        break;
                }
            }
            else
            {
                foreach (string word in results)
                {
                    textBox.Text += word + Environment.NewLine;
                }
            }
            if (results.Count == 500)
            {
                textBox.Text += Environment.NewLine;
                textBox.Text += "Zbyt wiele dopasowañ. " + Environment.NewLine +
                    "Wyœwietlam pierwsze 500.";
            }
        }
        private bool ValidatePattern(string pattern)
        {
            if (_dictionaryService.Mode == SearchMode.Length) return true;
            if (pattern.Length == 0)
            {
                textBoxPatternResults.Text = Messages.EmptyPattern;
                return false;
            }
            if (_dictionaryService.Mode == SearchMode.Metagram && pattern.Contains('.')
                || !DictionaryService.ValidatePattern(pattern, DictionaryService.AllowedChars))
            {
                MessageBox.Show("Wzorzec zawiera niedozwolone znaki.");
                return false;
            }

            return true;
        }
        /// <summary>
        /// Check if pattern contains only digits from 1 to 8, i.e. is a proper integer. 
        /// If true returns this integer. If not returns -1.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private int ValidateUluzSamPattern(string pattern)
        {
            int result;
            if (pattern.Length == 0) return -1;
            if (pattern.Contains('0') || pattern.Contains('9')) return -1;
            if(int.TryParse(pattern, out result)) return result;
            return -1;
        }
        private bool ValidateUluzSamGroups()
        {
            if (!DictionaryService.ValidatePattern(textBoxGr1.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr2.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr3.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr4.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr5.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr6.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr7.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidatePattern(textBoxGr8.Text.ToLower(), DictionaryService.AllowedLetters))
                return false;

            return true;
        }
        private List<string> ApplyFilters(List<string> words)
        {
            List<string> results = words;
            if (checkBoxBeginWith.Checked)
            {
                if (textBoxBeginsWith.Text.Length > 0)
                {
                    results = results
                        .Where(w => w.StartsWith(textBoxBeginsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                        .ToList();
                }
            }
            if (checkBoxEndsWith.Checked)
            {
                if (textBoxEndsWith.Text.Length > 0)
                {
                    results = results
                        .Where(w => w.EndsWith(textBoxEndsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                        .ToList();
                }
            }
            if (checkBoxContains.Checked)
            {
                if (textBoxContains.Text.Length > 0)
                {
                    results = results
                        .Where(w => w.Contains(textBoxContains.Text, StringComparison.CurrentCultureIgnoreCase))
                        .ToList();
                }
            }
            return results;
        }
        private List<string> BoundTo500(List<string> words)
        {
            List<string> results = words;
            if (results.Count <= 500) return results;
            return results.Take(500).ToList();
        }
        private void SetHelpLabels()
        {
            string msg = "Wyszukuje wyrazy pasuj¹ce do podanego wzorca. " +
                "Dozwolone s¹ jedynie litery i kropka (.), która zastêpuje dowoln¹ literê. ";
            labelPM.Text = msg;
            msg = "Wyszukuje wyrazy z³o¿one ze wszystkich podanych liter (anagramy). " +
                "Znak kropki (.) zastêpujê dowoln¹ literê.";
            labelAM.Text = msg;
            msg = "Wyszukuje wyrazy ró¿ni¹ce siê dok³adnie jedn¹ liter¹ od wyrazu podanego we wzorcu (metagramy). " +
                "Dozwolone s¹ tylko litery.";
            labelMM.Text = msg;
            msg = "Wyszukuje wyrazy o wskazanej w zakresie od-do iloœci znaków. W tym trybie wzorzec nie jest u¿ywany. " +
                "W celu ograniczenia iloœci dopasowañ zaleca siê u¿ycie dodatkowych filtrów.";
            labelLM.Text = msg;
            msg = "Pomocnik krzy¿ówkowicza v2.2.1" + Environment.NewLine +
                "Autor: Mariusz Doliñski" + Environment.NewLine + "© 2024";
            labelAbout.Text = msg;
        }
        private void SetMode()
        {
            if (_dictionaryService.Mode != SearchMode.UluzSam) return;
            if (radioPatternMode.Checked) _dictionaryService.Mode = SearchMode.Pattern;
            if (radioAnagramMode.Checked) _dictionaryService.Mode = SearchMode.Anagram;
            if (radioMetagramMode.Checked) _dictionaryService.Mode = SearchMode.Metagram;
            if (radioLengthMode.Checked) _dictionaryService.Mode = SearchMode.Length;
        }
        private List<int> ConvertIntToList(int number)
        {
            List<int> result = [];
            int digit;
            while (number > 0)
            {
                digit = number % 10;
                result.Insert(0,digit);
                number = (number - digit) / 10;
            }
            return result;
        }
        private string[] ConvertGroupsToArray() 
        {
            string[] result = new string[8];
            result[0] = textBoxGr1.Text.ToLower();
            result[1] = textBoxGr2.Text.ToLower();
            result[2] = textBoxGr3.Text.ToLower();
            result[3] = textBoxGr4.Text.ToLower();
            result[4] = textBoxGr5.Text.ToLower();
            result[5] = textBoxGr6.Text.ToLower();
            result[6] = textBoxGr7.Text.ToLower();
            result[7] = textBoxGr8.Text.ToLower();

            return result;
        }

        #endregion
    }
}
