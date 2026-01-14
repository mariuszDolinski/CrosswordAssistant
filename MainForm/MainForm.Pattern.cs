using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;
using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Searches;
using CrosswordAssistant.Services;

namespace CrosswordAssistant
{
    public partial class MainForm
    {
        private async void SearchPattern_Click(object sender, EventArgs e)
        {
            try
            {
                await MakeSearch(0);
            }
            catch (Exception ex)
            {
                labelPatternResultsInfo.Text = "Znalezionych dopasowań: 0";
                IsSearchPending(false);
                MessageBox.Show("Błąd wyszukiwania. Sprawdź szczegóły w logu aplikacji.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }
        private async void RandomWord_Click(object sender, EventArgs e)
        {
            try
            {
                await MakeSearch(1);
            }
            catch (Exception ex)
            {
                labelPatternResultsInfo.Text = "Znalezionych dopasowań: 0";
                IsSearchPending(false);
                MessageBox.Show("Błąd wyszukiwania. Sprawdź szczegóły w logu aplikacji.");
                Logger.WriteToLog(LogLevel.Error, ex.Message, ex.StackTrace ?? "");
            }
        }
        private void RadioButtonMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPatternMode.Checked)
            {
                OnModeChanged(Messages.PatternModeMessage, false);
            }
            else if (radioAnagramMode.Checked)
            {
                OnModeChanged(Messages.AnagramModeMessage, false);
            }
            else if (radioMetagramMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage, false);
            }
            else if (radioPM1Mode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage, false);
            }
            else if (radioSubWordMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage, false);
            }
            else if (radioSuperWordMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage, false);
            }
            else if (radioStenoAnagramMode.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage, false);
            }
            else if (radioWordInWord.Checked)
            {
                OnModeChanged(Messages.PatternModeMessage, false);
            }
            else if (radioUlozSamMode.Checked)
            {
                OnModeChanged(Messages.UlozSamModeMessage, true);
            }
            else if (radioWordsFromWord.Checked)
            {
                OnModeChanged(Messages.MetagramModeMessage, false);
            }
        }
        private void RadioLength_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLength.Checked)
            {
                textBoxLength.Enabled = true;
            }
            else
            {
                textBoxLength.Enabled = false;
            }
        }
        private void ActiveFilters_CheckedChanged(object sender, EventArgs e)
        {
            var obj = (CheckBox)sender;
            var container = (GroupBox?)obj.Parent;
            if (container == null) return;
            var radioButtons = container.Controls.OfType<RadioButton>().ToList();
            var textBox = container.Controls.OfType<TextBox>().ToList();
            var checkBoxes = container.Controls.OfType<CheckBox>().ToList();
            var checkBoxActive = checkBoxes.First(c => c.Text == "Aktywny");
            var checkBoxOthers = checkBoxes.FindAll(c => c.Text != "Aktywny").ToList();


            labelCurrentPatternLen.Text = textBoxPattern.Text.Length.ToString();
            FormService.FilterChecked(checkBoxActive, checkBoxOthers, textBox, radioButtons);
            if (!checkBoxActive.Checked) textBoxPattern.Focus();
        }
        private void SelectedFilters_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radio)
            {
                var container = (GroupBox?)radio.Parent;
                if (container == null) return;
                var textBoxes = container.Controls.OfType<TextBox>().ToList();
                foreach (var c in textBoxes) c.Focus();
            }

            if (sender is CheckBox cb)
            {
                var container = (GroupBox?)cb.Parent;
                if (container == null) return;
                var textBoxes = container.Controls.OfType<TextBox>().ToList();
                foreach (var c in textBoxes) c.Focus();
            }
        }
        private void CheckBoxLength_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLength.Checked)
            {
                SetLengthControlsEnabled(true);
                radioLength.Checked = true;
            }
            else
            {
                SetLengthControlsEnabled(false);
                radioLength.Checked = false;
                radioLengthInterval.Checked = false;
                textBoxLength.Text = "";
                textBoxLengthFrom.Text = "";
                textBoxLengthTo.Text = "";
            }
        }
        private void TextBoxLengthInterval_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLengthInterval.Checked)
            {
                textBoxLengthFrom.Enabled = true;
                textBoxLengthTo.Enabled = true;
            }
            else
            {
                textBoxLengthFrom.Enabled = false;
                textBoxLengthTo.Enabled = false;
            }
        }
        private void SearchGoogle_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                Utilities.SearchInWeb(WebSearch.Google, searchPhrase);
        }
        private void SearchSJP_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                Utilities.SearchInWeb(WebSearch.Sjp, searchPhrase);
        }
        private void SearchBing_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                Utilities.SearchInWeb(WebSearch.Bing, searchPhrase);
        }
        private void DuckDuckGoSearch_MenuClick(object sender, EventArgs e)
        {
            string searchPhrase = GetSelectedResult();
            if (searchPhrase.Length > 0)
                Utilities.SearchInWeb(WebSearch.DuckDuckGo, searchPhrase);
        }

        private async Task<SearchResponse> ExecutePatternSearchAsync()
        {
            string pattern = textBoxPattern.Text.Trim();
            if (!BaseSettings.CaseSensitive) pattern = pattern.ToLower();
            labelPatternResultsInfo.Text = "Szukam dopasowań...";
            var search = SearchFactory.CreateSearch(Search.Mode);
            List<string> matches;
            if (checkBoxLength.Checked && pattern.Length == 0)
            {
                matches = DictionaryService.CurrentDictionary;
            }
            else
            {
                var validateResponse = search.ValidatePattern(pattern);
                if (!validateResponse.Result)
                {
                    return new SearchResponse([], false, validateResponse.Message);
                }
                matches = await Task.Run(() => search.SearchMatches(pattern));
            }

            //await Task.Delay(20000);
            matches = ApplyFilters(matches);
            labelPatternResultsInfo.Text = "Znalezionych dopasowań: " + matches.Count;
            return new SearchResponse(matches, true, "");
        }
        private async Task<SearchResponse> ExecuteUlozSamSearchAsync()
        {
            string pattern = textBoxPattern.Text.Trim();
            labelPatternResultsInfo.Text = "Szukam dopasowań...";
            var search = SearchFactory.CreateSearch(Search.Mode);
            var validateResponse = search.ValidatePattern(pattern);
            if (!validateResponse.Result)
            {
                return new SearchResponse([], false, validateResponse.Message);
            }

            var groups = _customControls.ConvertUlozSamGroupsToArray();
            if (groups == null) return new SearchResponse([], false, "Litery w grupach nie powinny się powtarzać");
            foreach (string group in groups)
            {
                pattern += "|" + group.ToLower();
            }

            List<string> matches = await Task.Run(() => search.SearchMatches(pattern));
            labelPatternResultsInfo.Text = "Znalezionych dopasowań: " + matches.Count;
            return new SearchResponse(matches, true, "");
        }
        private List<string> ApplyFilters(List<string> words)
        {
            List<string> results = words;
            if (checkBoxLength.Checked)
            {
                int min = 0, max = 0;
                if (radioLength.Checked)
                {
                    min = FormService.TextBoxPositiveNumber(textBoxLength);
                    if (min <= 0)
                    {
                        MessageBox.Show("Błędna długość. Wpisz poprawne liczby.", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return [];
                    }
                    else
                    {
                        results = [.. results.Where(w => w.Length == min)];
                    }
                }
                else
                {
                    min = FormService.TextBoxPositiveNumber(textBoxLengthFrom);
                    max = FormService.TextBoxPositiveNumber(textBoxLengthTo);
                    if (min == -1 || max == -1 || (max > 0 && min > max) || (min == 0 && max == 0))
                    {
                        MessageBox.Show("Błędna długość. Wpisz poprawne liczby.", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return [];
                    }
                    else
                    {
                        if (min != 0 && max != 0)
                            results = [.. results.Where(w => w.Length >= min && w.Length <= max)];
                        else if (min == 0)
                            results = [.. results.Where(w => w.Length <= max)];
                        else
                            results = [.. results.Where(w => w.Length >= min)];
                    }
                }
            }
            if (checkBoxBeginsWithActive.Checked)
            {
                results = ApplyStartWithFilter(results);
            }
            if (checkBoxEndsWithActive.Checked)
            {
                results = ApplyEndsWithFilter(results);
            }
            if (checkBoxContainsActive.Checked)
            {
                results = ApplyContainsFilters(results);
            }
            return results;
        }
        private List<string> ApplyStartWithFilter(List<string> results)
        {
            if (radioButtonBeginsWith.Checked && textBoxBeginsWith.Text.Length > 0)
            {
                return [.. results.Where(w => w.BeginsWithAny(textBoxBeginsWith.Text))];
            }
            else if (radioButtonBeginWithNot.Checked && textBoxBeginsWith.Text.Length > 0)
            {
                return [.. results.Where(w => w.NotBeginsWithAll(textBoxBeginsWith.Text))];
            }
            else
            {
                return [];
            }
        }
        private List<string> ApplyEndsWithFilter(List<string> results)
        {
            if (radioButtonEndsWith.Checked && textBoxEndsWith.Text.Length > 0)
            {
                return [.. results.Where(w => w.EndsWithAny(textBoxEndsWith.Text))];
            }
            else if (radioButtonEndsWithNot.Checked && textBoxEndsWith.Text.Length > 0)
            {
                return [.. results.Where(w => w.NotEndsWithAll(textBoxEndsWith.Text))];
            }
            else
            {
                return [];
            }
        }
        private List<string> ApplyContainsFilters(List<string> results)
        {
            if (checkBoxContains.Checked && textBoxContains.Text.Length > 0)
            {
                if (radioButtonContainsAnd.Checked)
                    results = [.. results.Where(w => w.ContainsAll(textBoxContains.Text))];
                if (radioButtonContainsOr.Checked)
                    results = [.. results.Where(w => w.ContainsAny(textBoxContains.Text))];
            }
            if (checkBoxNotContains.Checked && textBoxNotContains.Text.Length > 0)
            {
                if (radioButtonContainsAnd.Checked)
                    results = [.. results.Where(w => w.NotContainsAny(textBoxNotContains.Text))];
                if (radioButtonContainsOr.Checked)
                    results = [.. results.Where(w => w.NotContainsSome(textBoxNotContains.Text))];
            }

            return results;
        }
        private string GetSelectedResult()
        {
            string searchPhrase = textBoxPatternResults.SelectedText;

            if (string.IsNullOrEmpty(searchPhrase))
            {
                MessageBox.Show("Najpierw zaznacz jakiś wyraz", "Uwaga", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return "";
            }
            return searchPhrase;
        }
        private void PatternKeyDownHandle(KeyEventArgs e, object sender)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SearchPattern_Click(sender, e);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.F6:
                    textBoxPattern.SelectAll();
                    textBoxPattern.Focus();
                    break;
            }
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1: radioPatternMode.Checked = true; break;
                    case Keys.D2: radioAnagramMode.Checked = true; break;
                    case Keys.D3: radioMetagramMode.Checked = true; break;
                    case Keys.D4: radioPM1Mode.Checked = true; break;
                    case Keys.D5: radioSubWordMode.Checked = true; break;
                    case Keys.D6: radioSuperWordMode.Checked = true; break;
                    case Keys.D7: radioStenoAnagramMode.Checked = true; break;
                    case Keys.D8: radioWordInWord.Checked = true; break;
                    case Keys.D9:
                        checkBoxLength.Checked = !checkBoxLength.Checked;
                        break;
                }
            }
        }

    }
}
