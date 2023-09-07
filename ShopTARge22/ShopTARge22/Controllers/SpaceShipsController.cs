using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Data;
using ShopTARge22.Models.SpaceShips;

namespace ShopTARge22.Controllers
{
    public class SpaceShipsController : Controller
    {
        private readonly ShopTARge22Context _context;

        public SpaceShipsController
            (
                ShopTARge22Context context
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuildDate = x.BuildDate,
                    Passengers = x.Passengers,
                });

            return View();
        }
    }
}
