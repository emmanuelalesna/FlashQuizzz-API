
using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashQuizzz.API.DAO;

public class FlashCardAnswerRepo : IFlashCardAnswerRepo
{

    private readonly AppDbContext _context;

    public FlashCardAnswerRepo(AppDbContext context)
    {
        this._context = context;
    }

    public async Task<FlashCardAnswer> Create(FlashCardAnswer item)
    {
        _context.FlashCardAnswer.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<ICollection<FlashCardAnswer>> GetAll()
    {
        return await _context.FlashCardAnswer.ToListAsync();
    }

    public async Task<FlashCardAnswer?> GetByID(int ID)
    {
        return await _context.FlashCardAnswer
                .FirstOrDefaultAsync(r => r.FlashCardAnswerID == ID);
    }

    public async Task<FlashCardAnswer?> GetByFlashCardID(int ID)
    {
        return await _context.FlashCardAnswer
                .FirstOrDefaultAsync(r => r.FlashCardID == ID);
    }

    public async Task<FlashCardAnswer?> GetByFlashCardAnswerName(string flashCardAnswerName)
    {
        return await _context.FlashCardAnswer
                .FirstOrDefaultAsync(r => r.FlashCardAnswerName == flashCardAnswerName);
    }

    public async Task<FlashCardAnswer?> GetByFlashCardAnswerStatus(bool isAnswer)
    {
        return await _context.FlashCardAnswer
                .FirstOrDefaultAsync(r => r.FlashCardIsAnswer == isAnswer);
    }

    public async Task<bool> Update(int ID, FlashCardAnswer newItem)
    {
        FlashCardAnswer? oldFlashCard = await _context.FlashCardAnswer
                                                .FirstOrDefaultAsync(r => r.FlashCardAnswerID == ID);

        if (oldFlashCard == null)
        {
            return false;
        }

        oldFlashCard.FlashCardAnswerName = newItem.FlashCardAnswerName;
        oldFlashCard.FlashCardCategory = newItem.FlashCardCategory;
        oldFlashCard.FlashCardIsAnswer = newItem.FlashCardIsAnswer;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> BulkUpdate(int flashCardID, List<FlashCardAnswer> newAnswers)
    {
        // Fetch all recipes with the given category ID
        var answers = await _context.FlashCardAnswer
            .Where(r => r.FlashCardID == flashCardID)
            .ToListAsync();

        if (answers.Count < 1)
        {
            return false;
        }

        // Loop through the fetched recipes and update them
        foreach (var answer in answers)
        {
            FlashCardAnswer? oldFlashCard = await _context.FlashCardAnswer
                                                .FirstOrDefaultAsync(r => r.FlashCardID == flashCardID);
            if (oldFlashCard != null)
            {
                oldFlashCard.FlashCardAnswerName = answer.FlashCardAnswerName;
                oldFlashCard.FlashCardCategory = answer.FlashCardCategory;
                oldFlashCard.FlashCardIsAnswer = answer.FlashCardIsAnswer;
            }
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<FlashCardAnswer> Delete(int ID)
    {
        FlashCardAnswer flashCard = _context.FlashCardAnswer.Find(ID)!;

        _context.FlashCardAnswer.Remove(flashCard);
        await _context.SaveChangesAsync();

        return flashCard;
    }
}