namespace FlashQuizzz.Entities;

public class Answer
 {
  public int AnswerId { get; set; }
  public int Questionfk { get; set; }

  public required string Name { get; set; }
  public bool IsAnswer { get; set; }
//  public Question? Question { get; set; }

 }