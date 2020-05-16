using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;


namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }


        [Required]
        [MinLength(3)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }


        [Required]
        [MinLength(3)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Date of Birth:")]
        public DateTime Birthday {get;set;}

        public int Age {
            get { return DateTime.Now.Year - Birthday.Year;}
        }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Navigation Property
        public List<Dish> CreatedDishes {get;set;} = new List<Dish> ();

    
        
    }
}