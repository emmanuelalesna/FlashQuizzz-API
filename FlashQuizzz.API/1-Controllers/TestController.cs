using Microsoft.AspNetCore.Mvc;

namespace FlashQuizzz.API.Controller;

[ApiController]
[Route("/")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, World! /");
    }
    
    [HttpGet("api/[controller]/helloworld")]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello World /api/test/helloworld");
    }
}