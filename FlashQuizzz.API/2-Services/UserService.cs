using FlashQuizzz.API.DAO.Interfaces;
using FlashQuizzz.API.Exceptions;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity;
using uUtil = FlashQuizzz.API.Utilities.UserUtility;

namespace FlashQuizzz.API.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _userRepo = userRepo;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateUser(UserDTO userToCreate)
    {
        User newUser = uUtil.DTOToUser(userToCreate);

        return await _userManager.CreateAsync(newUser, userToCreate.Password);
    }

    public async Task<ICollection<User>> GetAllUsers()
    {
        return await _userRepo.GetAll()!;
    }

    public async Task<User?> GetUserByID(string userID)
    {
        if (int.Parse(userID) < 1) throw new ArgumentException("Invalid ID");
        return await _userRepo.GetByID(userID);
    }

    public async Task<bool> UpdateUser(string ID, UserDTO userToUpdate)
    {
        // User user = uUtil.DTOToUser(userToUpdate);

        var user = await _userManager.FindByIdAsync(ID);

        if(user == null)
        {
            return false;
        }

        user.FirstName = userToUpdate.FirstName;
        user.LastName = userToUpdate.LastName;
        user.UserName = userToUpdate.Email;
        
        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<User?> DeleteUser(string ID)
    {
        User? userByID = await _userManager.FindByIdAsync(ID);

        if (userByID == null)
        {
            throw new InvalidUserException("User does not exst.");
        }

        var result = await _userManager.DeleteAsync(userByID);

        return result.Succeeded ? userByID : throw new InvalidUserException("An error occurred when deleting user.");
    }

    public async Task<SignInResult> LoginUser(UserDTO userLogin)
    {
        return await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, false);
    }

    public async Task LogoutUser()
    {
        await _signInManager.SignOutAsync();
    }
}