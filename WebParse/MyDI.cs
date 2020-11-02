using System;
using System.Collections.Generic;
using System.Text;

namespace WebParse
{
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

        public void ExtractLink(string URL)
        {
            myparser.ExtractLink(URL);
        }

        public void ExtractHref(string URL)
        {
            myparser.ExtractHref(URL);
        }

    }
}
