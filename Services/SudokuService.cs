using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Services
{
    public class SudokuService
    {
        private readonly TableLayoutPanel Boxes;
        public static Cell CurrentCellNull { get; private set; }

        public int[,] Digits { get; private set; }
        public Cell CurrentCell {  get; set; }

        public SudokuService(TableLayoutPanel gridPanel)
        {
            Boxes = gridPanel;
            Digits = new int[9,9];
            CurrentCellNull = new Cell(-1, -1, -1, null);
            CurrentCell = CurrentCellNull;
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
        public void UpdateCurrentCellDigit(int value)
        {
            CurrentCell.Label!.Text = value == 0 ? "" : value.ToString();
            CurrentCell.Value = value;
            Digits[CurrentCell.X, CurrentCell.Y] = value;
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
