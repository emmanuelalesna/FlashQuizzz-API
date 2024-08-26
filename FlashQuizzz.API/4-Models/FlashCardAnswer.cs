using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashQuizzz.API.Models;

public class FlashCardAnswer
{
    [Key]
    public int FlashCardAnswerID { get; set;}
    public required string FlashCardAnswerName { get; set; }
    public required bool FlashCardIsAnswer { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public required int FlashCardID { get; set; }
    
    [ForeignKey("FlashCardID")]
    public FlashCardCategory? FlashCardCategory { get; set; }
}