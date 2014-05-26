using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis.Model
{
    public class QuoteHistory
    {
        public ICollection<Quote> Quotes;

        public QuoteHistory()
        {
            Quotes = new List<Quote>();
        }

        public void AddQuote(Quote quote)
        {
            Quotes.Add(quote);
        }

        public void AddQuotes(ICollection<Quote> quotes)
        {
            foreach(Quote quote in quotes)
            {
                Quotes.Add(quote);
            }
        }

        
    }
}
