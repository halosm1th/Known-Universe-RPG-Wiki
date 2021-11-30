using System.IO;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Jpeg;
using TravellerGalaxyGenertor;

namespace TravellerWiki
{
    public class SubsectorImageGenerator : Controller
    {
        // GET
        public IActionResult GetImage(string imageID)
        {
            var generator = new TravellerSubsectorGeneratorService();
            using var image = generator.GenerateSubSectorImage(imageID);
            var byteStream = new MemoryStream();
            image.Save(byteStream, new JpegEncoder());
            byteStream.Flush();
            byteStream.Position = 0;
            return File(byteStream, "image/jpg");
        }
    }
}