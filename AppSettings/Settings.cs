using CrosswordAssistant.Services;
using System.Configuration;

namespace CrosswordAssistant.AppSettings
{
    public static class Settings
    {
        public const string DictionaryPathEntry = "dictionaryLocation";
        public const string DictionaryFileNameEntry = "dictionaryName";
        public const string MaxResultsEntry = "maxResultsDisplay";

        public const string DeafultSavePath = "Słowniki";
        public const string DefaultFileName = "slownik.txt";
        public const int DefaultResultDisplay = 500;

        public static string DictionaryPath { get; set; } = ConfigurationManager.AppSettings[DictionaryPathEntry] ?? DeafultSavePath;
        public static string DictionaryFileName { get; set; } = ConfigurationManager.AppSettings[DictionaryFileNameEntry] ?? DefaultFileName;
        public static int MaxResultsDisplay { get; set; } = ConfigurationManager.AppSettings[MaxResultsEntry] is null ? DefaultResultDisplay : int.Parse(ConfigurationManager.AppSettings[MaxResultsEntry]!);


        public static void SetToAppConfig(SettingsEntry entry)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[entry.Name] is not null)
                {
                    settings[entry.Name].Value = entry.Value;
                }
                else
                {
                    settings.Add(entry.Name, entry.Value);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Błąd zapisu ścieżki słownika do pliku konfiguracyjnego. Spróbuj ponownie.");
            }
        }
    }
}
