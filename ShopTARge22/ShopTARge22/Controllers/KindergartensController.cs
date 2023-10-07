using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Models.Kindergartens;

namespace ShopTARge22.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly IKindergartenServices _kindergartenServices;

        public KindergartensController
            (
            ShopTARge22Context context,
            IKindergartenServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher,
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult>Create (KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id= vm.Id,
                GroupName= vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName= vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };
            var result = await _kindergartenServices.Create(dto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

    }
}
