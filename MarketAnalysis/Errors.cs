using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalysis
{

    public class Errors
    {
        private static Errors instance;

        private Errors() { }

        public static Errors Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Errors();
                }
                return instance;
            }
        }

        public List<string> ErrorList { get; set; }

        public void LogError(string errorMessage, string stackTrace)
        {
            InitialiseErrorLog();
            string errorString = string.Format("{0} | {1}", errorMessage, stackTrace);
            ErrorList.Add(errorString);
        }

        public List<string> GetAllErrors()
        {
            InitialiseErrorLog();
            return ErrorList;
        }

        private void InitialiseErrorLog()
        {
            if (ErrorList == null)
            {
                ErrorList = new List<string>();
            }
        }
    }
}
