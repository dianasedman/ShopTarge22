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
            Assert.Null(result);
        }
    }
}
