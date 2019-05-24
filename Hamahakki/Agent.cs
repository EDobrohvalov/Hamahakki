using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    public class Agent : IAgent
    {
        #region Private members

        private readonly IUrlParamsBuilder urlParamsBuilder = new UrlParamsBuilder();
        private readonly List<ITasksHolder> taskHolders = new List<ITasksHolder>();

        #endregion
        internal Agent(IUrlParamsBuilder urlParamsBuilder)
        {
            this.urlParamsBuilder = urlParamsBuilder;
        }

        public Agent() : this(new UrlParamsBuilder())
        {
        }

        #region IAgent implementation

        public IRequestHandler From(HtmlNode node)
        {
            var req = new RequestToHtml(node);
            return MakeRequestHandler(req);
        }

        public IRequestHandler From(string url, params (string arg, string value)[] args)
        {
            return From(urlParamsBuilder.BuildUrl(url, args));
        }

        public IRequestHandler From(string url)
        {
            var req = new RequestToWeb(url);
            return MakeRequestHandler(req);
        }

        public async Task Run()
        {
            foreach (var taskHolder in taskHolders)
            {
                await taskHolder.RunTasks();
            }
            await Task.WhenAll(taskHolders.SelectMany(h => h.Tasks));
        }

        #endregion

        #region Private methods
        private IRequestHandler MakeRequestHandler(IRequestable request)
        {
            var handler = new RequestHandler(request);
            taskHolders.Add(handler);
            return handler;
        }
        #endregion
    }
}
