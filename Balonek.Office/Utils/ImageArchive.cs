using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unzumutbar.Extensions;
using Unzumutbar.Utilities;

namespace Balonek.Office.Utils
{
    public class ImageArchive
    {
        public static List<string> GetBackgrounds()
        {
            var backgroundList = new List<string>();
            var path = GetImagePath();
            foreach (var file in Directory.GetFiles(path, "bg_*"))
            {
                backgroundList.Add(file);
            }
            return backgroundList;
        }

        public static Bitmap GetRandomBackground()
        {
            try
            {
                var background = GetBackgrounds().Random();
                return LoadImage(background);
            }
            catch(Exception ex)
            {
                Program.Logger.LogError(ex);
                return ImageUtilities.DrawEmpyImage(1, 1);
            }
        }

        private static Bitmap LoadImage(string background)
        {
            using (Stream BitmapStream = File.Open(background, FileMode.Open))
            {
                Image img = Image.FromStream(BitmapStream);

                return new Bitmap(img);
            }
        }

        public static Bitmap GetRandomSmallImage()
        {
            try
            {
                var image = GetSmallImages().Random();
                return LoadImage(image);
            }
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                return ImageUtilities.DrawEmpyImage(1, 1);
            }
}

        public static List<string> GetSmallImages()
        {
            var imageList = new List<string>();
            string path = GetImagePath();
            foreach (var file in Directory.GetFiles(path, "im_*"))
            {
                imageList.Add(file);
            }
            return imageList;
        }

        private static string GetImagePath()
        {
            return Path.Combine(Program.AppDirectory, "Images");
        }
    }
}
