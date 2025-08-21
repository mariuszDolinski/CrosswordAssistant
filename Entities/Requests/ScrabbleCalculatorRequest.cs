namespace CrosswordAssistant.Entities.Requests
{
    public class ScrabbleCalculatorRequest(string word, int doubleWordBonus, int tripleWordBonus,
        string doubleBonusLetters, string tripleBonusLetters, string blanks)
    {
        public string Word { get; set; } = word;
        public int DoubleWordBonus { get; set; } = doubleWordBonus;
        public int TripleWordBonus { get; set; } = tripleWordBonus;
        public string DoubleBonusLetters { get; set; } = doubleBonusLetters;
        public string TripleBonusLetters { get; set; } = tripleBonusLetters;
        public string Blanks { get; set; } = blanks;
    }
}
