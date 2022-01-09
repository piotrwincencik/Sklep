using Sklep.Date.ViewModels;
using Sklep.Date.Base;
using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Date.Services
{
    public interface IProduktyService:IEntityBaseRepository<Produkt>
    {
        Task<Produkt> GetProduktByIdAsync(int id);
        Task<NewProduktDropdownsVM> GetNewProduktDropdownsValues();
        Task AddNewProduktAsync(NewProduktVM data);
        Task UpdateProduktAsync(NewProduktVM data);
    }
}
