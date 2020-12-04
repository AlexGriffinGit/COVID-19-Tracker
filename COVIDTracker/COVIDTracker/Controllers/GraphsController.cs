using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Controllers
{
    public class GraphsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            var emptyList = new List<Tuple<int, DateTime>>()
                 .Select(t => new { Count = t.Item1, Name = t.Item2 }).ToList();

            var client = new RestClient("https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=nation;areaName=england&structure={%22date%22:%22date%22,%22areaName%22:%22areaName%22,%22areaCode%22:%22areaCode%22,%22newCasesByPublishDate%22:%22newCasesByPublishDate%22,%22cumCasesByPublishDate%22:%22cumCasesByPublishDate%22,%22newDeathsByDeathDate%22:%22newDeathsByDeathDate%22,%22cumDeathsByDeathDate%22:%22cumDeathsByDeathDate%22}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var bulkPost = JObject.Parse(response.Content);
            for (int i = 334; i > 0; i -= 10)
            {
                var deaths = bulkPost["data"][i]["newCasesByPublishDate"];
                int deathtoadd = 0;
                if (deaths.Type != JTokenType.Null)
                {
                    deathtoadd = (int)deaths;
                }
                var date = (DateTime)bulkPost["data"][i]["date"];
                emptyList.Add(new
                {
                    Count = deathtoadd,
                    Name = date
                });
            }
            return Json(emptyList);
        }
    }
}
