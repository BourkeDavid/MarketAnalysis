using MarketAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis.Services.ExternalRequests
{
    /// <summary>
    /// Interface for requesting market data
    /// </summary>
    public interface IRequestData
    {
        void RequestQuote(string[] symbols);
        string QuoteString {get; }
        ICollection<Quote> GetQuotes();
    }
}
