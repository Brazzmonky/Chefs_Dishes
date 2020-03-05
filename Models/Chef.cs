using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Chefs_Dishes.Models
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value > DateTime.Now)
                return new ValidationResult("Date must be in the past");
            return ValidationResult.Success;
        }
    }

    [Table("chefs")]
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        [MinLength(2,ErrorMessage="First Name must be at least 2 Characters!")]
        [Display(Name="First Name")]
        public string first_name{get;set;}
        [Required]
        [MinLength(2,ErrorMessage="Last Name must be at least 2 characters!")]
        [Display(Name="Last Name")]
        public string last_name{get;set;}
        
        [Required]
        [Display(Name="Date of Birth")]
        [NoFutureDate(ErrorMessage="please enter a Date of Birth")]
        public DateTime dob{get;set;}

        [Required]
        [Display(Name="Age")]
        public int Age{get;set;}
        public List<Dish> CreatedDishes {get;set;}

        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;

    }

    

}