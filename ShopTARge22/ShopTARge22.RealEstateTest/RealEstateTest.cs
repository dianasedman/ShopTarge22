using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto realEstate = new();

            realEstate.Address = "asd";
            realEstate.SizeSqrt = 1024;
            realEstate.RoomCount = 5;
            realEstate.Floor = 3;
            realEstate.BuildingType = "asda";
            realEstate.BuiltInYear = DateTime.Now;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.UpdatedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstatesServices>().Create(realEstate);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            // kusime realestete, mida meil ei ole olemas
            RealEstateDto realEstate = new();

            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("1e9606e8-6846-4105-8e74-f9e5fb7f8b09");

            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classi
            await Svc<IRealEstatesServices>().DetailsAsync(guid);


            //Assert
            //assertimise vordlus, et vorrelda kahte guidi
            Assert.NotEqual(wrongGuid, guid);

        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqualWithCreate()
        {
            //Arrange
            // kusime realestete, mida meil ei ole olemas
            RealEstateDto realEstate = new();
            Guid guid = Guid.Parse("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");
            realEstate.Address = "asd";
            realEstate.SizeSqrt = 1024;
            realEstate.RoomCount = 5;
            realEstate.Floor = 3;
            realEstate.BuildingType = "asda";
            realEstate.BuiltInYear = DateTime.Now;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.UpdatedAt = DateTime.Now;

            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classi
            var result = await Svc<IRealEstatesServices>().Create(realEstate);

            //await Svc<IRealEstatesServices>().DetailsAsync(guid);


            //Assert
            //assertimise vordlus, et vorrelda kahte guidi
            Assert.NotEqual(result.Id, guid);
        }
        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            Guid databaseguid = Guid.Parse("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");
            Guid guid = Guid.Parse("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");



            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classi
            await Svc<IRealEstatesServices>().DetailsAsync(guid);


            //Assert
            //assertimise vordlus, et vorrelda kahte guidi
            Assert.Equal(databaseguid, guid);
        }

        [Fact]

        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            RealEstateDto RealEstate = MockRealEstateData();

            var addRealEstate = await Svc<IRealEstatesServices>().Create(RealEstate);
            var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate.Id);

            Assert.Equal(addRealEstate, result);

        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            RealEstateDto RealEstate = MockRealEstateData();

            var RealEstate1 = await Svc<IRealEstatesServices>().Create(RealEstate);
            var RealEstate2 = await Svc<IRealEstatesServices>().Create(RealEstate);

            var result = await Svc < IRealEstatesServices >(). Delete((Guid)RealEstate2.Id);

            Assert.NotEqual(result.Id, RealEstate1.Id);

        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDara()
        {
            // vaja luua guid, mida hakkame kasutama update puhul

            var guid = new Guid("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");
            RealEstateDto dto = MockRealEstateData();


            // vaja saada domainist andmed katte
            RealEstate realEstate = new();
            realEstate.Id = Guid.Parse("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");
            realEstate.Address = "Aadresslll";
            realEstate.SizeSqrt = 568;
            realEstate.RoomCount = 9;
            realEstate.Floor = 9;
            realEstate.BuildingType = "dnfo";
            realEstate.BuiltInYear = DateTime.Now.AddYears(1);

            await Svc<IRealEstatesServices>().Update(dto);

            Assert.Equal(realEstate.Id, guid);
            Assert.DoesNotMatch(realEstate.Address, dto.Address);
            Assert.DoesNotMatch(realEstate.Floor.ToString(), dto.Floor.ToString());
            Assert.NotEqual(realEstate.RoomCount, dto.RoomCount);




            //kasutan domain andmed
        }
        [Fact]

        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()

        {
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstatesServices>().Create(dto);

            RealEstateDto update = MockUpdateRealEstateData();
            var result = await Svc<IRealEstatesServices>().Update(update);

            Assert.DoesNotMatch(result.Address, createRealEstate.Address);
            Assert.NotEqual(result.UpdatedAt, createRealEstate.UpdatedAt);
            //Assert.Equal(result.CreatedAt, createRealEstate.CreatedAt);
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Address = "qwe",
                SizeSqrt = 134,
                RoomCount = 5,
                Floor = 6,
                BuildingType = "asda",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
        };
            return realEstate;
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Address = "qwe",
                SizeSqrt = 134123,
                RoomCount = 54,
                Floor = 63,
                BuildingType = "asda",
                BuiltInYear = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now.AddYears(1),
            };
            return realEstate;
        }

    }
}
