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
                        MessageBox.Show("Podaj poprawny zakres dla ilo�ci znak�w", "B��d danych",
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
            if (result == -1)
            {
                MessageBox.Show("Wzorzec zawiera niedozwolone znaki, powinien zawiera� tylko cyfry 1-8.",
                    "B��d wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPatternUls.ReadOnly = false;
                return;
            }
            if (!ValidateUluzSamGroups())
            {
                MessageBox.Show("Grupy zawieraj� niedozwolone znaki, powinnny zawiera� tylko litery polskiego alfabetu.",
                    "B��d grup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPatternUls.ReadOnly = false;
                return;
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
        private void searchGoogle_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                SearchInWeb(WebSearch.Google, searchPhrase);
        }
        private void searchSJP_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                SearchInWeb(WebSearch.Sjp, searchPhrase);
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
            labelLoadInfo.Text = _dictionaryService.RenderLoadInfo();
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
                        textBox.Text = "BRAK DOPASOWA�";
                        break;
                    case SearchMode.Anagram:
                        textBox.Text = "BRAK ANAGRAM�W";
                        break;
                    case SearchMode.Metagram:
                        textBox.Text = "BRAK METAGRAM�W";
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
                textBox.Text += "Zbyt wiele dopasowa�. " + Environment.NewLine +
                    "Wy�wietlam pierwsze 500.";
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
            if (int.TryParse(pattern, out result)) return result;
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
            string msg = "Wyszukuje wyrazy pasuj�ce do podanego wzorca. " +
                "Dozwolone s� jedynie litery i kropka (.), kt�ra zast�puje dowoln� liter�. ";
            labelPM.Text = msg;
            msg = "Wyszukuje wyrazy z�o�one ze wszystkich podanych liter (anagramy). " +
                "Znak kropki (.) zast�puj� dowoln� liter�.";
            labelAM.Text = msg;
            msg = "Wyszukuje wyrazy r�ni�ce si� dok�adnie jedn� liter� od wyrazu podanego we wzorcu (metagramy). " +
                "Dozwolone s� tylko litery.";
            labelMM.Text = msg;
            msg = "Wyszukuje wyrazy o wskazanej w zakresie od-do ilo�ci znak�w. W tym trybie wzorzec nie jest u�ywany. " +
                "W celu ograniczenia ilo�ci dopasowa� zaleca si� u�ycie dodatkowych filtr�w.";
            labelLM.Text = msg;
            msg = "Pomocnik krzy��wkowicza v2.2.2" + Environment.NewLine +
                "Autor: Mariusz Doli�ski" + Environment.NewLine + "� 2024";
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
        private List<int> ConvertIntToList(int number)
        {
            List<int> result = [];
            int digit;
            while (number > 0)
            {
                digit = number % 10;
                result.Insert(0, digit);
                number = (number - digit) / 10;
            }
            return result;
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
        private static void SearchInWeb(string web, string searchPhrase)
        {
            ProcessStartInfo processInfo = new()
            {
                FileName = web + searchPhrase,
                UseShellExecute = true
            };
            Process.Start(processInfo);
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
