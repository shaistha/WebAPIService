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
            HttpResponseMessage responseMessage = await _client.GetAsync(url + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var data1 = JsonConvert.DeserializeObject<string>(responseData);
                var data = JsonConvert.DeserializeObject<CarDetails>(data1);

                System.IO.File.WriteAllText(@"D:\jsonData.json", data.Data.ToString());

                using (StreamWriter file = System.IO.File.CreateText(@"D:\jsonData.json"))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, data);
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            return null;
        }
    }
}