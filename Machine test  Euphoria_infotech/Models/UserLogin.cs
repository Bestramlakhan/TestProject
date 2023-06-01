using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Machine_test__Euphoria_infotech.Models
{
    public class UserLogin
    {
        
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    
}
}