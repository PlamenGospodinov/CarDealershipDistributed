using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class SaleDTO
    {
        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string SellerName { get; set; }

        public DateTime? SaleDate { get; set; }

        public decimal SalePrice { get; set; }

        public CarDTO Car { get; set; }
    }
}
