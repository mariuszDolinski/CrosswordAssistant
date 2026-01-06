using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Enums;
using System.Text.RegularExpressions;

namespace CrosswordAssistant.Services
{
    public class FormService
    {
        public static void FilterChecked(CheckBox checkBox, List<CheckBox> checkBoxes, List<TextBox> textBoxes, List<RadioButton> radios)
        {
            foreach (var radio in radios)
                radio.Enabled = checkBox.Checked;
            if (checkBox.Checked)
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
            foreach (var cb in checkBoxes)
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
            if (BaseSettings.ScrabbleSortType == ScrabbleSort.LengthPoints)
                FillTextBoxScrabbleResultsLengthFirst(textBox, words, wl => [.. wl.OrderByDescending(w => w.GetWordPoints())]);
            else if (BaseSettings.ScrabbleSortType == ScrabbleSort.PointsAlph)
                FillTextBoxScrabbleResultsPointsAlph(textBox, words);
            else if (BaseSettings.ScrabbleSortType == ScrabbleSort.LengthAlph)
                FillTextBoxScrabbleResultsLengthFirst(textBox, words, wl => [.. wl.OrderBy(w => w)]);
        }
        public static void FillTextBoxWithWords(TextBox textBox, List<string> words, bool appendText)
        {
            int MaxResultDisplay = (int)Settings.SavedSettings[Settings.MaxResultsKey];
            string result = "";
            bool isBounded = false;
            if (words.Count > MaxResultDisplay)
            {
                words = [.. words.Take(MaxResultDisplay)];
                isBounded = true;
            }
            foreach (string word in words)
            {
                result += word + Environment.NewLine;
            }
            if (isBounded)
            {
                result += Environment.NewLine;
                result += "Zbyt wiele wyrazów do wyświetlenia. Pokazuję pierwsze " + MaxResultDisplay.ToString();
            }
            if (appendText)
                textBox.Text += Environment.NewLine + result;
            else
                textBox.Text = result;
        }
        public static int TextBoxPositiveNumber(TextBox textBox)
        {
            if (textBox.Text.Length == 0) return 0;
            if (int.TryParse(textBox.Text, out var result))
            {
                if (result <= 0) return -1;
                return result;
            }
            else
            {
                return -1;
            }
        }
        public static void FillTextBoxCriptharytmSolutions(TextBox textBox, List<string> solutions)
        {
            var result = string.Empty;
            int i = 1;
            foreach (var solution in solutions)
            {
                var solutionPart = solution.Split('|');
                result += i.ToString() + ". " + solutionPart[0] + Environment.NewLine;
                result += "Sprawdzenie: " + solutionPart[1] + Environment.NewLine;
                if(i - 1 < solutions.Count - 1)
                {
                    result += "------------------------------------------------------------------------";
                    result += Environment.NewLine;
                }                  
                i++;
            }
            textBox.Text = result;
        }

        private static void FillTextBoxScrabbleResultsLengthFirst(TextBox textBox, List<string> words, 
            Func<List<string>, List<string>> sortSelector)
        {
            string result = "";
            int maxLength = words.Max(w => w[..w.IndexOf('(')].Length);
            for (int i = maxLength; i > 3; i--)
            {
                var wordsByLength = words.Where(w => w[..w.IndexOf('(')].Length == i).ToList();
                if (wordsByLength.Count == 0) continue;
                wordsByLength = sortSelector(wordsByLength);
                result += $"Wyrazy {i}-literowe:" + Environment.NewLine;
                foreach (var word in wordsByLength)
                {
                    if (wordsByLength.IndexOf(word) != wordsByLength.Count - 1)
                        result += $"{word}, ";
                    else
                        result += $"{word}";
                }
                result += Environment.NewLine + Environment.NewLine;
                textBox.Text = result;
            }
        }

        private static void FillTextBoxScrabbleResultsPointsAlph(TextBox textBox, List<string> words)
        {
            string result = "";
            int maxPoints = words.Max(w => w.GetWordPoints());
            int minPoints = words.Min(w => w.GetWordPoints());

            for (int i = maxPoints; i >= minPoints; i--)
            {
                var wordsByPoints = words.Where(w => w.GetWordPoints() == i).ToList();
                if (wordsByPoints.Count == 0) continue;
                wordsByPoints = [.. wordsByPoints.OrderBy(w => w)];
                result += $"Wyrazy za {i} " + GetCorrectPrenouncation(i).ToString() + ":" + Environment.NewLine;
                foreach (var word in wordsByPoints)
                {
                    if (wordsByPoints.IndexOf(word) != wordsByPoints.Count - 1)
                        result += word[..word.IndexOf('(')] + ", ";
                    else
                        result += word[..word.IndexOf('(')];
                }
                result += Environment.NewLine + Environment.NewLine;
                textBox.Text = result;
            }
        }

        private static string GetCorrectPrenouncation(int n)
        {
            if (n == 1) return "punkt";
            else if (n == 12 || n == 13 || n == 14) return "punktów";
            else if (n % 10 == 2 || n % 10 == 3 || n % 10 == 4) return "punkty";
            else return "punktów"; 
        }
    }
}
