using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Sale : BaseEntity
    {
        public int CarID { get; set; }
        [Required]
        public virtual Car Car { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The first name can't be that long.")]
        public string ClientFirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The last name can't be that long.")]
        public string ClientLastName { get; set; }

        [StringLength(50, ErrorMessage = "The seller name can't be that long.")]
        public string SellerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SaleDate { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

    }
}
