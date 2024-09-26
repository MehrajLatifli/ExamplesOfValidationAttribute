using ConsoleApp.Contexts;
using ConsoleApp.Models;
using ConsoleApp.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = Setting.GetServiceProvider().GetService<AppDbContext>())
            {
                Person person;
                while (true)
                {
                    person = new Person();

                    Console.WriteLine("Enter Name:");
                    person.Name = Console.ReadLine();

                    Console.WriteLine("Enter Email:");
                    person.Email = Console.ReadLine();

                    Console.WriteLine("Enter Password:");
                    person.Password = Console.ReadLine();


                    int age;
                    while (true)
                    {
                        Console.WriteLine("Enter Age (16-45):");
                        string ageInput = Console.ReadLine();

                        if (int.TryParse(ageInput, out age) && age >= 16 && age <= 45)
                        {
                            person.Age = age;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer between 16 and 45.");
                        }
                    }

                    var validationResults = new List<ValidationResult>();
                    var validationContext = new ValidationContext(person);

                    if (!Validator.TryValidateObject(person, validationContext, validationResults, true))
                    {

                        foreach (var validationResult in validationResults)
                        {
                            Console.WriteLine(validationResult.ErrorMessage);
                        }


                        await Task.Delay(2000);
                        Console.Clear();
                    }
                    else
                    {
                        person.Secretkey = Guid.NewGuid();
                        person.Permission = "Admin";

                        await context.Persons.AddAsync(person);
                        await context.SaveChangesAsync();


                        foreach (var item in await context.Persons.ToListAsync())
                        {
                            Console.WriteLine(item.ToString());
                        }

                        break;
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
