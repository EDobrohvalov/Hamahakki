using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HtmlAgilityPack;

[assembly: InternalsVisibleTo("Hamahakki.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Hamahakki
{
    public class Agent : IAgent
    {
        #region Private members

        private readonly IUrlParamsBuilder urlParamsBuilder;
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
            if (node == null) throw new ArgumentNullException(nameof(node));
            var req = new RequestToHtml(node);
            return MakeRequestHandler(req);
        }

        public IRequestHandler From(string url, params (string arg, string value)[] args)
        {
            if (args == null) throw new ArgumentNullException();
            return From(urlParamsBuilder.BuildUrl(url, args));
        }

        public IRequestHandler From(string url)
        {
            if (url == null) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Requested URL is not valid");
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
            taskHolders.Clear();
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
