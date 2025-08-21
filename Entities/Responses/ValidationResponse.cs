namespace CrosswordAssistant.Searches
{
    public class ValidateResponse(bool result, string msg)
    {
        public bool Result { get; set; } = result;
        public string Message { get; set; } = msg;
    }
}
