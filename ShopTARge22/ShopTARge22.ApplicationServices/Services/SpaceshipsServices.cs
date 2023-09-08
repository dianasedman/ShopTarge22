using System;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Data;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShopTARge22Context _context;
        public SpaceshipsServices (ShopTARge22Context context) { _context = context; }
        public async Task<Spaceship> Create(SpaceshipDto dto)

        {
            Spaceship spaceship = new Spaceship();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.BuildDate = dto.BuildDate;
            spaceship.Passengers = dto.Passengers;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.Crew = dto.Crew;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            await _context.Spaceships.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
    }
}
