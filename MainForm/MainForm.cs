using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Entities.Requests;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Searches;
using CrosswordAssistant.Services;
using CrosswordAssistant.Services.Sudoku;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CrosswordAssistant
{
    public partial class MainForm : Form
    {
        private const string StartWithFilterName = "STRW";
        private const string EndWithFilterName = "ENDW";
        private const string ContainsFilterName = "CNTS";

        private readonly AppearanceSettings _appearance;
        private readonly DictionaryService _dictionaryService;
        private readonly List<Label> _infoLabels = [];
        private readonly Dictionary<string, string> _filtersNames = [];
        private readonly CustomControls _customControls;
        private readonly SudokuService _sudokuService;

        private bool _isCtrlPressedInSudoku;


        public MainForm()
        {
            InitializeComponent();
            SetSize();
            KeyPreview = true;
            _isCtrlPressedInSudoku = false;

            try { Settings.Init(); }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d przy wczytywaniu ustawieñ. SprawdŸ szczegó³y w logu.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }

            Search.IsPending = false;
            _appearance = new AppearanceSettings(this);
            _dictionaryService = new DictionaryService();
            if (DictionaryService.DictionaryLoadError())
            {
                Load += (s, e) => Close();
            }

            _customControls = new CustomControls(new CustomControlsRequest(
                panelCrpt, PanelPatternFilters, DeviceDpi));
            try { InitControls(); }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d przy inicjalizacji aplikacji. SprawdŸ szczegó³y w logu.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }

            _sudokuService = new SudokuService(tableSudokuBoxes);
        }

        #region events handlers
        
        
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
        private async void SolveCryptharitmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await MakeSearch(0);
            }
            catch (Exception ex)
            {
                labelPatternResultsInfo.Text = "Znalezionych rozwi¹zañ: 0";
                IsSearchPending(false);
                MessageBox.Show("Podczas próby rozwi¹zania kryptarytmu wyst¹pi³ b³¹d. SprawdŸ szczegó³y w logu aplikacji.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }
        private void AddComponentBtn_Click(object sender, EventArgs e)
        {
            if (_customControls.ComponentsCount == 5)
            {
                MessageBox.Show("Maksymalna iloœæ sk³adowych dzia³ania to 5.", "Za du¿o sk³adowych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _customControls.ComponentsCount++;
            _customControls.ClearCryptharitmControls();
            _customControls.InitializeCryptharitmControls();
        }
        private void RemoveComponentBtn_Click(object sender, EventArgs e)
        {
            if (_customControls.ComponentsCount == 2)
            {
                MessageBox.Show("Minimalna iloœæ sk³adowych dzia³ania to 2.", "Za malo sk³adowych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _customControls.ComponentsCount--;
            _customControls.ClearCryptharitmControls();
            _customControls.InitializeCryptharitmControls();
        }
        private async void LoadDictionaryBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(openFileDialog, DictionaryMode.NewFile))
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

                    await Task.Run(() => DictionaryService.LoadDictionaryAsync());
                }
                SetFileInfo(0);
                DictionaryService.PendingDictionaryLoading = false;
            }
        }
        private async void LoadToMerge_Click(object sender, EventArgs e)
        {
            textBoxWordsToMerge.Text = "Wczytujê plik..." + Environment.NewLine;
            var wordsToAdd = FileService.LoadTextFile(openFileDialog);
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

            AddWordsToDictionary(wordsToAdd);
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
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var currentTabIndex = tabControl.SelectedIndex;
                tabControl.SelectedTab = currentTabIndex switch
                {
                    0 => tabPageScrabble,
                    1 => tabPageCryptharitm,
                    2 => tabPageDictionary,
                    3 => tabPageAbout,
                    _ => tabPattern,
                };
            }
            switch (Search.Mode)
            {
                case SearchMode.None:
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
                            _customControls.SetComponentTextBoxFocus();
                            break;
                    }
                    break;
                case SearchMode.Sudoku:
                    SudokuKeyDownHandle(e);
                    break;
                default:
                    PatternKeyDownHandle(e, sender);
                    break;
            }
        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            labelScrabbleCurrentPatternLen.Text = textBoxScrabblePattern.Text.Length.ToString();
            if (e.KeyCode == Keys.ControlKey) _isCtrlPressedInSudoku = false;
        }
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Search.IsPending) return;
            var currentPage = (sender as TabControl)!.SelectedIndex;
            SetMode(currentPage);
        }
        private void ComboBoxOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxOperations.SelectedIndex)
            {
                case 1:
                    //AddComponentBtn.Text = "DODAJ SK£ADNIK";
                    //RemoveComponentBtn.Text = "USUÑ SK£ADNIK";
                    _customControls.SetCurrentOperatorLabelText("-");
                    Search.CurrentOperator = Operators.Subtraction;
                    break;
                case 2:
                    //AddComponentBtn.Text = "DODAJ CZYNNIK";
                    //RemoveComponentBtn.Text = "USUÑ CZYNNIK";
                    _customControls.SetCurrentOperatorLabelText("•");
                    Search.CurrentOperator = Operators.Multiplication;
                    break;
                default:
                    //AddComponentBtn.Text = "DODAJ SK£ADNIK";
                    //RemoveComponentBtn.Text = "USUÑ SK£ADNIK";
                    _customControls.SetCurrentOperatorLabelText("+");
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
            _infoLabels.Add(labelCryptharitmInfo);
            _infoLabels.Add(labelWordsFromWordInfo);
            SetFileInfo(0);
            labelAbout.Text = Messages.VersionInfo;
            labelMergeDicts.Text = Messages.MergeDictsInfo;

            _filtersNames[StartWithFilterName] = "Pocz¹tek";
            _filtersNames[EndWithFilterName] = "Koniec";
            _filtersNames[ContainsFilterName] = "Zawiera";

            groupBoxBeginWithFilters.Text = _filtersNames[StartWithFilterName];
            groupBoxEndsWithFilters.Text = _filtersNames[EndWithFilterName];
            comboBoxOperations.SelectedIndex = 0;

            _appearance.SetBackgroundColor();
            _appearance.SetTextBoxesCasing(BaseSettings.CaseSensitive);
        }
        private void IsSearchPending(bool pending)
        {
            switch (Search.Mode)
            {
                case SearchMode.Cryptharitm:
                    _customControls.SetCryptharitmTextBoxesReadOnly(pending);
                    AddComponentBtn.Enabled = !pending;
                    RemoveComponentBtn.Enabled = !pending;
                    comboBoxOperations.Enabled = !pending;
                    break;
                case SearchMode.Sudoku:
                    buttonValidateSudoku.Enabled = !pending;
                    buttonSolveSudoku.Enabled = !pending;
                    break;
                default: textBoxPattern.ReadOnly = pending; break;
            }
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
            var searchResponse = Search.Mode switch
            {
                SearchMode.Cryptharitm => await ExecuteCryptharitmSearchAsync(),
                SearchMode.UluzSam => await ExecuteUlozSamSearchAsync(),
                _ => await ExecutePatternSearchAsync(),
            };

            if (!searchResponse.Completed)
            {
                MessageBox.Show(searchResponse.Message, "B³¹d danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    switch (Search.Mode)
                    {
                        case SearchMode.Cryptharitm: FillTextBoxResults(searchResponse.SearchResults, textBoxCryptharitmResult); break;
                        default: FillTextBoxResults(searchResponse.SearchResults, textBoxPatternResults); break;
                    }

                }
            }
            IsSearchPending(false);
            //set mode, in case of being on different tab after search is completed
            SetMode(tabControl.SelectedIndex);
        }
        private async Task<SearchResponse> ExecuteCryptharitmSearchAsync()
        {
            string pattern = _customControls.JoinCryptharitmComponents();
            labelCryptharitmResultsInfo.Text = "Szukam rozwi¹zañ...";

            var search = SearchFactory.CreateSearch(Search.Mode);
            var validateResponse = search.ValidatePattern(pattern);
            if (!validateResponse.Result)
            {
                return new SearchResponse([], false, validateResponse.Message);
            }

            List<string> matches = await Task.Run(() => search.SearchMatches(pattern));
            labelCryptharitmResultsInfo.Text = "Znalezionych rozwi¹zañ: " + matches.Count;
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
        }
        private void SetMode(int tabIndex)
        {
            switch (tabIndex)
            {
                case 1:
                    Search.Mode = SearchMode.Scrabble;
                    break;
                case 2:
                    Search.Mode = SearchMode.Cryptharitm;
                    break;
                case 3:
                    Search.Mode = SearchMode.Sudoku;
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
                    else if (radioUlozSamMode.Checked) Search.Mode = SearchMode.UluzSam;
                    else if (radioWordsFromWord.Checked) Search.Mode = SearchMode.WordsFromWord;
                    else Search.Mode = SearchMode.None;
                    break;
            }
        }
        private void OnModeChanged(string message, bool isUlozSam)
        {
            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            SetMode(0);
            textBoxPatternResults.Text = message;
            groupBoxFilters.Visible = !isUlozSam;
            _customControls.SetUlozSamGroupBoxVisible(isUlozSam);
            checkBoxLength.Enabled = !isUlozSam;
            if (checkBoxLength.Checked && isUlozSam) checkBoxLength.Checked = false;
        }
        private void SetInfo(Label lbl, string msg)
        {
            FormService.SetLabelsBackColor(_infoLabels, Color.Silver);
            lbl.BackColor = Color.LightSteelBlue;
            textBoxAbout.Text = msg;
        }
        private void SetSize()
        {
            if (DeviceDpi < 100)
            {
                Width = 859; Height = 538;
            }
            MinimumSize = Size;
            MaximumSize = Size;
        }
        private void AddWordsToDictionary(List<string> wordsToAdd)
        {
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

        #endregion
    }
}
