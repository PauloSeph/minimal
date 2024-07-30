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
            app.MapGet("person", () => Persons);

            app.MapGet("person/{name}/{id}",
            (string name, int id) => Persons.Find(e => e.Name == name)
            );

            app.MapPost("person", ([FromBody] Person person,
             HttpContext request,
            [FromQuery] string query) =>
            {
                Persons.Add(person);

                var name = request.Request.Query["name"];

                return Results.Ok(request.Request.Path);
            });

            app.MapPut("person/{id:int}", (int id, Person personUpdate) =>
            {
                var person = Persons.Find(p => p.Id == id);

                if (person == null)
                    return Results.NotFound();

                person.Name = personUpdate.Name;

                return Results.Ok(person);
            });
            app.MapDelete("person/{id:int}", (int id) =>
            {
                var person = Persons.Find(p => p.Id == id);

                if (person == null)
                    return Results.NotFound();

                Persons.Remove(person);

                Console.WriteLine(Persons);

                return Results.Ok("Removido com sucesso!");
            });



        }
    }
}