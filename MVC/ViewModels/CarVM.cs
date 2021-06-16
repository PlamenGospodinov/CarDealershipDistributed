using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ViewModels
{
    [Bind(Exclude = "Id")]
    public class CarVM
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Model name can't be that long.")]
        [DisplayName("Model")]
        public string Model { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Condition")]
        public string Condition { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Color")]
        public string Color { get; set; }

        [Required]
        [DisplayName("Power")]
        [Range(70, 2000,
            ErrorMessage = "Power must be between 70 and 2000")]
        public int Power { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(5000, 5000000,
            ErrorMessage = "Price must be between 5000 and 5000000")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Manifacture date")]
        public DateTime ManifactureDate { get; set; }

        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Details")]
        public string Details { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Added by")]
        public string AddedBy { get; set; }
        [DisplayName("Brand Name")]
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
            BrandId = carDto.BrandId;
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