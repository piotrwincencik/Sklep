using Microsoft.EntityFrameworkCore;
using Sklep.Date.Base;
using Sklep.Date.ViewModels;
using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sklep.Date.Services
{
    public class ProduktyService:EntityBaseRepository<Produkt>, IProduktyService
    {
        private readonly AppDbContext _context;
        public ProduktyService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProduktAsync(NewProduktVM data)
        {
            var newProdukt = new Produkt()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                KategoriaId = data.KategoriaId,
                ProducentId = data.ProducentId
            };
            await _context.Produkty.AddAsync(newProdukt);
            await _context.SaveChangesAsync();
        }

        public async Task<Produkt> GetProduktByIdAsync(int id)
        {
            var produktDetails = await _context.Produkty
                .Include(c => c.Kategoria)
                .Include(p => p.Producent)
                .FirstOrDefaultAsync(n => n.Id == id);

            return produktDetails;
        }

        public async Task<NewProduktDropdownsVM> GetNewProduktDropdownsValues()
        {
            var response = new NewProduktDropdownsVM()
            {
                Kategorie = await _context.Kategorie.OrderBy(n => n.Name).ToListAsync(),
                Producenci = await _context.Producenci.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateProduktAsync(NewProduktVM data)
        {
            var dbProdukt = await _context.Produkty.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProdukt != null)
            {
                dbProdukt.Name = data.Name;
                dbProdukt.Description = data.Description;
                dbProdukt.Price = data.Price;
                dbProdukt.ImageURL = data.ImageURL;
                dbProdukt.ProducentId = data.ProducentId;
                await _context.SaveChangesAsync();
            }
        }
    }
}

