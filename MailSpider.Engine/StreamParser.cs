using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MailSpider.Engine
{
    public class StreamParser
    {
        private string _feed;
        //private const string EMAIL_REGEX = @"[\w\.=-]+@[\w\.-]+\.[\w]{2,3}";
        private const string EMAIL_REGEX = @"[A-Za-z0-9\.\<\>\/]*@[A-Za-z0-9\.\<\>\/]*";

        public StreamParser(string feed)
        {
            _feed = feed;
        }

        public List<string> Parse()
        {
            List<string> output = new List<string>();
            MatchCollection result = Regex.Matches(_feed, EMAIL_REGEX);
            foreach(Match m in result)
            {
                if(m.Value != "@media" && m.Value != "@")
                output.Add(m.Value);
            }
            
            return output;
        }

        
    }
}