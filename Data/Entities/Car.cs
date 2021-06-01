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
        [Required]
        public virtual Brand Brand { get; set; }

        [Required]
        [MaxLength(80)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string Condition { get; set; }

        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ManifactureDate { get; set; }

        [MaxLength(70)]
        public string Details { get; set; }

        [Required]
        [MaxLength(50)]
        public string AddedBy { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }


    }
}
