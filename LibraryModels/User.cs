using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;

namespace LibraryModels
{
    public class User //: IdentityUser
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Please provide a valid email.")]
        [MaxLength(50, ErrorMessage = "The email must not exceed 50 characters.")]
        [Required(ErrorMessage = "Please provide an email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a username.")]
        [MaxLength(15, ErrorMessage = "The username must not exceed 15 characters.")]
        public string Username { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "The password must have at least 15 characters.")]
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        //A user must have always 1 Cart 1-1
        [ForeignKey("BuyingCart")]
        public virtual int? BuyingCartId { get; set; }

        public virtual BuyingCart? BuyingCart { get; set; }
    }
}
