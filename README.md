# ExtremelySimpleSitemapGenerator
Extremely simple Sitemap generator to be used in a ASP.NET MVC controller

Example use:

```cs

  public class SitemapController : Controller
  {
    public ActionResult Index()
    {
      var items = new List<SitemapItem>();
      items.Add(
        new SitemapItem
        (
          Url.Action("Index", "Home", null, this.Request.Url.Scheme),
          new Dictionary<string, string>
          {
            { "de", Url.Action("Index", "Home", new RouteValueDictionary(new { language = "de" }), Request.Url.Scheme) },
            { "da", Url.Action("Index", "Home", new RouteValueDictionary(new { language = "da" }), Request.Url.Scheme) },
            { "es", Url.Action("Index", "Home", new RouteValueDictionary(new { language = "es" }), Request.Url.Scheme) },
          }
        ));
        
        
      }
    }
  }
    

```
