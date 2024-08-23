using FlashQuizzz.API.Models;

namespace FlashQuizzz.API.Utilities;

public static class UserUtility
{
    public static User DTOToUser(UserDTO userDTO)
    {
        User newUser = new()
        {
            FirstName = userDTO.FirstName, 
            LastName = userDTO.LastName,
            UserName = userDTO.Username,
            CratedDate = DateTime.UtcNow
        };
        return newUser;
    }
}

public static class FlashCardUtility
{
    public static FlashCard DTOToFlashCard(FlashCardDTO flashCardDTO)
    {
        FlashCard newFlashCard = new FlashCard()
        {
            FlashCardQuestion = flashCardDTO.FlashCardQuestion, 
            CreatedDate = flashCardDTO.CreatedDate,
            FlashCardAnswer = flashCardDTO.FlashCardAnswer,
            UserID = flashCardDTO.UserID!
        };
        return newFlashCard;
    }
}