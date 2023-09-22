using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.Domain;

namespace ShopTARge22.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstatesServices

    {
        private readonly ShopTARge22Context _context;
        public RealEstateServices
            (
                ShopTARge22Context context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.SizeSqrt = dto.SizeSqrt;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.UpdatedAt = DateTime.Now;

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;

        }

        public async Task<RealEstate> DetailsAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = dto.Id;
            realEstate.Address = dto.Address;
            realEstate.SizeSqrt = dto.SizeSqrt;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = dto.CreatedAt;
            realEstate.UpdatedAt = DateTime.Now;
            

            _context.RealEstates.Update(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realestatepId = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.RealEstates.Remove(realestatepId);
            await _context.SaveChangesAsync();

            return realestatepId;

        }
    }
}
