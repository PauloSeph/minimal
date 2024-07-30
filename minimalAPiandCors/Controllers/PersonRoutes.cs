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
            app.MapGet("/persons", () => Persons);

            app.MapGet("/persons/{name}/{id}",
            (string name, int id) => Persons.Find(e => e.Name == name)
            );

            app.MapPost("/pessoas", (Person person) => {

                if (person.Id > 0 && person.Name!.Length > 0)
                {
                    Persons.Add(person);
                    return Results.Ok(person);
                } else {
                    return Results.BadRequest();
                }
       
            });
        }
    }
}