using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Exceptions;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity;
using uUtil = FlashQuizzz.API.Utilities.UserUtility;

namespace FlashQuizzz.API.Services;

public class FlashCardCategoryService : IFlashCardCategoryService
{
    public Task<FlashCardCategory> CreateFlashCardCategory(FlashCardCategoryDTO newFlashCardCategory)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardCategory?> Delete(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FlashCardCategory>> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardCategory?> GetByFlashCardCategoryName(string flashCardName)
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardCategory?> GetFlashCardCategoryById(int flashCardID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(int ID, FlashCardCategoryDTO newFlashCard)
    {
        throw new NotImplementedException();
    }
}