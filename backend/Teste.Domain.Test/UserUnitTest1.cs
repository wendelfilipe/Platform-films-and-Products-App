using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Teste.Domain.Entites;
using Teste.Domain.Validation;
using Xunit;

namespace Teste.Domain.Test
{
    public class UserUnitTest1
    {
        [Fact(DisplayName = "Create User With Valid State")]
        public  void CreateUser_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new User(5,1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateUser_WithInvalidClassification_DomainExceptionValidation()
        {
            Action action = () => new User(6,1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, number must to be from 1 to 5");
        }
        [Fact]
        public void CreateUser_InvalidClassification_DomainExceptionValidation()
        {
            Action action = () => new User(0,1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, number must to be from 1 to 5");
        }
        [Fact]
        public void CreateUser_InvalidMovieId_DomainExceptionValidation()
        {
            Action action = () => new User(5, 0);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }
    }
}