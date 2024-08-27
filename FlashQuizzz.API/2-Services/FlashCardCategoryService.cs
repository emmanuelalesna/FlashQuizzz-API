using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Exceptions;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using cUtil = FlashQuizzz.API.Utilities.FlashCardCategoryUtility;

namespace FlashQuizzz.API.Services;

public class FlashCardCategoryService : IFlashCardCategoryService
{
    private readonly IFlashCardCategoryRepo _categoryRepo;

    public FlashCardCategoryService(IFlashCardCategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<FlashCardCategory> CreateFlashCardCategory(FlashCardCategoryDTO flashCardCategory)
    {
        FlashCardCategory newFlashCardCategory = cUtil.DTOToFlashCardCategory(flashCardCategory);

        if(flashCardCategory.FlashCardCategoryID != null && await _categoryRepo.GetByID((int)flashCardCategory.FlashCardCategoryID!) != null)
        {
            throw new InvalidFlashCardCategoryException($"FlashCard Category ID {flashCardCategory.FlashCardCategoryID} already exists.");
        }

        if(flashCardCategory.FlashCardCategoryName != null && await _categoryRepo.GetByName(flashCardCategory.FlashCardCategoryName) != null)
        {
            throw new InvalidFlashCardCategoryException($"FlashCard Category Name {flashCardCategory.FlashCardCategoryName} already registered.");
        }

        return await _categoryRepo.Create(newFlashCardCategory);
    }

    public async Task<FlashCardCategory?> Delete(int ID)
    {
        FlashCardCategory? flashCardCategory = await _categoryRepo.GetByID(ID) ?? throw new InvalidFlashCardCategoryException("Category does not exist.");
        return await _categoryRepo.Delete(ID);
    }

    public async Task<ICollection<FlashCardCategory>> GetAllCategories()
    {
        ICollection<FlashCardCategory> flashCardCol = await _categoryRepo.GetAll();
        List<FlashCardCategory> flashCardCategoriesList = flashCardCol.ToList();

        if(flashCardCategoriesList.IsNullOrEmpty())
        {
            throw new InvalidFlashCardCategoryException($"No category found.");
        }

        return flashCardCategoriesList;
    }

    public async Task<FlashCardCategory?> GetByFlashCardCategoryByName(string flashCardName)
    {
        FlashCardCategory? flashCardCategory = await _categoryRepo.GetByName(flashCardName);

        if (flashCardCategory == null)
        {
            throw new InvalidFlashCardCategoryException($"FlashCard Category with name {flashCardName} could not be found.");
        }

        return flashCardCategory;
    }

    public async Task<FlashCardCategory?> GetFlashCardCategoryById(int flashCardID)
    {
        if (flashCardID < 1) throw new ArgumentException("Invalid ID");

        FlashCardCategory? flashCardCategory = await _categoryRepo.GetByID(flashCardID);

        if(flashCardCategory == null)
        {
            throw new InvalidFlashCardCategoryException($"FlashCard Category with ID {flashCardID} could not be found.");
        }

        return flashCardCategory;
    }

    /**
    * 
    */
    public async Task<bool> Update(int ID, FlashCardCategoryDTO newFlashCard)
    {
        FlashCardCategory flashCardToUpdate = cUtil.DTOToFlashCardCategory(newFlashCard);

        return await _categoryRepo.Update(ID, flashCardToUpdate);
    }
}