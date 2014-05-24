using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis.Services.ExternalRequests
{
    public interface IRequestData
    {
        string RequestQuote(string[] symbols);
    }
}
