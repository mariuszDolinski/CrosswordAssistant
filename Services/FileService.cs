using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Entities.Responses;
using System.Configuration;
using System.Windows.Forms;

namespace CrosswordAssistant.Services
{
    public class FileService
    {
        private static readonly string SettingsSavePath = (string)Settings.SavedSettings[Settings.DictPathKey];
        private static readonly string SettingsFileNamePath = (string)Settings.SavedSettings[Settings.DictFileKey];
        private static readonly string SettingsDefaultSavePath = (string)Settings.DefaultSettings[Settings.DictPathKey];
        private static readonly string SettingsDefaultFileNamePath = (string)Settings.DefaultSettings[Settings.DictFileKey];

        public static string SavePath { get; private set; } = SettingsSavePath;
        public static string FileName { get; private set; } = SettingsFileNamePath;

        public static async Task<List<string>> ReadDictionaryAsync()
        {
            try
            {
                var words = await File.ReadAllLinesAsync(Path.Combine(SavePath, FileName));
                return [.. words];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Do poprawnego działania aplikacji wymagany jest plik ze słownikiem. " +
                    "Powinien się znaleźć w folderze 'Słowniki' w tej samej lokalizacji co aplikacja " +
                    "i nazywać się 'slownik.txt'. Plik powinien zawierać po jednym wyrazie w każdej linii.",
                    "Brak pliku ze słownikiem",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.WriteToLog(LogLevel.Warning, ex.Message, ex.StackTrace ?? "");
                return [Messages.NoFile];
            }
        }

        public static List<string> ReadDictionary()
        {
            try
            {
                var words = File.ReadAllLines(Path.Combine(SavePath, FileName));
                return [.. words];
            }
            catch (Exception ex)
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
                    SavePath = SettingsDefaultSavePath; FileName = SettingsDefaultFileNamePath;
                    Settings.SavedSettings[Settings.DictPathKey] = SavePath;
                    Settings.SavedSettings[Settings.DictFileKey] = FileName;
                    Settings.SaveSettingToAppConfig();
                    MessageBox.Show("Domyślne ustawienia zostały zmienione. Uruchom aplikację ponownie", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Logger.WriteToLog(LogLevel.Warning, ex.Message, ex.StackTrace ?? "");
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
            catch (Exception ex)
            {
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
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
                            Settings.CurrentSettings[Settings.DictPathKey] = Path.GetDirectoryName(ofd.FileName)!;
                            Settings.CurrentSettings[Settings.DictFileKey] = Path.GetFileName(ofd.FileName);
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
                    return [.. words];
                }
            }
            return [];
        }
        public static SudokuResponse IsFileInSudokuFormat(string[]? lines)
        {
            if(lines ==  null || lines.Length == 0)
            {
                return new SudokuResponse(null, false, "Podany plik jest pusty lub uszkodzony.", 0);
            }
            bool isCorrectFormat = true;
            int[,] digits = new int[9, 9];
            if (lines.Length != 9) isCorrectFormat = false;
            if (isCorrectFormat)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Length != 9)
                    {
                        isCorrectFormat = false;
                        break;
                    }
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        if (int.TryParse(lines[i][j].ToString(), out int val))
                        {
                            if(val >= 0 && val <= 9)
                            {
                                digits[i, j] = val;
                            }
                            else
                            {
                                isCorrectFormat = false;
                                break;
                            }
                        }
                        else
                        {
                            isCorrectFormat = false;
                            break;
                        }
                    }
                }
            }
            if (!isCorrectFormat)
            {
                return new SudokuResponse(null, false, "Podany plik ma zły format. Powinien zawierać dokładnie 9 wierszy, w każdym z nich dokładnie 9 cyfr od 0 do 9", 0);
            }

            return new SudokuResponse(digits, true, "", 0);
        }

    }
}
