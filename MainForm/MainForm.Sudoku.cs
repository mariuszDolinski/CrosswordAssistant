using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Searches;
using CrosswordAssistant.Services;
using CrosswordAssistant.Services.Sudoku;

namespace CrosswordAssistant
{
    public partial class MainForm
    {
        private async void SolveSudokuBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is not Button btn) return;
                SudokuMode mode = SudokuMode.None;
                if (btn.TabIndex == 201) mode = SudokuMode.Full;
                else if (btn.TabIndex == 202) mode = SudokuMode.Selection;
                else if (btn.TabIndex == 203) mode = SudokuMode.Uniqueness;
                await SearchForSudokuSolution(mode);
            }
            catch (Exception ex)
            {
                labelSudokuSolveInfo.Text = "Znalezionych rozwiązań: 0";
                IsSearchPending(false);
                MessageBox.Show("Podczas próby rozwiązania sudoku wystąpił błąd. Sprawdź szczegóły w logu aplikacji.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }
        private void ValidateSudokuBtn_Click(object sender, EventArgs e)
        {
            SudokuSolver sSolver = new(SudokuMode.None);
            var msg = sSolver.ValidateSudoku(_sudokuService.Digits, SudokuValidationMode.Full);
            if (msg.Length == 0)
            {
                MessageBox.Show("Poprawny diagram sudoku");
                labelSudokuSolveInfo.Text = "Diagram sudoku nie zwaiera błędów.";
            }
            else
            {
                MessageBox.Show(msg);
                labelSudokuSolveInfo.Text = msg;
            }
        }
        private void ClearSudokuGridBtn_Click(object sender, EventArgs e)
        {
            _sudokuService.ClearGrid(checkBoxClearDigits.Checked, checkBoxClearColors.Checked,
                checkBoxClearSelection.Checked);
            if (checkBoxClearDigits.Checked) labelSudokuSolveInfo.Text = "Kliknij odpowiedni przycisk, aby rozpocząć...";
        }
        private void SudokuCell_MouseDown(object sender, MouseEventArgs e)
        {
            SudokuService.MultiSelectOn = true;
            var lbl = sender as Label;
            if (lbl is not null) lbl.Capture = false;
            SudokuSelectedCellAction(sender, e);
        }
        private void SudokuCell_MouseUp(object sender, MouseEventArgs e)
        {
            SudokuService.MultiSelectOn = false;
        }
        private void SudokuCell_MouseEnter(object sender, EventArgs e)
        {
            if (SudokuService.MultiSelectOn)
            {
                if (sender is not Label cellLabel) return;
                int x = cellLabel.TabIndex / 10;
                int y = cellLabel.TabIndex % 10;
                var selectedCellIndex = _sudokuService.ExistsInSelectedCells(x, y);
                if (selectedCellIndex < 0)
                {
                    cellLabel.BackColor = Color.LightBlue;
                    int value = cellLabel.Text.Length == 0 ? 0 : int.Parse(cellLabel.Text);
                    _sudokuService.CurrentSelectedCells.Add(new Cell(x, y, value, cellLabel));
                }
            }
        }
        private void SaveSudokuToFileBtn_Click(object sender, EventArgs e)
        {
            SudokuSolver sSolver = new(SudokuMode.None);
            var msg = sSolver.ValidateSudoku(_sudokuService.Digits, SudokuValidationMode.Partial);
            if (msg != null && msg.Length > 0)
            {
                var response = MessageBox.Show("Diagram sudoku zawiera błędy. Czy nadal chcesz go zapisać?", "Błędny diagram", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.No) return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var gridText = _sudokuService.GetGridToTxt();
                    File.WriteAllLines(saveFileDialog.FileName, gridText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy próbie zapisu diagramu sudoku do pliku. Sprawdź szczegóły w logu.");
                    Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
                }
            }
        }
        private void LoadSudokuFromFileBtn_Click(object sender, EventArgs e)
        {
            if (_sudokuService.IsAnyCellNotEmpty())
            {
                var response = MessageBox.Show("Ta czynność spowoduje wyczyszczenie obecnego diagramu. Czy chcesz kontynuować?",
                    "Diagram nie jest pusty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.No) return;
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var lines = File.ReadAllLines(openFileDialog.FileName);
                    var response = FileService.IsFileInSudokuFormat(lines);
                    if (!response.ValidationResult)
                    {
                        MessageBox.Show(response.Message, "Zły format pliku", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    _sudokuService.ClearGrid(true, true, true);
                    _sudokuService.FillCurrentGrid(response.Grid!, SudokuMode.None);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy ładowaniu diagramu sudoku z pliku. Sprawdź szczegóły w logu.");
                    Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
                }
            }
        }

        private async Task SearchForSudokuSolution(SudokuMode mode)
        {
            if (DictionaryService.PendingDictionaryLoading || Search.IsPending)
            {
                MessageBox.Show("Trwa inne wyszukiwanie lub ładowanie nowego słownika. Spróbuj ponownie później", "Inna operacja w toku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IsSearchPending(true);

            var response = await ExecuteSudokuSolverAsync(mode);
            if (response.ValidationResult)
            {
                var msg = string.Empty;
                if (mode == SudokuMode.Uniqueness)
                {
                    if (response.SolutionsCount > 1)
                    {
                        msg = "Sudoku nie jest unikalne, posiada więcej niż jedno rozwiązanie.";
                    }
                    else
                    {
                        msg = "Sudoku jest unikalne, posiada dokładnie jedno rozwiązanie.";
                    }
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelSudokuSolveInfo.Text = msg;
                }
                else
                {
                    if (mode == SudokuMode.Selection && !_sudokuService.IsAnyEmptyCellSelected())
                    {
                        MessageBox.Show("Najpierw zaznacz jakieś puste komórki", "Brak zaznaczenia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (response.SolutionsCount > 1)
                    {
                        MessageBox.Show("Podane sudoku nie jest unikalne. Wyświetlam przykładowe rozwiązanie.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    _sudokuService.FillCurrentGrid(response.Grid!, mode);
                    labelSudokuSolveInfo.Text = $"Znalezionych rozwiązań: {response.SolutionsCount}";
                }
            }
            else
            {
                MessageBox.Show(response.Message, "Niepoprawne sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelSudokuSolveInfo.Text = "Znalezionych rozwiązań: 0";
            }
            IsSearchPending(false);
            SetMode(tabControl.SelectedIndex);
        }
        private async Task<SudokuResponse> ExecuteSudokuSolverAsync(SudokuMode mode)
        {
            labelSudokuSolveInfo.Text = mode == SudokuMode.Uniqueness ? "Sprawdzam unikalność..." : "Szukam rozwiązań...";
            SudokuSolver sSolver = new(mode);
            var response = await Task.Run(() => sSolver.SolveSudoku(_sudokuService.Digits));
            return response;
        }
        private void SudokuKeyDownHandle(KeyEventArgs e)
        {
            string value = string.Empty;
            if (e.KeyCode == Keys.ControlKey) _isCtrlPressedInSudoku = true;
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) _sudokuService.UpdateSelectedCellsDigit(0);
            if (_sudokuService.CurrentSelectedCells.Count > 0)
            {
                if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
                {
                    value = e.KeyCode.ToString()[1].ToString();
                }
                else if (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9)
                {
                    value = e.KeyCode.ToString()[6].ToString();
                }
            }
            if (value.Length > 0 && int.TryParse(value, out int correctValue))
            {
                _sudokuService.UpdateSelectedCellsDigit(correctValue);
            }
            else if (value.Length > 0)
            {
                MessageBox.Show("Coś poszło nie tak. Sprawdź log aplikacji");
                Logger.WriteToLog(LogLevel.Error, $"Błąd konwersji wartości {e.KeyCode.ToString()} na cyfrę");
            }
        }
        private void SudokuSelectedCellAction(object sender, EventArgs e)
        {
            if (sender is not Label cellLabel) return;
            int x = cellLabel.TabIndex / 10;
            int y = cellLabel.TabIndex % 10;
            var selectedCellIndex = _sudokuService.ExistsInSelectedCells(x, y);
            if (selectedCellIndex >= 0)
            {
                cellLabel.BackColor = Color.Transparent;
                _sudokuService.CurrentSelectedCells.RemoveAt(selectedCellIndex);
            }
            else
            {
                cellLabel.BackColor = Color.LightBlue;
                if (!_isCtrlPressedInSudoku) _sudokuService.ClearSelectedCells();
                int value = cellLabel.Text.Length == 0 ? 0 : int.Parse(cellLabel.Text);
                _sudokuService.CurrentSelectedCells.Add(new Cell(x, y, value, cellLabel));
            }
        }
    }
}
