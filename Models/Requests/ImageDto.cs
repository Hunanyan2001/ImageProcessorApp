namespace ImageProcessorApp.Models.Requests
{
    public class ImageDto
    {
        public string Id { get; set; }
        public List<EffectRequestDto> Effects { get; set; }
    }
}
