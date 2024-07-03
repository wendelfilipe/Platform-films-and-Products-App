using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Validation;

namespace Teste.Domain.Entites
{
    public class User
    {
        public int Id { get; private set; }
        public int? Classification { get; private set; }
        public int MovieId {get; set; }
        public Movie Movie { get; set;}

        public User(int? classification, int movieId)
        {
            DomainExceptionValidation.When(movieId <= 0, "Invalid Id Value");
            ValidationDomain(classification);
            MovieId = movieId;
        }

        public void ValidationDomain(int? classification)
        {

            DomainExceptionValidation.When(classification < 1, "Invalid number, number must to be from 1 to 5");
            DomainExceptionValidation.When(classification > 5, "Invalid number, number must to be from 1 to 5");
            Classification = classification;
        }
    }


    
}