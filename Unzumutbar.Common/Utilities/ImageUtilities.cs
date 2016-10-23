using System.Drawing;

namespace Unzumutbar.Utilities
{
    public static class ImageUtilities
    {
        public static Bitmap DrawEmpyImage(int x, int y, Brush brush = null)
        {
            if (brush == null)
                brush = Brushes.AntiqueWhite;

            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(brush, ImageSize);
            }
            return bmp;
        }
    }
}
