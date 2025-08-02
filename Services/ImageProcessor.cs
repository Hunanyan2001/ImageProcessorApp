using ImageProcessorApp.Interfaces;
using ImageProcessorApp.Models;

public class ImageProcessor : IImageProcessor
{
    public async Task<ImageData> ProcessAsync(ImageData image, IEnumerable<IImagePlugin> plugins)
    {
        ImageData result = image;

        foreach (var plugin in plugins)
        {
            result = await plugin.ProcessAsync(result);
        }

        return result;
    }
}