namespace SignalRWebUI.Dtos.MessageDto;

public class ResultMessageDto
{
    public int MessageId { get; set; }
    public string NameSurname { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
    public DateTime MessageDate { get; set; }
    public bool Status { get; set; }

}