using DustInTheWind.HttpClientWithMessageHandlersDemo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.HttpClientWithMessageHandlersDemo.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    [HttpGet]
    public GetDemoApiResponse Get([FromHeader] string dummy1, [FromHeader] string dummy2)
    {
        return new GetDemoApiResponse
        {
            Dummy1 = dummy1,
            Dummy2 = dummy2
        };
    }
}
