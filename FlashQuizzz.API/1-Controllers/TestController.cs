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
public class TestController : ControllerBase
{
    [HttpGet("helloworld")]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello World");
    }
}