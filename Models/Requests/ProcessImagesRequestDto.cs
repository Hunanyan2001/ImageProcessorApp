namespace ImageProcessorApp.Models.Requests
{
    public class ProcessImagesRequestDto
    {
        public List<ImageRequestDto> Images { get; set; } = new List<ImageRequestDto>();
    }
}
