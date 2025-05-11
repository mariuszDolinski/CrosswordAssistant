using System.Drawing;

namespace CrosswordAssistant.AppSettings
{
    public class AppearanceSettings(MainForm form)
    {
        private readonly MainForm _mainForm = form;

        private List< List<Label>> GetLabelsToSetColor()
        {
            return
                [
                    [
                        _mainForm.labelPattern,
                        _mainForm.labelCurrentPatternLen,
                        _mainForm.labelResultsCount
                    ],
                    [
                        _mainForm.labelUluzSam,
                        _mainForm.labelGr1,
                        _mainForm.labelGr2,
                        _mainForm.labelGr3,
                        _mainForm.labelGr4,
                        _mainForm.labelGr5,
                        _mainForm.labelGr6,
                        _mainForm.labelGr7,
                        _mainForm.labelGr8
                    ]
                ];
        }
        private List<Color> GetSettingsColors()
        {
            return
                [
                    Color.FromArgb((int)Settings.SavedSettings[Settings.PatternColorKey]),
                    Color.FromArgb((int)Settings.SavedSettings[Settings.UlozSamColorKey])
                ];
        }

        public void SetBackgroundColor()
        {
            var colorSettings = GetSettingsColors();
            var labelsToColor = GetLabelsToSetColor();
            foreach (var labels in labelsToColor)
            {
                foreach(var label in labels)
                {
                    label.BackColor = colorSettings[labelsToColor.IndexOf(labels)];
                }
            }
        }
    }
}
