using System;
using Moq;
using NUnit.Framework;

namespace Hamahakki.Tests
{
    [TestFixture]
    public class RequestMakerTests
    {
        private Mock<IUrlParamsBuilder> urlParamsBuilder;
        private IRequestMaker requestMaker;

        [SetUp]
        public void SetUp()
        {
            urlParamsBuilder = new Mock<IUrlParamsBuilder>();
            requestMaker = new Hamahakki.RequestMaker(urlParamsBuilder.Object);
        }

        [Test]
        public void From_UrlIsNull_ThrowArgumentNullException()
        {
            string url = null;
            Assert.Throws<ArgumentNullException>(() => requestMaker.From(url));
        }

        [Test]
        public void From_UrlIsNullWithArgs_ThrowArgumentNullException()
        {
            string url = null;
            var arg1 = ("a1", "v1");
            Assert.Throws<ArgumentNullException>(() => requestMaker.From(url, arg1));
        }

        [Test]
        public void From_UrlWithArgsAndArgsIsNull_ThrowArgumentNullException()
        {
            string url = "URL";
            Assert.Throws<ArgumentNullException>(() => requestMaker.From(url, null));
        }

        [Test]
        public void From_UrlIsEmpty_ThrowArgumentException()
        {
            string url = string.Empty;
            Assert.Throws<ArgumentException>(() => requestMaker.From(url));
        }

        [Test]
        public void From_HtmlNodeIsNull_ThrowArgumentNullException()
        {
            HtmlAgilityPack.HtmlNode node = null;
            Assert.Throws<ArgumentNullException>(() => requestMaker.From(node));
        }

        [Test]
        public void From_UrlWithArgs_UrlParamsBuilderCalledWithSameArgs()
        {
            var url = "URL";
            var arg1 = ("a1", "v1");
            var arg2 = ("a1", "v1");
            urlParamsBuilder.Setup(o => o.BuildUrl(url, arg1, arg2)).Returns(url);

            requestMaker.From(url, arg1, arg2);
            
            urlParamsBuilder.Verify(o => o.BuildUrl(url, arg1, arg2));
        }
    }
}