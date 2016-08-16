using System.Collections.Generic;
using System.Drawing;
using Unzumutbar.Extensions;

namespace Balonek.Office.Utils
{
    public class ImageArchive
    {
        public static List<Bitmap> GetBackgrounds()
        {
            var backgroundList = new List<Bitmap>();
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia00);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia01);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia02);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia03);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia04);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia05);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia06);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia07);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia08);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia09);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia10);

            return backgroundList;
        }

        public static Bitmap GetRandomBackground()
        {
            var backgrounds = GetBackgrounds();
            return backgrounds.Random();
        }


        public static Bitmap GetRandomSmallImage()
        {
            var images = GetSmallImages();
            return images.Random();
        }

        public static List<Bitmap> GetSmallImages()
        {
            var imageList = new List<Bitmap>();
            imageList.Add(Balonek.Office.Properties.Resources.im_sosia01);
            imageList.Add(Balonek.Office.Properties.Resources.im_sosia02);
            imageList.Add(Balonek.Office.Properties.Resources.im_sosia03);
            imageList.Add(Balonek.Office.Properties.Resources.im_sosia04);
            imageList.Add(Balonek.Office.Properties.Resources.im_sosia05);

            return imageList;
        }
    }
}
