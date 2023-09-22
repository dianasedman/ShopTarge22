using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Models.RealEstate;

namespace ShopTARge22.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly IRealEstatesServices _realEstatesServices;

        public RealEstatesController
            (
                ShopTARge22Context context,
                IRealEstatesServices realEstates
            )
        {
            _context = context;
            _realEstatesServices = realEstates;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    SizeSqrt = x.SizeSqrt,
                    BuildingType = x.BuildingType,
                    BuiltInYear = x.BuiltInYear
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel vm = new ();

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        
        public async Task<IActionResult>Create (RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrt = vm.SizeSqrt,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };
            var result = await _realEstatesServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult>Update(Guid id)
        {
            var realestate = await _realEstatesServices.DetailsAsync(id);
            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel();
            vm.Id = realestate.Id;
            vm.Address = realestate.Address;
            vm.RoomCount = realestate.RoomCount;
            vm.Floor = realestate.Floor;
            vm.BuildingType = realestate.BuildingType;
            vm.BuiltInYear = realestate.BuiltInYear;
            vm.CreatedAt = realestate.CreatedAt;
            vm.UpdatedAt = realestate.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult>Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrt = vm.SizeSqrt,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };
            var result = await _realEstatesServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realestate = await _realEstatesServices.DetailsAsync(id);
            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDetailsViewModel();
            vm.Id = realestate.Id;
            vm.Address = realestate.Address;
            vm.SizeSqrt = realestate.SizeSqrt;
            vm.RoomCount = realestate.RoomCount;
            vm.Floor = realestate.Floor;
            vm.BuildingType = realestate.BuildingType;
            vm.BuiltInYear = realestate.BuiltInYear;
            vm.CreatedAt = realestate.CreatedAt;
            vm.UpdatedAt = realestate.UpdatedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstatesServices.DetailsAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDeleteViewModel();
            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrt = realEstate.SizeSqrt;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType= realEstate.BuildingType;
            vm.BuiltInYear= realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt= realEstate.UpdatedAt;

            return View(vm) ;
        }

        [HttpPost]
        public async Task<IActionResult>DeleteConfirmation(Guid id)
        {
            var realestateId = await _realEstatesServices.Delete(id);
            if (realestateId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
