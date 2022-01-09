using Sklep.Date;
using Sklep.Date.Services;
using Sklep.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Controllers
{
    public class ProduktyController : Controller
    {
        private readonly IProduktyService _service;

        public ProduktyController(IProduktyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProdukty = await _service.GetAllAsync(n => n.Kategoria);
            return View(allProdukty);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProdukty = await _service.GetAllAsync(n => n.Kategoria);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allProdukty.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allProdukty.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allProdukty);
        }

        //GET: Produkty/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var produktDetail = await _service.GetProduktByIdAsync(id);
            return View(produktDetail);
        }

        //GET: Produkty/Create
        public async Task<IActionResult> Create()
        {
            var produktDropdownsData = await _service.GetNewProduktDropdownsValues();

            ViewBag.Kategorie = new SelectList(produktDropdownsData.Kategorie, "Id", "Name");
            ViewBag.Producenci = new SelectList(produktDropdownsData.Producenci, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProduktVM produkt)
        {
            if (!ModelState.IsValid)
            {
                var produktDropdownsData = await _service.GetNewProduktDropdownsValues();

                ViewBag.Kategoria = new SelectList(produktDropdownsData.Kategorie, "Id", "Name");
                ViewBag.Producenci = new SelectList(produktDropdownsData.Producenci, "Id", "Name");

                return View(produkt);
            }

            await _service.AddNewProduktAsync(produkt);
            return RedirectToAction(nameof(Index));
        }


        //GET: Produkty/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var produktDetails = await _service.GetProduktByIdAsync(id);
            if (produktDetails == null) return View("NotFound");

            var response = new NewProduktVM()
            {
                Id = produktDetails.Id,
                Name = produktDetails.Name,
                Description = produktDetails.Description,
                Price = produktDetails.Price,
                ImageURL = produktDetails.ImageURL,
                KategoriaId = produktDetails.KategoriaId,
                ProducentId = produktDetails.ProducentId,
            };

            var produktDropdownsData = await _service.GetNewProduktDropdownsValues();
            ViewBag.Kategorie = new SelectList(produktDropdownsData.Kategorie, "Id", "Name");
            ViewBag.Producenci = new SelectList(produktDropdownsData.Producenci, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProduktVM produkt)
        {
            if (id != produkt.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var produktDropdownsData = await _service.GetNewProduktDropdownsValues();

                ViewBag.Kategoria = new SelectList(produktDropdownsData.Kategorie, "Id", "Name");
                ViewBag.Producenci = new SelectList(produktDropdownsData.Producenci, "Id", "Name");

                return View(produkt);
            }

            await _service.UpdateProduktAsync(produkt);
            return RedirectToAction(nameof(Index));
        }
    }
}
