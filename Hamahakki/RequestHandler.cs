using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestHandler : IRequestHandler
    {
        private readonly IRequestable request;
        private readonly IJobsStorage jobsStorage;

        public RequestHandler(IJobsStorage jobsStorage, IRequestable request)
        {
            this.jobsStorage = jobsStorage;
            this.request = request;
        }

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

        private void AddJob(Action<HtmlNode> action)
        {
            jobsStorage.AddResponseAction(request, action);
        }
    }
}
