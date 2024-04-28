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
    }
}
