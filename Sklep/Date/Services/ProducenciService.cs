using Sklep.Date.Base;
using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Date.Services
{
    public class ProducenciService: EntityBaseRepository<Producent>, IProducenciService
    {
        public ProducenciService(AppDbContext context) : base(context)
        {

        }
    }
}
