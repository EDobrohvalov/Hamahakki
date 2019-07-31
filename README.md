# Getting started
 
Hamahakki - it's simple wrapper for [ScrappySharp](https://github.com/rflechner/ScrapySharp) for minification boilerplate code for actions like HTTP request, handling html response and parse it to custom structures.

## Basic examples of usages

### 

### Implement IParser interface

``` C#
    public interface IParser<T>
    {
        T Parse(HtmlNode node);
    }
```

### Like this, for example.

``` C#
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
```

### Define scenario with result handlers, and run agent.

```C#
    var hama = new Hamahakki.RequestMaker();
    hama.From("https://google.com")
        .ParseTo<string>(new HelloWorldParser(), stringValue => {
            // stringValue - is result of HelloWorldParser work.
            // In current example value is equal 'Hello world!'
        })
        .ParseTo<int>(new FortyTwoParser(), intValue => {
            // intValue - is result of FortyTwoParser work.
            // In current example value is equal 42  
        })
        .RawHtmlNode(htmlNode => {
            // htmlNode - contain HTML code of http://google.com site
        });
    hama.Run(); // waiting for execution all requests and all parsers jobs
```
