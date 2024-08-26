
using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashQuizzz.API.DAO;

public class FlashCardCategoryRepo : IFlashCardCategoryRepo
{

    private readonly AppDbContext _context;

    public FlashCardCategoryRepo(AppDbContext context)
    {
        this._context = context;
    }

    public async Task<FlashCardCategory> Create(FlashCardCategory item)
    {
        _context.FlashCardCategory.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<ICollection<FlashCardCategory>> GetAll()
    {
        return await _context.FlashCardCategory.ToListAsync();
    }

    public async Task<FlashCardCategory?> GetByID(int ID)
    {
        return await _context.FlashCardCategory
                .FirstOrDefaultAsync(r => r.FlashCardCategoryID == ID);
    }

    public async Task<FlashCardCategory?> GetByFlashCardCategoryName(string flashCardCategoryName)
    {
        return await _context.FlashCardCategory
                .FirstOrDefaultAsync(r => r.FlashCardCategoryName == flashCardCategoryName);
    }

    public async Task<FlashCardCategory?> GetByFlashCardCategoryStatus(bool isActive)
    {
        return await _context.FlashCardCategory
                .FirstOrDefaultAsync(r => r.FlashCardCategoryStatus == isActive);
    }

    public async Task<bool> Update(int ID, FlashCardCategory newItem)
    {
        FlashCardCategory? oldFlashCard = await _context.FlashCardCategory
                                                .FirstOrDefaultAsync(r => r.FlashCardCategoryID == ID);

        if (oldFlashCard == null)
        {
            return false;
        }

        oldFlashCard.FlashCardCategoryName = newItem.FlashCardCategoryName;
        oldFlashCard.FlashCardCategoryStatus = newItem.FlashCardCategoryStatus;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<FlashCardCategory> Delete(int ID)
    {
        FlashCardCategory flashCard = _context.FlashCardCategory.Find(ID)!;

        _context.FlashCardCategory.Remove(flashCard);
        await _context.SaveChangesAsync();

        return flashCard;
    }
}