using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }


        public string Condition { get; set; }


        public string Color { get; set; }


        public int Power { get; set; }


        public decimal Price { get; set; }


        public DateTime ManifactureDate { get; set; }


        public string Details { get; set; }


        public string AddedBy { get; set; }

        public BrandDTO Brand { get; set; }

        
        public int BrandId { get; set; }
    }
}
