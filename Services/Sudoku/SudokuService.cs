using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using System.Drawing.Drawing2D;

namespace CrosswordAssistant.Services.Sudoku
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
                            else Digits[i + 3 * r, j + 3 * c] = int.Parse(cell.Text);
                        }
                    }
                }
            }
        }

        public void FillCurrentGrid(int[,] board, FillGridMode mode)
        {
            for (int r = 0; r < Boxes.RowCount; r++)
            {
                for (int c = 0; c < Boxes.ColumnCount; c++)
                {
                    if (Boxes.GetControlFromPosition(c, r)!.Controls[0] is not TableLayoutPanel sudokuBoxes) continue;
                    for (int i = 0; i < sudokuBoxes.RowCount; i++)
                    {
                        for (int j = 0; j < sudokuBoxes.ColumnCount; j++)
                        {
                            int row = i + 3 * r, col = j + 3 * c;
                            if (sudokuBoxes.GetControlFromPosition(j, i) is not Label cell) continue;
                            else if (board[row, col] == 0)
                            {
                                cell.Text = "";                              
                                Digits[row, col] = 0;
                            }
                            else 
                            {
                                if (mode == FillGridMode.Full)
                                {
                                    if (board[row, col] != Digits[row, col])
                                        cell.ForeColor = Color.CornflowerBlue;
                                }
                                cell.Text = board[row, col].ToString();
                                Digits[row, col] = board[row, col];
                            }                          
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
