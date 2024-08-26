using FlashQuizzz.API.Models;

namespace FlashQuizzz.API.DAO.Interfaces;

public interface IFlashCardAnswerRepo
{
    // Create
    public Task<FlashCardAnswer> Create(FlashCardAnswer item);

    // Read
    public Task<FlashCardAnswer?> GetByID(int ID);

    public Task<ICollection<FlashCardAnswer>>? GetAll();

    // Update
    public Task<bool> Update(int ID, FlashCardAnswer newItem);

    // Delete
    public Task<FlashCardAnswer> Delete(int ID);
}