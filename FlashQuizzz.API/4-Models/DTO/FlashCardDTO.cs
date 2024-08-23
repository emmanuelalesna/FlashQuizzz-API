namespace FlashQuizzz.API.Models;

public class FlashCardDTO
{
    public string FlashCardQuestion { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string FlashCardAnswer { get; set; }
    public string? UserID { get; set; }
}