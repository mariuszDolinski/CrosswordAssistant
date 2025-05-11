using System.Drawing;

namespace CrosswordAssistant.AppSettings
{
    public class AppearanceSettings(MainForm form)
    {
        private readonly MainForm _mainForm = form;

        private Dictionary<Color, List<Label>> GetColorSettings()
        {
            return new Dictionary<Color, List<Label>>()
            {
                {
                    Color.FromArgb((int)Settings.SavedSettings[Settings.PatternColorKey]),
                    new List<Label>() 
                    {
                        _mainForm.labelPattern,
                        _mainForm.labelCurrentPatternLen,
                        _mainForm.labelResultsCount
                    }
                }
            };
        }

        public void SetBackgroundColor()
        {
            foreach (var cs in GetColorSettings())
            {
                foreach(var label in cs.Value)
                {
                    label.BackColor = cs.Key;
                }
            }
        }
    }
}
