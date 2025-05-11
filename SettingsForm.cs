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
        }
        private void SetButtonsVisibility()
        {
            bool isChange = Settings.ExistsUnsavedSeting();
            buttonSettingsApply.Enabled = isChange;
            buttonSettingsOK.Enabled = isChange;
        }
        private bool ValidateSettings()
        {
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
            if (setColorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.CurrentSettings[Settings.PatternColorKey] = setColorDialog.Color.ToArgb();
                labelColorPattern.BackColor = setColorDialog.Color;
                SetButtonsVisibility();
            }
        }
        private void UlozSamColor_Click(object sender, EventArgs e)
        {
            if (setColorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.CurrentSettings[Settings.UlozSamColorKey] = setColorDialog.Color.ToArgb();
                labelColorUlozSam.BackColor = setColorDialog.Color;
                SetButtonsVisibility();
            }
        }

    }
}
