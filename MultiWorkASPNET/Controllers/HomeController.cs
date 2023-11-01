using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiWorkASPNET.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultiWorkASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewPageIndex(ImageAndDescriptionModel imageAndDescriptionModel)
        {
            if (imageAndDescriptionModel.Image != null)
            {
                // Получение массива байтов изображения
                byte[] imageData;
                using (var memoryStream = new MemoryStream())
                {
                    imageAndDescriptionModel.Image.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }

                // Установка массива байтов в модели
                imageAndDescriptionModel.ImageData = imageData;
            }
            return View(imageAndDescriptionModel);
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
