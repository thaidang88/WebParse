using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

using System.Linq;

namespace WebParse
{
    public class MyParser : Parser
    {
        public void ParseWeb()
        {
            string result = null;
            string url = "https://www.kitco.com";
            WebResponse response = null;
            StreamReader reader = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
                ParseGoldPrice(result);
                //Console.Write(result);
            }
            catch (Exception ex)
            {
                // handle error
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (response != null)
                    response.Close();
            }
        }

        public void ParseGoldPrice(String result)
        {

            if (result.Contains("lgq-ask"))
            {
                String[] temp = result.Split("lgq-ask");
                if (temp.Length > 1)
                {
                    String[] temp1 = temp[1].Split("</td>");
                    if (temp1.Length > 1)
                    {
                        String[] temp3 = temp1[0].Split(">");
                        if (temp3.Length > 1)
                        {
                            String goldprice = temp3[1];
                            Console.WriteLine("Gold Price Ask {0} USD", goldprice);
                        }
                    }
                }
            }

            if (result.Contains("lgq-bid"))
            {
                String[] temp = result.Split("lgq-bid");
                if (temp.Length > 1)
                {
                    String[] temp1 = temp[1].Split("</td>");
                    if (temp1.Length > 1)
                    {
                        String[] temp3 = temp1[0].Split(">");
                        if (temp3.Length > 1)
                        {
                            String goldprice = temp3[1];
                            Console.WriteLine("Gold Price Bid {0} USD", goldprice);
                        }
                    }
                }
            }

            if (result.Contains("lgq-chg"))
            {
                String[] temp = result.Split("lgq-chg");
                if (temp.Length > 1)
                {
                    String[] temp1 = temp[1].Split("</td>");
                    if (temp1.Length > 1)
                    {
                        String[] temp3 = temp1[0].Split(">");
                        if (temp3.Length > 1)
                        {
                            String goldprice = temp3[1];
                            Console.WriteLine("Gold Price Change {0} ", goldprice);
                        }
                    }
                }
            }

            if (result.Contains("lgq-chg-percent"))
            {
                String[] temp = result.Split("lgq-chg-percent");
                if (temp.Length > 1)
                {
                    String[] temp1 = temp[1].Split("</td>");
                    if (temp1.Length > 1)
                    {
                        String[] temp3 = temp1[0].Split(">");
                        if (temp3.Length > 1)
                        {
                            String goldprice = temp3[1];
                            Console.WriteLine("Gold Price Change Percentage {0} % ", goldprice);
                        }
                    }
                }
            }
        }

        public void ExtractGoldPrice(string URL)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);
            var ar = doc.DocumentNode.SelectNodes("td#lgq-ask");

            //doc.DocumentNode
            //Console.Write(ar.);
        }

        public void ExtractLink(string URL)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);
            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            var ret = new List<HtmlNode>();
            File.Delete("WriteFile.txt");
            foreach (HtmlNode link in links)
            {
                //cbl_items.Items.Add(link);
                //if (link.InnerHtml.Contains("news/2020-10-30/"))
                //if (link.Attributes["href"].Value.Contains("news/2020-10-30"))
                if ((link.Attributes["href"].Value.Contains("a")) && (!link.Attributes["href"].Value.Contains("javascript")))
                {
                    //if (!ret.Contains(link))
                    {
                        ret.Add(link);
                        String html = link.Attributes["href"].Value;
                        String title = link.InnerText;
                        if (!html.Contains("http"))
                        {
                            html = URL + html;
                        }
                        Console.WriteLine(title);
                        Console.WriteLine(html);
                        //ExtractLink(URL + link.Attributes["href"].Value);
                        File.AppendAllText("WriteFile.txt", title + "\n");
                        File.AppendAllText("WriteFile.txt", html + "\n");

                    }
                }
            }

        }

        public void ExtractHref(string URL)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);
            // extracting all links
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.Contains("a"))
                {
                    // showing output
                    Console.WriteLine(att.Value);
                    //Console.WriteLine(att.Name);
                    //Console.WriteLine((att.)

                }
            }
        }

        public void ExtractGoldKitco(String url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(url);
            // extracting all links
            //SelectSingleNode("//*[@id='test']")
            var bid = doc.DocumentNode.SelectSingleNode("//*[@id='" + "lgq-bid" + "']");
            var ask = doc.DocumentNode.SelectSingleNode("//*[@id='" + "lgq-ask" + "']");
            var chg = doc.DocumentNode.SelectSingleNode("//*[@id='" + "lgq-chg" + "']");
            var pct = doc.DocumentNode.SelectSingleNode("//*[@id='" + "lgq-chg-percent" + "']");
            //lgq - chg - percent
            Console.WriteLine("Bid :" + bid.InnerText);
            Console.WriteLine("Ask :" + ask.InnerText);
            Console.WriteLine("Chg :" + chg.InnerText);
            Console.WriteLine("Pct :" + pct.InnerText);
        }

        public void ExtractDownJonesFromInvesting(String url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(url);
            // extracting all links
            //SelectSingleNode("//*[@id='test']")
            var index = doc.DocumentNode.SelectSingleNode("//*[@id='sb_last_169']");
            var chg = doc.DocumentNode.SelectSingleNode("//*[@id='sb_change_169']");
            var pct = doc.DocumentNode.SelectSingleNode("//*[@id='sb_changepc_169']");
            //var pct = doc.DocumentNode.SelectSingleNode("//*[@id='" + "lgq-chg-percent" + "']");
            //lgq - chg - percent
            Console.WriteLine("index :" + index.InnerText);
            //Console.WriteLine("Ask :" + ask.InnerText);
            Console.WriteLine("Chg :" + chg.InnerText);
            Console.WriteLine("Pct :" + pct.InnerText);
        }


        public void ExtractIndexFromInvesting(String url)
        {
            var URL = "https://www.investing.com";
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);

            var list = new Dictionary<string, string>()
            {
                {"sb_last_8873", "US30 Futures"},
                {"sb_last_8839", "US 500 Futures"},
                {"sb_last_169","Dow Jones"},
                {"sb_last_166", "S&P 500"},
                {"sb_last_14958", "Nasdaq"},
                {"sb_last_44336", "S&P 500 VIX"},
                {"sb_last_8827", "Dollar Index"}
            };

            foreach (var x in list)
            {
                var name = doc.DocumentNode.SelectSingleNode("//*[@id='" + x.Key + "']");
                Console.WriteLine(x.Value + ": " + name.InnerText);
            }
        }

        public void ExtractHrefNew(string URL)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);
            File.Delete("WriteFile.txt");
            // extracting all links
            List<String> htmls = new List<String>();
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                String html = link.Attributes["href"].Value;
                String title = link.InnerText;

                if ((html.Contains("a")) && (!html.Contains("javascript"))&&(IsValidLink(html)))
                {
                    if (title.Length > 20)
                    {
                        if (!html.Contains("http"))
                        {
                            html = URL + html;
                        }
                        if (!htmls.Contains(html))
                        {
                            Console.WriteLine(title);
                            Console.WriteLine(html);
                            htmls.Add(html);
                            File.AppendAllText("WriteFile.txt", title + "\n");
                            File.AppendAllText("WriteFile.txt", html + "\n");
                        }
                    }
                }
            }
        }

        public bool IsValidBDSLink(String url)
        {
            String[]temp = url.Split("/");
            if(temp.Length==3)
            {
                return true;
            }
            return false;
        }

        public bool IsValidLink(String url)
        {
            if(url.Contains(".html")||url.Contains(".chn"))
            {
                return true;
            }
            return false;
        }
        public void ExtractHrefFromBDS(string URL,String str)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);
            File.Delete("WriteFile.txt");
            // extracting all links
            List<String> htmls = new List<String>();
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                String html = link.Attributes["href"].Value;
                String title = link.InnerText;

                if ((html.Contains("a")) && !html.Contains("javascript") )
                {
                    //if(html.Contains(str))
                    { 
                    //if (title.Length > 20&&!title.Contains("\n"))
                    if (title.Length > 20 )
                     {
                            
                            if (html.Contains(str)&&IsValidBDSLink(html))
                            {
                                if (!htmls.Contains(html))
                                {
                                    if (title.Contains("/"))
                                    {
                                        Console.WriteLine(title);
                                        Console.WriteLine(html);
                                        if (!html.Contains("http"))
                                        {
                                            html = URL + html;
                                        }
                                        ExtractDataFromBds(html);
                                        htmls.Add(html);
                                        File.AppendAllText("WriteFile.txt", title + "\n");
                                        File.AppendAllText("WriteFile.txt", html + "\n");
                                    }
                                }
                            }
                    }
                    }
                }
            }

        }
        
        public void ExtractAllImages(String url)
	{
		
		// declare html document
		var document = new HtmlWeb().Load(url);
		
		// now using LINQ to grab/list all images from website
		var ImageURLs = document.DocumentNode.Descendants("img")
										.Select(e => e.GetAttributeValue("src", null))
										.Where(s => !String.IsNullOrEmpty(s));
		
		// now showing all images from web page one by one
		foreach(var item in ImageURLs)
		{
			if (item != null)
			{
				Console.WriteLine(item);
			}
		}
	}

        public void ExtractDataFromBds(String url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(url);
            
            // filter html elements on the basis of class name
            IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants("span").Where(n => n.HasClass("sp2"));
            foreach (var item in nodes)
            {
                // displaying final output
                Console.WriteLine(item.InnerHtml);
               
            }

            nodes= doc.DocumentNode.Descendants("h1").Where(n => n.HasClass("tile-product"));
            foreach (var item in nodes)
            {
                // displaying final output
                Console.WriteLine(item.InnerHtml);

            }

            //nodes = doc.DocumentNode.Descendants("span").Where(n => n.HasClass("hidden-phone hidden-mobile des showPhone tooltip"));
            //foreach (var item in nodes)
            //{
            //    // displaying final output
            //    Console.WriteLine(item.InnerHtml);

            //}

            nodes = doc.DocumentNode.Descendants("span").Where(n => n.HasClass("phoneEvent"));
            foreach (var item in nodes)
            {
                // displaying final output
                Console.WriteLine(item.InnerHtml);

            } 
        }
    }
}
