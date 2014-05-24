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
            
            string[] symbols = {"PLE.L"};
            
            Console.WriteLine(requestMarketData.RequestQuote(symbols));

        }
    }
}
