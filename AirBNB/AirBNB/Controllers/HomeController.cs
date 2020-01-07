using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AirBNB.Models;
using AirBNB.DAL;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;

namespace AirBNB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, AirBNBContext context)
        {
            _logger = logger;
            unitOfWork = new UnitOfWork(context);
        }

        public IActionResult Index()
        {
            FeatureCollection featureCollection = new FeatureCollection();

            foreach (var listings in unitOfWork.Listings.GetAll()) {
                featureCollection.Features.Add(
                    new Feature(
                        new Point(
                             new Position((string)listings.Latitude.GetValueOrDefault(0).ToString().Replace(',', '.'), (string)listings.Longitude.GetValueOrDefault(0).ToString().Replace(',', '.')))));
                           // new Position((double)listings.Latitude, (double)listings.Longitude))));
            }

            return View(new JsonResult(JsonConvert.SerializeObject(featureCollection)));
        }


        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
