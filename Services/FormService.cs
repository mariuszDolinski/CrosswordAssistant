namespace CrosswordAssistant.Services
{
    public class FormService
    {
        public static void SwitchControlVisibility(Control control)
        {
            if (control.Visible)
            {
                control.Visible = false;
            }
            else
            {
                control.Visible = true;
            }
        }
        public static void FilterChecked(CheckBox checkBox, TextBox textBox) 
        {
            if (checkBox.Checked)
            {
                textBox.Enabled = true;
            }
            else
            {
                textBox.Enabled = false;
                textBox.Text = "";
            }
        }
        public static void ResetLabelsBackColor(List<Label> labels, Color color)
        {
            foreach (Label label in labels)
            {
                label.BackColor = color;
            }
        }
        public static void FillTextBoxScrabbleResults(TextBox textBox, List<string> words, string pattern)
        {
            string result = "";
            int maxLength = words.Max(w => w.Length);
            int score;
            for (int i = maxLength; i > 3; i--) 
            {
                var wordsByLength = words.Where(w => w.Length == i).ToList();
                if (wordsByLength.Count == 0) continue;
                result += $"Wyrazy {i}-literowe:" + Environment.NewLine;
                foreach (var word in wordsByLength)
                {
                    score = Utilities.CountScrabblePoints(word, pattern);
                    if(wordsByLength.IndexOf(word) != wordsByLength.Count - 1)
                        result += $"{word}({score}), ";
                    else
                        result += $"{word}({score})";
                }
                result += Environment.NewLine + Environment.NewLine;
                textBox.Text = result;
            }
        }
    }
}
