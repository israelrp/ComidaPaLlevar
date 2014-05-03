using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvbola.BusinessLayer.Tools
{
    public static class Utilities
    {
        public static DateTime ObtenerFechaHoraActual()
        {
            DateTime fechaHora = DateTime.UtcNow;
            TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            fechaHora = TimeZoneInfo.ConvertTime(fechaHora, zona);
            return fechaHora;
        }

        //public static Image ScaleImage(Image image, int maxWidth, int maxHeight, bool rotate)
        //{
        //    var ratioX = (double)maxWidth / image.Width;
        //    var ratioY = (double)maxHeight / image.Height;
        //    var ratio = Math.Min(ratioX, ratioY);

        //    var newWidth = (int)(image.Width * ratio);
        //    var newHeight = (int)(image.Height * ratio);

        //    var newImage = ResizeImage(image, newWidth, newHeight, rotate);
        //    return newImage;
        //}

        //public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height, bool rotate)
        //{
        //    //a holder for the result
        //    Bitmap result = new Bitmap(width, height);
        //    //set the resolutions the same to avoid cropping due to resolution differences
        //    result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    //use a graphics object to draw the resized image into the bitmap
        //    using (Graphics graphics = Graphics.FromImage(result))
        //    {
        //        //set the resize quality modes to high quality
        //        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //        //draw the image into the target bitmap
        //        graphics.DrawImage(image, 0, 0, result.Width, result.Height);
        //    }
        //    result.RotateFlip(RotateFlipType.Rotate90FlipNone);
        //    if (rotate)
        //    {
        //        //result.RotateFlip(RotateFlipType.Rotate90FlipNone);
        //    }

        //    //return the resulting bitmap
        //    return result;
        //}
    }
}
