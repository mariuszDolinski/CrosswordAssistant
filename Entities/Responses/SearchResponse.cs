namespace CrosswordAssistant.Entities.Responses
{
    public class SearchResponse(List<string> results, bool completed, string msg)
    {
        public List<string> SearchResults { get; set; } = results;
        public bool Completed { get; set; } = completed;
        public string Message { get; set; } = msg;
    }
}
