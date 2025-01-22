namespace CrosswordAssistant.Entities
{
    public static class ScrabbleBonuses
    {
        public static int TripleWordBonus { get; set; }
        public static int DoubleWordBonus { get; set; }
        public static int TripleLetterBonus { get; set; }
        public static int DoubleLetterBonus { get; set; }


        public static bool ValidateBonuses()
        {
            if (TripleWordBonus > 0 && DoubleWordBonus > 0)
            {
                MessageBox.Show("Jednoczesnie może być atywny tylko jeden rodzaj premii słownej", "Uwaga",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (TripleLetterBonus > 0 && DoubleLetterBonus > 0)
            {
                MessageBox.Show("Jednoczesnie może być atywny tylko jeden rodzaj premii literowej", "Uwaga",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
