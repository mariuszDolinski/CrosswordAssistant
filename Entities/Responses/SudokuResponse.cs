namespace CrosswordAssistant.Entities.Responses
{
    public class SudokuResponse(int[,]? grid, bool validate, string msg, int count)
    {
        public int[,]? Grid { get; set; } = grid;
        public bool ValidationResult { get; set; } = validate;
        public string Message { get; set; } = msg;
        public int SolutionsCount { get; set; } = count;
    }
}
