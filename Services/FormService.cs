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
        public static void ResetLabelsBackColor(List<Label> labels, Color color)
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
                wordsByLength = wordsByLength.OrderByDescending(w => w.GetWordPoints()).ToList();
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
            string result = "";
            if(words.Count > 500)
            {
                result = "Zbyt wiele wyrazów do wyświetlenia. Pokazuję pierwsze 500.";
                result += Environment.NewLine + Environment.NewLine;
                words = words.Take(500).ToList();
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
    }
}
