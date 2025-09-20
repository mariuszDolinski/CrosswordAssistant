using CrosswordAssistant.Services;
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
                        _mainForm.labelPatternResultsInfo
                    ],
                    [
                        _mainForm.labelCryptharitms,
                        _mainForm.labelCriptharytmInfo
                    ],
                    [
                        _mainForm.labelScrabble,
                        _mainForm.labelScrabbleCurrentPatternLen,
                        _mainForm.labelScrabbleCalc,
                        _mainForm.labelScrabbePoints
                    ]
                ];
        }
        private static List<Color> GetSettingsColors()
        {
            return
                [
                    Color.FromArgb((int)Settings.SavedSettings[BaseSettings.PatternColorKey]),
                    Color.FromArgb((int)Settings.SavedSettings[BaseSettings.CryptharitmColorKey]),
                    Color.FromArgb((int)Settings.SavedSettings[BaseSettings.ScrabbleColorKey])
                ];
        }

        public void SetBackgroundColor()
        {
            var colorSettings = GetSettingsColors();
            var labelsToColor = GetLabelsToSetColor();
            foreach (var labels in labelsToColor)
            {
                FormService.SetLabelsBackColor(labels, colorSettings[labelsToColor.IndexOf(labels)]);
            }
        }
        public void SetMainFormLocation()
        {
            var setLocation = (int)Settings.SavedSettings[BaseSettings.MainFormPosKey];
            var scr = Screen.PrimaryScreen;
            int screenWidth = scr is null ? 0 : scr.Bounds.Width;
            int screenHeight = scr is null ? 0 : scr.Bounds.Height;
            int formWidth = _mainForm.Width;
            int formHeight = _mainForm.Height;
            _mainForm.Location = setLocation switch
            {
                1 => new Point(0, 0),
                2 => new Point(screenWidth - formWidth, 0),
                3 => new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2),
                _ => new Point(0, 0),
            };
        }
        public void SetTextBoxesCasing(bool caseSensitive)
        {
            _mainForm.textBoxPattern.CharacterCasing = caseSensitive ? CharacterCasing.Normal : CharacterCasing.Upper;
            _mainForm.textBoxBeginsWith.CharacterCasing = caseSensitive ? CharacterCasing.Normal : CharacterCasing.Upper;
            _mainForm.textBoxEndsWith.CharacterCasing = caseSensitive ? CharacterCasing.Normal : CharacterCasing.Upper;
            _mainForm.textBoxContains.CharacterCasing = caseSensitive ? CharacterCasing.Normal : CharacterCasing.Upper;
            _mainForm.textBoxNotContains.CharacterCasing = caseSensitive ? CharacterCasing.Normal : CharacterCasing.Upper;
        }
    }
}
