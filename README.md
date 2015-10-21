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

      items.Add(
        new SitemapItem
        (
          Url.Action("Index", "Contact", null, this.Request.Url.Scheme),
          new Dictionary<string, string>
          {
            { "de", Url.Action("Index", "Contact", new RouteValueDictionary(new { language = "de" }), Request.Url.Scheme) },
            { "da", Url.Action("Index", "Contact", new RouteValueDictionary(new { language = "da" }), Request.Url.Scheme) },
            { "es", Url.Action("Index", "Contact", new RouteValueDictionary(new { language = "es" }), Request.Url.Scheme) },
          }
        ));
      
      var sitemapDoc = SitemapGenerator.Sitemap(items);   
      var stringWriter = new StringWriter();
      sitemapDoc.Save(stringWriter);
  
      var sitemapString = wr.GetStringBuilder().ToString();

      // Fix .NET bug: http://stackoverflow.com/a/24075012/600559
      sitemapString =  sitemapString.Replace("utf-16", "utf-8");
      
      return this.Content(sitemapString, "text/xml");
    }
  }
    

```
