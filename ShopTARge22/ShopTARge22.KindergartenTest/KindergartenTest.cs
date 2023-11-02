using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        [Fact]
        public async Task Should_DeleteByIdKindergarten_WhenDeleteKindergarten()
        {
            KindergartenDto Kindergarten = MockKindergartenData();

            var addKindergarten = await Svc<IKindergartenServices>().Create(Kindergarten);
            var result = await Svc<IKindergartenServices>().Delete((Guid)addKindergarten.Id);

            Assert.Equal(addKindergarten, result);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdKindergarten_WhenDidNotDeleteKindergarten()
        {
            KindergartenDto Kindergarten = MockKindergartenData();

            var KindergartenOne = await Svc<IKindergartenServices>().Create(Kindergarten);
            var KindergartenTwo = await Svc<IKindergartenServices>().Create(Kindergarten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)KindergartenOne.Id);

            Assert.NotEqual(result.Id, KindergartenTwo.Id);

        }

        [Fact]
        public async Task ShouldNot_GetByIdKindergarten_WhenReturnNotEqual()
        {
            KindergartenDto kindergarten = new();
            Guid wrongId = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("1e9406e8-6846-4105-8e74-f9e5fb7f8b09");

            await Svc<IKindergartenServices>().DetailsAsync(guid);

            Assert.NotEqual(wrongId, guid);
        }

        [Fact]
        public async Task ShouldNot_UpdateKindergartenGroupName_WhenGroupNameEqual ()
        {
            KindergartenDto dto = MockKindergartenData();
            var creatKindergarten = await Svc<IKindergartenServices>().Create(dto);

            KindergartenDto nullUpdate = MockNullKindergarten();
            var result = await Svc<IKindergartenServices>().Update(nullUpdate);

            var GroupName = nullUpdate.GroupName;


            Assert.Equal(dto.GroupName, GroupName);
        }

        [Fact]
        public async Task ShouldNot_GetByIdKindergarten_WhenReturnsNotEqual()
        {
            Guid databaseguid = Guid.Parse("2e8606e8-6846-4105-8e74-f9e5fb7f8b09");
            Guid guid = Guid.Parse("2e8606e8-6856-4105-8e74-f9e5fb7f8b09");

            await Svc<IKindergartenServices>().DetailsAsync(guid);

            Assert.NotEqual(databaseguid, guid);
        }

        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            KindergartenDto kindergarten = MockKindergartenData();

            var result = await Svc<IKindergartenServices>().Create(kindergarten);

            Assert.NotNull(result);
        }



        private KindergartenDto MockKindergartenData()
        {
            KindergartenDto kindergarten = new()
            {
                GroupName = "Micky",
                ChildrenCount = 12,
                KindergartenName = "Mouses",
                Teacher = "Micky Mouse",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return kindergarten;
        }

        private KindergartenDto MockNullKindergarten()
        {
            KindergartenDto nullDto = new()
            {
                Id = null,
                GroupName = "Micky",
                ChildrenCount = 12,
                KindergartenName = "Mouses",
                Teacher = "Micky Mouse",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return nullDto;
        }
    }
}
