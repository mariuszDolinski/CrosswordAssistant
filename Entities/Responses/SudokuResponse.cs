namespace CrosswordAssistant.Entities.Responses
{
    public class SudokuResponse(int[,]? grid, bool validate, string msg)
    {
        public int[,]? SolvedGrid { get; set; } = grid;
        public bool ValidateResult { get; set; } = validate;
        public string Message { get; set; } = msg;
    }
}
