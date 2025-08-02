using ImageProcessorApp.Interfaces;
using ImageProcessorApp.Models.Requests;
using ImageProcessorApp.Models.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageProcessingService _processingService;

    public ImageController(IImageProcessingService processingService)
    {
        _processingService = processingService;
    }

    [HttpPost("process")]
    public async Task<ActionResult<ProcessImagesResponseDto>> ProcessImages([FromBody] ProcessImagesRequestDto request)
    {
        var result = await _processingService.ProcessImagesAsync(request);
        return Ok(result);
    }
}