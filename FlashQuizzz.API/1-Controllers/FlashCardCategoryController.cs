using System.Security.Claims;
using FlashQuizzz.API.Exceptions;
using FlashQuizzz.API.Models;
using FlashQuizzz.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FlashQuizzz.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class FlashCardCategoryController : ControllerBase
{
     private readonly IFlashCardCategoryService _catService;

     public FlashCardCategoryController(IFlashCardCategoryService catService)
     {
          this._catService = catService;
     }

     [HttpPost("create"), Authorize]
     public async Task<IActionResult> CreateCategory(FlashCardCategoryDTO flashCardCategoryDTO)
     {
        try
        {
            // var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(flashCardCategoryDTO.FlashCardCategoryID != null){
                flashCardCategoryDTO.FlashCardCategoryID = null;
            }
            flashCardCategoryDTO.CreatedDate = DateTime.Now;
            FlashCardCategory category = await _catService.CreateFlashCardCategory(flashCardCategoryDTO);
            
            return Ok(category);
        }
        catch (InvalidFlashCardCategoryException e)
        {
            return NotFound("create => " +e.Message + " " + e.StackTrace);
        }
     }

     [HttpGet("category/{id}"), Authorize]
     public async Task<IActionResult> GetCategoryByID(int id)
     {
          var category = await _catService.GetFlashCardCategoryById(id);

          if (category is null) return NotFound("Category does not exist!");
          return Ok(category);
     }

     [HttpGet("category/name/{name}"),Authorize]
     public async Task<IActionResult> GetCategoryByName(string name)
     {
          var category = await _catService.GetByFlashCardCategoryByName(name);

          if (category is null) return NotFound("Category does not exist!");
          return Ok(category);
     }

     [HttpGet("categories"), Authorize]
     public async Task<IActionResult> GetAllCategories()
     {
          ICollection<FlashCardCategory> categories = await _catService.GetAllCategories();
          List<FlashCardCategory> categoriesList = categories.ToList();

          if (categoriesList.IsNullOrEmpty())
          {
               return NotFound("Category does not exist!");
          }

          return Ok(categoriesList);
     }
}