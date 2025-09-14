namespace CrosswordAssistant.Entities.Requests
{
    public class CustomControlsRequest(Panel cryptharitmPanel, Panel patternPanel)
    {
        public Panel CryptaritmPanel { get; set; } = cryptharitmPanel;
        public Panel PatternPanel { get; set; } = patternPanel;
    }
}
