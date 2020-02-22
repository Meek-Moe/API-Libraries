using HtmlAgilityPack;
using Meek.Moe.ZeroChan.Entities;
using Meek.Moe.ZeroChan.Entities.PageSubEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Meek.Moe.ZeroChan.Utilities
{
    class PageJsonParser
    {
        public static TagResultsPageByPages ParseSearchQueryPageWithPageCount(string page, int currentPage)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page);
            HtmlNodeCollection jsons = htmlDoc.DocumentNode.SelectNodes("//script[@type='application/ld+json']");
            HtmlNode pageText = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='pagination']");
            if (jsons == null)
            {
                throw new Exception("No data found!\n" +
                    "This might have accoured because of the following:\n" +
                    "- Selected pagenumber was higher than the number of total pages");
            }
            string pageTextNumbers = new string(pageText.InnerText.Where(x => char.IsDigit(x)).ToArray());
            string totalPagesText = pageTextNumbers.Substring(currentPage.ToString().Length);
            int totalPages = int.Parse(totalPagesText);
            PageGeneralInfo general = default;
            PageItems items = default;
            if (currentPage == 1)
            {
                general = JsonSerializer.Deserialize<PageGeneralInfo>(jsons[0].InnerText);
                items = JsonSerializer.Deserialize<PageItems>(jsons[1].InnerText);
            }
            else
            {
                items = JsonSerializer.Deserialize<PageItems>(jsons[0].InnerText);
            }
            return new TagResultsPageByPages
            {
                GeneralInfo = general,
                Items = items,
                CurrentPage = currentPage,
                TotalPages = totalPages
            };
        }

        public static TagResultsPageByID ParseSearchQueryPageWithID(string page, int currentID)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page);
            HtmlNodeCollection jsons = htmlDoc.DocumentNode.SelectNodes("//script[@type='application/ld+json']");
            HtmlNode nextIDNode = htmlDoc.DocumentNode.SelectSingleNode("//a[@rel='next']");
            HtmlAttribute nextIDAttribute = nextIDNode.Attributes.FirstOrDefault(x => x.Name == "href");
            int nextID = int.Parse(new string(nextIDAttribute.Value.Where(x => char.IsDigit(x)).ToArray()));
            PageGeneralInfo general = default;
            PageItems items = default;
            if (currentID == 0)
            {
                general = JsonSerializer.Deserialize<PageGeneralInfo>(jsons[0].InnerText);
                items = JsonSerializer.Deserialize<PageItems>(jsons[1].InnerText);
            }
            else
            {
                items = JsonSerializer.Deserialize<PageItems>(jsons[0].InnerText);
            }
            return new TagResultsPageByID
            {
                GeneralInfo = general,
                Items = items,
                CurrentID = currentID,
                NextID = nextID
            };
        }
    }
}
