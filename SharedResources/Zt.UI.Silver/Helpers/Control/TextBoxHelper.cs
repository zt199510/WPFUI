using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Zt.UI.Silver
{
   public class TextBoxHelper
    {
        #region FocusedBorderBrush
        public static Brush GetFocusedBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusedBorderBrushProperty);
        }

        public static void SetFocusedBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(TextBoxHelper));
        #endregion

        #region FocusedShadowColor
        public static Color? GetFocusedShadowColor(DependencyObject obj)
        {
            return (Color?)obj.GetValue(FocusedShadowColorProperty);
        }

        public static void SetFocusedShadowColor(DependencyObject obj, Color? value)
        {
            obj.SetValue(FocusedShadowColorProperty, value);
        }

        public static readonly DependencyProperty FocusedShadowColorProperty =
            DependencyProperty.RegisterAttached("FocusedShadowColor", typeof(Color?), typeof(TextBoxHelper));

        #endregion


        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(TextBoxHelper));
        #endregion

        #region Watermark 水印
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper));


        #endregion
        #region Icon
        public static object GetIcon(DependencyObject obj)
        {
            return obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(TextBoxHelper));
        #endregion

        #region Header
        public static object GetHeader(DependencyObject obj)
        {
            return obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(TextBoxHelper));
        #endregion


        #region HeaderWidth
        public static string GetHeaderWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderWidthProperty);
        }

        public static void SetHeaderWidth(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderWidthProperty, value);
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.RegisterAttached("HeaderWidth", typeof(string), typeof(TextBoxHelper), new PropertyMetadata("Auto"));
        #endregion

        #region IsClearButtonVisible
        public static bool GetIsClearButtonVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsClearButtonVisibleProperty);
        }

        public static void SetIsClearButtonVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsClearButtonVisibleProperty, value);
        }

        public static readonly DependencyProperty IsClearButtonVisibleProperty =
            DependencyProperty.RegisterAttached("IsClearButtonVisible", typeof(bool), typeof(TextBoxHelper));
        #endregion

        #region (Internal) TextBoxHook
        internal static bool GetTextBoxHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(TextBoxHookProperty);
        }

        internal static void SetTextBoxHook(DependencyObject obj, bool value)
        {
            obj.SetValue(TextBoxHookProperty, value);
        }

        internal static readonly DependencyProperty TextBoxHookProperty =
            DependencyProperty.RegisterAttached("TextBoxHook", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(OnTextBoxHookChanged));


        private static void OnTextBoxHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as TextBox;
            textbox.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(ClearButtonClicked));
            textbox.AddHandler(Button.ClickEvent, new RoutedEventHandler(ClearButtonClicked));
        }

        private static void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;

            if (button == null || button.Name != "PART_BtnClear")
                return;

            var textbox = sender as TextBox;

            if (textbox == null)
                return;

            textbox.Text = "";
        }

        /// <summary>
        /// 是否弹出数字键盘
        /// </summary>
        // Using a DependencyProperty as the backing store for Changage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangageProperty =
            DependencyProperty.RegisterAttached("Changage", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(OntextBoxChanged));

        private static void OntextBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {     

            var textbox = d as TextBox;
            textbox.RemoveHandler(TextBox.PreviewMouseDownEvent, new RoutedEventHandler(TestMouseLefuDown));
            textbox.AddHandler(TextBox.PreviewMouseDownEvent, new RoutedEventHandler(TestMouseLefuDown));
        }

        private static void TestMouseLefuDown(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            Point WindosPoint = box.TransformToAncestor(Window.GetWindow(box)).Transform(new Point(0, 0));
            Point BoxPoint = box.PointToScreen(new Point(0, 0));
            NumberPage number;
       
            if (GetIsVerification(box))
            {
                var Max = GetMaxNum(box);
                var Min = GetMinNum(box);
                number = new NumberPage(Min, Max);
            }
            else
            {
                number = new NumberPage();
            }


          
            number.Owner = Application.Current.MainWindow;
            int hn = (int)box.ActualHeight;
            if(BoxPoint.Y+hn+ number.Width > 900)
            {
                number.Left = BoxPoint.X + box.ActualWidth;
                number.Top = WindosPoint.Y - number.Height;
            }
            else
            {
                number.Left = BoxPoint.X;
                number.Top = BoxPoint.Y + hn;
            }
            
            number.ShowDialog();
           
            box.Text = number.Result;
            
        }

        public static bool GetChangage(DependencyObject obj)
        {
            return (bool)obj.GetValue(ChangageProperty);
        }

        public static void SetChangage(DependencyObject obj, bool value)
        {
            obj.SetValue(ChangageProperty, value);
        }





        #region 最大最小值判断


        public static bool GetIsVerification(DependencyObject obj)
        {

            return (bool)obj.GetValue(IsVerificationProperty);
        }

        public static void SetIsVerification(DependencyObject obj, bool value)
        {
            obj.SetValue(IsVerificationProperty, value);
        }

        
        // Using a DependencyProperty as the backing store for IsVerification.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVerificationProperty =
            DependencyProperty.Register("IsVerification", typeof(bool), typeof(TextBoxHelper));



        // Using a DependencyProperty as the backing store for MaxNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxNumProperty =
            DependencyProperty.Register("MaxNum", typeof(float), typeof(TextBoxHelper));

        public static float GetMaxNum(DependencyObject obj)
        {   
           
            return (float)obj.GetValue(MaxNumProperty);
        }

        public static void SetMaxNum(DependencyObject obj, float value)
        {
            obj.SetValue(MaxNumProperty, value);
        }

        public static readonly DependencyProperty MinNumProperty =
          DependencyProperty.Register("MinNum", typeof(float), typeof(TextBoxHelper));

        public static float GetMinNum(DependencyObject obj)
        {
            return (float)obj.GetValue(MinNumProperty);
        }

        public static void SetMinNum(DependencyObject obj, float value)
        {
            obj.SetValue(MinNumProperty, value);
        }
        #endregion
        #endregion
    }
}
