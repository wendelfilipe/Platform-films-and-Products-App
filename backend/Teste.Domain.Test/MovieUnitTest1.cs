using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Teste.Domain.Entites;
using Teste.Domain.Entites.Enums;
using Teste.Domain.Validation;
using Xunit;

namespace Teste.Domain.Test
{
    public class MovieUnitTest1
    {
        [Fact(DisplayName = "Create Movie With Valid State")]
        public  void CreateMovie_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Movie("Harry Potter", Gender.Action, 5, "5-2011", "Muito bom", "print.png");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Movie With Valid State")]
        public  void CreateMovie_WithValidParametersEmpty_ResultObjectValidState()
        {
            Action action = () => new Movie("Harry Potter", Gender.Action, 5, "5-2011", null, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateMovie_EmptyName_DomainExceptionValidation()
        {
            Action action = () => new Movie("", Gender.Action, 5, "5-2011", "Muito bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, Name is required");
        }
        [Fact]
        public void CreateMovie_NullName_DomainExceptionValidation()
        {
            Action action = () => new Movie(null, Gender.Action, 5, "5-2011", "Muito bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, Name is required");
        }
        [Fact]
        public void CreateMovie_InvalidGender_DomainExceptionValidation()
        {
            Action action = () => new Movie("Harry Potter", 0, 5, "5-2011", "Muito bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid gender, Gender is required");
        }
        [Fact]
        public void CreateMovie_InvalidClassification_DomainExceptionValidation()
        {
            Action action = () => new Movie("Harry Potter", Gender.Action, 0, "5-2011", "Muito bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, number must to be from 1 to 5");
        }
        [Fact]
        public void CreateMovie_InvalidClassificationNumber_DomainExceptionValidation()
        {
            Action action = () => new Movie("Harry Potter", Gender.Action, 6, "5-2011", "Muito bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, number must to be from 1 to 5");
        }
        [Fact]
        public void CreateMovie_NullDate_DomainExceptionValidation()
        {
            Action action = () => new Movie("Harry Potter", Gender.Action, 5, null, "Muito Bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid date, Date is required");
        }
         [Fact]
        public void CreateMovie_EmptyDate_DomainExceptionValidation()
        {
            Action action = () => new Movie("Harry Potter", Gender.Action, 5, "", "Muito bom", "print.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid date, Date is required");
        }
    }
}