using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Application.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "The Classification is required")]
        [DisplayName("classification")]
        public int? Classification { get; set; }

        [Required(ErrorMessage = "The MovieId is required")]
        [DisplayName("movieId")]
        public int MovieId { get; set; }
    }
}