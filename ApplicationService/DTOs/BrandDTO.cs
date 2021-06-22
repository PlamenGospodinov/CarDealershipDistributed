using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public string CountryOfOrigin { get; set; }
        public short FoundedIn { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedFrom { get; set; }
        public int LowestModelPrice { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public bool Validate()
        {
            return (!String.IsNullOrEmpty(BrandName) && !String.IsNullOrEmpty(CountryOfOrigin) && !String.IsNullOrEmpty(AddedFrom));
        }
    }
}
