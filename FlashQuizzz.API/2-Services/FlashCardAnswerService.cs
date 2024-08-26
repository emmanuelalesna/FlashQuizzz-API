using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Exceptions;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity;
using uUtil = FlashQuizzz.API.Utilities.UserUtility;

namespace FlashQuizzz.API.Services;

public class FlashCardAnswerService : IFlashCardAnswerService
{
    public Task<FlashCardAnswer> CreateFlashCardAnswer(FlashCardAnswerDTO newFlashCardAnswer)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardAnswer?> Delete(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FlashCardAnswer>> GetAllAnswers()
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardAnswer?> GetByFlashCardAnswerName(string flashCardName)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FlashCardAnswer>?> GetFlashCardAnswerByFlashCardId(int flashCardID)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardAnswer?> GetFlashCardAnswerById(int flashCardID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(int ID, FlashCardAnswerDTO newFlashCard)
    {
        throw new NotImplementedException();
    }
}