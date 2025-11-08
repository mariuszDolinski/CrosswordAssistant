namespace CrosswordAssistant.Entities
{
    public class Cell(int x, int y, int v, Label? l)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Value { get; set; } = v;
        public Label? Label { get; set; } = l;

        public void SetCell(int x, int y, int v, Label? l)
        {
            X = x; Y = y; Value = v; Label = l;
        }

        public void SetCellLabel(string txt)
        {
            if (Label is null) return;
            Label.Text = txt;
        }
    }
}
