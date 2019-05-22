namespace Hamahakki
{
    internal interface IUrlParamsBuilder
    {
        string BuildUrl(string baseUrl, params (string arg, string value)[] args);
    }
}