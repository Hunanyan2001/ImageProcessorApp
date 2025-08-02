namespace ImageProcessorApp.Interfaces
{
    using ImageProcessorApp.Models;

    public interface IImagePlugin
    {
        string Name { get; }
        Task<ImageData> ProcessAsync(ImageData image);
    }
}