namespace CrosswordAssistant.AppSettings
{
    public class SettingsEntry(string name, string value, string defaultValue)
    {
        public string Name { get; set; } = name;
        public string Value { get; set; } = value;
        public string DefaultValue { get; set; } = defaultValue;
    }
}
