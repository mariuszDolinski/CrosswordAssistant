using CrosswordAssistant.Entities;
using CrosswordAssistant.Searches;
using CrosswordAssistant.Services;
using System.Diagnostics;
using System.Globalization;

namespace CrosswordAssistant
{
    public partial class MainForm : Form
    {
        private readonly DictionaryService _dictionaryService;
        private readonly List<Label> _infoLabels = [];
        private readonly SearchFactory _searchFactory;
        private bool _isEnterSuppressed = true;

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            KeyPreview = true;

            _dictionaryService = new DictionaryService();
            _searchFactory = new SearchFactory();
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
            if (DictionaryService.PendingDictionaryLoading) return;

            string pattern = textBoxPattern.Text.Trim().ToLower();
            if (Search.Mode == SearchMode.Length)
            {
                pattern = textBoxMinLen.Text + "+" + textBoxMaxLen.Text;
            }

            var search = _searchFactory.CreateSearch(Search.Mode);

            if (!search.ValidatePattern(pattern)) return;
            textBoxPattern.ReadOnly = true;
            List<string> matches = search.SearchMatches(pattern);

            matches = ApplyFilters(matches);
            matches = Utilities.BoundTo500(matches);
            FillTextBoxResults(matches, textBoxPatternResults);
            textBoxPattern.ReadOnly = false;
        }
        private void UluzSamSearch_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading) return;

            var search = _searchFactory.CreateSearch(Search.Mode);
            string pattern = textBoxPatternUls.Text;
            if (!search.ValidatePattern(pattern)) return;

            textBoxPatternUls.ReadOnly = true;

            string[] groups = ConvertGroupsToArray();
            foreach (string group in groups)
            {
                pattern += "+" + group.ToLower();
            }
            List<string> matches = search.SearchMatches(pattern);

            matches = Utilities.BoundTo500(matches);
            FillTextBoxResults(matches, textBoxResultsUls);
            textBoxPatternUls.ReadOnly = false;
        }
        private void SearchScrabble_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading) return;

            var search = _searchFactory.CreateSearch(Search.Mode);
            string pattern = textBoxScrabblePattern.Text.ToLower();
            if (!search.ValidatePattern(pattern)) return;
            textBoxScrabbleResults.ReadOnly = true;
            List<string> matches = search.SearchMatches(pattern);

            FillTextBoxResults(matches, textBoxScrabbleResults);
            textBoxScrabbleResults.ReadOnly = false;
        }
        private async void LoadDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetFileFromDialog(newDictionaryDialog))
            {
                DictionaryService.PendingDictionaryLoading = true;
                int count = 0;
                SetFileInfo(-1);
                using (var timer = new System.Windows.Forms.Timer())
                {
                    timer.Tick += (s, e) =>
                    {
                        SetFileInfo(count + 1);
                        count++;
                    };
                    timer.Interval = 1000;
                    timer.Enabled = true;

                    await Task.Run(() => _dictionaryService.LoadDictionaryAsync());
                }                   
                SetFileInfo(0);
                DictionaryService.PendingDictionaryLoading = false;
            }
        }
        private void AddToDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading) return;

            if (textBoxAddToDictionary.Text.Length == 0)
            {
                MessageBox.Show("Nie podano �adnych wyraz�w do dodania.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var wordsToAdd = textBoxAddToDictionary.Lines.ToList();
            wordsToAdd = Utilities.CorrectLines(wordsToAdd);
            if (wordsToAdd.Count == 0)
            {
                MessageBox.Show("Nie podano �adnych wyraz�w do dodania.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DictionaryService.ValidateWordsToAdd(wordsToAdd))
            {
                MessageBox.Show("Wyrazy do dodania powinny zaczyna� i ko�czy� si� liter� " +
                    "oraz zawiera� tylko litery i znak pauzy (-)", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addedWords = _dictionaryService.AddWordsToDictionary(wordsToAdd);
            if (addedWords.Count == 0)
            {
                MessageBox.Show("Podane wyrazy s� ju� w bie��cym s�owniku.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string msg = "";
            foreach (var word in addedWords)
            {
                msg += word + Environment.NewLine;
            }
            if (FileService.SaveDictionary(DictionaryService.CurrentDictionary))
            {
                MessageBox.Show("Wyrazy: " + Environment.NewLine + msg + "dodane poprawnie.", "Dodano wyrazy do s�ownika",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetFileInfo(0);
        }
        private void RadioPattern_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            if (radioPatternMode.Checked)
            {
                Search.Mode = SearchMode.Pattern;
                textBoxPatternResults.Text = Messages.PatternModeMessage;
            }
        }
        private void RadioAnagram_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            if (radioAnagramMode.Checked)
            {
                Search.Mode = SearchMode.Anagram;
                textBoxPatternResults.Text = Messages.AnagramModeMessage;
            }
        }
        private void RadioLength_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = "0";
            if (radioLengthMode.Checked)
            {
                groupBoxMode.Size = new Size(groupBoxMode.Size.Width, 190);
                Search.Mode = SearchMode.Length;
                textBoxPatternResults.Text = Messages.LengthModeMessage;
                textBoxPattern.Enabled = false;
                textBoxPattern.Text = "";
            }
            else
            {
                groupBoxMode.Size = new Size(groupBoxMode.Size.Width, 140);
                textBoxPattern.Enabled = true;
            }
        }
        private void RadioMetagram_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            if (radioMetagramMode.Checked)
            {
                Search.Mode = SearchMode.Metagram;
                textBoxPatternResults.Text = Messages.MetagramModeMessage;
            }
        }
        private void RadioPM1_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            if (radioPM1Mode.Checked)
            {
                Search.Mode = SearchMode.PlusMinus1;
                textBoxPatternResults.Text = Messages.MetagramModeMessage;
            }
        }
        private void CheckBoxStartWith_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            FormService.FilterChecked(checkBoxBeginWith, textBoxBeginsWith);
            if (!checkBoxBeginWith.Checked) textBoxPattern.Focus();
        }
        private void CheckBoxEndsWith_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            FormService.FilterChecked(checkBoxEndsWith, textBoxEndsWith);
            if (!checkBoxEndsWith.Checked) textBoxPattern.Focus();
        }
        private void CheckBoxContains_CheckedChanged(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            FormService.FilterChecked(checkBoxContains, textBoxContains);
            if (!checkBoxContains.Checked) textBoxPattern.Focus();
        }
        private void CheckBoxNotContains_CheckedChange(object sender, EventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            FormService.FilterChecked(checkBoxNotContains, textBoxNotContains);
            if(!checkBoxNotContains.Checked) textBoxPattern.Focus();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (Search.Mode)
            {
                case SearchMode.None:
                    break;
                case SearchMode.UluzSam:
                    switch (e.KeyCode)
                    {
                        case Keys.Enter:
                            UluzSamSearch_Click(sender, e);
                            e.SuppressKeyPress = true;
                            break;
                        case Keys.F6:
                            textBoxPatternUls.SelectAll();
                            textBoxPatternUls.Focus();
                            break;
                    }
                    break;
                case SearchMode.Scrabble:
                    switch (e.KeyCode)
                    {
                        case Keys.Enter:
                            SearchScrabble_Click(sender, e);
                            e.SuppressKeyPress = true;
                            break;
                        case Keys.F6:
                            textBoxScrabblePattern.SelectAll();
                            textBoxScrabblePattern.Focus();
                            break;
                    }
                    break;
                default:
                    switch (e.KeyCode)
                    {
                        case Keys.Enter:
                            SearchPattern_Click(sender, e);
                            e.SuppressKeyPress = true;
                            break;
                        case Keys.F6:
                            textBoxPattern.SelectAll();
                            textBoxPattern.Focus();
                            break;
                    }
                    if (e.Control)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.D1: radioPatternMode.Checked = true; break;
                            case Keys.D2: radioAnagramMode.Checked = true; break;
                            case Keys.D3: radioMetagramMode.Checked = true; break;
                            case Keys.D4: radioPM1Mode.Checked = true; break;
                            case Keys.D5: radioLengthMode.Checked = true; break;
                            case Keys.D6: 
                                checkBoxBeginWith.Checked = !checkBoxBeginWith.Checked;
                                break;
                            case Keys.D7:
                                checkBoxEndsWith.Checked = !checkBoxEndsWith.Checked;
                                break;
                            case Keys.D8:
                                checkBoxContains.Checked = !checkBoxContains.Checked;
                                break;
                            case Keys.D9:
                                checkBoxNotContains.Checked = !checkBoxNotContains.Checked;
                                break;
                        }
                    }
                    break;
            }
        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            labelScrabbleCurrentPatternLen.Text = textBoxScrabblePattern.Text.Length.ToString();
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
            if (currentPage == 3) _isEnterSuppressed = false;
            else _isEnterSuppressed = true;
        }
        private void PatternInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.PatternInfo);
        }
        private void AnagramInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.AnagramInfo);
        }
        private void MetagramInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.MetagramInfo);
        }
        private void LengthInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.LengthInfo);
        }
        private void UlozSamInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.UlozSamInfo);
        }
        private void PlusMinus1Info_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.PlusMinus1Info);
        }
        private void ScrabbleInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.ScrabbleInfo);
        }
        private void FiltersInfo_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.FiltersInfo);
        }
        private void Shortcuts_Click(object sender, EventArgs e)
        {
            SetInfo((Label)sender, Messages.Shortcuts);
        }
        #endregion

        #region private methods
        private void InitControls()
        {
            textBoxPatternResults.Text = Messages.PatternModeMessage + Environment.NewLine;
            textBoxAddToDictionary.PlaceholderText = "Wpisz wyrazy do dodania " + Environment.NewLine +
                "(po jednym w linii)";
            _infoLabels.Add(labelPatternInfo);
            _infoLabels.Add(labelAnagramInfo);
            _infoLabels.Add(labelMetagramInfo);
            _infoLabels.Add(labelLengthInfo);
            _infoLabels.Add(labelUlozSamInfo);
            _infoLabels.Add(labelPM1Info);
            _infoLabels.Add(labelShortcuts);
            _infoLabels.Add(labelScrabbleInfo);
            _infoLabels.Add(labelInfoFilters);
            SetFileInfo(0);
            labelAbout.Text = Messages.VersionInfo;
        }
        private void SetFileInfo(int mode)
        {
            if(mode == -1)
            {
                labelWordsCount.TextAlign = ContentAlignment.MiddleLeft;
                labelFileName.TextAlign = ContentAlignment.MiddleLeft;
                labelWordsCount.BackColor = Color.Khaki;
                labelFileName.BackColor = Color.Khaki;
                labelFileName.Text = "Wczytuj� nowy s�ownik";
                labelWordsCount.Text = "Wczytuj� nowy s�ownik";
                return;
            }
            if(mode > 0)
            {
                labelFileName.Text = "Wczytuj� nowy s�ownik".AppendDots(mode);
                labelWordsCount.Text = "Wczytuj� nowy s�ownik".AppendDots(mode);
                return;
            }
            labelFileName.Text = FileService.FileName;
            int wordsCount = _dictionaryService.GetWordsCount();
            var nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            labelWordsCount.Text = wordsCount.ToString("N0", nfi);
            labelFileName.BackColor = Color.MediumAquamarine;
            labelWordsCount.TextAlign = ContentAlignment.MiddleCenter;
            labelFileName.TextAlign = ContentAlignment.MiddleCenter;
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
            string result = "";
            if (results.Count == 0)
            {
                switch (Search.Mode)
                {
                    case SearchMode.Anagram:
                        textBox.Text = "BRAK ANAGRAM�W";
                        break;
                    case SearchMode.Metagram:
                        textBox.Text = "BRAK METAGRAM�W";
                        break;
                    default:
                        textBox.Text = "BRAK DOPASOWA�";
                        break;
                }
            }
            else
            {
                if (Search.Mode != SearchMode.Scrabble)
                {
                    foreach (string word in results)
                    {
                        result += word + Environment.NewLine;
                    }
                    textBox.Text = result;
                }
                else
                {
                    FormService.FillTextBoxScrabbleResults(textBoxScrabbleResults, results);
                }
            }
            if (results.Count == 500 && Search.Mode != SearchMode.Scrabble)
            {
                textBox.Text += Environment.NewLine;
                textBox.Text += "Zbyt wiele dopasowa�. " + Environment.NewLine +
                    "Wy�wietlam pierwsze 500.";
            }
        }
        private List<string> ApplyFilters(List<string> words)
        {
            List<string> results = words;
            if (checkBoxBeginWith.Checked && textBoxBeginsWith.Text.Length > 0)
            {
                results = results
                    .Where(w => w.StartsWith(textBoxBeginsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            if (checkBoxEndsWith.Checked && textBoxEndsWith.Text.Length > 0)
            {
                results = results
                    .Where(w => w.EndsWith(textBoxEndsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            if (checkBoxContains.Checked && textBoxContains.Text.Length > 0)
            {
                results = results
                    .Where(w => w.Contains(textBoxContains.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            if (checkBoxNotContains.Checked && textBoxNotContains.Text.Length > 0)
            {
                results = results
                    .Where(w => w.NotContainsAny(textBoxNotContains.Text))
                    .ToList();
            }
            return results;
        }
        private void SetMode(int tabIndex)
        {
            switch (tabIndex)
            {
                case 1:
                    Search.Mode = SearchMode.UluzSam;
                    break;
                case 2:
                    Search.Mode = SearchMode.Scrabble;
                    break;
                case 3:
                case 4:
                    Search.Mode = SearchMode.None;
                    break;
                default:
                    if (radioPatternMode.Checked) Search.Mode = SearchMode.Pattern;
                    else if (radioAnagramMode.Checked) Search.Mode = SearchMode.Anagram;
                    else if (radioMetagramMode.Checked) Search.Mode = SearchMode.Metagram;
                    else if (radioLengthMode.Checked) Search.Mode = SearchMode.Length;
                    else if (radioPM1Mode.Checked) Search.Mode = SearchMode.PlusMinus1;
                    else Search.Mode = SearchMode.None;
                    break;
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
            if (Search.Mode == SearchMode.UluzSam)
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
        private void SetInfo(Label lbl, string msg)
        {
            FormService.ResetLabelsBackColor(_infoLabels, Color.Silver);
            lbl.BackColor = Color.LightSteelBlue;
            textBoxAbout.Text = msg;
        }
        #endregion
    }
}
