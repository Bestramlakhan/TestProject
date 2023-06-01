using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Machine_test__Euphoria_infotech.Models
{
    public class UserRegistation
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Your Name must be   Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your Address must be   Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Your UserName must be   Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Your Password must be   Required")]
        public string  Password { get; set; }
        [Required(ErrorMessage = "Enter Your Role must be   Required")]
        public Role RoleName { get; set; }
        [Required(ErrorMessage = "Enter Your Age must be   Required")]
        public string  Age { get; set; }


        public enum Role
        {
                    User,
                    Admin
        }
    }
}