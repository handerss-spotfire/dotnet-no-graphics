using System.Drawing;
using System.IO;

namespace NoGraphics
{
    class Program
    {
        const string InPath = "image.png";
        const string NoGraphicsPath = "out1.png";
        const string GraphicsPath = "out2.png";
        const string IntermidiatePath = "intermidiate.png";

        static void Main(string[] args)
        {
            var image = Image.FromFile(InPath);
            var bitmap = UseGraphics(image);

            var clone = bitmap.Clone() as Image;
            clone.Save(NoGraphicsPath);

            bitmap.Save(IntermidiatePath);
            File.Delete(IntermidiatePath);
            var clone2 = bitmap.Clone() as Image;
            clone2.Save(GraphicsPath);
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
