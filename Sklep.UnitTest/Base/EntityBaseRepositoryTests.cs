using Sklep.Models;
using Sklep.Date.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.UnitTest.Models
{
    class EntityBaseRepositoryTests
    {
        private Dictionary<int, Produkt> produkt = new Dictionary<int, Produkt>();
        private int index = 0;
        public Produkt Add(Produkt produkt)
        {
            produkt.Id = ++index;
            produkt.Add(produkt.Id, produkt);
            return produkt;
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Produkt UpdateAsync(Produkt produkt)
        {
            throw new NotImplementedException();
        }
    }
}
