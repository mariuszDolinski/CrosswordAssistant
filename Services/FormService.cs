using CrosswordAssistant.AppSettings;

namespace CrosswordAssistant.Services
{
    public class FormService
    {
        public static void FilterChecked(CheckBox checkBox, List<CheckBox> checkBoxes, List<TextBox> textBoxes, List<RadioButton> radios) 
        {
            foreach(var radio in radios)
                radio.Enabled = checkBox.Checked;
            if(checkBox.Checked)
                radios[1].Checked = checkBox.Checked;
            else
                foreach (var radio in radios)
                    radio.Checked = checkBox.Checked;
            foreach (var tb in textBoxes)
            {
                tb.Enabled = checkBox.Checked;
                tb.Text = "";
                tb.Focus();
            }
            foreach(var cb in checkBoxes)
            {
                cb.Enabled = checkBox.Checked;
                cb.Checked = false;
            }
        }
        public static void SetLabelsBackColor(List<Label> labels, Color color)
        {
            foreach (Label label in labels)
            {
                label.BackColor = color;
            }
        }
        public static void FillTextBoxScrabbleResults(TextBox textBox, List<string> words)
        {
            string result = "";
            int maxLength = words.Max(w => w[..w.IndexOf('(')].Length);
            for (int i = maxLength; i > 3; i--) 
            {
                var wordsByLength = words.Where(w => w[..w.IndexOf('(')].Length == i).ToList();
                wordsByLength = [..wordsByLength.OrderByDescending(w => w.GetWordPoints())];
                if (wordsByLength.Count == 0) continue;
                result += $"Wyrazy {i}-literowe:" + Environment.NewLine;
                foreach (var word in wordsByLength)
                {
                    if(wordsByLength.IndexOf(word) != wordsByLength.Count - 1)
                        result += $"{word}, ";
                    else
                        result += $"{word}";
                }
                result += Environment.NewLine + Environment.NewLine;
                textBox.Text = result;
            }
        }
        public static void FillTextBoxWithWords(TextBox textBox, List<string> words, bool appendText)
        {
            int MaxResultDisplay = (int)Settings.SavedSettings[Settings.MaxResultsKey];
            string result = "";
            if(words.Count > MaxResultDisplay)
            {
                result = "Zbyt wiele wyrazów do wyświetlenia. Pokazuję pierwsze " + MaxResultDisplay.ToString();
                result += Environment.NewLine + Environment.NewLine;
                words = words.Take(MaxResultDisplay).ToList();
            }
            foreach (string word in words)
            {
                result += word + Environment.NewLine;
            }
            if(appendText)
                textBox.Text += Environment.NewLine + result;
            else
                textBox.Text = result;
        }
        public static int TextBoxPositiveNumber(TextBox textBox)
        {
            if (textBox.Text.Length == 0) return 0;
            if(int.TryParse(textBox.Text, out var result))
            {
                if (result <= 0) return -1;
                return result;
            }
            else
            {
                return -1;
            }
        }
        public static void GenerateCryptharitmControls(SplitterPanel panel, int count)
        {
            TextBox[] components = new TextBox[count];
            for (int i = 0; i < count; i++)
            {
                components[i] = new()
                {
                    CharacterCasing = CharacterCasing.Upper,
                    Location = new Point(110, 136 + 37 * i),
                    Name = "textBoxComponent" + (i + 1).ToString(),
                    Size = new Size(305, 31),
                    TabIndex = i + 21,
                    TextAlign = HorizontalAlignment.Right
                };
                panel.Controls.Add(components[i]);
            }

            var lastComponentY = components[count -  1].Location.Y;

            Label labelOperator = new()
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
                Size = new Size(393, 1),
                TabIndex = 10
            };

            TextBox textBoxSum = new()
            {
                CharacterCasing = CharacterCasing.Upper,
                Location = new Point(88, lastComponentY + 88),
                Name = "textBoxSum",
                Size = new Size(327, 31),
                TabIndex = 21 + count,
                TextAlign = HorizontalAlignment.Right
            };

            panel.Controls.Add(labelOperator);
            panel.Controls.Add(labelCryptLine);
            panel.Controls.Add(textBoxSum);
        }

        public static void ClearCryptharitmControls(SplitterPanel panel)
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
    }
}
