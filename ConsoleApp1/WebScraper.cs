using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;

namespace ConsoleApp1
{
    class WebScraper
    {
        public WebScraper() { }

        public async void GetHtmlAsync() // async because GetStringAsync
        {
            var url = "https://www.ebay.com/sch/i.html?_nkw=xbox+one&_in_kw=1&_ex_kw=&_sacat=0&LH_Complete=1&_udlo=&_udhi=&_samilow=&_samihi=&_sadis=15&_stpos=&_sargn=-1%26saslc%3D1&_salic=1&_sop=12&_dmd=1&_ipg=50&_fosrp=1";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);  // Will wait for answer - can take time
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var products = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("ListViewInner")).ToList();

            var ProduceListItems = products[0].Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("item")).ToList();

            foreach (var productListItem in ProduceListItems)
            {
                Console.WriteLine(productListItem.GetAttributeValue("listingid",""));

                Console.WriteLine(productListItem.Descendants("h3")
                    .Where(node=> node.GetAttributeValue("class","")
                    .Equals("lvtitle")).FirstOrDefault().InnerText);

                Console.WriteLine();
            }




        }
        public void Run()
        {
            GetHtmlAsync();
        }


    }
}
