using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MailSpider.Engine
{
    public class Spider
    {

        public const string QUERY_TEMPLATE = @"http://www.google.it/search?hl=it&q={0}+{1}";
        public const string QUERY_TEMPLATE2 = @"http://www.google.it/search?hl=it&q={0}";
        public event EventHandler<ResultsFoundEventArgs> ResultsFound;
        public void DoSearch(string searchParameter)
        {
            StreamGetter getter = new StreamGetter(string.Format(QUERY_TEMPLATE,searchParameter,"email"));
            StreamParser parser = new StreamParser(getter.GetPageStream());
            if (ResultsFound != null) ResultsFound(this, new ResultsFoundEventArgs(parser.Parse()));
            StreamGetter getter2 = new StreamGetter(string.Format(QUERY_TEMPLATE, searchParameter, "mail"));
            StreamParser parser2 = new StreamParser(getter2.GetPageStream());
            if (ResultsFound != null) ResultsFound(this, new ResultsFoundEventArgs(parser2.Parse()));
            StreamGetter getter3 = new StreamGetter(string.Format(QUERY_TEMPLATE2, searchParameter));
            StreamParser parser3 = new StreamParser(getter3.GetPageStream());
            if (ResultsFound != null) ResultsFound(this, new ResultsFoundEventArgs(parser3.Parse()));
        }

    }

    public class ResultsFoundEventArgs : EventArgs
    {

        public IList<string> Results { get; private set; }

        public ResultsFoundEventArgs(IList<string> results)
        {
            Results = results;
        }

        
       
    }
}
