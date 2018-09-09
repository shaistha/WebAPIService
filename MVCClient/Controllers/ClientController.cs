using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCClient.Models;
using Newtonsoft.Json;

namespace MVCClient.Controllers
{
    public class ClientController : Controller
    {
        HttpClient _client;
        //Web API Service
        string url = "http://localhost:57587/api/APIService/readjsonfromfile?value=";

        public ClientController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ReadJsonData(CarDetails inputValue)
        {
            var id = inputValue.Data.First().ToString();
            //async calls to the Api service using URL 
            HttpResponseMessage responseMessage = await _client.GetAsync(url + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                //Deserialize the json data received from the API
                var data1 = JsonConvert.DeserializeObject<string>(responseData);
                var data = JsonConvert.DeserializeObject<CarDetails>(data1);

                //Write Json data to the file
                System.IO.File.WriteAllText(@"D:\jsonData.json", data.Data.ToString());

                using (StreamWriter file = System.IO.File.CreateText(@"D:\jsonData.json"))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, data);
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            return null;
        }
    }
}