using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Zt.UI.Silver
{
    /// <summary>
    /// NumberPage.xaml 的交互逻辑
    /// </summary>
    public partial class NumberPage : Window
    {


        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        public static extern IntPtr WindowFromPoint(int xPoint,int yPoint);

   
        public bool IsVerification { get; set; }
        public string Result { get; set; } = string.Empty;

        private IKeyboardMouseEvents keyboardMouseEvents;
        public NumberPage()
        {

            InitializeComponent();
            Subscribe();
            EndNmae.Text = string.Empty;

    
        }
        public NumberPage(float _Min=-999999, float _Max= 999999)
        {
            
            InitializeComponent();
            Subscribe();
         
            EndNmae.Text = string.Empty;
            IsVerification = true;
            MaxText.Text = _Max.ToString(); 
            MinText.Text = _Min.ToString();


        
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(OnButtonMouseEnter));
            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(OnButtonMouseEnter));
        }

        private void OnButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = e.Source as Button;
                if (button == null) return;
                switch (button.Tag)
                {
                    case ".":
                        if (EndNmae.Text.IndexOf(button.Tag.ToString()) > 0)
                            break;
                        else
                            if(EndNmae.Text!="")
                            EndNmae.Text += button.Tag;

                       
                        break;
                    case "Enter":
                        if (IsVerification)
                        {
                            if (float.Parse(EndNmae.Text) >= float.Parse(MaxText.Text)
                                || float.Parse(EndNmae.Text) <= float.Parse(MinText.Text))
                            {
                                MessageBox.Show("超出限制范围");
                                return;
                            }
                               
                            Result = EndNmae.Text;
                            this.Close();
                        }
                        Result = EndNmae.Text;
                        this.Close();
                        break;
                    case "backspace":
                        
                        EndNmae.Text = EndNmae.Text.Substring(0, EndNmae.Text.Length - 1);
                        break;
                    case "Close":
                        break;
                    case "-":
                        EndNmae.Text = reverse(float.Parse(EndNmae.Text)).ToString();
                        break;
                    default:
                        EndNmae.Text += button.Tag;
                        break;
                }
            }
            catch (Exception)
            {

            
            }
          
           
            
        }

        protected override void OnClosed(EventArgs e)
        {
           
          
            keyboardMouseEvents.MouseDown -= MouseDown1Click;
            keyboardMouseEvents.Dispose();
        }
        private float reverse(float i)
        {
            return float.Parse((i > 0 ? "-" : "") + Math.Abs(i));
        }
        private void Subscribe()
        {
            keyboardMouseEvents = Hook.GlobalEvents();
            keyboardMouseEvents.MouseDown += MouseDown1Click;
                
        }

        private void MouseDown1Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            var handle = WindowFromPoint(e.X, e.Y);
            if (handle == hwnd) return;
        
            this.Close();
        }

        private void MouseDownClick(object sender, MouseEventExtArgs e)
        {
               
       
            
        }
    }
}
