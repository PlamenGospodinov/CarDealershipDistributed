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
        [MaxLength(30)]
        public string BrandName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CountryOfOrigin { get; set; }
        public short FoundedIn { get; set; }
        public DateTime? AddedOn { get; set; }
        [Required]
        [MaxLength(50)]
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