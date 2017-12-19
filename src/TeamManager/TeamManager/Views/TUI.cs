using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
using TeamManager.Presenters;
using TeamManager.Views.Windows;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views
{
    /// <summary>
    /// Opening the Team Manager app in console mode.
    /// </summary>
    public class TUI
    {
        public static void Show()
        {
            new MainTui().Show();
        }
    }
}
