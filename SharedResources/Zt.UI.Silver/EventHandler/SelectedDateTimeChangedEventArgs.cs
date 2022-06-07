using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Zt.UI.Silver.EventHandler
{
    public class SelectedDateTimeChangedEventArgs : RoutedEventArgs
    {
        public SelectedDateTimeChangedEventArgs(DateTime dateTime, RoutedEvent routedEvent) : base(routedEvent)
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; set; }
    }

    public delegate void SelectedDateTimeChangedEventHandler(object sender, SelectedDateTimeChangedEventArgs e);
}
