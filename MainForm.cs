using CrosswordAssistant.Entities;
using CrosswordAssistant.Services;
using System.Diagnostics;

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
            matches = Utilities.BoundTo500(matches);
            FillTextBoxResults(matches, textBoxPatternResults);
            textBoxPattern.ReadOnly = false;
        }
        private void UluzSamSearch_Click(object sender, EventArgs e)
        {
            textBoxPatternUls.ReadOnly = true;
            _dictionaryService.Mode = SearchMode.UluzSam;
            int result = Utilities.ValidateUluzSamPattern(textBoxPatternUls.Text);
            if (result == -1)
            {
                MessageBox.Show("Wzorzec zawiera niedozwolone znaki, powinien zawieraæ tylko cyfry 1-8.",
                    "B³¹d wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPatternUls.ReadOnly = false;
                return;
            }
            if (!ValidateUluzSamGroups())
            {
                MessageBox.Show("Grupy zawieraj¹ niedozwolone znaki, powinnny zawieraæ tylko litery polskiego alfabetu.",
                    "B³¹d grup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPatternUls.ReadOnly = false;
                return;
            }
            List<int> digits = Utilities.ConvertIntToList(result);
            string[] groups = ConvertGroupsToArray();
            List<string> matches = _dictionaryService.SearchUluzSam(digits, groups);
            matches = Utilities.BoundTo500(matches);
            FillTextBoxResults(matches, textBoxResultsUls);
            textBoxPatternUls.ReadOnly = false;
        }
        private void LoadDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetFileFromDialog(newDictionaryDialog))
            {
                _dictionaryService.LoadDictionary();
                SetFileInfo();
            }
        }
        private void AddToDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (textBoxAddToDictionary.Text.Length == 0)
            {
                MessageBox.Show("Nie podano ¿adnych wyrazów do dodania.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var wordsToAdd = textBoxAddToDictionary.Lines.ToList();
            wordsToAdd = Utilities.CorrectLines(wordsToAdd);
            if (wordsToAdd.Count == 0)
            {
                MessageBox.Show("Nie podano ¿adnych wyrazów do dodania.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DictionaryService.ValidateWordsToAdd(wordsToAdd))
            {
                MessageBox.Show("Wyrazy do dodania powinny zaczynaæ i koñczyæ siê liter¹ " +
                    "oraz zawieraæ tylko litery i znak pauzy (-)", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addedWords = _dictionaryService.AddWordsToDictionary(wordsToAdd);
            if (addedWords.Count == 0)
            {
                MessageBox.Show("Podane wyrazy s¹ ju¿ w bie¿¹cym s³owniku.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string msg = "";
            foreach (var word in addedWords)
            {
                msg += word + Environment.NewLine;
            }
            if (FileService.SaveDictionary(_dictionaryService.CurrentDictionary))
            {
                MessageBox.Show("Wyrazy: " + Environment.NewLine + msg + "dodane poprawnie.", "Dodano wyrazy do s³ownika",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        private void SearchGoogle_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                Utilities.SearchInWeb(WebSearch.Google, searchPhrase);
        }
        private void SearchSJP_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                Utilities.SearchInWeb(WebSearch.Sjp, searchPhrase);
        }
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentPage = (sender as TabControl)!.SelectedIndex;
            SetMode(currentPage);
        }
        #endregion

        #region private methods
        private void InitControls()
        {
            textBoxPatternResults.Text = Messages.PatternModeMessage + Environment.NewLine;
            textBoxAddToDictionary.PlaceholderText = "Wpisz wyrazy do dodania " + Environment.NewLine +
                "(po jednym w linii)";
            SetFileInfo();
            SetHelpLabels();
        }
        private void SetFileInfo()
        {
            labelFileName.Text = FileService.FileName;
            int wordsCount = _dictionaryService.GetWordsCount();
            labelWordsCount.Text = wordsCount.ToString();
            if (wordsCount < 10)
            {
                labelWordsCount.BackColor = Color.DarkSalmon;
            }
            else
            {
                labelWordsCount.BackColor = Color.MediumAquamarine;
            }
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
                || !DictionaryService.ValidateAllowedChars(pattern, DictionaryService.AllowedPatternChars))
            {
                MessageBox.Show("Wzorzec zawiera niedozwolone znaki.");
                return false;
            }

            return true;
        }
        private bool ValidateUluzSamGroups()
        {
            if (!DictionaryService.ValidateAllowedChars(textBoxGr1.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr2.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr3.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr4.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr5.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr6.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr7.Text.ToLower(), DictionaryService.AllowedLetters)
                || !DictionaryService.ValidateAllowedChars(textBoxGr8.Text.ToLower(), DictionaryService.AllowedLetters))
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
            msg = "Pomocnik krzy¿ówkowicza v2.2.4" + Environment.NewLine +
                "Autor: Mariusz Doliñski" + Environment.NewLine + "© 2024";
            labelAbout.Text = msg;
        }
        private void SetMode(int tabIndex)
        {
            if (tabIndex == 1)
            {
                _dictionaryService.Mode = SearchMode.UluzSam;
            }
            else if (tabIndex == 0)
            {
                if (radioPatternMode.Checked) _dictionaryService.Mode = SearchMode.Pattern;
                else if (radioAnagramMode.Checked) _dictionaryService.Mode = SearchMode.Anagram;
                else if (radioMetagramMode.Checked) _dictionaryService.Mode = SearchMode.Metagram;
                else if (radioLengthMode.Checked) _dictionaryService.Mode = SearchMode.Length;
            }
        }
        private string[] ConvertGroupsToArray()
        {
            string[] result =
            [
                textBoxGr1.Text.ToLower(),
                textBoxGr2.Text.ToLower(),
                textBoxGr3.Text.ToLower(),
                textBoxGr4.Text.ToLower(),
                textBoxGr5.Text.ToLower(),
                textBoxGr6.Text.ToLower(),
                textBoxGr7.Text.ToLower(),
                textBoxGr8.Text.ToLower(),
            ];
            return result;
        }
        private string GetSelectedResult()
        {
            string searchPhrase;
            if (_dictionaryService.Mode == SearchMode.UluzSam)
            {
                searchPhrase = textBoxResultsUls.SelectedText;
            }
            else
            {
                searchPhrase = textBoxPatternResults.SelectedText;
            }

            if (string.IsNullOrEmpty(searchPhrase))
            {
                MessageBox.Show("Zaznacz tekst do wyszukania", "Uwaga", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return "";
            }
            return searchPhrase;
        }
        #endregion
    }
}
