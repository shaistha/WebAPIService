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
            //Read json from json file from D drive. Sample json is on git
            using (StreamReader file = File.OpenText(@"D:\jsonData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                //deserialize json data to check if the input value is A-A-A or A-A 
                detailsData = (Car)serializer.Deserialize(file, typeof(Car));

                if (value == "A-A-A")
                {
                    //if input is A-A-A -> reverse the priority in json array
                    detailsData.data.Reverse();
                    
                    //serialize the json data to send it over to the client
                    return JsonConvert.SerializeObject(detailsData);
                }
                else if (value == "A-A")
                {
                    //Storing the first element of array in a temporary variable
                    var tempData = detailsData.data[0];
                    
                    //assign second element of array to be the first element.
                    detailsData.data[0] = detailsData.data[1];

                    //Assign value stored in temporary variable to be the second element
                    detailsData.data[1] = tempData;
                    detailsData.data[2] = detailsData.data[2];

                    return JsonConvert.SerializeObject(detailsData);
                }

                return JsonConvert.SerializeObject(detailsData);
            }
        }
    }
}