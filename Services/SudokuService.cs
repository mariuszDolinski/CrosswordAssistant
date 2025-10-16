using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Services
{
    public class SudokuService
    {
        private readonly TableLayoutPanel Boxes;
        public static bool MultiSelectOn {  get; set; }

        public int[,] Digits { get; private set; }
        public List<Cell> CurrentSelectedCells {  get; set; }

        public SudokuService(TableLayoutPanel gridPanel)
        {
            Boxes = gridPanel;
            Digits = new int[9,9];
            CurrentSelectedCells = [];
            MultiSelectOn = false;
            InitDigits();
        }

        public void GetCurrentGrid()
        {
            for (int r = 0; r < Boxes.RowCount; r++)
            {
                for(int c = 0; c < Boxes.ColumnCount; c++)
                {
                    if (Boxes.GetControlFromPosition(c, r)!.Controls[0] is not TableLayoutPanel sudokuBoxes) continue;
                    for (int i = 0; i < sudokuBoxes.RowCount; i++)
                    {
                        for (int j = 0; j < sudokuBoxes.ColumnCount; j++)
                        {
                            if (sudokuBoxes.GetControlFromPosition(j, i) is not Label cell) continue;
                            else if (cell.Text == "") continue;
                            else Digits[i + 3 * r, j + 3 * c] = Int32.Parse(cell.Text);
                        }
                    }
                }
            }
        }
        public void UpdateSelectedCellsDigit(int value)
        {
            foreach(var cell in CurrentSelectedCells)
            {
                cell.Label!.Text = value == 0 ? "" : value.ToString();
                cell.Value = value;
                Digits[cell.X, cell.Y] = value;
            }
        }
        public int ExistsInSelectedCells(int x, int y)
        {
            foreach (var cell in CurrentSelectedCells)
            {
                if (cell.X == x && cell.Y == y) return CurrentSelectedCells.IndexOf(cell);
            }
            return -1;
        }
        public void ClearSelectedCells()
        {
            foreach( var cell in CurrentSelectedCells)
            {
                cell.Label!.BackColor = Color.Transparent;
            }
            CurrentSelectedCells.Clear();
        }

        private void InitDigits()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Digits[i, j] = 0;
                }
            }
        }
    }
}
