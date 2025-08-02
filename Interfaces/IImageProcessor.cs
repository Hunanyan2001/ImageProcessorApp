using ImageProcessorApp.Models;

namespace ImageProcessorApp.Interfaces
{
    public interface IImageProcessor
    {
        Task<ImageData> ProcessAsync(ImageData image, IEnumerable<IImagePlugin> plugins);
    }
}