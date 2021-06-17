using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Car : BaseEntity
    {
        public int BrandID { get; set; }
        //[Required]
        public virtual Brand Brand { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The model name can't be that long.")]
        public string Model { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The condition can't be that long..")]
        public string Condition { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The color can't be that long.")]
        public string Color { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ManifactureDate { get; set; }

        [StringLength(60, ErrorMessage = "The details can't be that long.")]
        public string Details { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string AddedBy { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }


    }
}
