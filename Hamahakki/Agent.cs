using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    public class Agent : IAgent
    {
        #region Private members

        private readonly IRequestFactory requestFactory = new RequestFactory();
        private readonly IUrlParamsBuilder urlParamsBuilder = new UrlParamsBuilder();
        private readonly IJobsStorage jobsStorage = new JobsStorage();

        #endregion
        internal Agent(
            IRequestFactory requestFactory,
            IUrlParamsBuilder urlParamsBuilder,
            IJobsStorage jobsStorage)
        {
            this.requestFactory = requestFactory;
            this.urlParamsBuilder = urlParamsBuilder;
            this.jobsStorage = jobsStorage;
        }

        public Agent() : this(new RequestFactory(), new UrlParamsBuilder(), new JobsStorage())
        {
        }

        #region IAgent implementation

        public IRequestHandler FromNode(HtmlNode node)
        {
            var req = requestFactory.CreateHtmlRequest(node);
            return MakeRequestHandler(req);
        }

        public IRequestHandler FromWeb(string url, params (string arg, string value)[] args)
        {
            var req = requestFactory.CreateWebRequest(urlParamsBuilder.BuildUrl(url, args));
            return MakeRequestHandler(req);
        }

        public IRequestHandler FromWeb(string url)
        {
            var req = requestFactory.CreateWebRequest(url);
            return MakeRequestHandler(req);
        }

        public async Task Run()
        {
            await jobsStorage.DoRequestActions();
            await jobsStorage.DoResponceActions();
        }

        #endregion

        #region Private methods
        private IRequestHandler MakeRequestHandler(IRequestable request)
        {
            var handler = new RequestHandler(jobsStorage, request);
            jobsStorage.AddRequestAction(request);
            return handler;
        }
        #endregion
    }
}
