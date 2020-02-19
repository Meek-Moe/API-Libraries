using HtmlAgilityPack;
using Meek.Moe.ZeroChan.Entities;
using Meek.Moe.ZeroChan.Entities.PageSubEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Meek.Moe.ZeroChan.Utilities
{
    class PageJsonParser
    {
        public static TagResultsPageByPages ParseSearchQueryPageWithPageCount(string page)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page);
            HtmlNodeCollection jsons = htmlDoc.DocumentNode.SelectNodes("//script[@type='application/ld+json']");
            PageGeneralInfo general = JsonSerializer.Deserialize<PageGeneralInfo>(jsons[0].InnerText);
            PageItems items = JsonSerializer.Deserialize<PageItems>(jsons[1].InnerText);
            return new TagResultsPageByPages
            {
                GeneralInfo = general,
                Items = items 
            };
        }

        public static TagResultsPageByID ParseSearchQueryPageWithID(string page)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page);
            HtmlNodeCollection jsons = htmlDoc.DocumentNode.SelectNodes("//script[@type='application/ld+json']");
            PageGeneralInfo general = JsonSerializer.Deserialize<PageGeneralInfo>(jsons[0].InnerText);
            PageItems items = JsonSerializer.Deserialize<PageItems>(jsons[1].InnerText);
            return new TagResultsPageByID
            {
                GeneralInfo = general,
                Items = items
            };
        }
    }
}
