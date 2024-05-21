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
        public static void FilterChecked(CheckBox checkBox, TextBox textBox) 
        {
            if (checkBox.Checked)
            {
                textBox.Enabled = true;
            }
            else
            {
                textBox.Enabled = false;
                textBox.Text = "";
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
