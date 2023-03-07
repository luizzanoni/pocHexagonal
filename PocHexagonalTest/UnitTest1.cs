using Application.Services;
using Domain.Adapters;
using Domain.Entities;
using Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PocHexagonalTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var curintcha = new Club
            {
                Id = 1,
                Name = "Curintcha"
            };
            var parmeira = new Club
            {
                Id = 2,
                Name = "Parmeira"
            };
            var santos = new Club
            {
                Id = 3,
                Name = "Peixe"
            };
            var clubList = new List<Club> {
                curintcha,
                parmeira,
                santos
            };           
            Mock<IClubRepository> mock = new Mock<IClubRepository>();
            mock.Setup(m => m.GetAll()).Returns(Task.FromResult(clubList.AsEnumerable()));
            var service = new ClubServiceManager(mock.Object);

            var curintchaRes = new Club
            {
                Id = 1,
                Name = "Aqui � Curintcha, mano!"
            };
            var parmeiraRes = new Club
            {
                Id = 2,
                Name = "Aqui � Parmeira, meu!"
            };
            var santosRes = new Club
            {
                Id = 3,
                Name = "Peixe"
            };
            var expectedRes = new List<Club> {
                curintchaRes,
                parmeiraRes,
                santosRes
            };
            var expectedResult = Task.FromResult(expectedRes.AsEnumerable());

            // act
            var clubs = service.RecoverAllClubs();
            

            // assert
            Assert.Equivalent(expectedResult.Result, clubs.Result);
        }
    }
}