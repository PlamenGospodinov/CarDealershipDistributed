using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Brand : BaseEntity
    {
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

        public virtual ICollection<Car> Cars { get; set; }

    }
}
