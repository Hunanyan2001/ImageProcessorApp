namespace ImageProcessorApp.Models.Responses
{
    public class ImageResponseDto
    {
        public string Id { get; set; }
        public byte[] ProcessedImageData { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
