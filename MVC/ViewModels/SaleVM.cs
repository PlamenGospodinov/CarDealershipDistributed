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
    public class SaleVM
    {
        
        
            public int Id { get; set; }
            [Required]
            [StringLength(20, ErrorMessage = "Client's first name can't be that long.")]
            [DisplayName("Client's first name")]
            public string ClientFirstName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "Client's last name can't be that long.")]
            [DisplayName("Client's last name")]
            public string ClientLastName{ get; set; }

            [Required]
            [StringLength(40, ErrorMessage = "Seller's name can't be that long.")]
            [DisplayName("Seller's name")]
            public string SellerName { get; set; }

            [Required]
            [DisplayName("Sale Date")]
            [DataType(DataType.Date)]
            public DateTime? SaleDate { get; set; }

            [Required]
            [Range(5000, 5000000,
            ErrorMessage = "Price must be between 5000 and 5000000")]
            [DisplayName("Sale Price")]
            public decimal SalePrice { get; set; }

             [DisplayName("Car Id")]
             public int CarId { get; set; }

            // public string Car = 

        public CarVM CarVM { get; set; }

            public SaleVM() { }

        public SaleVM(SaleDTO saleDto)
        {
            Id = saleDto.Id;
            ClientFirstName = saleDto.ClientFirstName;
            ClientLastName = saleDto.ClientLastName;
            SellerName = saleDto.SellerName;
            SaleDate = saleDto.SaleDate;
            SalePrice = saleDto.SalePrice;

            CarVM = new CarVM
            {
                Id = saleDto.CarId,
                Model = saleDto.Car.Model,
                Condition = saleDto.Car.Condition,
                Color = saleDto.Car.Color,
                Power = saleDto.Car.Power,
                Price = saleDto.Car.Price,
                ManifactureDate = saleDto.Car.ManifactureDate,
                Details = saleDto.Car.Details,
                AddedBy = saleDto.Car.AddedBy
            };
        }
    }
}