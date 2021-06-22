using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string BrandName { get; set; }
        [Required]
        [StringLength(30)]
        public string CountryOfOrigin { get; set; }
        public short FoundedIn { get; set; }
        [DataType(DataType.Date)]
        
        public DateTime AddedOn { get; set; }
        [Required]
        [StringLength(50)]
        public string AddedFrom { get; set; }
        public int LowestModelPrice { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
