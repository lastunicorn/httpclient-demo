namespace DustInTheWind.HttpClientDemo.WebApi.Models;

public class GetDummyApiResponse
{
    public bool HasDummyHeader { get; set; }

    public string Dummy { get; set; }

    public bool HasAuthorizationHeader { get; set; }
}
