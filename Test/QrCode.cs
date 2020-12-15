using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;

namespace Test
{
   public class QrCode
    {

        public static ImageSource CodelImgsBit(string str,int size)
        {

      
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
               
            };

            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");     // 编码问题
            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H);
            int codeSizeInPixels = size;      // 设置图片长宽
            writer.Options.Height = codeSizeInPixels;
            writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0; 
           // 设置边框
            BitMatrix bm = writer.Encode(str);
            Bitmap img = writer.Write(bm);
           
            return BitmapToBitmapImage(img);
        }

        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                
                return result;
            }
        }
    }
}
