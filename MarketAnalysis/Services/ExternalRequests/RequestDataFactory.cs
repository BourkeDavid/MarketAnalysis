using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis.Services.ExternalRequests
{
    /// <summary>
    /// Factory for returning the class used for requesting data
    /// </summary>
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

        /// <summary>
        /// Enum of data providers
        /// </summary>
        public enum RequstDataEnum
        {
            Yahoo
        }
    }
}
