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
        [StringLength(40)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Condition { get; set; }

        [Required]
        [StringLength(30)]
        public string Color { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        
        
        public DateTime ManifactureDate { get; set; }

        [StringLength(60)]
        public string Details { get; set; }

        [Required]
        [StringLength(50)]
        public string AddedBy { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }


    }
}
