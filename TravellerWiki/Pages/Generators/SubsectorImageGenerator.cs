using System;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using TravellerGalaxyGenertor;

namespace TravellerWiki
{
    public class SubsectorImageGenerator : Controller
    {
        // GET
        public IActionResult GetImage(int imageID)
        {
            var generator = new TravellerSubsectorGeneratorService();
            var image = generator.GenerateSubSectorImage(imageID);
            ImageConverter ic = new ImageConverter();
            var bytes = (byte[]) ic.ConvertTo(image, typeof(byte[])) ?? Array.Empty<byte>();
                            
            return File(bytes, "image/jpg");
        }
    }
}