using ConsoleApp.Attributes;
using ConsoleApp.Attributes.ConsoleApp.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name.")]
        public string Name { get; set; }

        [AnyOf(typeof(EmailAddressAttribute), typeof(UrlAttribute))]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password.")]
        [AllOf(typeof(MinimumLengthAttribute), typeof(UppercaseLetterAttribute))]
        public string Password { get; set; }

        [NotMapped]
        public Guid Secretkey { get; set; }

        public string Permission { get; set; }

        [Range(16, 45, ErrorMessage = "Age must be between 16 and 45.")]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"\n Id: {Id}, \n Name: {Name}, \n Email: {Email}, \n Password: {Password}, \n Secretkey: {Secretkey}, \n Permission: {Permission}, \n Age: {Age}";
        }
    }
}
