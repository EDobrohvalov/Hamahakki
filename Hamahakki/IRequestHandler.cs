using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    public interface IRequestHandler
    {
        IRequestHandler ParseTo<T>(IParser<T> parser, Action<T> resultHandler);
        IRequestHandler RawHtmlNode(Action<HtmlNode> htmlHandler);
    }

    internal interface ITasksHolder : IRequestHandler
    {
        Task RunTasks();
        IEnumerable<Task> Tasks { get; }
    }



}
