using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.LinkLabel;

namespace CrosswordAssistant.Services.Sudoku
{
    public class SudokuService
    {
        private readonly TableLayoutPanel Boxes;
        private readonly Label[,] CellLabels;
        public static bool MultiSelectOn {  get; set; }

        public int[,] Digits { get; private set; }
        public List<Cell> CurrentSelectedCells {  get; set; }

        public SudokuService(TableLayoutPanel gridPanel)
        {
            Boxes = gridPanel;
            Digits = new int[9,9];
            CellLabels = new Label[9,9];
            CurrentSelectedCells = [];
            MultiSelectOn = false;
            InitDigits();
            InitCellLabels();
        }

        public void GetCurrentGrid()
        {
            for (int r = 0; r < 9; r++)
            {
                for(int c = 0; c < 9; c++)
                {
                    if (CellLabels[r, c].Text == "") continue;
                    else Digits[r, c] = int.Parse(CellLabels[r, c].Text);
                }
            }
        }

        public void FillCurrentGrid(int[,] board, SudokuMode mode)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r, c] == 0)
                    {
                        CellLabels[r, c].Text = "";                              
                        Digits[r, c] = 0;
                    }
                    else 
                    {
                        if (mode == SudokuMode.Full)
                        {
                            if (board[r, c] != Digits[r, c])
                            {
                                CellLabels[r, c].ForeColor = Color.CornflowerBlue;
                            }
                        }
                        else if (mode == SudokuMode.Selection)
                        {
                            if (ExistsInSelectedCells(r, c) == -1) continue;
                            else if (board[r, c] != Digits[r, c])
                            {
                                CellLabels[r, c].ForeColor = Color.CornflowerBlue;
                            }
                        }
                        CellLabels[r, c].Text = board[r, c].ToString();
                        Digits[r, c] = board[r, c];
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
        public void ClearGrid(bool digits, bool colors, bool selection)
        {
            for (int r = 0; r < 9; r++)
            {
                for(int  c = 0; c < 9; c++)
                {
                    if(digits)
                    {
                        Digits[r, c] = 0;
                        CellLabels[r, c].Text = "";
                    }
                    if(colors) CellLabels[r, c].ForeColor = SystemColors.ControlText;
                    if(selection) CellLabels[r, c].BackColor = Color.Transparent;
                }
            }
            if (selection)
            {
                CurrentSelectedCells.Clear();
                MultiSelectOn = false;
            }           
        }
        public bool IsAnyCellSelected() => CurrentSelectedCells.Count != 0;
        public bool IsAnyEmptyCellSelected()
        {
            if(!IsAnyCellSelected()) return false;
            foreach (var cell in CurrentSelectedCells)
            {
                if (cell.Value == 0) return true;
            }
            return false;
        }
        public List<string> GetGridToTxt()
        {
            List<string> result = [];
            string line;
            for (int r = 0; r < 9; r++)
            {
                line = string.Empty;
                for (int c = 0; c < 9; c++)
                {
                    line += Digits[r, c].ToString();
                }
                result.Add(line);
            }
            return result;
        }
        public bool IsAnyCellNotEmpty()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (Digits[r, c] > 0) return true;
                }
            }
            return false;
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
        private void InitCellLabels()
        {
            for(int r = 0; r < 9; r++)
                for(int c = 0;  c < 9; c++)
                    CellLabels[r, c] = new Label();

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
                            CellLabels[row, col] = cell;
                        }
                    }
                }
            }
        }
    }
}
