using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class CarVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Model name can't be that long.")]
        public string Model { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string Condition { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string Color { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ManifactureDate { get; set; }

        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string Details { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string AddedBy { get; set; }

        public int BrandId { get; set; }

        public BrandVM BrandVM { get; set; }

        public CarVM() { }

        public CarVM(CarDTO carDto)
        {
            Id = carDto.Id;
            Model = carDto.Model;
            Condition = carDto.Condition;
            Color = carDto.Color;
            Power = carDto.Power;
            Price = carDto.Price;
            ManifactureDate = carDto.ManifactureDate;
            Details = carDto.Details;
            AddedBy = carDto.AddedBy;
            BrandVM = new BrandVM
            {
                Id = carDto.BrandId,
                BrandName = carDto.Brand.BrandName,
                CountryOfOrigin = carDto.Brand.CountryOfOrigin,
                FoundedIn = carDto.Brand.FoundedIn,
                AddedOn = carDto.Brand.AddedOn,
                AddedFrom = carDto.Brand.AddedFrom,
                LowestModelPrice = carDto.Brand.LowestModelPrice

            };
        }
    }
}