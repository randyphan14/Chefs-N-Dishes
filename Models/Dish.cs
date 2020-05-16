using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }


        [Required]
        [MinLength(3)]
        [Display(Name = "Name of Dish:")]
        public string Name { get; set; }

        [Required]
        [Range(1, 5000)]
        [Display(Name = "# of Calories: ")]
        public int Calories { get; set; }


        [Required]
        [MinLength(3)]
        [Display(Name = "Description:")]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Chef: ")]
        public int ChefId {get;set;}


        [Required]
        [Range(1,6)]
        [Display(Name = "Tastiness ")]

        public int Tastiness { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
        //Navigation Property
        public Chef Creator {get;set;}
    }
}