namespace CrosswordAssistant.Services
{
    public class CustomControls
    {
        private readonly MainForm _mainForm;

        //Cryptharitm dynamic controls
        public List<TextBox> ComponentTextBox;
        public TextBox OperationResultTextBox;
        public Label CurrentOperatorLabel;

        public int ComponentsCount;

        public CustomControls(MainForm mainForm)
        {
            _mainForm = mainForm;
            ComponentTextBox = [];
            OperationResultTextBox = new TextBox();
            CurrentOperatorLabel = new Label();
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
                _mainForm.SplitContainerCryptharitms.Panel2.Controls.Add(ComponentTextBox[i]);
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

            _mainForm.SplitContainerCryptharitms.Panel2.Controls.Add(CurrentOperatorLabel);
            _mainForm.SplitContainerCryptharitms.Panel2.Controls.Add(labelCryptLine);
            _mainForm.SplitContainerCryptharitms.Panel2.Controls.Add(OperationResultTextBox);
        }
        public void ClearCryptharitmControls()
        {
            foreach (Control control in _mainForm.SplitContainerCryptharitms.Panel2.Controls.OfType<Control>().ToList())
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
