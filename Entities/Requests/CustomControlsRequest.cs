namespace CrosswordAssistant.Entities.Requests
{
    public class CustomControlsRequest(Panel cryptharitmPanel, Panel patternPanel, int dpi)
    {
        public Panel CryptaritmPanel { get; set; } = cryptharitmPanel;
        public Panel PatternPanel { get; set; } = patternPanel;
        public int DeviceDpi { get; set; } = dpi;
    }
}
