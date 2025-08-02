using ImageProcessorApp.Models.Requests;
using ImageProcessorApp.Models.Responses;

namespace ImageProcessorApp.Interfaces
{
    public interface IImageProcessingService
    {
        Task<ProcessImagesResponseDto> ProcessImagesAsync(ProcessImagesRequestDto request);
    }
}
