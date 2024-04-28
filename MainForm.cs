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
            if (pattern.Length == 0)
            {
                textBoxPatternResults.Text = Messages.EmptyPattern;
                return;
            }
            textBoxPattern.ReadOnly = true;
            List<string> matches = new List<string>();
            switch (_dictionaryService.Mode)
            {
                case SearchMode.Pattern:
                    matches = _dictionaryService.SearchByPattern(pattern);
                    break;
                case SearchMode.Anagram:
                    //TO DO
                    break;
            }
            
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
                        textBox.Text = "Funkcje jeszcze nie dostêpna.";
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
                textBox.Text += "Zbyt wiele dopasowañ. Wyœwietlam pierwsze 500.";
            }
        }
        #endregion

    }
}
