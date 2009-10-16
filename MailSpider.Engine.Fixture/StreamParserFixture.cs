using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace MailSpider.Engine.Fixture
{
    [TestFixture]
    public class StreamParserFixture
    {
        [Test]
        public void StreamParser_NoEmailInString_NoResults()
        {
            StreamParser parser = new StreamParser("lsdfhdsfhsdf");
            IList<string> result = parser.Parse();
            Assert.AreEqual(result.Count(), 0);
        }     

    }
}
