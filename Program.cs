using System.Drawing;
using System.IO;

namespace NoGraphics
{
    class Program
    {
        const string InPath = "image.png";

        static void Main(string[] args)
        {
            var image = Image.FromFile(InPath);
            var bitmap = UseGraphics(image);

            var clone = bitmap.Clone() as Image;
            
            // Empty on Linux. Blue square on Windows.
            clone.Save("out1.png");

            var notClone = new Bitmap(bitmap);
            
            // Blue square on both platforms.
            notClone.Save("out2.png");

            bitmap.Save("intermidiate.png");
            File.Delete("intermidiate.png");
            var clone2 = bitmap.Clone() as Image;
            
            // Blue square on both platforms.
            clone2.Save("out3.png");
        }

        private static Bitmap UseGraphics(Image image)
        {
            var bitmap = new Bitmap(image.Width, image.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image, 0, 0);
            }
            return bitmap;
        }
    }
}
