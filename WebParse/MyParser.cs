using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;


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
                    if ((link.Attributes["href"].Value.Contains("a"))&&(!link.Attributes["href"].Value.Contains("javascript")))
                    {
                    //if (!ret.Contains(link))
                    {
                        ret.Add(link);
                        String html= link.Attributes["href"].Value;
                        String title=link.InnerText;
                        if(!html.Contains("http"))
                        {
                            html = URL+html;
                        }
                        Console.WriteLine(title);
                        Console.WriteLine(html);
                        //ExtractLink(URL + link.Attributes["href"].Value);
                        File.AppendAllText("WriteFile.txt", title + "\n");
                        File.AppendAllText("WriteFile.txt", html+"\n");
                        
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
            Console.WriteLine("Bid :"+bid.InnerText);
            Console.WriteLine("Ask :" + ask.InnerText);
            Console.WriteLine("Chg :" + chg.InnerText);
            Console.WriteLine("Pct :" + pct.InnerText);
        }
    }
}
