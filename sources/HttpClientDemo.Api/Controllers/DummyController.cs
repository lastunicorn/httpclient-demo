using DustInTheWind.HttpClientDemo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.HttpClientDemo.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController : ControllerBase
{
    [HttpGet]
    public GetDummyApiResponse Get([FromHeader] string dummy, [FromHeader] string authorization)
    {
        return new GetDummyApiResponse
        {
            HasDummyHeader = dummy != null,
            Dummy = dummy,
            HasAuthorizationHeader = authorization != null
        };
    }
}
