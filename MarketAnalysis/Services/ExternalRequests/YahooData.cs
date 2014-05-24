using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using MarketAnalysis.Services.ExternalRequests;

namespace MarketAnalysis.Services.ExternalRequests
{
    public class YahooData : IRequestData
    {
        public string RequestQuote(string[] symbols)
        {
            StringBuilder symbolBuilder = new StringBuilder();
            // Builds %22PLE.L%22%2C%22RMG.L%22
            for (int i = 0; i < symbols.Length; i++)
            {
                if (i < symbols.Length - 1)
                {
                    symbolBuilder.Append(string.Format("%22{0}%22%2C", symbols[i]));
                }
                else
                {
                    symbolBuilder.Append(string.Format("%22{0}%22", symbols[i]));
                }
            }
            string symbolsString = symbolBuilder.ToString();
            //string url = string.Format(@"http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})%0A%09%09&format=json&diagnostics=true&env=http%3A%2F%2Fdatatables.org%2Falltables.env&callback=", symbolsString);
            string requestString = string.Format(@"http://query.yahooapis.com/v1/public/yql?q=select%20symbol%2C%20Ask%2C%20Bid%2C%20PercentChange%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})&format=json&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=", symbolsString);
            string response = MakeRequest(requestString);
            return response;
        }

        private string MakeRequest(string requestString)
        {
            WebResponse response = null;
            string output = string.Empty;
            try
            {
                //WebProxy proxy = (WebProxy)WebProxy.GetDefaultProxy();
                //if (proxy.Address != null)
                //{
                //    proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                //    WebRequest.DefaultWebProxy = new System.Net.WebProxy(proxy.Address, proxy.BypassProxyOnLocal, proxy.BypassList, proxy.Credentials);
                //}

                WebRequest request = WebRequest.Create(requestString);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());

                writer.Close();
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        output = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                Errors.Instance.LogError(e.Message, e.StackTrace);
            }
            finally
            {
                if (response != null)
                {
                    var responseStream = response.GetResponseStream();
                    if (responseStream != null) responseStream.Close();
                }
            }
            return output;
        }
    }
}



