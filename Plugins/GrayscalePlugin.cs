using ImageProcessorApp.Interfaces;
using ImageProcessorApp.Models;

namespace ImageProcessorApp.Plugins
{
    public class GrayscalePlugin : IImagePlugin
    {
        public string Name => "Grayscale";

        public async Task<ImageData> ProcessAsync(ImageData image)
        {
            using var inputStream = new MemoryStream(image.Data);
            using var outputStream = new MemoryStream();

            using (var img = await Image.LoadAsync(inputStream))
            {
                img.Mutate(x => x.Grayscale());
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