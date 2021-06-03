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
        [MaxLength(20)]
        public string ClientFirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string ClientLastName { get; set; }

        [MaxLength(50)]
        public string SellerName { get; set; }

        public DateTime? SaleDate { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

    }
}
