using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using GoogleTranslateFreeApi;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Controller
{
    public class APIDecorator : FileDataDecorator
    {
        public APIDecorator(IComponent data) : base(data) { }
        public override void WriteData(string text)
        {
            string response = GetTranslated(text, "en", "uk");

            base.WriteData(response);
        }

        public override string ReadData()
        {
            string data =  base.ReadData();

            string resultText = GetTranslated(data, "uk", "en");

            return resultText;
        }

        private string GetTranslated(string text, string from, string to)
        {
            string url = "https://google-translate105.p.rapidapi.com/v1/rapid/translate";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("X-RapidAPI-Key", "019cb831c8mshb8164d67aedd359p1f7515jsna15372892922");
            request.AddHeader("X-RapidAPI-Host", "google-translate105.p.rapidapi.com");
            request.AddParameter("application/x-www-form-urlencoded", $"text={text}&to_lang={to}&from_lang={from}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            JObject obj = JObject.Parse(response.Content);

            string decodedString = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(obj["translated_text"].ToString()));

            return decodedString;
        }

    }
}
