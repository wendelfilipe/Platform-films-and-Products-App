using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Entites.Enums;
using Teste.Domain.Validation;

namespace Teste.Domain.Entites
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public int? Classification { get; private set; }
        public string Date { get; private set; }
        public string? Comment { get; private set;}
        public string? Image {get; private set; }
        public ICollection<User> Users {get; private set; }

        public Movie(string name, Gender gender, int? classification, string date, string? comment, string? image)
        {
            ValidationDomain(name, gender, classification, date, comment, image);
        }

        public void Update(int id, string name, Gender gender, int? classification, string date, string? comment, string? image)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid Id Value");
            ValidationDomain(name, gender, classification, date, comment, image);
            Id = id;
        }
        
        //Method to Validation if parameters is right
        public void ValidationDomain(string name, Gender gender, int? classification, string date, string? comment, string? image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is required");
            DomainExceptionValidation.When(gender == 0 , "Invalid gender, Gender is required");
            DomainExceptionValidation.When(classification < 1, "Invalid number, number must to be from 1 to 5");
            DomainExceptionValidation.When(classification > 5, "Invalid number, number must to be from 1 to 5");
            DomainExceptionValidation.When(string.IsNullOrEmpty(date), "Invalid date, Date is required");

            Name = name;
            Gender = gender;
            Classification = classification;
            Date = date;
            Comment = comment;
            Image = image;
        }
    }
}