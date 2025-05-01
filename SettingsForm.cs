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
            SetDictionaryPath();
        }

        private void SetDictionaryPath()
        {
            textBoxDefaultDictPath.Text = Path.GetFullPath(Settings.DictionaryPath) + "\\" + Settings.DictionaryFileName;
        }
        private void SaveNewDictionaryPathBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(openFileDialogNewDefaultDictPath, DictionaryMode.NewPath))
            {
                MessageBox.Show("Nowy domyślna lokalizacja pliku ze słownikiem zastała ustawiona." +
                    Environment.NewLine + "Zmiany będą widoczne po ponownym uruchomieniu aplikacji.");
                SetDictionaryPath();
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
            Settings.SetToAppConfig(new SettingsEntry(Settings.DictionaryPathEntry, Settings.DictionaryPath, Settings.DeafultSavePath));
            Settings.SetToAppConfig(new SettingsEntry(Settings.DictionaryFileNameEntry, Settings.DictionaryFileName, Settings.DefaultFileName));
            buttonSettingsApply.Enabled = false;
            buttonSettingsOK.Enabled = false;
        }

        private void SettingsSave_Click(object sender, EventArgs e)
        {
            SettingsApply_Click(sender, e);
            SettingsCancel_Click(sender, e);
        }
    }
}
