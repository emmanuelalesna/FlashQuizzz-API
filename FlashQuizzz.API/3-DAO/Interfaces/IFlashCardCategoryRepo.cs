using FlashQuizzz.API.Models;

namespace FlashQuizzz.API.DAO.Interfaces;

public interface IFlashCardCategoryRepo
{
    // Create
    public Task<FlashCardCategory> Create(FlashCardCategory item);

    // Read
    public Task<FlashCardCategory?> GetByID(int ID);

    public Task<ICollection<FlashCardCategory>>? GetAll();

    // Update
    public Task<bool> Update(int ID, FlashCardCategory newItem);

    // Delete
    public Task<FlashCardCategory> Delete(int ID);
}