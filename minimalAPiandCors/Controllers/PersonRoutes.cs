using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            app.MapGet("persons", () => Persons);

            app.MapGet("persons/{name}/{id}",
            (string name, int id) => Persons.Find(e => e.Name == name)
            );

            app.MapPost("persons", ([FromBody] Person person,
             HttpContext request,
            [FromQuery] string query) =>
            {         
                    Persons.Add(person);

                    var name = request.Request.Query["name"];

                    return Results.Ok(request.Request.Path);
            });

            app.MapPut("persons/{id:int}", (int id,  Person personUpdate) =>
            {
                var person = Persons.Find( p => p.Id == id);

                if (person == null)
                    return Results.NotFound();

                person.Name = personUpdate.Name;

                return Results.Ok(person);
            });
        }
    }
}