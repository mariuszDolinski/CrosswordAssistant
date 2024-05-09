using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Services
{
    public class FileService
    {
        public static string SavePath { get; private set; } = "Słowniki";
        public static string FileName { get; private set; } = "slownik.txt";

        public static List<string> ReadDictionary()
        {
            try
            {
                var words = File.ReadAllLines(Path.Combine(SavePath, FileName));
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

        public static bool SetFileFromDialog(OpenFileDialog ofd)
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
                    FileName = Path.GetFileName(ofd.FileName);
                    SavePath = Path.GetDirectoryName(ofd.FileName)!;
                    return true;
                }
            }
            return false;
        }

    }
}
