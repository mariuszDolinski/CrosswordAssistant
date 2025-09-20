using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Requests;

namespace CrosswordAssistant.Services
{
    public class CustomControls
    {
        private readonly string[] GroupLetters = ["AĄBC", "ĆDEĘ", "FGHI", "JKLŁ", "MNŃO", "ÓPRS", "ŚTUW", "YZŹŻ"];
        //MainForm controls
        private readonly Panel CryptharitmPanel;
        private readonly Panel PatternPanel;

        public int ComponentsCount { get; set; }

        //Cryptharitm dynamic controls
        public List<TextBox> ComponentTextBox {  get; set; }
        public TextBox OperationResultTextBox { get; set; }
        public Label CurrentOperatorLabel { get; set; }


        //Ułóż sam mode
        public Label[] GroupLabel { get; set; }
        public TextBox[] GroupTextBox { get; set; }
        public GroupBox UlozSamGroups {  get; set; }

        public CustomControls(CustomControlsRequest request)
        {
            CryptharitmPanel = request.CryptaritmPanel;
            PatternPanel = request.PatternPanel;
            ComponentTextBox = [];
            OperationResultTextBox = new TextBox();
            CurrentOperatorLabel = new Label();
            UlozSamGroups = new GroupBox();
            GroupLabel = new Label[8];
            GroupTextBox = new TextBox[8];
            ComponentsCount = 2;

            InitializeControls();
        }

        private void InitializeControls()
        {
            InitializeCryptharitmControls();
            InitializeUlozSamControls();
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

            OperationResultTextBox = new()
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
        public void InitializeUlozSamControls()
        {
            var bColor = Color.FromArgb((int)Settings.SavedSettings[BaseSettings.PatternColorKey]);
            
            UlozSamGroups = new GroupBox()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "groupBoxFilters",
                Size = new Size(709, 473),
                TabIndex = 2,
                TabStop = false,
                Text = "Grupy liter",
                Visible = false
            };

            int offsetX = 0;
            int offsetY = 0;
            for (int i = 0; i < 8; i++)
            {
                if (i > 3) { offsetX = 350; offsetY = -4; }
                GroupLabel[i] = new Label
                {
                    BackColor = bColor,
                    Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    Location = new Point(25 + offsetX, 45 * (i + 1 + offsetY)),
                    Margin = new Padding(4, 2, 3, 2),
                    Name = "labelGr1",
                    Size = new Size(72, 36),
                    TabIndex = 0,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = (i + 1).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                GroupTextBox[i] = new TextBox
                {
                    Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    Location = new Point(105 + offsetX, 45 * (i + 1 + offsetY)),
                    Margin = new Padding(3, 1, 3, 3),
                    Name = "textBoxGr1",
                    Size = new Size(215, 36),
                    TabIndex = 30,
                    Text = GroupLetters[i],
                    CharacterCasing = CharacterCasing.Upper
                };
                UlozSamGroups.Controls.Add(GroupLabel[i]);
                UlozSamGroups.Controls.Add(GroupTextBox[i]);
            }

            PatternPanel.Controls.Add(UlozSamGroups);
        }
    }
}
