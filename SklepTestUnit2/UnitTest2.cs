using FakeItEasy;
using System;
using Xunit;
using Sklep.Models;
using Sklep.Controllers;
using Sklep.Date;
using Sklep.Date.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SklepTestUnit2
{
    public class ApiProduktyControllerTest
    {
        [Fact]
        public void GetAsyncProduktyTest()
        {
            EntityBaseRepository repository = new EntityBaseRepository();
            repository.Add(new Sklep.Models.Produkt() { Name = "TEST" });
            repository.Add(new Sklep.Models.Produkt() { Name = "TEST" });
            ProduktyController controllerTest = new ProduktyController(repository);
            System.Collections.Generic.IList<Sklep.Models.Produkt> produkt = controllerTest.GetProduktByIdAsync();
            Assert.Equal(2, produkty.Count);
        }

        public void DeleteABookTest()
        {
            EntityBaseRepository repository = new EntityBaseRepository();
            repository.Add(new Sklep.Models.Produkt() { Name = "TEST" });
            repository.Add(new Sklep.Models.Produkt() { Name = "TEST" });
            ProduktyController controllerTest = new ProduktyController(repository);
            Microsoft.AspNetCore.Mvc.IActionResult actionResult = controllerTest.DeleteProdukt(2);
            Assert.IsType<OkResult>(actionResult);
            actionResult = controllerTest.DeleteProdukt(6);
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}
