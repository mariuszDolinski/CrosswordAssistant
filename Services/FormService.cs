namespace CrosswordAssistant.Services
{
    public class FormService
    {
        public static void SwitchControlVisibility(Control control)
        {
            if (control.Visible)
            {
                control.Visible = false;
            }
            else
            {
                control.Visible = true;
            }
        }
        public static void FilterChecked(CheckBox checkBox, TextBox[] textBox) 
        {
            if (checkBox.Checked)
            {
                for(int i = 0; i < textBox.Length; i++)
                    textBox[i].Enabled = true;
            }
            else
            {
                for (int i = 0; i < textBox.Length; i++)
                {
                    textBox[i].Enabled = false;
                    textBox[i].Text = "";
                }
            }
        }
        public static void ResetLabelsBackColor(List<Label> labels, Color color)
        {
            foreach (Label label in labels)
            {
                label.BackColor = color;
            }
        }
    }
}
