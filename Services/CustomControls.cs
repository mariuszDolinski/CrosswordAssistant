using CrosswordAssistant.Entities.Requests;

namespace CrosswordAssistant.Services
{
    public class CustomControls
    {
        //MainForm controls
        private readonly Panel CryptharitmPanel;
        private readonly Panel PatternPanel;

        //Cryptharitm dynamic controls
        public List<TextBox> ComponentTextBox;
        public TextBox OperationResultTextBox;
        public Label CurrentOperatorLabel;

        //Ułóż sam mode
        public GroupBox UlozSamGroups;

        public int ComponentsCount;

        public CustomControls(CustomControlsRequest request)
        {
            CryptharitmPanel = request.CryptaritmPanel;
            PatternPanel = request.PatternPanel;
            ComponentTextBox = [];
            OperationResultTextBox = new TextBox();
            CurrentOperatorLabel = new Label();
            UlozSamGroups = new GroupBox();
            ComponentsCount = 2;

            InitializeControls();
        }

        public void InitializeControls()
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

            CryptharitmPanel.Controls.Add(CurrentOperatorLabel);
            CryptharitmPanel.Controls.Add(labelCryptLine);
            CryptharitmPanel.Controls.Add(OperationResultTextBox);
            PatternPanel.Controls.Add(UlozSamGroups);
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
    }
}
