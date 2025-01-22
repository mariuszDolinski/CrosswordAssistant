using CrosswordAssistant.Entities;
using CrosswordAssistant.Searches;
using CrosswordAssistant.Services;
using System.Globalization;

namespace CrosswordAssistant
{
    public partial class MainForm : Form
    {
        private const string StartWithFilterName = "STRW";
        private const string EndWithFilterName = "ENDW";
        private const string ContainsFilterName = "CNTS";

        private readonly DictionaryService _dictionaryService;
        private readonly List<Label> _infoLabels = [];
        private readonly Dictionary<string, string> _filtersNames = [];

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
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
            if (DictionaryService.PendingDictionaryLoading) return;

            string pattern = textBoxPattern.Text.Trim().ToLower();

            try
            {
                var search = SearchFactory.CreateSearch(Search.Mode);

                List<string> matches;
                if (checkBoxLength.Checked && pattern.Length == 0)
                {
                    matches = DictionaryService.CurrentDictionary;
                    textBoxPattern.ReadOnly = true;
                }
                else
                {
                    if (!search.ValidatePattern(pattern)) return;
                    textBoxPattern.ReadOnly = true;
                    matches = search.SearchMatches(pattern);
                }

                matches = ApplyFilters(matches);
                labelResultsCount.Text = "Znalezionych dopasowañ: " + matches.Count;
                matches = Utilities.BoundTo500(matches);
                FillTextBoxResults(matches, textBoxPatternResults);
                textBoxPattern.ReadOnly = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Podany tryb nie zosta³ jeszcze zaimplementowany");
            }
        }
        private void UluzSamSearch_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading) return;

            var search = SearchFactory.CreateSearch(Search.Mode);
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

            var search = SearchFactory.CreateSearch(Search.Mode);
            string pattern = textBoxScrabblePattern.Text.ToLower();
            if (!search.ValidatePattern(pattern)) return;
            textBoxScrabbleResults.ReadOnly = true;
            List<string> matches = search.SearchMatches(pattern);

            FillTextBoxResults(matches, textBoxScrabbleResults);
            textBoxScrabbleResults.ReadOnly = false;
        }
        private async void LoadDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(newDictionaryDialog))
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
        private async void LoadToMerge_Click(object sender, EventArgs e)
        {
            textBoxWordsToMerge.Text = "Wczytujê plik..." + Environment.NewLine;
            var wordsToAdd = FileService.LoadTextFile(newDictionaryDialog);
            textBoxWordsToMerge.Text += "OK" + Environment.NewLine;

            if (wordsToAdd.Count > 0)
            {
                textBoxWordsToMerge.Text += "Szukam nowych wyrazów..." + Environment.NewLine;
                var newWords = await _dictionaryService.MergeWithDictionaryAsync(wordsToAdd);
                textBoxWordsToMerge.Text += "OK" + Environment.NewLine;
                if (newWords.Count > 0)
                {
                    labelMergeDicts.Text = "Iloœæ wyrazów w pliku: " + wordsToAdd.Count;
                    labelMergeDicts.Text += Environment.NewLine;
                    labelMergeDicts.Text += "Iloœæ nowych wyrazów: " + newWords.Count.ToString();
                    if (newWords.Count > 10000)
                    {
                        textBoxWordsToMerge.Text += Environment.NewLine + "UWAGA. Zbyt wiele nowych wyrazów. " +
                            "Maksymalna dopuszczalna iloœæ to: 10 000. Kliknij Anuluj i spróbuj ponownie.";
                        buttonMergeDicts.Enabled = false;
                    }
                    else
                    {
                        textBoxWordsToMerge.Text += Environment.NewLine + "Wyrazy do dodania: ";
                        FormService.FillTextBoxWithWords(textBoxWordsToMerge, newWords, true);
                        buttonMergeDicts.Enabled = true;
                    }
                }
                else
                {
                    textBoxWordsToMerge.Text += Environment.NewLine +
                        "Brak nowych wyrazów we wczytanym pliku. Kliknij Anuluj.";
                    buttonMergeDicts.Enabled = false;
                }
                textBoxWordsToMerge.Select(0, 0);
                buttonLoadDictToMerge.Enabled = false;
                buttonCancelMerge.Enabled = true;
            }
        }
        private void CancelMerge_Click(object sender, EventArgs e)
        {
            _dictionaryService.ClearDictionaryToMerge();
            labelMergeDicts.Text = Messages.MergeDictsInfo;
            textBoxWordsToMerge.Text = "";
            buttonLoadDictToMerge.Enabled = true;
            buttonMergeDicts.Enabled = false;
            buttonCancelMerge.Enabled = false;
        }
        private void MergeDicts_Click(object sender, EventArgs e)
        {
            textBoxWordsToMerge.Text = "Dodajê nowe wyrazy do s³ownika...";
            int c = 1;
            foreach (var newWord in DictionaryService.DictionaryToMerge)
            {
                textBoxWordsToMerge.Text = "Dodajê nowe wyrazy do s³ownika... ";
                textBoxWordsToMerge.Text += c.ToString() + "/" + DictionaryService.DictionaryToMerge.Count.ToString();
                c++;
                List<string> oneWord = [newWord];
                _dictionaryService.AddWordsToDictionary(oneWord);
            }
            textBoxWordsToMerge.Text += Environment.NewLine + "Wykonane";
            textBoxWordsToMerge.Text += Environment.NewLine + "Zapisujê do pliku... ";
            if (FileService.SaveDictionary(DictionaryService.CurrentDictionary))
            {
                MessageBox.Show("Wyrazy (" + DictionaryService.DictionaryToMerge.Count.ToString() + ") dodane poprawnie",
                    "Dodawanie wyrazów zakoñczone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxWordsToMerge.Text = "";
                labelMergeDicts.Text = Messages.MergeDictsInfo;
            }
            buttonLoadDictToMerge.Enabled = true;
            buttonMergeDicts.Enabled = false;
            buttonCancelMerge.Enabled = false;
        }
        private void AddToDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading) return;

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
            else if (wordsToAdd.Count > 10000)
            {
                MessageBox.Show("odano zbyt wiele wyrazów. Proszê ograniczyæ listê do maksymlanie 10 000 s³ów.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (FileService.SaveDictionary(DictionaryService.CurrentDictionary))
            {
                MessageBox.Show("Wyrazy: " + Environment.NewLine + msg + "dodane poprawnie.", "Dodano wyrazy do s³ownika",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetFileInfo(0);
        }
        private void RemoveFromDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading) return;

            if (textBoxAddToDictionary.Text.Length == 0)
            {
                MessageBox.Show("Nie podano ¿adnych wyrazów do usuniêcia.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var response = MessageBox.Show("Czy na pewno chcesz usun¹æ podane wyrazy ze s³ownika? Wciœnij Tak aby kontynuowaæ lub Nie aby anulowaæ."
                , "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (response == DialogResult.No) return;

            var wordsToRemove = textBoxAddToDictionary.Lines.ToList();
            wordsToRemove = Utilities.CorrectLines(wordsToRemove);
            var removedWords = DictionaryService.RemoveWordsFromDictionary(wordsToRemove);
            if (removedWords.Count == 0)
            {
                MessageBox.Show("Podane wyrazy nie wystêpuj¹ w bie¿¹cym s³owniku.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string msg = "";
            foreach (var word in removedWords)
            {
                msg += word + Environment.NewLine;
            }

            if (FileService.SaveDictionary(DictionaryService.CurrentDictionary))
            {
                MessageBox.Show("Wyrazy: " + Environment.NewLine + msg + "usuniête poprawnie.", "Usuniêto wyrazy ze s³ownika",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetFileInfo(0);
        }
        private void RadioButtonMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPatternMode.Checked)
            {
                OnModeChanged(Messages.PatternModeMessage);
            }
            else if (radioAnagramMode.Checked)
            {
                OnModeChanged(Messages.AnagramModeMessage);
            }
            else if (radioMetagramMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage);
            }
            else if (radioPM1Mode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage);
            }
            else if (radioSubWordMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage);
            }
            else if (radioSuperWordMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage);
            }
            else if (radioStenoAnagramMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage);
            }
            else if (radioWordInWord.Checked)
            {
                OnModeChanged(Messages.PatternModeMessage);
            }
        }
        private void RadioLength_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLength.Checked)
            {
                textBoxLength.Enabled = true;
            }
            else
            {
                textBoxLength.Enabled = false;
            }
        }
        private void ActiveFilters_CheckedChanged(object sender, EventArgs e)
        {
            var obj = (CheckBox)sender;
            var container = (GroupBox?)obj.Parent;
            if (container == null) return;
            var radioButtons = container.Controls.OfType<RadioButton>().ToList();
            var textBox = container.Controls.OfType<TextBox>().ToList();
            var checkBoxes = container.Controls.OfType<CheckBox>().ToList();
            var checkBoxActive = checkBoxes.First(c => c.Text == "Aktywny");
            var checkBoxOthers = checkBoxes.FindAll(c => c.Text != "Aktywny").ToList();


            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            FormService.FilterChecked(checkBoxActive, checkBoxOthers, textBox, radioButtons);
            if (!checkBoxActive.Checked) textBoxPattern.Focus();
        }
        private void SelectedFilters_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radio)
            {
                var container = (GroupBox?)radio.Parent;
                if (container == null) return;
                var textBoxes = container.Controls.OfType<TextBox>().ToList();
                foreach (var c in textBoxes) c.Focus();
            }

            if (sender is CheckBox cb)
            {
                var container = (GroupBox?)cb.Parent;
                if (container == null) return;
                var textBoxes = container.Controls.OfType<TextBox>().ToList();
                foreach (var c in textBoxes) c.Focus();
            }
        }
        private void CheckBoxLength_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLength.Checked)
            {
                SetLengthControlsEnabled(true);
                radioLength.Checked = true;
            }
            else
            {
                SetLengthControlsEnabled(false);
                radioLength.Checked = false;
                radioLengthInterval.Checked = false;
                textBoxLength.Text = "";
                textBoxLengthFrom.Text = "";
                textBoxLengthTo.Text = "";
            }
        }
        private void TextBoxLengthInterval_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLengthInterval.Checked)
            {
                textBoxLengthFrom.Enabled = true;
                textBoxLengthTo.Enabled = true;
            }
            else
            {
                textBoxLengthFrom.Enabled = false;
                textBoxLengthTo.Enabled = false;
            }
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
                            case Keys.D5: radioSubWordMode.Checked = true; break;
                            case Keys.D6: radioSuperWordMode.Checked = true; break;
                            case Keys.D7: radioStenoAnagramMode.Checked = true; break;
                            case Keys.D8: radioWordInWord.Checked = true; break;
                            case Keys.D9:
                                checkBoxLength.Checked = !checkBoxLength.Checked;
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
        }
        private void InfoLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var container = (TableLayoutPanel?)label.Parent;
            if (container == null) return;
            SetInfo(label, Messages.GetInfoMessage(container.GetRow(label)));
        }
        private void OpenSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new(this);
            settingsForm.Show();
            Enabled = false;
        }
        private void LetterBonus_CountChanged(object sender, EventArgs e)
        {
            var bonus = (NumericUpDown)sender;
            if (bonus.TabIndex == numericUpDownDoubleCharBonus.TabIndex)
            {
                if (bonus.Value > 0)
                {
                    textBoxDoubleBonusLetters.Enabled = true;
                }
                else
                {
                    textBoxDoubleBonusLetters.Enabled = false;
                    textBoxDoubleBonusLetters.Text = string.Empty;
                }

            }
            if (bonus.TabIndex == numericUpDownTripleCharBonus.TabIndex)
            {
                if (bonus.Value > 0)
                {
                    textBoxTripleBonusLetters.Enabled = true;
                }
                else
                {
                    textBoxTripleBonusLetters.Enabled = false;
                    textBoxTripleBonusLetters.Text = string.Empty;
                }

            }
            if (bonus.TabIndex == numericUpDownBlanks.TabIndex) 
            { 
                if(bonus.Value == 1)
                {
                    textBoxBlankLetter1.Enabled = true;
                    textBoxBlankLetter2.Enabled = false;
                    textBoxBlankLetter2.Text = string.Empty;
                }
                else if(bonus.Value == 2)
                {
                    textBoxBlankLetter1.Enabled = true;
                    textBoxBlankLetter2.Enabled = true;
                }
                else
                {
                    textBoxBlankLetter1.Enabled = false;
                    textBoxBlankLetter2.Enabled = false;
                    textBoxBlankLetter1.Text = string.Empty;
                    textBoxBlankLetter2.Text = string.Empty;
                }
            }
        }

        #endregion

        #region private methods
        private void InitControls()
        {
            textBoxPatternResults.Text = Messages.PatternModeMessage + Environment.NewLine;
            _infoLabels.Add(labelPatternInfo);
            _infoLabels.Add(labelAnagramInfo);
            _infoLabels.Add(labelMetagramInfo);
            _infoLabels.Add(labelLengthInfo);
            _infoLabels.Add(labelUlozSamInfo);
            _infoLabels.Add(labelPM1Info);
            _infoLabels.Add(labelShortcuts);
            _infoLabels.Add(labelScrabbleInfo);
            _infoLabels.Add(labelInfoFilters);
            _infoLabels.Add(labelSubwordInfo);
            _infoLabels.Add(labelSuperWordInfo);
            _infoLabels.Add(labelStenoAnagramInfo);
            _infoLabels.Add(labelWordInWordInfo);
            SetFileInfo(0);
            labelAbout.Text = Messages.VersionInfo;
            labelMergeDicts.Text = Messages.MergeDictsInfo;

            _filtersNames[StartWithFilterName] = "Pocz¹tek";
            _filtersNames[EndWithFilterName] = "Koniec";
            _filtersNames[ContainsFilterName] = "Zawiera";

            groupBoxBeginWithFilters.Text = _filtersNames[StartWithFilterName];
            groupBoxEndsWithFilters.Text = _filtersNames[EndWithFilterName];

        }
        private void SetLengthControlsEnabled(bool isEnabled)
        {
            radioLength.Enabled = isEnabled;
            radioLengthInterval.Enabled = isEnabled;
            labelLength.Enabled = isEnabled;
            labelLength2.Enabled = isEnabled;
            labelLength3.Enabled = isEnabled;
            labelLength4.Enabled = isEnabled;
            labelLength5.Enabled = isEnabled;
        }
        public void SetFileInfo(int mode)
        {
            if (mode == -1)
            {
                labelWordsCount.TextAlign = ContentAlignment.MiddleLeft;
                labelFileName.TextAlign = ContentAlignment.MiddleLeft;
                labelWordsCount.BackColor = Color.Khaki;
                labelFileName.BackColor = Color.Khaki;
                labelFileName.Text = "Wczytujê nowy s³ownik";
                labelWordsCount.Text = "Wczytujê nowy s³ownik";
                return;
            }
            if (mode > 0)
            {
                labelFileName.Text = "Wczytujê nowy s³ownik".AppendDots(mode);
                labelWordsCount.Text = "Wczytujê nowy s³ownik".AppendDots(mode);
                return;
            }
            labelFileName.Text = FileService.FileName;
            int wordsCount = _dictionaryService.GetWordsCount();
            var nfi = new NumberFormatInfo
            {
                NumberGroupSeparator = " "
            };
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

            if (results.Count == 0)
            {
                textBox.Text = Search.Mode switch
                {
                    SearchMode.Anagram => "BRAK ANAGRAMÓW",
                    SearchMode.Metagram => "BRAK METAGRAMÓW",
                    _ => "BRAK DOPASOWAÑ",
                };
            }
            else
            {
                if (Search.Mode != SearchMode.Scrabble)
                {
                    FormService.FillTextBoxWithWords(textBox, results, false);
                }
                else
                {
                    FormService.FillTextBoxScrabbleResults(textBoxScrabbleResults, results);
                }
            }
            if (results.Count == 500 && Search.Mode != SearchMode.Scrabble)
            {
                textBox.Text += Environment.NewLine;
                textBox.Text += "Zbyt wiele dopasowañ. " + Environment.NewLine +
                    "Wyœwietlam pierwsze 500.";
            }
        }
        private List<string> ApplyFilters(List<string> words)
        {
            List<string> results = words;
            if (checkBoxLength.Checked)
            {
                int min = 0, max = 0;
                if (radioLength.Checked)
                {
                    min = FormService.TextBoxPositiveNumber(textBoxLength);
                    if (min <= 0)
                    {
                        MessageBox.Show("B³êdna d³ugoœæ. Wpisz poprawne liczby.", "B³êdne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return [];
                    }
                    else
                    {
                        results = results
                        .Where(w => w.Length == min)
                        .ToList();
                    }
                }
                else
                {
                    min = FormService.TextBoxPositiveNumber(textBoxLengthFrom);
                    max = FormService.TextBoxPositiveNumber(textBoxLengthTo);
                    if (min == -1 || max == -1 || (max > 0 && min > max) || (min == 0 && max == 0))
                    {
                        MessageBox.Show("B³êdna d³ugoœæ. Wpisz poprawne liczby.", "B³êdne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return [];
                    }
                    else
                    {
                        if (min != 0 && max != 0)
                            results = results
                            .Where(w => w.Length >= min && w.Length <= max)
                            .ToList();
                        else if (min == 0)
                            results = results
                            .Where(w => w.Length <= max)
                            .ToList();
                        else
                            results = results
                            .Where(w => w.Length >= min)
                            .ToList();
                    }
                }
            }
            if (checkBoxBeginsWithActive.Checked)
            {
                results = ApplyStartWithFilter(results);
            }
            if (checkBoxEndsWithActive.Checked)
            {
                results = ApplyEndsWithFilter(results);
            }
            if (checkBoxContainsActive.Checked)
            {
                results = ApplyContainsFilters(results);
            }
            return results;
        }
        private List<string> ApplyStartWithFilter(List<string> results)
        {
            if (radioButtonBeginsWith.Checked && textBoxBeginsWith.Text.Length > 0)
            {
                return results
                    .Where(w => w.StartsWith(textBoxBeginsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            else if (radioButtonBeginWithNot.Checked && textBoxBeginsWith.Text.Length > 0)
            {
                return results
                    .Where(w => !w.StartsWith(textBoxBeginsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            else
            {
                return [];
            }
        }
        private List<string> ApplyEndsWithFilter(List<string> results)
        {
            if (radioButtonEndsWith.Checked && textBoxEndsWith.Text.Length > 0)
            {
                return results
                    .Where(w => w.EndsWith(textBoxEndsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            else if (radioButtonEndsWithNot.Checked && textBoxEndsWith.Text.Length > 0)
            {
                return results
                    .Where(w => !w.EndsWith(textBoxEndsWith.Text, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            else
            {
                return [];
            }
        }
        private List<string> ApplyContainsFilters(List<string> results)
        {
            if (checkBoxContains.Checked && textBoxContains.Text.Length > 0)
            {
                if (radioButtonContainsAnd.Checked)
                    results = results
                        .Where(w => w.ContainsAll(textBoxContains.Text))
                        .ToList();
                if (radioButtonContainsOr.Checked)
                    results = results
                    .Where(w => w.ContainsAny(textBoxContains.Text))
                    .ToList();
            }
            if (checkBoxNotContains.Checked && textBoxNotContains.Text.Length > 0)
            {
                if (radioButtonContainsAnd.Checked)
                    results = results
                    .Where(w => w.NotContainsAny(textBoxNotContains.Text))
                    .ToList();
                if (radioButtonContainsOr.Checked)
                    results = results
                    .Where(w => w.NotContainsSome(textBoxNotContains.Text))
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
                    else if (radioPM1Mode.Checked) Search.Mode = SearchMode.PlusMinus1;
                    else if (radioSubWordMode.Checked) Search.Mode = SearchMode.SubWord;
                    else if (radioSuperWordMode.Checked) Search.Mode = SearchMode.SuperWord;
                    else if (radioStenoAnagramMode.Checked) Search.Mode = SearchMode.StenoAnagram;
                    else if (radioWordInWord.Checked) Search.Mode = SearchMode.WordInWord;
                    else Search.Mode = SearchMode.None;
                    break;
            }
        }
        private void OnModeChanged(string message)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            SetMode(0);
            textBoxPatternResults.Text = message;
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
