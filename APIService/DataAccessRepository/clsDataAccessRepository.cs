using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using APIService.Models;
using Newtonsoft.Json.Linq;
using System.IO;

namespace APIService.DataAccessRepository
{
    public class clsDataAccessRepository : IDataAccessRepository
    {
        //Load Json from a file
        public string LoadJsonFromFile(string value)
        {
            Car detailsData;
            using (StreamReader file = File.OpenText(@"D:\jsonData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                detailsData = (Car)serializer.Deserialize(file, typeof(Car));
                if(value == "A-A-A")
                {
                    detailsData.data[0] = "Fiat";
                    detailsData.data[1] = "BMW";
                    detailsData.data[2] = "Ford";
                    return JsonConvert.SerializeObject(detailsData);
                }
                else if(value == "A-A")
                {
                    detailsData.data[0] = "BMW";
                    detailsData.data[1] = "Ford";
                    detailsData.data[2] = "Fiat";
                    return JsonConvert.SerializeObject(detailsData);
                }
                return JsonConvert.SerializeObject(detailsData);
            }
        }
    }
}