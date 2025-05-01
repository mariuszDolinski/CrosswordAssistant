namespace CrosswordAssistant.AppSettings
{
    public class SettingsEntry(string name, string value)
    {
        public string Name { get; set; } = name;
        public string Value { get; set; } = value;
    }
}
