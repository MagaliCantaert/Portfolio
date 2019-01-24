using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class ContactViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter your last name.")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name ="E-mail Address")]
        [Required(ErrorMessage = "Enter a valid e-mailaddress.")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Enter a subject.")]
        public string Subject { get; set; }

        [Display(Name = "Your Message")]
        [Required(ErrorMessage = "Enter your message.")]
        public string Message { get; set; }
    }
}
