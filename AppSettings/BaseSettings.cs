namespace CrosswordAssistant.AppSettings
{
    public class BaseSettings
    {
        public static int MaxResultDisplay { get; set; }
        public static bool CaseSensitive { get; set; }

        public const string LogLevelKey = "logLevel";
        public const string DictPathKey = "dictionaryLocation";
        public const string DictFileKey = "dictionaryName";
        public const string MaxResultsKey = "maxResultsDisplay";
        public const string PatternColorKey = "patternColor";
        public const string CryptharitmColorKey = "cryptharitmColor";
        public const string ScrabbleColorKey = "scrabbleColor";
        public const string MainFormPosKey = "mainFormPosition";
        public const string CaseSensitiveKey = "caseSensitive";

        protected readonly static List<string> SettingsRequiredRestart =
        [
            "dictionaryLocation", "dictionaryName",
            "patternColor", "cryptharitmColor", "scrabbleColor"
        ];
    }
}
