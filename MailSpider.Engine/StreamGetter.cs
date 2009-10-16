using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MailSpider.Engine
{
    public class StreamGetter
    {

        private readonly string _query;

        public StreamGetter(string query)
        {
            _query = query;
        }

        public string GetPageStream()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_query);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            byte[] buffer = new byte[8192];
            StringBuilder stringBuilder = new StringBuilder();
            string tempString = null;
            int count = 0;
            do
            {

                count = responseStream.Read(buffer, 0, buffer.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buffer, 0, count);
                    stringBuilder.Append(tempString);
                }
            } while (count > 0);

            return stringBuilder.ToString();
        }
    }
}
