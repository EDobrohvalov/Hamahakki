using Hamahakki;
using HtmlAgilityPack;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class HelloWorldParser : IParser<string>
    {
        public string Parse(HtmlNode node)
        {
            return "Hello world!";
        }
    }

    public class FortyTwoParser : IParser<int>
    {
        public int Parse(HtmlNode node)
        {
            return 42;
        }
    }

    public class HisAliveTest
    {

        [Test]
        public void Run()
        {
            var actualSting = "";
            var actualInt = 0;
            HtmlNode actualNode = null;

            var requestMaker = new Hamahakki.RequestMaker();
            requestMaker.From("http://google.com")
                .ParseTo<string>(new HelloWorldParser(), str => actualSting = str)
                .ParseTo<int>(new FortyTwoParser(), v => actualInt = v)
                .RawHtmlNode(v =>  actualNode = v)
                .Run();

            Assert.AreEqual("Hello world!", actualSting);
            Assert.AreEqual(42, actualInt);
            Assert.IsNotEmpty(actualNode.InnerHtml);
        }
    }
}