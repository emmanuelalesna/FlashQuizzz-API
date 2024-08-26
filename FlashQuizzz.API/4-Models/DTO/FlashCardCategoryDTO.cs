namespace FlashQuizzz.API.Models;

public class FlashCardCategoryDTO
{
    public string FlashCardCategoryName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public bool FlashCardCategoryStatus { get; set; }
}