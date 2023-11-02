using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using ShopTARge22.Core.Dto.WeatherDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models;
using ShopTARge22.Models.Forecast;

namespace ShopTARge22.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;
        public ChuckNorrisController
            (IChuckNorrisServices chuckNorrisServices)
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }
        //[HttpPost]
        //public IActionResult SearchChuckNorris(ChuckNorrisViewModel model)
        //{ if (ModelState.IsValid)
        //    {
        //        RedirectToAction("Chuck", "Norris", new { norris = model.NorrisName });
        //    }

        //}

        public IActionResult Chuck()
        {
            OpenChuckNorrisResultDto dto = new();

            _chuckNorrisServices.OpenChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            vm.Categories = dto.Categories;
            vm.Value = dto.Value;

            return View(vm);
        }
    }
}
