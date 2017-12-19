using TeamManager.Views.Windows;

namespace TeamManager.Views
{
    /// <summary>
    /// Opening the Team Manager app in console mode.
    /// </summary>
    public class Tui
    {
        public static void Show()
        {
            new MainTui().Show();
        }
    }
}
