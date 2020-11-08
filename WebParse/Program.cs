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
            MyParser myParser = new MyParser();
            //mydi.ExtractGoldPrice("https://www.kitco.com");
            //mydi.ParseWeb();
            //mydi.ExtractLink("https://vnexpress.net");
            //mydi.ExtractLink("https://cafef.vn");

            //Console.WriteLine("-----------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------");
            //mydi.ExtractLink("https://www.kitco.com");
            //mydi.ExtractDataFromBds("");
            //mydi.ExtractGoldKitco("https://www.kitco.com");



            myParser.ExtractHrefFromBDS("https://batdongsan.com.vn/ban-nha-rieng-phuong-15-8", "ban-nha-rieng");

            myParser.ExtractDataFromBds("");

            //myParser.ExtractHrefNew("https://vnexpress.net");
            //myParser.ExtractHrefNew("https://dantri.com.vn");
            //myParser.ExtractHrefNew("https://cafef.vn/thi-truong-chung-khoan.chn");
            //myParser.ExtractHrefNew("https://thanhnien.vn/tai-chinh-kinh-doanh/");
        }
    }
}
