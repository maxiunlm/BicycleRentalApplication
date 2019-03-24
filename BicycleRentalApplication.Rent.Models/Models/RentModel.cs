using BicycleRentalApplication.Rent.Models.Rents;
using System;
using System.ComponentModel.DataAnnotations;

namespace BicycleRentalApplication.Rent.Models.Models
{
    public class RentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Bicycles { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
