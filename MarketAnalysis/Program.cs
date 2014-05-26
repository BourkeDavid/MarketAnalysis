using MarketAnalysis.Model;
using MarketAnalysis.Services.ExternalRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {

            QuoteHistory quoteHistory = new QuoteHistory();
            IRequestData requestMarketData = RequestDataFactory.GetInstance(RequestDataFactory.RequstDataEnum.Yahoo);            
            

           // string[] symbols = {"PLE.L"};
            string[] symbols = { "PLE.L", "RMG.L" };

            int limit = 10;
            int counter = 0;
            while (counter++ < limit)
            {
                requestMarketData.RequestQuote(symbols);
                ICollection<Quote> quotes = requestMarketData.GetQuotes();
                quoteHistory.AddQuotes(quotes);
                Thread.Sleep(1000); 
            }

            ICollection<Quote> allQuotes = quoteHistory.Quotes;
            foreach(Quote quote in allQuotes)
            {
                Console.WriteLine(quote.Ask);
            }
            Console.ReadLine();
            

        }
    }
}
