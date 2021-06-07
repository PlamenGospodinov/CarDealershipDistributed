using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BrandVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The brand name can't be that long.")]
        public string BrandName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Country of origin can't be that long.")]
        public string CountryOfOrigin { get; set; }
        public short FoundedIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AddedOn { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string AddedFrom { get; set; }
        public int LowestModelPrice { get; set; }

        public BrandVM(){}

        public BrandVM(BrandDTO brandDTO)
        {
            Id = brandDTO.Id;
            BrandName = brandDTO.BrandName;
            CountryOfOrigin = brandDTO.CountryOfOrigin;
            FoundedIn = brandDTO.FoundedIn;
            AddedOn = brandDTO.AddedOn;
            AddedFrom = brandDTO.AddedFrom;
            LowestModelPrice = brandDTO.LowestModelPrice;
        }
    }
}