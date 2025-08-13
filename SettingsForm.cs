using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using CrosswordAssistant.Services;

namespace CrosswordAssistant
{
    public partial class SettingsForm : Form
    {
        private readonly MainForm _currentMainForm;
        private bool _isValidateOk;
        public SettingsForm(MainForm form)
        {
            _currentMainForm = form;
            _isValidateOk = true;
            InitializeComponent();
            SetCurrentSettings();
        }

        private void SetCurrentSettings()
        {
            textBoxDefaultDictPath.Text = Path.GetFullPath((string)Settings.CurrentSettings[Settings.DictPathKey]) + "\\" + Settings.CurrentSettings[Settings.DictFileKey];
            textBoxMaxResultsCount.Text = Settings.CurrentSettings[Settings.MaxResultsKey].ToString();
            labelColorPattern.BackColor = Color.FromArgb((int)Settings.CurrentSettings[Settings.PatternColorKey]);
            labelColorUlozSam.BackColor = Color.FromArgb((int)Settings.CurrentSettings[Settings.UlozSamColorKey]);
            labelColorScrabble.BackColor = Color.FromArgb((int)Settings.CurrentSettings[Settings.ScrabbleColorKey]);
            SetMainFormPositionRadioButtons();
            SetCaseSensitiveRdioButtons();
        }
        private void SetButtonsVisibility()
        {
            bool isChange = Settings.ExistsUnsavedSetting();
            buttonSettingsApply.Enabled = isChange;
            buttonSettingsOK.Enabled = isChange;
        }
        private bool ValidateSettings()
        {
            if (Settings.ExistsSettingsRequiredRestart())
            {
                var response = MessageBox.Show("Niektóre ze zmienionych ustawień wymagają restartu aplikacji. Wybierz 'Tak' jeśli chcesz kontynuować, " +
                    "a następnie zamknij aplikację. Wybierz 'Nie' aby anulować zmiany.", "Wymagane ponowne uruchomienie", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (response == DialogResult.No) return false;
            }
            bool isInt = int.TryParse(textBoxMaxResultsCount.Text, out int currentMax);
            if (!isInt)
            {
                MessageBox.Show("Maksymalna ilość dopasowań powinna być liczbą.", "Maksymalna ilość dopasowań", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (currentMax < 10 || currentMax > 1000)
            {
                MessageBox.Show("Maksymalna ilość dopasowań powinna być liczbą z przedziału [10,1000].", "Maksymalna ilość dopasowań", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void SetCustomColors()
        {
            setColorDialog.CustomColors =
            [
                ColorTranslator.ToOle(labelColorPattern.BackColor),
                ColorTranslator.ToOle(labelColorUlozSam.BackColor),
                ColorTranslator.ToOle(labelColorScrabble.BackColor)
            ];
        }
        private void SetNewColor(Label label, string key)
        {
            SetCustomColors();
            if (setColorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.CurrentSettings[key] = setColorDialog.Color.ToArgb();
                label.BackColor = setColorDialog.Color;
                SetButtonsVisibility();
            }
        }
        private void SetMainFormPositionRadioButtons()
        {
            switch ((int)Settings.SavedSettings[Settings.MainFormPosKey])
            {
                case 1: radioBtnPosTL.Checked = true; break;
                case 2: radioBtnPosTR.Checked = true; break;
                case 3: radioBtnPosC.Checked = true; break;
                default: radioBtnPosC.Checked = true; break;
            }
        }
        private void SetCaseSensitiveRdioButtons()
        {
            switch ((byte)Settings.SavedSettings[Settings.CaseSensitiveKey])
            {
                case 0: radioBtnCaseSensitiveNo.Checked = true; break;
                case 1: radioBtnCaseSensitiveYes.Checked = true; break;
                default: radioBtnCaseSensitiveNo.Checked = true; break;
            }
        }


        private void Settings_OnClosed(object sender, FormClosingEventArgs e)
        {
            Settings.CancelCurrentSettings();
            _currentMainForm.Enabled = true;
        }
        private void MaxResults_TextChanged(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(textBoxMaxResultsCount.Text, out int currentMax);
            if (isInt)
            {
                Settings.CurrentSettings[Settings.MaxResultsKey] = currentMax;
                SetButtonsVisibility();
            }
        }
        private void SettingsCancel_Click(object sender, EventArgs e)
        {
            Settings.CancelCurrentSettings();
            Close();
            Dispose();
        }
        private void SettingsApply_Click(object? sender, EventArgs e)
        {
            if (ValidateSettings())
            {
                Settings.SaveCurrentSettings();
                Settings.SaveSettingToAppConfig();
                buttonSettingsApply.Enabled = false;
                buttonSettingsOK.Enabled = false;
                _currentMainForm.MaxResultDisplay = (int)Settings.SavedSettings[Settings.MaxResultsKey];
                _isValidateOk = true;
            }
            else
            {
                _isValidateOk = false;
            }
        }
        private void SettingsSave_Click(object sender, EventArgs e)
        {
            SettingsApply_Click(sender, e);
            if (_isValidateOk)
            {
                Close();
                Dispose();
            }
        }
        private void SaveNewDictionaryPathBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(openFileDialogNewDefaultDictPath, DictionaryMode.NewPath))
            {
                MessageBox.Show("Nowy domyślna lokalizacja pliku ze słownikiem zastała ustawiona." +
                    Environment.NewLine + "Zmiany będą widoczne po ponownym uruchomieniu aplikacji.");
                SetCurrentSettings();
                SetButtonsVisibility();
            }
        }
        private void BackToDefaultSettings_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Czy na pewno chcesz przywrócić domyślne ustawienia aplikacji?",
                "Przywracanie ustawień domyślnych", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (response == DialogResult.Yes)
            {
                Settings.ReturnToDefaultSettings();
                Settings.SaveCurrentSettings();
                Settings.SaveSettingToAppConfig();

                MessageBox.Show("Ustawienia domyślne zostały przywrócone. Niektóre zmiany mogą być widoczne dopiero po ponownym uruchomieniu aplikacji.",
                "Przywracanie ustawień domyślnych", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PatternColor_Click(object sender, EventArgs e)
        {
            SetNewColor(labelColorPattern, Settings.PatternColorKey);
        }
        private void UlozSamColor_Click(object sender, EventArgs e)
        {
            SetNewColor(labelColorUlozSam, Settings.UlozSamColorKey);
        }
        private void ScrabbleColor_Click(object sender, EventArgs e)
        {
            SetNewColor(labelColorScrabble, Settings.ScrabbleColorKey);
        }
        private void RadioBtnPos_CheckedChange(object sender, EventArgs e)
        {
            var radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                Settings.CurrentSettings[Settings.MainFormPosKey] = radioBtn.TabIndex - 3;
                SetButtonsVisibility();
            }
        }
        private void RadioBtnCaseSensitive_CheckedChaged(object sender, EventArgs e)
        {
            var radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                Settings.CurrentSettings[Settings.CaseSensitiveKey] = radioBtn.TabIndex - 9;
                SetButtonsVisibility();
            }
        }
    }
}
