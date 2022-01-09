using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Models
{
    public class NewProduktVM
    {
        public int Id { get; set; }

        [Display(Name = "Produkt name")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Opis produktu")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }

        [Display(Name = "Cena w PLN")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        public double Price { get; set; }

        [Display(Name = "Zdjecie URL")]
        [Required(ErrorMessage = "Zdjecie jest wymagane")]
        public string ImageURL { get; set; }
		
        //relacje

        [Display(Name = "Wybierz kategorie")]
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        public int KategoriaId { get; set; }

        [Display(Name = "Wybierz producenta")]
        [Required(ErrorMessage = "Producent jest wymagany")]
        public int ProducentId { get; set; }
    }
}
