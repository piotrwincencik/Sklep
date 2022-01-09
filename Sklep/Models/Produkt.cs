using Sklep.Date.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Models
{
    public class Produkt:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Musisz nadać nazwę.")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Musisz dodać opis.")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Musisz dodać cenę.")]
        public double Price { get; set; }
        [Display(Name = "ImageURL")]
        [Required(ErrorMessage = "Musisz dodać zdjęcie.")]
        public string ImageURL { get; set; }

        //relacje

        //kategoria
        public int KategoriaId { get; set; }
        [ForeignKey("KategoriaId")]
        public Kategoria Kategoria { get; set; }

        //producent
        public int ProducentId { get; set; }
        [ForeignKey("ProducentId")]
        public Producent Producent { get; set; }
    }
}
