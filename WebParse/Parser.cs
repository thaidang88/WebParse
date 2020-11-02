using System;
using System.Collections.Generic;
using System.Text;

namespace WebParse
{
    public interface Parser
    {
        void ParseWeb();
        void ExtractGoldPrice(String url);

        void ExtractLink(String url);

        void ExtractHref(String url);

        void ExtractGoldKitco(String url);
    }
}
