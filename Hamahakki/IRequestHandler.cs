using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    public interface IRequestHandler
    {
        IRequestHandler AddParserJob<T>(IParser<T> parser, Action<T> resultHandler);
        IRequestHandler AddHtmlHandler(Action<HtmlNode> htmlHandler);
    }

    internal interface IResponseTasksProvider : IRequestHandler
    {
        Task Do ();
        IEnumerable<Task> Tasks {get;}
    }

}
