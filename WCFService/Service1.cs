using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFService;

namespace WCFServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private BrandManagementService brandService = new BrandManagementService();
        private CarManagementService carService = new CarManagementService();
        private SaleManagementService saleService = new SaleManagementService();
        public string DeleteBrand(int id)
        {
            if (!brandService.Delete(id))
            {
                return "Brand is not deleted!";
            }
            else
            {
                return "Brand is deleted!";
            }
        }

        public string DeleteCar(int id)
        {
            if (!carService.Delete(id))
            {
                return "Car is not deleted!";
            }
            else
            {
                return "Car is deleted!";
            }
        }

        public string DeleteSale(int id)
        {
            if (!saleService.Delete(id))
            {
                return "Sale is not deleted!";
            }
            else
            {
                return "Sale is deleted!";
            }
        }

        public BrandDTO GetBrandByID(int id)
        {
            return brandService.GetById(id);
        }

        public List<BrandDTO> GetBrands(string filter)
        {
            return brandService.Get(filter);
        }

        public List<BrandDTO> GetBrands()
        {
            throw new NotImplementedException();
        }

        public CarDTO GetCarByID(int id)
        {
            return carService.GetById(id);
        }

        public List<CarDTO> GetCars(string filter)
        {
            return carService.Get(filter);
        }

        public List<CarDTO> GetCars()
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public SaleDTO GetSaleByID(int id)
        {
            return saleService.GetById(id);
        }

        public List<SaleDTO> GetSales(string filter)
        {
            return saleService.Get(filter);
        }

        public List<SaleDTO> GetSales()
        {
            throw new NotImplementedException();
        }

        public string PostBrand(BrandDTO brandDto)
        {
            if (!brandService.Save(brandDto))
                return "Brand is not inserted";

            return "Brand is inserted";
        }

        public string PostCar(CarDTO carDto)
        {
            if (!carService.Save(carDto))
                return "Car is not inserted";

            return "Car is inserted";
        }


        public string PostSale(SaleDTO saleDto)
        {
            if (!saleService.Save(saleDto))
                return "Sale is not inserted";

            return "Sale is inserted";
        }

        public string PutBrand(BrandDTO brandDto)
        {
            throw new NotImplementedException();
        }

        public string PutCar(CarDTO carDto)
        {
            throw new NotImplementedException();
        }

        public string PutSale(SaleDTO saleDto)
        {
            throw new NotImplementedException();
        }
    }
}