using System;
using System.Linq;

namespace Hamahakki
{
    internal class UrlParamsBuilder : IUrlParamsBuilder
    {
        public string BuildUrl(string baseUrl, params (string arg, string value)[] args)
        {
            if (baseUrl == null) throw new ArgumentNullException();
            if (args.Length == 0) return baseUrl;
            return $"{baseUrl}?{string.Join("&", args.Select(arg => $"{arg.arg}={arg.value}"))}";
        }
    }
}
