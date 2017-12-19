using TeamManager.Views.Windows;

namespace TeamManager.Views
{
    /// <summary> Terminal User Interface Class. </summary>
    public class Tui
    {

        /// <summary> Starts the Team Manager application in console mode. </summary>
        public static void Show()
        {
            new MainTui().Show();
        }
    }
}
