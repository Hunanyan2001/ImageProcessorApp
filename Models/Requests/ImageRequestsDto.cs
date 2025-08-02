using ImageProcessorApp.Models.Requests;

public class ImageRequestDto
{
    public string Id { get; set; }
    public byte[] ImageData { get; set; }
    public List<EffectRequestDto> Effects { get; set; }
}