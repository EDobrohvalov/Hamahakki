using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestHandler : IRequestHandler, IResponseTasksProvider
    {
        private readonly IRequestable request;
        private List<Task> _tasks = new List<Task>();

        public RequestHandler(IRequestable request)
        {
            this.request = request;
        }

        public IEnumerable<Task> Tasks => _tasks;

        public IRequestHandler AddHtmlHandler(Action<HtmlNode> handler)
        {
            AddJob(response =>
            {
                handler(response);
            });
            return this;
        }

        public IRequestHandler AddParserJob<T>(IParser<T> htmlParser, Action<T> handler)
        {
            AddJob(response =>
            {
                handler(htmlParser.Parse(response));
            });
            return this;
        }

        public async Task Do()
        {
            await request.Request();
        }

        private void AddJob(Action<HtmlNode> action)
        {
            _tasks.Add(request.AddHandlerAction(action));
        }
    }
}
