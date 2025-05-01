using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using CrosswordAssistant.Services;

namespace CrosswordAssistant
{
    public partial class SettingsForm : Form
    {
        private readonly MainForm _currentMainForm;
        public SettingsForm(MainForm form)
        {
            _currentMainForm = form;
            InitializeComponent();
            SetCurrentSettings();
        }

        private void SetCurrentSettings()
        {
            textBoxDefaultDictPath.Text = Path.GetFullPath(Settings.DictionaryPath) + "\\" + Settings.DictionaryFileName;
            textBoxMaxResultsCount.Text = Settings.MaxResultsDisplay.ToString();
        }
        private void SaveNewDictionaryPathBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(openFileDialogNewDefaultDictPath, DictionaryMode.NewPath))
            {
                MessageBox.Show("Nowy domyślna lokalizacja pliku ze słownikiem zastała ustawiona." +
                    Environment.NewLine + "Zmiany będą widoczne po ponownym uruchomieniu aplikacji.");
                SetCurrentSettings();
                buttonSettingsApply.Enabled = true;
                buttonSettingsOK.Enabled = true;
            }
        }
        private void Settings_OnClosed(object sender, FormClosingEventArgs e)
        {
            _currentMainForm.Enabled = true;
        }
        private void SettingsCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void SettingsApply_Click(object sender, EventArgs e)
        {
            Settings.MaxResultsDisplay = int.Parse(textBoxMaxResultsCount.Text);
            Settings.SetToAppConfig(new SettingsEntry(Settings.DictionaryPathEntry, Settings.DictionaryPath));
            Settings.SetToAppConfig(new SettingsEntry(Settings.DictionaryFileNameEntry, Settings.DictionaryFileName));
            Settings.SetToAppConfig(new SettingsEntry(Settings.MaxResultsEntry, Settings.MaxResultsDisplay.ToString()));
            buttonSettingsApply.Enabled = false;
            buttonSettingsOK.Enabled = false;
        }

        private void SettingsSave_Click(object sender, EventArgs e)
        {
            SettingsApply_Click(sender, e);
            SettingsCancel_Click(sender, e);
        }

        private void MaxResults_TextChanged(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(textBoxMaxResultsCount.Text, out int currentMax);
            if (isInt)
            {
                buttonSettingsApply.Enabled = currentMax != Settings.MaxResultsDisplay;
                buttonSettingsOK.Enabled = currentMax != Settings.MaxResultsDisplay;
            }
        }
    }
}
