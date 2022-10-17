using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace WeatherTideStormglass
{
    internal class WebRequestData
    {
        public DeserializeTide _tide { get; set; }
        public DeserializeWeather _weather { get; set; }
        public WebRequestData()
        {
            const string lat = "lat=" + "-6.200000";
            const string lng = "lng=" + "106.816666";
            const string WEBSERVICE_URL_TIDE = "https://api.stormglass.io/v2/tide/extremes/point?" + lat + "&" + lng;
            const string WEBSERVICE_URL_WEATHER = "https://api.stormglass.io/v2/weather/point?" + lat + "&" + lng + "&params=airTemperature";
            try
            {
                WebRequest webRequestTide = WebRequest.Create(WEBSERVICE_URL_TIDE);
                WebRequest webRequestWeather = WebRequest.Create(WEBSERVICE_URL_WEATHER);

                if (webRequestTide != null && webRequestWeather != null)
                {
                    webRequestTide.Method = "GET";
                    webRequestTide.Timeout = 12000;
                    webRequestTide.ContentType = "application/json";
                    webRequestTide.Headers.Add("Authorization", "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002");

                    webRequestWeather.Method = "GET";
                    webRequestWeather.Timeout = 12000;
                    webRequestWeather.ContentType = "application/json";
                    webRequestWeather.Headers.Add("Authorization", "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002");

                    Stream st = webRequestTide.GetResponse().GetResponseStream();
                    StreamReader str = new StreamReader(st);

                    Stream sw = webRequestWeather.GetResponse().GetResponseStream();
                    StreamReader swr = new StreamReader(sw);

                    var jsonResponseTide = str.ReadToEnd();
                    var dataTide = JsonConvert.DeserializeObject<DeserializeTide>(jsonResponseTide);
                    _tide = dataTide;

                    var jsonResponseWeather = swr.ReadToEnd();
                    var dataWeather = JsonConvert.DeserializeObject<DeserializeWeather>(jsonResponseWeather);
                    _weather = dataWeather;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public DeserializeTide returnDataTide()
        {
            return _tide;
        }
    }
}
