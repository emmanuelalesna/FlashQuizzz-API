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
            UserName = userDTO.Email,
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
            FlashCardCategoryID = flashCardDTO.FlashCardCategoryID,
            CreatedDate = flashCardDTO.CreatedDate,
            FlashCardAnswer = flashCardDTO.FlashCardAnswer,
            UserID = flashCardDTO.UserID
        };
        return newFlashCard;
    }
}

public static class FlashCardCategoryUtility
{
    public static FlashCardCategory DTOToFlashCardCategory(FlashCardCategoryDTO flashCardCategoryDTO)
    {
        FlashCardCategory newFlashCardCategory = new FlashCardCategory()
        {
            FlashCardCategoryName = flashCardCategoryDTO.FlashCardCategoryName, 
            CreatedDate = flashCardCategoryDTO.CreatedDate,
            FlashCardCategoryStatus = flashCardCategoryDTO.FlashCardCategoryStatus
        };
        return newFlashCardCategory;
    }
}

public static class FlashCardAnswerUtility
{
    public static FlashCardAnswer DTOToFlashCardAnswer(FlashCardAnswerDTO flashCardAnswerDTO)
    {
        FlashCardAnswer newFlashCardAnswer = new FlashCardAnswer()
        {
            FlashCardID = (int)flashCardAnswerDTO.FlashCardID,
            FlashCardAnswerName = flashCardAnswerDTO.FlashCardAnswerName, 
            CreatedDate = flashCardAnswerDTO.CreatedDate,
            FlashCardIsAnswer = flashCardAnswerDTO.FlashCardIsAnswer
        };
        return newFlashCardAnswer;
    }
}