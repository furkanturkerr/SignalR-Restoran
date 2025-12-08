namespace SignalRWebUI.Dtos.TestimonialDto;

public class GetTestimonialDto
{
    public int TestimonialId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Command { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}