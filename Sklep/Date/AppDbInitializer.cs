using Sklep.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

                //Cinema
                if (!context.Kategorie.Any())
                {
                    context.Kategorie.AddRange(new List<Kategoria>()
                    {
                        new Kategoria()
                        {
                            Name = "Kategoria 1",
                            Description = "This is the description"
                        },
                        new Kategoria()
                        {
                            Name = "Kategoria  2",
                            Description = "This is the description"
                        },
                        new Kategoria()
                        {
                            Name = "Kategoria  3",
                            Description = "This is the description"
                        }
                    });
                    context.SaveChanges();
                }

                //Producers
                if (!context.Producenci.Any())
                {
                    context.Producenci.AddRange(new List<Producent>()
                    {
                        new Producent()
                        {
                            Pic = "https://files.fm/u/cg6wewbns#/view/unnamed2.png",
                            Name = "Producent 1",
                            Description = "This is the description"

                        },
                        new Producent()
                        {
                            Pic = "https://files.fm/u/cg6wewbns#/view/unnamed2.png",
                            Name = "Producent 2",
                            Description = "This is the description"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Produkty.Any())
                {
                    context.Produkty.AddRange(new List<Produkt>()
                    {
                        new Produkt()
                        {
                            Name = "Life",
                            Description = "This is the description",
                            Price = 39.50,
                            ImageURL = "1.jpg",
                            KategoriaId = 1,
                            ProducentId = 1
                        },
                        new Produkt()
                        {
                            Name = "Simple",
                            Description = "This is the description",
                            Price = 29.50,
                            ImageURL = "1.jpg",
                            KategoriaId = 2,
                            ProducentId = 2
                        },
                        new Produkt()
                        {
                            Name = "Is",
                            Description = "This is the description",
                            Price = 420.00,
                            ImageURL = "1.jpg",
                            KategoriaId = 3,
                            ProducentId = 1
                        },
                        new Produkt()
                        {
                            Name = "Veri",
                            Description = "This is the description",
                            Price = 39.50,
                            ImageURL = "1.jpg",
                            KategoriaId = 1,
                            ProducentId = 2
                        }
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
