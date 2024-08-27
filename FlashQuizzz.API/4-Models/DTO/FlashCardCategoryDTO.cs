namespace FlashQuizzz.API.Models;

public class FlashCardCategoryDTO
{
    public int? FlashCardCategoryID { get; set; } = null!;
    public string FlashCardCategoryName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public bool FlashCardCategoryStatus { get; set; }
}