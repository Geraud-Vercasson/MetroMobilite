using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace MetroMobilite
{
    class MetroAPICall : IMetroAPICall
    {
        private string _baseUrl;

        internal MetroAPICall()
        {
            _baseUrl = "http://data.metromobilite.fr/api/";
        }
        public T Get<T>(string urlFromEndpoint)
        {
            WebRequest request = WebRequest.Create(_baseUrl + urlFromEndpoint);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string jsonString = reader.ReadToEnd();
            response.Close();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
