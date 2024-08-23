using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Exceptions;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity;
using uUtil = FlashQuizzz.API.Utilities.UserUtility;

namespace FlashQuizzz.API.Services;

public class FlashCardService : IFlashCardService
{
    public Task<FlashCard> CreateFlashCard(FlashCardDTO newFlashCard)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCard?> Delete(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FlashCard>> GetAllFlashCards()
    {
        throw new NotImplementedException();
    }

    public Task<FlashCard?> GetByFlashCardName(string flashCardName)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCard?> GetByFlashCardNameAndUserID(string flashCardName, string UserID)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCard?> GetByFlashCardNumber(int flashCardNumber)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCard?> GetByFlashCardNumberAndUserID(int flashCardID, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FlashCard>> GetByUser(string ID)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCard?> GetFlashCardById(int flashCardID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(int ID, FlashCardDTO newFlashCard)
    {
        throw new NotImplementedException();
    }
}