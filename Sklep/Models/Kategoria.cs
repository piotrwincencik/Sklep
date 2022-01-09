using Sklep.Date.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Models
{
    public class Kategoria:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Musisz nadać nazwę.")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Musisz dodać opis.")]
        public string Description { get; set; }

        //relacja
        public List<Produkt> Produkty { get; set; }
    }
}
