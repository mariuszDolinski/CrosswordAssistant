using CrosswordAssistant.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrosswordAssistant
{
    public partial class SettingsForm : Form
    {
        //private readonly MainForm currentMainForm;
        public SettingsForm(MainForm form)
        {
            //currentMainForm = form;
            InitializeComponent();
            SetDictionaryPath();
        }

        private void SetDictionaryPath()
        {
            textBoxDefaultDictPath.Text = Path.GetFullPath(FileService.SavePath) + "\\" + FileService.FileName;
        }

        private void saveNewDictionaryPathBtn_Click(object sender, EventArgs e)
        {
            if (FileService.SetCurrentDictionaryPathFromDialog(openFileDialogNewDefaultDictPath))
            {
                MessageBox.Show("Nowy domyślna lokalizacja pliku ze słownikiem zastała ustawiona." +
                    Environment.NewLine + "Zmiany będą widoczne po ponownym uruchomieniu aplikacji.");
                ConfigurationManager.AppSettings["dictionaryLocation"] = FileService.SavePath;
                ConfigurationManager.AppSettings["dictionaryName"] = FileService.FileName;
                FileService.SetDictionaryPathToAppConfig();
                SetDictionaryPath();
            }
        }
    }
}
