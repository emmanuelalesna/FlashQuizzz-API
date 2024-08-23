
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FlashQuizzz.API.Models;

public class User : IdentityUser
{
    
    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";
    
    public DateTime CratedDate { get; set; }

    // One-to-Many Relationship between User and FlashCards
    // Initializing the list so that we can store returned FlashCards later
    public ICollection<FlashCard>? FlashCards  { get; set; }
   
}