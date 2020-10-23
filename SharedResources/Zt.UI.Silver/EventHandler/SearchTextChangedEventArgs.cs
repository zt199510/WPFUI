using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Zt.UI.Silver.EventHandler
{
    public class SearchTextChangedEventArgs : RoutedEventArgs
    {
        public SearchTextChangedEventArgs(string text, RoutedEvent routedEvent) : base(routedEvent)
        {
            Text = text;
        }

        public string Text { get; set; }
    }

    public delegate void SearchTextChangedEventHandler(object sender, SearchTextChangedEventArgs e);
}
