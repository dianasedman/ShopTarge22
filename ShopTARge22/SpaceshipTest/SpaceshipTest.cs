using ShopTARge22.Core.Dto;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            SpaceshipDto spaceship = new();

            spaceship.Name = "Name";
            spaceship.Type = "kpof";
            spaceship.BuiltDate = DateTime.Now.AddYears(-3);
            spaceship.Passengers = 4512;
            spaceship.CargoWeight = 100;
            spaceship.Crew = 4388;
            spaceship.EnginePower = 100;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);


        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            //Arrange
            // kusime realestete, mida meil ei ole olemas
            SpaceshipDto spaceship = new();

            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("1e9606e8-6746-4105-8e74-f9e5fb7f8b09");

            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classi
            await Svc<ISpaceshipsServices>().DetailsAsync(guid);


            //Assert
            //assertimise vordlus, et vorrelda kahte guidi
            Assert.NotEqual(wrongGuid, guid);
        }
        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqualWithCreate()
        {
            //Arrange
            // kusime realestete, mida meil ei ole olemas
            SpaceshipDto spaceship = new();
            Guid guid = Guid.Parse("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");
            spaceship.Name = "Name";
            spaceship.Type = "kpof";
            spaceship.BuiltDate = DateTime.Now;
            spaceship.Passengers = 4512;
            spaceship.CargoWeight = 100;
            spaceship.Crew = 4388;
            spaceship.EnginePower = 100;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            //Assert
            Assert.NotEqual(result.Id, guid);
        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            Guid databaseguid = Guid.Parse("2e8646e8-6846-4105-8e74-f9e5fb7f8b09");
            Guid guid = Guid.Parse("2e8646e8-6846-4105-8e74-f9e5fb7f8b09");

            //Act
            await Svc<ISpaceshipsServices>().DetailsAsync(guid);


            //Assert
            Assert.Equal(databaseguid, guid);
        }

        [Fact]

        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

            Assert.Equal(addSpaceship, result);

        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "qwe",
                Type = "lkg",
                BuiltDate = DateTime.Now,
                Passengers = 64,
                CargoWeight = 658411,
                Crew = 13,
                EnginePower = 35135,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return spaceship;
        }
    }
}
