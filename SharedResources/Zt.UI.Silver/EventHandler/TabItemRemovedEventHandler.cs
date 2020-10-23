using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Zt.UI.Silver.EventHandler
{
    public class TabItemRemovedEventArgs : RoutedEventArgs
    {
        public TabItemRemovedEventArgs(TabItem removedItem, bool removedFromSource, RoutedEvent routedEvent) : base(routedEvent)
        {
            RemovedItem = removedItem;
            RemovedFromSource = removedFromSource;
        }

        public TabItem RemovedItem { get; set; }

        public bool RemovedFromSource { get; set; }
    }

    public delegate void TabItemRemovedEventHandler(object sender, TabItemRemovedEventArgs e);
}
