using CrosswordAssistant.Entities.Responses;
using System.Runtime.CompilerServices;

namespace CrosswordAssistant.Services.Sudoku
{
    public class SudokuSolver
    {
        private readonly int[] Rows;
        private readonly int[] Columns;
        private readonly int[] Boxes;
        private readonly List<(int r, int c)> EmptyCells;

        public SudokuSolver()
        {
            Rows = new int[9]; Columns = new int[9]; Boxes = new int[9]; EmptyCells = [];
        }

        public string ValidateSudoku(int[,] board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    int val = board[r, c];
                    if (val == 0)
                    {
                        EmptyCells.Add((r, c));
                        continue;
                    }
                    if (val < 1 || val > 9) return "Błędne cyfry sudoku";

                    int bit = 1 << val;
                    int boxIndex = r / 3 * 3 + c / 3; //numer boxa od 0 do 8
                    if ((Rows[r] & bit) != 0 || (Columns[c] & bit) != 0 || (Boxes[boxIndex] & bit) != 0)
                        return $"Wiersz, kolumna lub kwadrat 3x3 zawieraja powtarzającą się cyfrę {val}";
                    Rows[r] |= bit;
                    Columns[c] |= bit;
                    Boxes[boxIndex] |= bit;
                }
            }
            if (EmptyCells.Count > 64) return "Wpisz conajmniej 17 poprawnych cyfr";
            return "";
        }

        public SudokuResponse SolveSudoku(int[,] board)
        {
            if (board == null || board.GetLength(0) != 9 || board.GetLength(1) != 9)
                return new SudokuResponse(null, false, "Błędny rozmiar diagramu sudoku.");

            var validateResult = ValidateSudoku(board);
            if (validateResult.Length > 0)
                return new SudokuResponse(null, false, validateResult);

            int emptiesCount = EmptyCells.Count;
            var tempBoard = Utilities.CopyArray(board, 9, 9);

            bool result = DepthFirstSearch(emptiesCount, tempBoard);
            if (result) return new SudokuResponse(board, true, "");
            else return new SudokuResponse(null, false, "Nie mogłem znaleźć rozwiązania.");
        }

        bool DepthFirstSearch(int remaining, int[,] board)
        {
            if (remaining == 0) return true;

            // wybieramy komórkę z najmniejszą ilością mozliwych cyfr
            int bestIndex = -1;
            int bestCount = 10;
            int bestMask = 0;
            for (int i = 0; i < EmptyCells.Count; i++)
            {
                var (r, c) = EmptyCells[i];
                if (board[r, c] != 0) continue; // już wypełnione w rekursji

                int boxIndex = r / 3 * 3 + c / 3;
                int usedDigits = Rows[r] | Columns[c] | Boxes[boxIndex];
                int availableDigits = ~usedDigits & 0x3FE; // bity 1..9 (0x3FE = 1111111110)
                if (availableDigits == 0) return false; // brak możliwych cyfr

                // policz liczbę dostępnych cyfr (licz bitów)
                int count = CountBits(availableDigits);
                if (count < bestCount)
                {
                    bestCount = count;
                    bestIndex = i;
                    bestMask = availableDigits;
                    if (count == 1) break;
                }
            }

            if (bestIndex == -1) return false; 

            var (br, bc) = EmptyCells[bestIndex];
            int bBoxIndex = br / 3 * 3 + bc / 3;

            for (int mask = bestMask; mask != 0; mask &= mask - 1)//zabieramy pierwszą jedynkę z prawej (amieniamy na zero)
            {
                int pickBit = mask & -mask; // najmłodszy ustawiony bit, pierwsze 1 od prawej
                int digit = BitToDigit(pickBit);

                board[br, bc] = digit;
                Rows[br] |= pickBit;
                Columns[bc] |= pickBit;
                Boxes[bBoxIndex] |= pickBit;

                if (DepthFirstSearch(remaining - 1, board)) return true;

                board[br, bc] = 0;
                Rows[br] &= ~pickBit;
                Columns[bc] &= ~pickBit;
                Boxes[bBoxIndex] &= ~pickBit;
            }

            return false;
        }

        /// <summary>
        /// Zamieniamy liczbę, ktra w zapisie binarnym ma tylko jedną 1 na liczbę całkowitą
        /// </summary>
        /// <param name="bit">ciąg zerojedynkowy z jedną 1</param>
        /// <returns></returns>
        private static int BitToDigit(int bit)
        {
            int d = 0;
            while ((bit >>= 1) != 0) d++;
            return d;
        }

        // Pomocnicze: liczy liczbę jedynek w masce (popcount)
        private static int CountBits(int x)
        {
            int cnt = 0;
            while (x != 0)
            {
                x &= x - 1;
                cnt++;
            }
            return cnt;
        }
    }
}
