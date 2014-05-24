using MarketAnalysis.Model;
using MarketAnalysis.Services.ExternalRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {

            IRequestData requestMarketData = RequestDataFactory.GetInstance(RequestDataFactory.RequstDataEnum.Yahoo);            
            
           // string[] symbols = {"PLE.L"};
            string[] symbols = { "PLE.L", "RMG.L" };
            requestMarketData.RequestQuote(symbols);
            ICollection<Quote> quotes = requestMarketData.GetQuotes();


            foreach(Quote quote in quotes)
            {
                Console.WriteLine(quote.Ask);
            }
            

        }
    }
}
