using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobilite
{
    class LineProvider : ILineProvider
    {
        private IMetroAPICall _metroAPICall;

        public LineProvider()
        {
            _metroAPICall = new MetroAPICall();
        }

        public Dictionary<string, Line> getLines(List<string> lineNames)
        {

            Dictionary<string, Line> myDict = new Dictionary<string, Line>();
            string myUrl = makeUrl(lineNames);
            if (myUrl == "") return myDict;
            List<Line> lineList = _metroAPICall.Get<List<Line>>(myUrl);


            foreach(Line line in lineList)
            {
                if (!myDict.ContainsKey(line.id))
                {
                    myDict.Add(line.id, line);
                }
            }

            return myDict;
        }

        private string makeUrl(List<string> lineNames)
        {
            if (lineNames.Count == 0) return "";

            string urlWithoutEndPoint = "routers/default/index/routes?codes=";
            string codes = "";

            foreach (string lineName in lineNames)
            {
                if (codes.Length != 0)
                {
                    codes += ",";
                }

                codes += lineName;
            }

            return urlWithoutEndPoint + codes;
        }
    }
}
