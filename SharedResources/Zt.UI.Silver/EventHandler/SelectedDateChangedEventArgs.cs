using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Zt.UI.Silver.EventHandler
{
    public class SelectedDateChangedEventArgs : RoutedEventArgs
    {
        public SelectedDateChangedEventArgs(DateTime dateTime, RoutedEvent routedEvent) : base(routedEvent)
        {
            Date = dateTime.Date;
        }

        public DateTime Date { get; set; }
    }

    public delegate void SelectedDateChangedEventHandler(object sender, SelectedDateChangedEventArgs e);
}
