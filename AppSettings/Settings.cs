using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Services;
using System.Configuration;
using System.Security.AccessControl;

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
            DefaultSettings[CryptharitmColorKey] = -7114533;
            DefaultSettings[ScrabbleColorKey] = -2968436;
            DefaultSettings[MainFormPosKey] = (int)MainFormPosition.Center;
            DefaultSettings[CaseSensitiveKey] = 0;
            DefaultSettings[LogLevelKey] = (int)Logger.LogLevel;
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
            SavedSettings[CryptharitmColorKey] = ConfigurationManager.AppSettings[CryptharitmColorKey] is null ? DefaultSettings[CryptharitmColorKey] : int.Parse(ConfigurationManager.AppSettings[CryptharitmColorKey]!);
            SavedSettings[ScrabbleColorKey] = ConfigurationManager.AppSettings[ScrabbleColorKey] is null ? DefaultSettings[ScrabbleColorKey] : int.Parse(ConfigurationManager.AppSettings[ScrabbleColorKey]!);
            SavedSettings[MainFormPosKey] = ConfigurationManager.AppSettings[MainFormPosKey] is null ? DefaultSettings[MainFormPosKey] : int.Parse(ConfigurationManager.AppSettings[MainFormPosKey]!);
            SavedSettings[CaseSensitiveKey] = ConfigurationManager.AppSettings[CaseSensitiveKey] is null ? DefaultSettings[CaseSensitiveKey] : int.Parse(ConfigurationManager.AppSettings[CaseSensitiveKey]!);
            SavedSettings[LogLevelKey] = ConfigurationManager.AppSettings[LogLevelKey] is null ? DefaultSettings[LogLevelKey]: int.Parse(ConfigurationManager.AppSettings[LogLevelKey]!);
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
            Logger.LogLevel = (LogLevel)SavedSettings[LogLevelKey];
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
                MessageBox.Show("Zapis ustawień do pliku konfiguracyjnego nie powiódł się. Spróbuj ponownie.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.WriteToLog(LogLevel.Warning, ex.Message, ex.StackTrace ?? "");
            }
        }
        public static void ClearAppConfig()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                bool isRemoved = false;
                foreach(var cfk in settings.AllKeys)
                {
                    if (cfk is null) continue;
                    if (!DefaultSettings.ContainsKey(cfk))
                    {
                        settings.Remove(cfk);
                        isRemoved = true;
                    }
                }
                if (isRemoved)
                {
                    configFile.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    MessageBox.Show("Zbędne wpisy w pliku konfiguracyjnym zostały usunięte.", "Czyszczenie pliku konfiguracyjnego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nie znalazłem niepotrzebnych wpisów. Plik konfiguracyjny nie został zmieniony.", "Czyszczenie pliku konfiguracyjnego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("Operacja nie powiodła się. Spróbuj ponownie.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.WriteToLog(LogLevel.Warning, ex.Message, ex.StackTrace ?? "");
            }
        }
    }
}
