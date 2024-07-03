using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Entites.Enums;

namespace Teste.Application.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MaxLength(100)]
        [DisplayName("name")]
        public string Name { get; set; }
        
        [DisplayName("gender")]
        [Required(ErrorMessage = "The gender is required")]
        public Gender Gender { get; set; }

        [Range(1, 5)]
        public int? Classification { get; set; }

        [Required(ErrorMessage = "The date is required")]
        public string Date { get; set; }

        [MaxLength(450)]
        public string? Comment { get; set;}

        [MaxLength(100)]
        public string? Image {get; set; }
    }
}