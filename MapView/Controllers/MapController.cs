using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNetCore.Mvc;
namespace MapView.Controllers
{
    public class MapController : Controller
    {
       

       
        [HttpPost]
        public JsonResult Index()
        {
            var latitude = Request.Form["lat"];
            var longitude = Request.Form["lng"];

            var location = new
            {
                latitude = latitude,
                longitude = longitude
            };

           

            return Json(new { status = "success", data = location });
        }
    }
}
