namespace FlashQuizzz.API.Models;

public class FlashCardAnswerDTO
{
    public DateTime CreatedDate { get; set; }
    public required string FlashCardAnswerName { get; set; }
    public bool FlashCardIsAnswer { get; set; }
    public int? FlashCardID { get; set; }
}