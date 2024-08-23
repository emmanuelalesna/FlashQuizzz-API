using FlashQuizzz.API.Models;

namespace FlashQuizzz.API.DAO.Interfaces;

public interface IFlashCardRepo
{
    // Create
    public Task<FlashCard> Create(FlashCard item);

    // Read
    public Task<FlashCard?> GetByID(int ID);

    public Task<ICollection<FlashCard>>? GetAll();

    // Update
    public Task<bool> Update(int ID, FlashCard newItem);

    // Delete
    public Task<FlashCard> Delete(int ID);
}