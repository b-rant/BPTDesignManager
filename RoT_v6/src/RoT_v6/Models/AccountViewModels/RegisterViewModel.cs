using Microsoft.AspNetCore.Mvc.Rendering;
using RoT_v6.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoT_v6.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }



        [DataType(DataType.Text)]
        [Display(Name = "Role")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }
        public string Role { get; set; }

        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();

            /* Roles.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Admin"
            });
            Roles.Add(new SelectListItem()
            {
                Value = "2",
                Text = "ShopManager"
            });
            Roles.Add(new SelectListItem()
            {
                Value = "3",
                Text = "Purchaser"
            });
            Roles.Add(new SelectListItem()
            {
                Value = "4",
                Text = "Employee"
            }); */

            }
        public void getRoles(ApplicationDbContext _context)
        {
            var roles = from r in _context.identityRole select r;
            var listRole = roles.ToList();
            foreach (var Data in listRole)
            {
                Roles.Add(new SelectListItem()
                {

                    Value = Data.Id,
                    Text = Data.Name
              });
           }
        }
      }
   }

