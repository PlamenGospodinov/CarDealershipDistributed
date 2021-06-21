using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CarDealershipDbContext : DbContext
    {
        public CarDealershipDbContext()
        //: base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieCatalogDb.mdf;Initial Catalog=MovieCatalogDb123;Integrated Security=True")
        : base(@"Data Source=.\sqlexpress;Initial Catalog=CarDealershipDb;Integrated Security=SSPI;")
        { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }

        

    }

}
