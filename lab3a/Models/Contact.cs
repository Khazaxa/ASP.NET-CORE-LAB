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
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }          // pole opcjonalne
        [Display(Name = "Data urodzenia")]
        public DateTime? Birth { get; set; }        // pole opcjonalne
        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }
        [HiddenInput]
        public DateTime Created { get; set; }
        
    }
}
