using Sklep.Controllers;
using Sklep.Date.Base;
using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepTestUnit2
{
    class EntityBaseRepository 
    {
        private Dictionary<int, Produkt> produkty = new Dictionary<int, Produkt>();
        private int index = 0;
        public Produkt Add(Produkt produkt)
        {
            produkt.Id = ++index;
            produkty.Add(produkt.Id, produkt);
            return produkt;
        }

        public void AddAuthorToBook(int authorId, int bookId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Produkt> FindAll()
        {
            return produkty.Values.ToList();
        }

        public Produkt GetByIdAsync(int id)
        {
            return produkty[id];
        }

        public Produkt UpdateAsync(Produkt produkt)
        {
            throw new NotImplementedException();
        }
    }
}
