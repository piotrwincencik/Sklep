using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Date.ViewModels
{
    public class NewProduktDropdownsVM
    {
        public NewProduktDropdownsVM()
        {
            Producenci = new List<Producent>();
            Kategorie = new List<Kategoria>();
        }

        public List<Producent> Producenci { get; set; }
        public List<Kategoria> Kategorie { get; set; }
    }
}
