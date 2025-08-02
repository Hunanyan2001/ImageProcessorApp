using ImageProcessorApp.Configurations;
using ImageProcessorApp.Interfaces;
using ImageProcessorApp.Models;
using ImageProcessorApp.Models.Requests;
using ImageProcessorApp.Models.Responses;
using Microsoft.Extensions.Options;

public class ImageProcessingService : IImageProcessingService
{
    private readonly IImageProcessor _imageProcessor;
    private readonly IEnumerable<IImagePlugin> _plugins;
    private readonly ImageProcessingOptions _options;

    public ImageProcessingService(IImageProcessor imageProcessor, IEnumerable<IImagePlugin> plugins, IOptions<ImageProcessingOptions> options)
    {
        _imageProcessor = imageProcessor;
        _plugins = plugins;
        _options = options.Value;
    }

    public async Task<ProcessImagesResponseDto> ProcessImagesAsync(ProcessImagesRequestDto request)
    {
        var response = new ProcessImagesResponseDto
        {
            Images = new List<ImageResponseDto>()
        };

        foreach (var imageReq in request.Images)
        {
            try
            {
                var pluginsToApply = new List<IImagePlugin>();
                foreach (var effect in imageReq.Effects)
                {
                    if (!_options.Plugins.Contains(effect.Type, StringComparer.OrdinalIgnoreCase))
                        continue;

                    var plugin = _plugins.FirstOrDefault(p =>
                        p.Name.Equals(effect.Type, StringComparison.OrdinalIgnoreCase));

                    if (plugin != null)
                        pluginsToApply.Add(plugin);
                }

                var imageData = new ImageData
                {
                    FileName = $"{imageReq.Id}.jpg",
                    ContentType = "image/jpeg",
                    Data = imageReq.ImageData
                };

                var processedImage = await _imageProcessor.ProcessAsync(imageData, pluginsToApply);

                response.Images.Add(new ImageResponseDto
                {
                    Id = imageReq.Id,
                    ProcessedImageData = processedImage.Data,
                    ErrorMessage = null
                });
            }
            catch (Exception ex)
            {
                response.Images.Add(new ImageResponseDto
                {
                    Id = imageReq.Id,
                    ProcessedImageData = null,
                    ErrorMessage = $"Failed to process image: {ex.Message}"
                });
            }
        }

        return response;
    }
}
