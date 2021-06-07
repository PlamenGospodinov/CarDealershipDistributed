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
        [StringLength(30, ErrorMessage = "The brand name can't be that long.")]
        public string BrandName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The country name can't be that long.")]
        public string CountryOfOrigin { get; set; }
        public short FoundedIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AddedOn { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        public string AddedFrom { get; set; }
        public int LowestModelPrice { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
