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
            //mydi.ParseWeb();
            mydi.ExtractLink("https://vnexpress.net");
            mydi.ExtractLink("https://cafef.vn");

            //Console.WriteLine("-----------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------");
            //mydi.ExtractHref("https://www.kitco.com");
        }
    }
}
