using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MapView.Models;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Net;
using System.Device.Location;
using System.Web;




namespace MapView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        private List<Foodtruck> Getjsondata()
        {
            {
                using (WebClient webClient = new System.Net.WebClient())
                {
                    WebClient n = new WebClient();
                    var json = n.DownloadString("https://data.sfgov.org/resource/6a9r-agq8.json");
                 
                     List<Foodtruck> foodtruck = JsonConvert.DeserializeObject<List<Foodtruck>>(json);

                    return foodtruck;
                }
            }

        }

        public JsonResult Getfoodtruck(string lat, string lng ){

          var foodtrucks = Getjsondata();

            List<double> distances = new List<double>();
            List<NearbyFT> response = new List<NearbyFT>();

            var sCoord = new GeoCoordinate(Convert.ToDouble(lat), Convert.ToDouble(lng));

            foreach(Foodtruck truck in foodtrucks){

                var eCoord = new GeoCoordinate(Convert.ToDouble(truck.Latitude), Convert.ToDouble(truck.Longitude));
                var distance =  sCoord.GetDistanceTo(eCoord);


                if (distance < 1000.0) {
                    distances.Add(distance);
                    NearbyFT resp = new NearbyFT();
                    resp.lng = truck.Longitude;
                    resp.lat = truck.Latitude;
                    resp.title = truck.Locationdescription;

                    response.Add(resp);
                }
            }

            return Json(response);

        }
    }
}