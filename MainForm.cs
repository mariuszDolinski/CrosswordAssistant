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

            _dictionaryService = new DictionaryService();
            if (_dictionaryService.DictionaryLoadError())
            {
                Load += (s, e) => Close();
                return;
            }

            InitControls();
        }

        #region events handlers
        private void PatternLabel_Click(object sender, EventArgs e)
        {
            FormService.SwitchControlVisibility(labelSpace2);
            FormService.SwitchControlVisibility(labelPatternInfo);
        }
        private void SearchPattern_Click(object sender, EventArgs e)
        {
            string pattern = textBoxPattern.Text.Trim().ToLower();
            if (!IsPatternCorrect(pattern)) return;
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
        #endregion

        #region private methods
        private void InitControls()
        {
            string msg = "Wyszukuje wszystkie wyrazy pasuj¹ce do podanego wzorca. " +
                Environment.NewLine + "Znak . (kropka) zastêpuje dowoln¹ literê.";
            labelPatternInfo.Text = msg;
            msg = Messages.PatternModeMessage;
            textBoxPatternResults.Text = msg + Environment.NewLine;
        }
        private void FillTextBoxResults(List<string> results, TextBox textBox)
        {
            textBox.Text = "";
            if (results.Count == 0)
            {
                switch (_dictionaryService.Mode)
                {
                    case SearchMode.Pattern:
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
        private bool IsPatternCorrect(string pattern)
        {
            if (_dictionaryService.Mode == SearchMode.Length) return true;
            if (pattern.Length == 0)
            {
                textBoxPatternResults.Text = Messages.EmptyPattern;
                return false;
            }
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
        #endregion
    }
}
