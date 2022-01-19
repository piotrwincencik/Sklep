using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sklep.Date.Services;
using Sklep.Models;

namespace Sklep.Controllers
{
    public class ProducenciController : Controller
    {
        private readonly IProducenciService _service;

        public ProducenciController(IProducenciService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducenci = await _service.GetAllAsync();
            return View(allProducenci);
        }

        //GET: Producenci/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producentDetails = await _service.GetByIdAsync(id);
            if (producentDetails == null) return View("NotFound");
            return View(producentDetails);
        }

        //GET: Producencis/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Pic,Name,Description")] Producent producent)
        {
            if (!ModelState.IsValid) return View(producent);

            await _service.AddAsync(producent);
            return RedirectToAction(nameof(Index));
        }

        //GET: Producenci/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producentDetails = await _service.GetByIdAsync(id);
            if (producentDetails == null) return View("NotFound");
            return View(producentDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pic,Name,Description")] Producent producent)
        {
            if (!ModelState.IsValid) return View(producent);

            if (id == producent.Id)
            {
                await _service.UpdateAsync(id, producent);
                return RedirectToAction(nameof(Index));
            }
            return View(producent);
        }

        //GET: producent/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producentDetails = await _service.GetByIdAsync(id);
            if (producentDetails == null) return View("NotFound");
            return View(producentDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producentDetails = await _service.GetByIdAsync(id);
            if (producentDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

