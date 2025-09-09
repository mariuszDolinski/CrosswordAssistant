using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Entities.Requests;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Searches;
using CrosswordAssistant.Services;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CrosswordAssistant
{
    public partial class MainForm : Form
    {
        private const string StartWithFilterName = "STRW";
        private const string EndWithFilterName = "ENDW";
        private const string ContainsFilterName = "CNTS";

        private int ComponentsCount;

        private readonly AppearanceSettings _appearance;
        private readonly DictionaryService _dictionaryService;
        private readonly List<Label> _infoLabels = [];
        private readonly Dictionary<string, string> _filtersNames = [];

        public List<TextBox> ComponentTextBox;
        public TextBox OperationResult;
        public Label CurrentOperatorLabel;

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
            KeyPreview = true;
            ComponentsCount = 2;

            try { Settings.Init(); }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d przy wczytywaniu ustawieñ. SprawdŸ szczegó³y w logu.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }

            ComponentTextBox = [];
            OperationResult = new TextBox();
            CurrentOperatorLabel = new Label();
            Search.IsPending = false;
            _appearance = new AppearanceSettings(this);
            _dictionaryService = new DictionaryService();
            if (_dictionaryService.DictionaryLoadError())
            {
                Load += (s, e) => Close();
                return;
            }

            try { InitControls(); }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d przy inicjalizacji aplikacji. SprawdŸ szczegó³y w logu.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }

        #region events handlers
        private async void SearchPattern_Click(object sender, EventArgs e)
        {
            try
            {
                await MakeSearch(0);
            }
            catch (Exception ex)
            {
                labelPatternResultsInfo.Text = "Znalezionych dopasowañ: 0";
                IsSearchPending(false);
                MessageBox.Show("B³¹d wyszukiwania. SprawdŸ szczegó³y w logu aplikacji.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }
        private async void RandomWord_Click(object sender, EventArgs e)
        {
            try
            {
                await MakeSearch(1);
            }
            catch (Exception ex)
            {
                labelPatternResultsInfo.Text = "Znalezionych dopasowañ: 0";
                IsSearchPending(false);
                MessageBox.Show("B³¹d wyszukiwania. SprawdŸ szczegó³y w logu aplikacji.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }
        private void UluzSamSearch_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading || Search.IsPending)
            {
                MessageBox.Show("Trwa inne wyszukiwanie lub ³adowanie nowego s³ownika. Spróbuj ponownie póŸniej", "Inna operacja w toku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var search = SearchFactory.CreateSearch(Search.Mode);
            string pattern = textBoxPatternUls.Text;
            var validateResult = search.ValidatePattern(pattern);
            if (!validateResult.Result)
            {
                MessageBox.Show(validateResult.Message, "B³¹d wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxPatternUls.ReadOnly = true;

            string[] groups = ConvertGroupsToArray();
            foreach (string group in groups)
            {
                pattern += "|" + group.ToLower();
            }
            List<string> matches = search.SearchMatches(pattern);

            FillTextBoxResults(matches, textBoxResultsUls);
            textBoxPatternUls.ReadOnly = false;
        }
        private void SearchScrabble_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading || Search.IsPending)
            {
                MessageBox.Show("Trwa inne wyszukiwanie lub ³adowanie nowego s³ownika. Spróbuj ponownie póŸniej", "Inna operacja w toku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var search = SearchFactory.CreateSearch(Search.Mode);
            string pattern = textBoxScrabblePattern.Text.ToLower();
            var validateResult = search.ValidatePattern(pattern);
            if (!validateResult.Result)
            {
                MessageBox.Show(validateResult.Message, "B³¹d wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBoxScrabbleResults.ReadOnly = true;
            List<string> matches = search.SearchMatches(pattern);

            FillTextBoxResults(matches, textBoxScrabbleResults);
            textBoxScrabbleResults.ReadOnly = false;
        }
        private void SolveCryptharitmBtn_Click(object sender, EventArgs e)
        {
            if (DictionaryService.PendingDictionaryLoading || Search.IsPending)
            {
                MessageBox.Show("Trwa inne wyszukiwanie lub ³adowanie nowego s³ownika. Spróbuj ponownie póŸniej", "Inna operacja w toku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pattern = JoinCryptharitmWords();
            if (pattern.Length == 0) return;

            var search = SearchFactory.CreateSearch(Search.Mode);
            var validateResult = search.ValidatePattern(pattern);
            if (!validateResult.Result)
            {
                MessageBox.Show(validateResult.Message, "B³¹d danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> matches = search.SearchMatches(pattern);
            textBoxCryptharitmResult.Text = "";
            FillTextBoxResults(matches, textBoxCryptharitmResult);
        }
        private void AddComponentBtn_Click(object sender, EventArgs e)
        {
            if (ComponentsCount == 5)
            {
                MessageBox.Show("Maksymalna iloœæ sk³adowych dzia³ania to 5.", "Za du¿o sk³adowych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComponentsCount++;
            ClearCryptharitmControls(splitContainerCryptharitms.Panel1);
            GenerateCryptharitmControls(splitContainerCryptharitms.Panel1);
        }
        private void RemoveComponentBtn_Click(object sender, EventArgs e)
        {
            if (ComponentsCount == 2)
            {
                MessageBox.Show("Minimalna iloœæ sk³adowych dzia³ania to 2.", "Za malo sk³adowych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComponentsCount--;
            ClearCryptharitmControls(splitContainerCryptharitms.Panel1);
            GenerateCryptharitmControls(splitContainerCryptharitms.Panel1);
        }
        private async void LoadDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(newDictionaryDialog, DictionaryMode.NewFile))
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
                MessageBox.Show("Podano zbyt wiele wyrazów. Proszê ograniczyæ listê do maksymlanie 10 000 s³ów.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Logger.WriteToLog(LogLevel.Info, $"Dodano ${addedWords.Count} nowe wyrazy do s³ownika ${FileService.FileName}");
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
            if (e.KeyCode == Keys.F5)
            {
                var currentTabIndex = tabControl.SelectedIndex;
                tabControl.SelectedTab = currentTabIndex switch
                {
                    0 => tabPageUlozSam,
                    1 => tabPageScrabble,
                    2 => tabPageDictionary,
                    3 => tabPageAbout,
                    _ => tabPattern,
                };
            }
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
                case SearchMode.Cryptharitm:
                    switch (e.KeyCode)
                    {
                        case Keys.Enter:
                            SolveCryptharitmBtn_Click(sender, e);
                            e.SuppressKeyPress = true;
                            break;
                        case Keys.F6:
                            ComponentTextBox[0].SelectAll();
                            ComponentTextBox[0].Focus();
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
            if (Search.IsPending) return;
            var currentPage = (sender as TabControl)!.SelectedIndex;
            SetMode(currentPage);
        }
        private void ComboBoxOperations_SelectedIndesChanged(object sender, EventArgs e)
        {
            switch (comboBoxOperations.SelectedIndex)
            {
                case 1:
                    AddComponentBtn.Text = "DODAJ SK£ADNIK";
                    RemoveComponentBtn.Text = "USUÑ SK£ADNIK";
                    CurrentOperatorLabel.Text = "-";
                    Search.CurrentOperator = Operators.Subtraction;
                    break;
                case 2:
                    AddComponentBtn.Text = "DODAJ CZYNNIK";
                    RemoveComponentBtn.Text = "USUÑ CZYNNIK";
                    CurrentOperatorLabel.Text = "•";
                    Search.CurrentOperator = Operators.Multiplication;
                    break;
                default:
                    AddComponentBtn.Text = "DODAJ SK£ADNIK";
                    RemoveComponentBtn.Text = "USUÑ SK£ADNIK";
                    CurrentOperatorLabel.Text = "+";
                    Search.CurrentOperator = Operators.Addition;
                    break;
            }
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
        private void CalculateScrabbleScore_Click(object sender, EventArgs e)
        {
            var word = textBoxScrabbleCalc.Text.ToLower();
            var doubleWordBonus = (int)numericUpDownDoubleBonus.Value;
            var tripleWordBonus = (int)numericUpDownTripleBonus.Value;
            var doubleBonusLetters = textBoxDoubleBonusLetters.Text.ToLower();
            var tripleBonusLetters = textBoxTripleBonusLetters.Text.ToLower();
            var blanksLetters = (textBoxBlankLetter1.Text + textBoxBlankLetter2.Text).ToLower();
            var request = new ScrabbleCalculatorRequest(word, doubleWordBonus, tripleWordBonus, doubleBonusLetters, tripleBonusLetters, blanksLetters);

            labelScrabbePoints.Text = ScrabbleCalculator.CalculateScrabbleScoreForWord(request).ToString();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            _appearance.SetMainFormLocation();
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
            comboBoxOperations.SelectedIndex = 0;

            GenerateCryptharitmControls(splitContainerCryptharitms.Panel1);

            _appearance.SetBackgroundColor();
            _appearance.SetTextBoxesCasing(BaseSettings.CaseSensitive);
        }
        private void IsSearchPending(bool pending)
        {
            textBoxPattern.ReadOnly = pending;
            Search.IsPending = pending;
        }
        /// <summary>
        /// Make asynchronous search and fill textbox with matches
        /// </summary>
        /// <param name="random">number of retuned matches</param>
        /// <returns>return all matches in alphabetical order if random=0, return n random matches if random=n</returns>
        private async Task MakeSearch(int random)
        {
            if (DictionaryService.PendingDictionaryLoading || Search.IsPending)
            {
                MessageBox.Show("Trwa inne wyszukiwanie lub ³adowanie nowego s³ownika. Spróbuj ponownie póŸniej", "Inna operacja w toku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IsSearchPending(true);
            var searchResponse = await ExecuteSearch();
            if (!searchResponse.Completed)
            {
                MessageBox.Show(searchResponse.Message, "B³¹d wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IsSearchPending(false);
                return;
            }
            else if (random == 1 && searchResponse.SearchResults.Count == 0)
            {
                FillTextBoxResults([], textBoxPatternResults);
            }
            else
            {
                if (random == 1)
                {
                    Random rand = new();
                    FillTextBoxResults([searchResponse.SearchResults[rand.Next(searchResponse.SearchResults.Count)]], textBoxPatternResults);
                }
                else
                {
                    FillTextBoxResults(searchResponse.SearchResults, textBoxPatternResults);
                }
            }
            IsSearchPending(false);
            //set mode, in case of being on different tab afte search is completed
            SetMode(tabControl.SelectedIndex);
        }
        private async Task<SearchResponse> ExecuteSearch()
        {
            string pattern = textBoxPattern.Text.Trim();
            if (!BaseSettings.CaseSensitive) pattern = pattern.ToLower();
            labelPatternResultsInfo.Text = "Szukam dopasowañ...";
            var search = SearchFactory.CreateSearch(Search.Mode);
            List<string> matches;
            if (checkBoxLength.Checked && pattern.Length == 0)
            {
                matches = DictionaryService.CurrentDictionary;
            }
            else
            {
                var validateResponse = search.ValidatePattern(pattern);
                if (!validateResponse.Result)
                {
                    return new SearchResponse([], false, validateResponse.Message);
                }
                matches = await Task.Run(() => search.SearchMatches(pattern));
            }

            await Task.Delay(20000);
            matches = ApplyFilters(matches);
            labelPatternResultsInfo.Text = "Znalezionych dopasowañ: " + matches.Count;
            matches = Utilities.BoundResults(matches);
            return new SearchResponse(matches, true, "");
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
                    SearchMode.Cryptharitm => "BRAK ROZWI¥ZAÑ",
                    _ => "BRAK DOPASOWAÑ",
                };
            }
            else
            {
                switch (Search.Mode)
                {
                    case SearchMode.Scrabble:
                        FormService.FillTextBoxScrabbleResults(textBoxScrabbleResults, results);
                        break;
                    case SearchMode.Cryptharitm:
                        FormService.FillTextBoxCriptharytmSolutions(textBoxCryptharitmResult, results);
                        break;
                    default:
                        FormService.FillTextBoxWithWords(textBox, results, false);
                        break;
                }
            }
            if (results.Count == BaseSettings.MaxResultDisplay && Search.Mode != SearchMode.Scrabble)
            {
                textBox.Text += Environment.NewLine;
                textBox.Text += "Zbyt wiele dopasowañ. " + Environment.NewLine +
                    "Wyœwietlam pierwsze " + BaseSettings.MaxResultDisplay.ToString();
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
                        results = [.. results.Where(w => w.Length == min)];
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
                            results = [.. results.Where(w => w.Length >= min && w.Length <= max)];
                        else if (min == 0)
                            results = [.. results.Where(w => w.Length <= max)];
                        else
                            results = [.. results.Where(w => w.Length >= min)];
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
                return [.. results.Where(w => w.BeginsWithAny(textBoxBeginsWith.Text))];
            }
            else if (radioButtonBeginWithNot.Checked && textBoxBeginsWith.Text.Length > 0)
            {
                return [.. results.Where(w => w.NotBeginsWithAll(textBoxBeginsWith.Text))];
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
                return [.. results.Where(w => w.EndsWithAny(textBoxEndsWith.Text))];
            }
            else if (radioButtonEndsWithNot.Checked && textBoxEndsWith.Text.Length > 0)
            {
                return [.. results.Where(w => w.NotEndsWithAll(textBoxEndsWith.Text))];
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
                    results = [.. results.Where(w => w.ContainsAll(textBoxContains.Text))];
                if (radioButtonContainsOr.Checked)
                    results = [.. results.Where(w => w.ContainsAny(textBoxContains.Text))];
            }
            if (checkBoxNotContains.Checked && textBoxNotContains.Text.Length > 0)
            {
                if (radioButtonContainsAnd.Checked)
                    results = [.. results.Where(w => w.NotContainsAny(textBoxNotContains.Text))];
                if (radioButtonContainsOr.Checked)
                    results = [.. results.Where(w => w.NotContainsSome(textBoxNotContains.Text))];
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
                    Search.Mode = SearchMode.Cryptharitm;
                    break;
                case 4:
                case 5:
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
            FormService.SetLabelsBackColor(_infoLabels, Color.Silver);
            lbl.BackColor = Color.LightSteelBlue;
            textBoxAbout.Text = msg;
        }
        private void GenerateCryptharitmControls(SplitterPanel panel)
        {
            ComponentTextBox = [];
            for (int i = 0; i < ComponentsCount; i++)
            {
                ComponentTextBox.Add(new TextBox()
                {
                    CharacterCasing = CharacterCasing.Upper,
                    Location = new Point(110, 196 + 43 * i),
                    Name = "textBoxComponent" + (i + 1).ToString(),
                    Size = new Size(270, 31),
                    TabIndex = i + 21,
                    TextAlign = HorizontalAlignment.Right,
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238)
                });
                panel.Controls.Add(ComponentTextBox[i]);
            }

            var lastComponentY = ComponentTextBox[ComponentsCount - 1].Location.Y;

            CurrentOperatorLabel = new()
            {
                AutoSize = true,
                Location = new Point(27, lastComponentY + 36),
                Name = "labelOperator",
                Size = new Size(24, 25),
                TabIndex = 7,
                Text = "+"
            };

            Label labelCryptLine = new()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, lastComponentY + 64),
                Name = "labelCryptLine",
                Size = new Size(358, 1),
                TabIndex = 10
            };

            OperationResult = new()
            {
                CharacterCasing = CharacterCasing.Upper,
                Location = new Point(88, lastComponentY + 88),
                Name = "textBoxSum",
                Size = new Size(292, 31),
                TabIndex = 21 + ComponentsCount,
                TextAlign = HorizontalAlignment.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238)
            };

            panel.Controls.Add(CurrentOperatorLabel);
            panel.Controls.Add(labelCryptLine);
            panel.Controls.Add(OperationResult);
        }
        private static void ClearCryptharitmControls(SplitterPanel panel)
        {
            foreach (Control control in panel.Controls.OfType<Control>().ToList())
            {
                if (control.Name.Contains("textBoxComponent") || control.Name == "labelOperator"
                    || control.Name == "labelCryptLine" || control.Name == "textBoxSum")
                {
                    control.Dispose();
                }
            }
        }
        private string JoinCryptharitmWords()
        {
            string pattern = string.Empty;
            for (int i = 0; i < ComponentsCount; i++)
            {
                if (ComponentTextBox[i].Text.Contains('|'))
                {
                    MessageBox.Show("Wykryto niedozwolony znak. U¿ywaj tylko liter polskiego alabetu.", "B³¹d danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                }
                pattern += ComponentTextBox[i].Text + "|";
            }
            if (OperationResult.Text.Contains('|'))
            {
                MessageBox.Show("Wykryto niedozwolony znak. U¿ywaj tylko liter polskiego alabetu.", "B³¹d danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            pattern += OperationResult.Text;
            return pattern;
        }

        #endregion
    }
}
