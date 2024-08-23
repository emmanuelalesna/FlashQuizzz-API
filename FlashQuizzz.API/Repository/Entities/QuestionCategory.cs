namespace FlashQuizzz.Entities;

public class QuestionCategory
 {
  public int QuestionCategoryId { get; set; }

  public required string Name { get; set; }
  public bool Status { get; set; }
//public ICollection<Question>? Question{ get; }

 }