using ImageProcessorApp.Interfaces;
using ImageProcessorApp.Models;

namespace ImageProcessorApp.Plugins
{
    public class ResizePlugin : IImagePlugin
    {
        public string Name => "Resize";

        private const int TargetWidth = 300;
        private const int TargetHeight = 300;

        public async Task<ImageData> ProcessAsync(ImageData image)
        {
            using var inputStream = new MemoryStream(image.Data);
            using var outputStream = new MemoryStream();

            using (var img = await Image.LoadAsync(inputStream))
            {
                img.Mutate(x => x.Resize(TargetWidth, TargetHeight));
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