using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashQuizzz.API.Models;

public class FlashCardCategory 
{
    [Key]
    public int FlashCardCategoryID { get; set;}
    public required string FlashCardCategoryName { get; set; }
    public required bool FlashCardCategoryStatus { get; set; } = true;
    public DateTime CreatedDate { get; set; }
}