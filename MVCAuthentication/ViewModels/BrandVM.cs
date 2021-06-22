﻿using MVCAuthentication.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAuthentication.ViewModels
{
    public class BrandVM
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The brand name can't be that long.")]
        [DisplayName("Brand Name")]
        public string BrandName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Country of origin can't be that long.")]
        [DisplayName("Country of origin")]
        public string CountryOfOrigin { get; set; }
        [DisplayName("Founded in")]
        [Range(1880, 2021,
            ErrorMessage = "Year must be between 1880 and 2021.")]
        public short FoundedIn { get; set; }
        [DataType(DataType.Date)]

        [DisplayName("Added on(date)")]
        public DateTime AddedOn { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Added from")]
        public string AddedFrom { get; set; }
        [DisplayName("Lowest model price")]
        [Range(5000, 5000000,
            ErrorMessage = "Price must be between 5000 and 5000000")]
        public int LowestModelPrice { get; set; }

        public BrandVM() { }

        public BrandVM(BrandDTO brandDto)
        {
            Id = brandDto.Id;
            BrandName = brandDto.BrandName;
            CountryOfOrigin = brandDto.CountryOfOrigin;
            FoundedIn = brandDto.FoundedIn;
            AddedOn = brandDto.AddedOn;
            AddedFrom = brandDto.AddedFrom;
            LowestModelPrice = brandDto.LowestModelPrice;
        }
    }
}