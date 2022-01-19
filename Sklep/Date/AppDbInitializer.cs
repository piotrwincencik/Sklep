using Sklep.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Sklep.Date
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Kategoria
                if (!context.Kategorie.Any())
                {
                    context.Kategorie.AddRange(new List<Kategoria>()
                    {
                        new Kategoria()
                        {
                            Name = "Naklejka",
                            Description = "Naklejka 5x5cm"
                        },
                        new Kategoria()
                        {
                            Name = "Koszulka",
                            Description = "Koszulka standardowy krój"
                        },
                    });
                    context.SaveChanges();
                }
                //Producenct
                if (!context.Producenci.Any())
                {
                    context.Producenci.AddRange(new List<Producent>()
                    {
                        new Producent()
                        {
                            Name = "Producent",
                            Description = "Siema",
                            Pic = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg"

                        },
                        new Producent()
                        {
                            Name = "Producent",
                            Description = "Siema",
                            Pic = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg"

                        },
                        new Producent()
                        {
                            Name = "Producent",
                            Description = "Siema",
                            Pic = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg"

                        },
                        new Producent()
                        {
                            Name = "Producent",
                            Description = "Siema",
                            Pic = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg"

                        },
                        new Producent()
                        {
                            Name = "Producent",
                            Description = "Siema",
                            Pic = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg"

                        },
                    });
                    context.SaveChanges();
                }
                //Produkty
                if (!context.Produkty.Any())
                {
                    context.Produkty.AddRange(new List<Produkt>()
                    {
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the Life",
                            Price = 10,
                            ImageURL = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg",
                            KategoriaId = 3,
                            ProducentId = 3,
                        },
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the Life",
                            Price = 10,
                            ImageURL = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg",
                            KategoriaId = 3,
                            ProducentId = 3,
                        },
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the Life",
                            Price = 10,
                            ImageURL = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg",
                            KategoriaId = 3,
                            ProducentId = 3,
                        },
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the Life",
                            Price = 10,
                            ImageURL = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg",
                            KategoriaId = 3,
                            ProducentId = 3,
                        },
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the Life",
                            Price = 10,
                            ImageURL = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg",
                            KategoriaId = 3,
                            ProducentId = 3,
                        },
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the Life",
                            Price = 10,
                            ImageURL = "https://png.pngtree.com/element_pic/00/16/07/115783931601b5c.jpg",
                            KategoriaId = 3,
                            ProducentId = 3,
                        },
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
