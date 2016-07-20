using System;
using System.Collections.Generic;
using System.Drawing;

namespace Balonek.Office.Utils
{
    public class ImageArchive
    {
        private static Random rnd = new Random();
        public static List<Bitmap> GetBackgrounds()
        {
            var backgroundList = new List<Bitmap>();
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia00);
            backgroundList.Add(Balonek.Office.Properties.Resources.bg_sosia01);

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

            return imageList;
        }
    }
}
