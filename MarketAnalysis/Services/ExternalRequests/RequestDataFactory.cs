using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis.Services.ExternalRequests
{
    public static class RequestDataFactory
    {
        public static IRequestData GetInstance(RequstDataEnum requestDataEnum)
        {
            switch (requestDataEnum)
            {
                case RequstDataEnum.Yahoo:
                    return new YahooData();
                
                default:
                    return new YahooData();
            }   
        }

        public enum RequstDataEnum
        {
            Yahoo
        }
    }
}
