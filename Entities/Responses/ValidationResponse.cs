namespace CrosswordAssistant.Entities.Responses
{
    public class ValidationResponse(bool result, string msg)
    {
        public bool Result { get; set; } = result;
        public string Message { get; set; } = msg;
    }
}
