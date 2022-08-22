using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EyeCare.WindowsSettingsBrightnessController;

namespace EyeCare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                int brightness = ImageBrightness(ScreenShot());

                int targetBrightness = brightness > 50 ? (int)((100 - brightness) * 0.7) : brightness - (int)(Math.Abs(100 - brightness) * 1);

                targetBrightness = Math.Abs(targetBrightness);

                Set(targetBrightness);
                Console.WriteLine(targetBrightness);
            }
        }

        public static int ImageBrightness(Bitmap img)
        {
            var totalPixels = img.Width * img.Height;
            var totalBrightness = 0;
            for (var x = 0; x < img.Width; x++)
            {
                for (var y = 0; y < img.Height; y++)
                {
                    var pixel = img.GetPixel(x, y);
                    totalBrightness += pixel.R;
                }
            }
            return (int)((totalBrightness / totalPixels) / 255.0 * 100);
        }

        public static Bitmap ScreenShot()
        {
            var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics.FromImage(bmp).CopyFromScreen(0, 0, 0, 0, bmp.Size);
            return bmp;
        }
    }
}
