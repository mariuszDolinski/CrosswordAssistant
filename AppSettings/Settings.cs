using CrosswordAssistant.Services;
using System.Configuration;

namespace CrosswordAssistant.AppSettings
{
    public class Settings
    {
        public static Dictionary<string, object> DefaultSettings { get; private set; } = [];
        public static Dictionary<string, object> SavedSettings { get; private set; } = [];
        public static Dictionary<string, object> CurrentSettings { get; private set; } = [];


        public const string DictPathKey = "dictionaryLocation";
        public const string DictFileKey = "dictionaryName";
        public const string MaxResultsKey = "maxResultsDisplay";
        public const string PatternColorKey = "patternColor";

        //public const string DeafultSavePath = "Słowniki";
        //public const string DefaultFileName = "slownik.txt";
        //public const int DefaultResultDisplay = 500;

        //public static string DictionaryPath { get; set; } = ConfigurationManager.AppSettings[DictPathKey] ?? DeafultSavePath;
        //public static string DictionaryFileName { get; set; } = ConfigurationManager.AppSettings[DictFileKey] ?? DefaultFileName;
        //public static int MaxResultsDisplay { get; set; } = ConfigurationManager.AppSettings[MaxResultsKey] is null ? DefaultResultDisplay : int.Parse(ConfigurationManager.AppSettings[MaxResultsKey]!);

        public static void Init()
        {
            SetDefaultSettings();
            GetSavedSettings();
            InitCurrentSettings();
        }
        private static void SetDefaultSettings()
        {
            DefaultSettings[DictPathKey] = "Słowniki";
            DefaultSettings[DictFileKey] = "slownik.txt";
            DefaultSettings[MaxResultsKey] = 500;
            DefaultSettings[PatternColorKey] = -7357297;
        }
        public static void CancelCurrentSettings()
        {
            foreach (var cs in CurrentSettings)
            {
                CurrentSettings[cs.Key] = SavedSettings[cs.Key];
            }
        }
        public static void SaveCurrentSettings()
        {
            foreach (var cs in CurrentSettings)
            {
                SavedSettings[cs.Key] = CurrentSettings[cs.Key];
            }
        }
        public static bool ExistsUnsavedSeting()
        {
            foreach (var cs in CurrentSettings)
            {
                if(SavedSettings[cs.Key].ToString() != CurrentSettings[cs.Key].ToString())
                {
                    return true;
                }
            }

            return false;
        }
        public static void GetSavedSettings()
        {
            SavedSettings[DictPathKey] = ConfigurationManager.AppSettings[DictPathKey] ?? DefaultSettings[DictPathKey];
            SavedSettings[DictFileKey]= ConfigurationManager.AppSettings[DictFileKey] ?? DefaultSettings[DictFileKey];
            SavedSettings[MaxResultsKey] = ConfigurationManager.AppSettings[MaxResultsKey] is null ? DefaultSettings[MaxResultsKey] : int.Parse(ConfigurationManager.AppSettings[MaxResultsKey]!);
            SavedSettings[PatternColorKey] = ConfigurationManager.AppSettings[PatternColorKey] is null ? DefaultSettings[PatternColorKey] : int.Parse(ConfigurationManager.AppSettings[PatternColorKey]!);
        }
        public static void ReturnToDefaultSettings()
        {
            foreach (var ss in SavedSettings)
            {
                CurrentSettings[ss.Key] = DefaultSettings[ss.Key];
            }
        }
        private static void InitCurrentSettings()
        {
            foreach (var ss in SavedSettings)
            {
                CurrentSettings.Add(ss.Key, ss.Value);
            }
        }

        public static void SaveSettingToAppConfig()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                foreach (var ss in SavedSettings) 
                {
                    if (settings[ss.Key] is not null)
                    {
                        settings[ss.Key].Value = SavedSettings[ss.Key].ToString();
                    }
                    else
                    {
                        settings.Add(ss.Key, SavedSettings[ss.Key].ToString());
                    }
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
