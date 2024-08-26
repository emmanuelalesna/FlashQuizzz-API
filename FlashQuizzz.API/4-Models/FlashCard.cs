using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashQuizzz.API.Models;

public class FlashCard 
{
    [Key]
    public int FlashCardID { get; set;}
    public required string FlashCardQuestion { get; set; }
    public required string FlashCardAnswer { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string UserID { get; set; }
    public required int FlashCardCategoryID { get; set; }

    [ForeignKey("UserID")]
    public User? User { get; set; }

    [ForeignKey("FlashCardCategoryID")]
    public FlashCardCategory? FlashCardCategory { get; set; }
}