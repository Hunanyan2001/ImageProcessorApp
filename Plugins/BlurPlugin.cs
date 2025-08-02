using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;
using System.Threading.Tasks;
using ImageProcessorApp.Models;
using ImageProcessorApp.Interfaces;

namespace ImageProcessorApp.Plugins
{
    public class BlurPlugin : IImagePlugin
    {
        public string Name => "Blur";

        public async Task<ImageData> ProcessAsync(ImageData image)
        {
            using var inputStream = new MemoryStream(image.Data);
            using var outputStream = new MemoryStream();

            using (var img = await Image.LoadAsync(inputStream))
            {
                img.Mutate(x => x.GaussianBlur());
                await img.SaveAsJpegAsync(outputStream);
            }

            return new ImageData
            {
                FileName = image.FileName,
                ContentType = "image/jpeg",
                Data = outputStream.ToArray()
            };
        }
    }
}
