using System.Collections.Generic;
using System.Xml.Linq;

namespace ExtremelySimpleSitemapGenerator
{
  /// <summary>
  /// Documentation:
  /// https://github.com/frederiksen/ExtremelySimpleSitemapGenerator
  /// </summary>
  public abstract class SitemapGenerator
  {
    public static XDocument Sitemap(List<SitemapItem> items)
    {
      //https://support.google.com/webmasters/answer/2620865?hl=en

      XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
      XNamespace xhtml = "http://www.w3.org/1999/xhtml";

      var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", null));

      var root = new XElement(
        ns + "urlset",
        new XAttribute("xmlns", ns.NamespaceName),
        new XAttribute(XNamespace.Xmlns + "xhtml", xhtml)
        );

      foreach (var item in items)
      {
        var node = new XElement(ns + "url");
        var nodeloc = new XElement(ns + "loc", item.Url);
        node.Add(nodeloc);

        // alternate
        foreach (KeyValuePair<string, string> entry in item.Alternate)
        {
          var a = new XElement(xhtml + "link",
               new XAttribute("rel", "alternate"),
               new XAttribute("hreflang", entry.Key),
               new XAttribute("href", entry.Value)
          );
          node.Add(a);
        }

        // add to root
        root.Add(node);
      }

      xmlDoc.Add(root);

      return xmlDoc;
    }
  }
}
