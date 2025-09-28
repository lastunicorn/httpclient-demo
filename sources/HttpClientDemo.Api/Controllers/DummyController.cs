using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.HttpClientDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Success";
    }
}
