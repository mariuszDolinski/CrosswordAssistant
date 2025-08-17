using CrosswordAssistant.Entities;
using CrosswordAssistant.Services;
using System.Configuration;

namespace CrosswordAssistant.AppSettings
{
    public class Settings : BaseSettings
    {
        public static Dictionary<string, object> DefaultSettings { get; private set; } = [];
        public static Dictionary<string, object> SavedSettings { get; private set; } = [];
        public static Dictionary<string, object> CurrentSettings { get; private set; } = [];
      
        public static void Init()
        {
            SetDefaultSettings();
            GetSavedSettings();
            InitCurrentSettings();
            SetCurrentSettings();
        }
        private static void SetDefaultSettings()
        {
            DefaultSettings[DictPathKey] = "Słowniki";
            DefaultSettings[DictFileKey] = "slownik.txt";
            DefaultSettings[MaxResultsKey] = 500;
            DefaultSettings[PatternColorKey] = -7357297;
            DefaultSettings[UlozSamColorKey] = -7114533;
            DefaultSettings[ScrabbleColorKey] = -2968436;
            DefaultSettings[MainFormPosKey] = (int)MainFormPosition.Center;
            DefaultSettings[CaseSensitiveKey] = 0;
        }
        private static void InitCurrentSettings()
        {
            foreach (var ss in SavedSettings)
            {
                CurrentSettings.Add(ss.Key, ss.Value);
            }
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
        public static bool ExistsSettingsRequiredRestart()
        {
            foreach (var cs in CurrentSettings)
            {
                if (SavedSettings[cs.Key].ToString() != CurrentSettings[cs.Key].ToString())
                {
                    if (SettingsRequiredRestart.Contains(cs.Key)) return true;
                }
            }
            return false;
        }
        public static bool ExistsUnsavedSetting()
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
            SavedSettings[UlozSamColorKey] = ConfigurationManager.AppSettings[UlozSamColorKey] is null ? DefaultSettings[UlozSamColorKey] : int.Parse(ConfigurationManager.AppSettings[UlozSamColorKey]!);
            SavedSettings[ScrabbleColorKey] = ConfigurationManager.AppSettings[ScrabbleColorKey] is null ? DefaultSettings[ScrabbleColorKey] : int.Parse(ConfigurationManager.AppSettings[ScrabbleColorKey]!);
            SavedSettings[MainFormPosKey] = ConfigurationManager.AppSettings[MainFormPosKey] is null ? DefaultSettings[MainFormPosKey] : int.Parse(ConfigurationManager.AppSettings[MainFormPosKey]!);
            SavedSettings[CaseSensitiveKey] = ConfigurationManager.AppSettings[CaseSensitiveKey] is null ? DefaultSettings[CaseSensitiveKey] : int.Parse(ConfigurationManager.AppSettings[CaseSensitiveKey]!);
        }
        public static void ReturnToDefaultSettings()
        {
            foreach (var ss in SavedSettings)
            {
                CurrentSettings[ss.Key] = DefaultSettings[ss.Key];
            }
        }
        public static void SetCurrentSettings()
        {
            MaxResultDisplay = (int)SavedSettings[MaxResultsKey];
            CaseSensitive = (int)SavedSettings[CaseSensitiveKey] == 1;
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
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine("Zapisu ścieżki słownika do pliku konfiguracyjnego nie powiódł się. Spróbuj ponownie.");
                Logger.WriteToLog(LogLevel.Warning, ex.Message, ex.StackTrace ?? "");
            }
        }
    }
}
