using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using System.Configuration;
using System.Windows.Forms;

namespace CrosswordAssistant.Services
{
    public class FileService
    {
        public static string SavePath { get; private set; } = Settings.DictionaryPath;
        public static string FileName { get; private set; } = Settings.DictionaryFileName;

        public static async Task<List<string>> ReadDictionaryAsync()
        {
            try
            {
                var words = await File.ReadAllLinesAsync(Path.Combine(SavePath, FileName));
                return new List<string>(words);
            }
            catch
            {
                MessageBox.Show("Do poprawnego działania aplikacji wymagany jest plik ze słownikiem. " +
                    "Powinien się znaleźć w folderze 'Słowniki' w tej samej lokalizacji co aplikacja " +
                    "i nazywać się 'slownik.txt'. Plik powinien zawierać po jednym wyrazie w każdej linii.",
                    "Brak pliku ze słownikiem",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return [Messages.NoFile];
            }
        }

        public static List<string> ReadDictionary()
        {
            try
            {
                var words = File.ReadAllLines(Path.Combine(SavePath, FileName));
                return new List<string>(words);
            }
            catch
            {
                var resp = MessageBox.Show("Do poprawnego działania aplikacji wymagany jest plik ze słownikiem. " +
                    "Upewnij się, że w folderze 'Słowniki' w tej samej lokalizacji co aplikacja " +
                    "znajduje się plik ze słownikiem o nazwie 'slownik.txt'. " +
                    "Plik powinien zawierać po jednym wyrazie w każdej linii.  Jeśli tak możesz przywrócić domyślne ustawienia." +
                    Environment.NewLine + Environment.NewLine + "Czy checesz przywrócić domyślne ustawienia " +
                    "ścieżki do pliku ze słownikiem?",
                    "Błąd pliku ze słownikiem", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(resp == DialogResult.Yes)
                {
                    SavePath = Settings.DeafultSavePath; FileName = Settings.DefaultFileName;
                    Settings.SetToAppConfig(new SettingsEntry(Settings.DictionaryPathEntry, Settings.DictionaryPath));
                    Settings.SetToAppConfig(new SettingsEntry(Settings.DictionaryFileNameEntry, Settings.DictionaryFileName));
                    MessageBox.Show("Domyślne ustawienia zostały zmienione. Uruchom aplikację ponownie", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return [Messages.NoFile];
            }
        }

        public static bool SaveDictionary(List<string> words)
        {
            try
            {
                File.WriteAllLines(Path.Combine(SavePath, FileName), words);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SetCurrentDictionaryPathFromDialog(OpenFileDialog ofd, DictionaryMode mode)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.EndsWith("txt"))
                {
                    MessageBox.Show("Wybrany plik nie jest plikiem tekstowym.");
                    return false;
                }
                else
                {
                    switch (mode)
                    {
                        case DictionaryMode.NewFile:
                            FileName = Path.GetFileName(ofd.FileName);
                            SavePath = Path.GetDirectoryName(ofd.FileName)!;
                            break;
                        case DictionaryMode.NewPath:
                            Settings.DictionaryPath = Path.GetDirectoryName(ofd.FileName)!;
                            Settings.DictionaryFileName = Path.GetFileName(ofd.FileName);
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        public static List<string> LoadTextFile(OpenFileDialog ofd)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.EndsWith("txt"))
                {
                    MessageBox.Show("Wybrany plik nie jest plikiem tekstowym.");
                    return [];
                }
                else
                {
                    var words = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(ofd.FileName)!, Path.GetFileName(ofd.FileName)));
                    return new List<string>(words);
                }
            }
            return [];
        }

    }
}
