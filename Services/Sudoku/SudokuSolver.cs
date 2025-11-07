using CrosswordAssistant.Entities.Responses;
using System.Runtime.CompilerServices;

namespace CrosswordAssistant.Services.Sudoku
{
    public class SudokuSolver
    {
        private readonly int[] Rows = new int[9];
        private readonly int[] Columns = new int[9];
        private readonly int[] Boxes = new int[9];
        private readonly List<(int r, int c)> EmptyCells = [];

        public string ValidateSudoku(int[,] board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    int v = board[r, c];
                    if (v == 0)
                    {
                        EmptyCells.Add((r, c));
                        continue;
                    }
                    if (v < 1 || v > 9) return "Błędne cyfry sudoku";

                    int bit = 1 << v;
                    int bIdx = r / 3 * 3 + c / 3; //numer boxa od 0 do 8
                    if ((Rows[r] & bit) != 0 || (Columns[c] & bit) != 0 || (Boxes[bIdx] & bit) != 0)
                        return $"Wiersz, kolumna lub box zawieraja powtarzającą się cyfrę {v}";
                    Rows[r] |= bit;
                    Columns[c] |= bit;
                    Boxes[bIdx] |= bit;
                }
            }
            if (EmptyCells.Count > 64) return "Wpisz conajmniej 17 poprawnych cyfr";
            return "";
        }
    }
}
