using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWeatherAPI
{
    class City
    {
        const string APP_ID = "28f42846d5d8eeef56519508bf485887";

        private string name;
        private string temp;
        private string min;
        private string max;
        private string humidity;
        private string description;
        private string wind;
        private string realFeel;

        public string Name { get => name; set => name = value; }
        public string Temp { get => temp; set => temp = value; }
        public string Min { get => min; set => min = value; }
        public string Max { get => max; set => max = value; }
        public string Humidity { get => humidity; set => humidity = value; }
        public string Description { get => description; set => description = value; }
        public string Wind { get => wind; set => wind = value; }
        public string RealFeel { get => realFeel; set => realFeel = value; }

        public JObject response(string CityName)
        {

            string query = String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", CityName, APP_ID);
            JObject response = JObject.Parse(new System.Net.WebClient().DownloadString(query));

            return response;
        }

        public City(string CityName)
        {
            JObject api = response(CityName);

            Name = api.SelectToken("name").ToString();
            Temp = api.SelectToken("main.temp").ToString();
            Min = api.SelectToken("main.temp_min").ToString();
            Max = api.SelectToken("main.temp_max").ToString();
            Humidity = api.SelectToken("main.humidity").ToString();
            Description = api.SelectToken("weather[0].description").ToString();
            Wind = api.SelectToken("wind.speed").ToString();
            RealFeel = api.SelectToken("main.feels_like").ToString();
        }

        public string BaseQuery()
        {
            return response(this.Name).ToString();
        }
    }
}
