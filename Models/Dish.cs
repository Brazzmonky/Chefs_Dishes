using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs_Dishes.Models
{
    [Table("dishes")]
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required]
        [MinLength(3,ErrorMessage="Name of Dish must be at least 3 characters!")]
        [Display(Name="Name of Dish")]
        public string DishName{get;set;}

        [Required]
        [Range(0,Int32.MaxValue,ErrorMessage="Must have a calorie count between 0 and 1000")]
        [Display(Name="# of Calories")]
        public int Calorie{get;set;}

        [Required]
        [MaxLength(100,ErrorMessage="Description required but has a 100 character limit")]
        [Display(Name="Description")]
        public string Description{get;set;}
        
        [Required]
        [Range(1,5,ErrorMessage="Tastiness must be between 1 and 5")]
        [Display(Name="Tastiness")]
        public int Tastiness{get;set;}
   
        [Required]
        [Display(Name="Chef")]
        public int ChefId{get;set;}
        public Chef Creator {get;set;}
    }
}    



    