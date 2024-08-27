using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FlashQuizzz.API.Services;

public interface IUserService
{
    // Create
    Task<IdentityResult> CreateUser(UserDTO newUser);

    // Read
    Task<User?> GetUserByID(string userID);

    public Task<SignInResult> LoginUser(UserDTO loginDto);

    public Task LogoutUser();

    Task<ICollection<User>> GetAllUsers();

    // Update
    Task<bool> UpdateUser(string ID, UserDTO userToUpdate);

    // Delete
    Task<User?> DeleteUser(string ID);
}

public interface IFlashCardService
{
    // Create
    Task<FlashCard> CreateFlashCard(FlashCardDTO newFlashCard);

    // Read
    Task<FlashCard?> GetFlashCardById(int flashCardID);

    public Task<ICollection<FlashCard>> GetByUser(string ID);

    public Task<ICollection<FlashCard>> GetByCategory(int ID);

    public Task<FlashCard?> GetByFlashCardNumberAndUserID(int flashCardID, string userId);
    public Task<FlashCard?> GetByFlashCardNumber(int flashCardNumber);

    public Task<FlashCard?> GetByFlashCardName(string flashCardName);

    public Task<FlashCard?> GetByFlashCardNameAndUserID(string flashCardName, string UserID);

    Task<ICollection<FlashCard>> GetAllFlashCards();

    // Update
    Task<bool> Update(int ID, FlashCardDTO newFlashCard);

    // Delete
    Task<FlashCard?> Delete(int ID);
}

public interface IFlashCardCategoryService
{
    // Create
    Task<FlashCardCategory> CreateFlashCardCategory(FlashCardCategoryDTO newFlashCardCategory);

    // Read
    Task<FlashCardCategory?> GetFlashCardCategoryById(int flashCardID);

    Task<ICollection<FlashCardCategory>> GetAllCategories();

    Task<FlashCardCategory?> GetByFlashCardCategoryByName(string flashCardName);

    // Update
    Task<bool> Update(int ID, FlashCardCategoryDTO newFlashCard);

    // Delete
    Task<FlashCardCategory?> Delete(int ID);
}

public interface IFlashCardAnswerService
{
    // Create
    Task<FlashCardAnswer> CreateFlashCardAnswer(FlashCardAnswerDTO newFlashCardAnswer);

    // Read
    Task<FlashCardAnswer?> GetFlashCardAnswerById(int flashCardID);
    
    Task<ICollection<FlashCardAnswer>?> GetFlashCardAnswerByFlashCardId(int flashCardID);

    Task<ICollection<FlashCardAnswer>> GetAllAnswers();

    Task<FlashCardAnswer?> GetByFlashCardAnswerName(string flashCardName);

    // Update
    Task<bool> Update(int ID, FlashCardAnswerDTO newFlashCard);

    // Delete
    Task<FlashCardAnswer?> Delete(int ID);
}

