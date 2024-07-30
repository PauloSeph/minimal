using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimalAPIandCors.Models;

namespace minimalAPIandCors
{
    public static class PersonRoutes
    {

        public static List<Person> Persons = [
            new Person {Id = 1, Name = "Pedrin"},
            new Person {Id = 2, Name = "Valquiria"},
            new Person {Id = 3, Name = "Ungria"},
            new Person {Id = 4, Name = "Natalia"}
        ];

        public static void PersonRouteMaps(this WebApplication app)
        {
            app.MapGet("/person", () =>
                new { Name = "test" }
            );
        }
    }
}