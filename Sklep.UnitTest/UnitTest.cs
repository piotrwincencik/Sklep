using Sklep.Controllers;
using Sklep.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sklep.Date.Base;
using Sklep.Date.Services;

namespace Sklep.UnitTest

{
    public class SklepControllerTest
    {
        [TestMethod]
        public void ProduktyService_Given_Id_Should_Get_Name()
        {
            //Arrange
            var produktId = 1;
            var expected = "AAA";
            var produkt = new Produkt() { Name = expected, Id = produktId };

            var produktRepositoryMock = new Mock<IEntityBaseRepository<Produkt>>();
            produktRepositoryMock.Setup(m => m.GetByID(produktId)).Returns(produkt).Verifiable();

            var unitOfWorkMock = new Mock<IProduktyService>();
            unitOfWorkMock.Setup(m => m.productRepository).Returns(productRepositoryMock.Object);

            IProduktyService sut = new ProduktyService(unitOfWorkMock.Object);
            //Act
            var actual = sut.GetProduktByIdAsync(produktId);

            //Assert
            produktRepositoryMock.Verify();//verify that GetByID was called based on setup.
            Assert.IsNotNull(actual);//assert that a result was returned
            Assert.AreEqual(expected, actual);//assert that actual result was as expected
        }
    }
}
