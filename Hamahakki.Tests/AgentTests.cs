using Hamahakki;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class AgentTests
    {
        private Mock<IUrlParamsBuilder> urlParamsBuilder;
        private IAgent agent;

        [SetUp]
        public void SetUp()
        {
            urlParamsBuilder = new Mock<IUrlParamsBuilder>();
            agent = new Hamahakki.Agent(urlParamsBuilder.Object);
        }

        [Test]
        public void From_UrlIsNull_ThrowArgumentNullException()
        {
            string url = null;
            Assert.Throws<ArgumentNullException>(() => agent.From(url));
        }

        [Test]
        public void From_UrlIsNullWithArgs_ThrowArgumentNullException()
        {
            string url = null;
            var arg1 = ("a1", "v1");
            Assert.Throws<ArgumentNullException>(() => agent.From(url, arg1));
        }

        [Test]
        public void From_UrlWithArgsAndArgsIsNull_ThrowArgumentNullException()
        {
            string url = "URL";
            Assert.Throws<ArgumentNullException>(() => agent.From(url, null));
        }

        [Test]
        public void From_UrlIsEmpty_ThrowArgumentException()
        {
            string url = string.Empty;
            Assert.Throws<ArgumentException>(() => agent.From(url));
        }

        [Test]
        public void From_HtmlNodeIsNull_ThrowArgumentNullException()
        {
            HtmlAgilityPack.HtmlNode node = null;
            Assert.Throws<ArgumentNullException>(() => agent.From(node));
        }

        [Test]
        public void From_UrlWithArgs_UrlParamsBuilderCalledWithSameArgs()
        {
            var url = "URL";
            var arg1 = ("a1", "v1");
            var arg2 = ("a1", "v1");
            urlParamsBuilder.Setup(o => o.BuildUrl(url, arg1, arg2)).Returns(url);

            agent.From(url, arg1, arg2);
            
            urlParamsBuilder.Verify(o => o.BuildUrl(url, arg1, arg2));
        }
    }
}