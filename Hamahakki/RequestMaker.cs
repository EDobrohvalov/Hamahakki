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
    public class RequestMaker : IRequestMaker
    {
        #region Private members

        private readonly IUrlParamsBuilder urlParamsBuilder;

        #endregion
        internal RequestMaker(IUrlParamsBuilder urlParamsBuilder)
        {
            this.urlParamsBuilder = urlParamsBuilder;
        }

        public RequestMaker() : this(new UrlParamsBuilder())
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

        #endregion

        #region Private methods
        private IRequestHandler MakeRequestHandler(IRequestable request)
        {
            var handler = new RequestHandler(request);
            return handler;
        }
        #endregion
    }
}
