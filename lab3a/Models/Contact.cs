using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3a.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz podac imie!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, ma 50 znakow")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }          // pole opcjonalne
        public DateTime? Birth { get; set; }        // pole opcjonalne
    }
}
