using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Requests;

namespace CrosswordAssistant.Services
{
    public class CustomControls
    {
        private static double Scale;
        private readonly string[] DefaultGroupLetters = ["AĄBC", "ĆDEĘ", "FGHI", "JKLŁ", "MNŃO", "ÓPRS", "ŚTUW", "YZŹŻ"];
        //MainForm controls
        private readonly Panel CryptharitmPanel;
        private readonly Panel PatternPanel;

        public int ComponentsCount { get; set; }

        //Cryptharitm dynamic controls
        private List<TextBox> ComponentTextBox;
        private TextBox OperationResultTextBox;
        private Label CurrentOperatorLabel;


        //Ułóż sam mode
        private readonly Label[] GroupLabel;
        private readonly TextBox[] GroupTextBox;
        private GroupBox GenerateUlozSamCode;
        private GroupBox UlozSamGroups;
        private GroupBox UlozSamSettings;
        private TextBox WordToCodeTextBox;
        private Button ConvertToCodeBtn;
        private Label CodeResultLabel;

        public CustomControls(CustomControlsRequest request)
        {
            CryptharitmPanel = request.CryptaritmPanel;
            PatternPanel = request.PatternPanel;
            ComponentTextBox = [];
            GroupLabel = new Label[8];
            GroupTextBox = new TextBox[8];
            ComponentsCount = 2;

            SetScale(request.DeviceDpi);
            InitializeControls();
        }

        private void SetScale(int dpi)
        {
            if (dpi < 100) Scale = 0.75;
            else if (dpi < 130) Scale = 0.9;
            else Scale = 1;
        }
        private void InitializeControls()
        {
            InitializeCryptharitmControls();
            InitializeUlozSamControls();
        }
        private void InitializeUlozSamControls()
        {
            var bColor = Color.FromArgb((int)Settings.SavedSettings[BaseSettings.PatternColorKey]);

            InitializedUlozSamGroupBoxes();

            int offsetX = 0;
            int offsetY = 0;
            for (int i = 0; i < 8; i++)
            {
                if (i > 3) { offsetX = (int)(275 * Scale); offsetY = -4; }
                GroupLabel[i] = new Label
                {
                    BackColor = bColor,
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    Location = new Point(25 + offsetX, (int)(41 * Scale) * (i + 1 + offsetY)),
                    Margin = new Padding(4, 2, 3, 2),
                    Name = "labelGr1",
                    Size = new Size(50, (int)(33 * Scale)),
                    TabIndex = 10 + i,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = (i + 1).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                GroupTextBox[i] = new TextBox
                {
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    Location = new Point(100 + offsetX, (int)(41 * Scale) * (i + 1 + offsetY)),
                    Margin = new Padding(3, 1, 3, 3),
                    Name = "textBoxGr1",
                    Size = new Size(150, 36),
                    TabIndex = 30 + i,
                    Text = DefaultGroupLetters[i],
                    CharacterCasing = CharacterCasing.Upper
                };
                UlozSamGroups.Controls.Add(GroupLabel[i]);
                UlozSamGroups.Controls.Add(GroupTextBox[i]);
            }

            WordToCodeTextBox = new TextBox()
            {
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238),
                Location = new Point(25, (int)(40 * Scale)),
                Margin = new Padding(3, 1, 3, 3),
                Name = "wordToCodeTextBox",
                Size = new Size((int)(555 * Scale), 36),
                TabIndex = 2,
                CharacterCasing = CharacterCasing.Upper,
                PlaceholderText = "Podaj wyraz i kliknij przycisk, aby wygenerować kod"
            };

            ConvertToCodeBtn = new Button()
            {
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238),
                Location = new Point(26, (int)(int)(90 * Scale)),
                Size = new Size((int)(180 * Scale), (int)(36 * Scale)),
                Name = "convertToCodeBtn",
                TabIndex = 3,
                Text = "GENERUJ KOD >>>",
                UseVisualStyleBackColor = true,
            };

            CodeResultLabel = new Label()
            {
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular, GraphicsUnit.Point, 238),
                Location = new Point((int)(220 * Scale), (int)(90 * Scale)),
                Margin = new Padding(4, 2, 3, 2),
                Name = "codeResultLabel",
                Size = new Size((int)(360 * Scale), (int)(36 * Scale)),
                TabIndex = 4,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            ConvertToCodeBtn.Click += ConvertWordToUlozSamCode_Click;
            PatternPanel.Controls.Add(UlozSamSettings);
            GenerateUlozSamCode.Controls.Add(WordToCodeTextBox);
            GenerateUlozSamCode.Controls.Add(ConvertToCodeBtn);
            GenerateUlozSamCode.Controls.Add(CodeResultLabel);
        }
        private void InitializedUlozSamGroupBoxes()
        {
            UlozSamSettings = new GroupBox()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "groupBoxUlozSamGroups",
                Size = new Size(709, 473),
                TabIndex = 2,
                TabStop = false,
                Text = "Dodatkowe opcje",
                Visible = false
            };
            UlozSamGroups = new GroupBox()
            {
                Dock = DockStyle.Top,
                Location = new Point(0, 0),
                Name = "groupBoxUlozSamGroups",
                Size = new Size(709, (int)(225 * Scale)),
                TabIndex = 3,
                TabStop = false,
                Text = "Grupy liter",
                Visible = true
            };
            GenerateUlozSamCode = new GroupBox()
            {
                Dock = DockStyle.Fill,
                Location = new Point(3, 230),
                Name = "groupBoxGenerateUlozSamCode",
                Size = new Size(703, 188),
                TabIndex = 4,
                TabStop = false,
                Text = "Generuj kod",
                Visible = true
            };
            UlozSamSettings.Controls.Add(GenerateUlozSamCode);
            UlozSamSettings.Controls.Add(UlozSamGroups);
        }
        public void InitializeCryptharitmControls()
        {
            ComponentTextBox = [];
            for (int i = 0; i < ComponentsCount; i++)
            {
                ComponentTextBox.Add(new TextBox()
                {
                    CharacterCasing = CharacterCasing.Upper,
                    Location = new Point(155, 196 + 43 * i),
                    Name = "textBoxComponent" + (i + 1).ToString(),
                    Size = new Size(270, 31),
                    TabIndex = i + 21,
                    TextAlign = HorizontalAlignment.Right,
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238)
                });
                CryptharitmPanel.Controls.Add(ComponentTextBox[i]);
            }

            var lastComponentY = ComponentTextBox[ComponentsCount - 1].Location.Y;

            CurrentOperatorLabel = new()
            {
                AutoSize = true,
                Location = new Point(72, lastComponentY + 36),
                Name = "labelOperator",
                Size = new Size(24, 25),
                TabIndex = 7,
                Text = "+"
            };

            Label labelCryptLine = new()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(72, lastComponentY + 64),
                Name = "labelCryptLine",
                Size = new Size(358, 1),
                TabIndex = 10
            };

            OperationResultTextBox = new TextBox()
            {
                CharacterCasing = CharacterCasing.Upper,
                Location = new Point(133, lastComponentY + 88),
                Name = "textBoxSum",
                Size = new Size(292, 31),
                TabIndex = 21 + ComponentsCount,
                TextAlign = HorizontalAlignment.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238)
            };

            CryptharitmPanel.Controls.Add(CurrentOperatorLabel);
            CryptharitmPanel.Controls.Add(labelCryptLine);
            CryptharitmPanel.Controls.Add(OperationResultTextBox);
        }
        public void ClearCryptharitmControls()
        {
            foreach (Control control in CryptharitmPanel.Controls.OfType<Control>().ToList())
            {
                if (control.Name.Contains("textBoxComponent") || control.Name == "labelOperator"
                    || control.Name == "labelCryptLine" || control.Name == "textBoxSum")
                {
                    control.Dispose();
                }
            }
        }
        public string JoinCryptharitmComponents()
        {
            string pattern = string.Empty;
            for (int i = 0; i < ComponentsCount; i++)
            {
                if (ComponentTextBox[i].Text.Contains('|'))
                {
                    MessageBox.Show("Wykryto niedozwolony znak. Używaj tylko liter polskiego alabetu.", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                }
                pattern += ComponentTextBox[i].Text + "|";
            }
            if (OperationResultTextBox.Text.Contains('|'))
            {
                MessageBox.Show("Wykryto niedozwolony znak. Używaj tylko liter polskiego alabetu.", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            pattern += OperationResultTextBox.Text;
            return pattern;
        }    
        public void SetCryptharitmTextBoxesReadOnly(bool ro)
        {
            foreach (var tb in ComponentTextBox) tb.ReadOnly = ro;
            OperationResultTextBox.ReadOnly = ro;
        }
        public string[]? ConvertUlozSamGroupsToArray()
        {
            string tmp = string.Empty ;
            string[] result = new string[8];
            for (int i = 0; i < 8; i++)
            {
                foreach(var ch in GroupTextBox[i].Text)
                {
                    if(tmp.Contains(ch)) return null;
                    else
                    {
                        result[i] += ch;
                        tmp += ch;
                    }
                }
            } 
            return result;
        }
        public void SetUlozSamGroupBoxVisible(bool visible)
        {
            UlozSamSettings.Visible = visible;
        }
        public void SetCurrentOperatorLabelText(string txt)
        {
            CurrentOperatorLabel.Text = txt;
        }
        public void SetComponentTextBoxFocus()
        {
            ComponentTextBox[0].SelectAll();
            ComponentTextBox[0].Focus();
        }

        private void ConvertWordToUlozSamCode_Click(object? sender, EventArgs e)
        {
            var word = WordToCodeTextBox.Text;
            if(word is null || word.Length == 0)
            {
                MessageBox.Show("Podaj wyraz do konwersji.", "Brak wyrazu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var groups = ConvertUlozSamGroupsToArray();
            if (groups == null)
            {
                MessageBox.Show("Litery w grupach nie powinny się powtarzać", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string result = string.Empty;
            bool groupFound;
            foreach(var ch in word)
            {
                groupFound = false;
                for (int i = 0; i<groups.Length; i++)
                {
                    if (groups[i].Contains(ch))
                    {
                        result += (i + 1).ToString();
                        groupFound = true;
                    }
                }
                if (!groupFound)
                {
                    MessageBox.Show("Błędny znak w wyrazie. Nie występuje w żadnej z grup.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            CodeResultLabel.Text = result;
        }
    }
}
