﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Models
{
    public class RegisterNewUserViewModel
    {   
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        //Mostra o nome do user. neste caso usamos o email
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }


        [Required]
        
        public string Password { get; set; }

        //Confirma se password é igual 
        [Required]
        [Compare ("Password")]
        public string Confirm { get; set; }



    }
}