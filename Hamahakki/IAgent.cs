using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Hamahakki
{
    public interface IAgent 
    {
        IRequestHandler FromWeb(string url, params (string arg, string value)[] args);
        IRequestHandler FromWeb(string url);
        IRequestHandler FromNode(HtmlNode node);
        Task Run();
    }

}
