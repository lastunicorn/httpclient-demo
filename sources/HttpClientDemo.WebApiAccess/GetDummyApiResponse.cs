namespace DustInTheWind.HttpClientDemo.WebApiAccess;

internal class GetDummyApiResponse
{
    public bool HasDummyHeader { get; set; }

    public string Dummy { get; set; }

    public bool HasAuthorizationHeader { get; set; }
}
