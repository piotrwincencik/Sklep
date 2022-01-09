using Sklep.Date.Base;
using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Date.Services
{
    public class KategorieService: EntityBaseRepository<Kategoria>, IKategorieService
    {
        public KategorieService(AppDbContext context) : base(context)
        {

        }
    }
}
