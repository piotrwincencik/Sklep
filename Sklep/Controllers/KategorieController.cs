using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sklep.Models;
using Sklep.Date.Services;

namespace Sklep.Controllers
{
    public class KategorieController : Controller
    {
    private readonly IKategorieService _service;

    public KategorieController(IKategorieService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allKategorie = await _service.GetAllAsync();
        return View(allKategorie);
    }

    //GET: kategoria/details/1
    public async Task<IActionResult> Details(int id)
    {
        var kategorieDetails = await _service.GetByIdAsync(id);
        if (kategorieDetails == null) return View("NotFound");
        return View(kategorieDetails);
    }

    //GET: kategoria/create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name,Description")] Kategoria kategoria)
    {
        if (!ModelState.IsValid) return View(kategoria);

        await _service.AddAsync(kategoria);
        return RedirectToAction(nameof(Index));
    }

    //GET: kategoria/edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var kategoriaDetails = await _service.GetByIdAsync(id);
        if (kategoriaDetails == null) return View("NotFound");
        return View(kategoriaDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Kategoria kategoria)
    {
        if (!ModelState.IsValid) return View(kategoria);

        if (id == kategoria.Id)
        {
            await _service.UpdateAsync(id, kategoria);
            return RedirectToAction(nameof(Index));
        }
        return View(kategoria);
    }

    //GET: producers/delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var kategoriaDetails = await _service.GetByIdAsync(id);
        if (kategoriaDetails == null) return View("NotFound");
        return View(kategoriaDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var kategoriaDetails = await _service.GetByIdAsync(id);
        if (kategoriaDetails == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
}
