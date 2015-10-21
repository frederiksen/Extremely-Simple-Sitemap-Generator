using System.Collections.Generic;

namespace ExtremelySimpleSitemapGenerator
{
  /// <summary>
  /// Documentation:
  /// https://github.com/frederiksen/ExtremelySimpleSitemapGenerator
  /// </summary>
  public class SitemapItem
  {
    public SitemapItem(string url, Dictionary<string, string> alternate)
    {
      Url = url;
      Alternate = alternate;
    }

    public string Url { get; private set; }

    public Dictionary<string, string> Alternate { get; private set; }
  }
}