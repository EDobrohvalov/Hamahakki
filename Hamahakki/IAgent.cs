using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Hamahakki
{
    public interface IAgent 
    {
        IRequestHandler From(string url, params (string arg, string value)[] args);
        IRequestHandler From(string url);
        IRequestHandler From(HtmlNode node);
        Task Run();
    }

}
