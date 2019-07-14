using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestHandler : IRequestHandler
    {
        #region Members
        private readonly IRequestable request;
        private readonly List<Task> tasks = new List<Task>();
        #endregion

        #region Ctor
        public RequestHandler(IRequestable request)
        {
            this.request = request;
        }
        #endregion

        #region ITasksHolder iplementation
        public async Task Run()
        {
            await request.Request();
            await Task.WhenAll(tasks);
        }
        #endregion

        #region IRequestHandler implementation
        public IRequestHandler RawHtmlNode(Action<HtmlNode> handler)
        {
            AddTask(handler);
            return this;
        }

        public IRequestHandler ParseTo<T>(IParser<T> htmlParser, Action<T> handler)
        {
            AddTask(response =>
            {
                handler(htmlParser.Parse(response));
            });
            return this;
        }
        #endregion

        #region Private methods
        private void AddTask(Action<HtmlNode> action)
        {
            tasks.Add(request.AddHandlerAction(action));
        }
        #endregion

    }
}
