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
        //[Required]
        public virtual Car Car { get; set; }

        [Required]
        [StringLength(30)]
        public string ClientFirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string ClientLastName { get; set; }

        [StringLength(50)]
        public string SellerName { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime SaleDate { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

    }
}
