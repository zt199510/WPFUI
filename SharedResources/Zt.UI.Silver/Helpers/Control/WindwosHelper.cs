using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Zt.UI.Silver
{
    public class WindwosHelper : Window
    {

        static WindwosHelper()
        {
            StyleProperty.OverrideMetadata(typeof(WindwosHelper), new FrameworkPropertyMetadata(Application.Current.FindResource("ZTWindowsStyle")));
        }
    }
}
