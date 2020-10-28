using System;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace WebParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello this is program parse goldprice from Kitco written by Thai Dang thaidangminhbk3i@gmail.com");
            MyDI mydi = new MyDI(new MyParser());
            //mydi.ExtractGoldPrice("https://www.kitco.com");
            mydi.ParseWeb();
        }
        public interface Parser
        {
            void ParseWeb();
            void ExtractGoldPrice(String url);
        }

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
                                Console.WriteLine("Gold Price Ask {0} USD" , goldprice);
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
        }

        public class MyDI
        {
            private Parser myparser;
            public MyDI(Parser parser)
            {
                myparser = parser;
            }
            public void ParseWeb()
            {
                myparser.ParseWeb();
            }

            public void ExtractGoldPrice(string URL)
            {
                myparser.ExtractGoldPrice(URL);
            }

        }

    }
}
