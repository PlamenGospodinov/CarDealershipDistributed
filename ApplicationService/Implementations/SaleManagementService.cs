using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System.Collections.Generic;
using Data.Context;

namespace ApplicationService.Implementations
{
    public class SaleManagementService
    {
        private CarDealershipDbContext ctx = new CarDealershipDbContext();

        public List<SaleDTO> Get()
        {
            List<SaleDTO> salesDto = new List<SaleDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.SaleRepository.Get())
                {
                    salesDto.Add(new SaleDTO
                    {
                        Id = item.Id,
                        ClientFirstName = item.ClientFirstName,
                        ClientLastName = item.ClientLastName,
                        SellerName = item.SellerName,
                        SaleDate = item.SaleDate,
                        SalePrice = item.SalePrice,
                        Car = new CarDTO
                        {
                            Id = item.Car.Id,
                            Model = item.Car.Model,
                            Condition = item.Car.Condition,
                            Color = item.Car.Color,
                            Power = item.Car.Power,
                            Price = item.Car.Price,
                            ManifactureDate = item.Car.ManifactureDate,
                            Details = item.Car.Details,
                            AddedBy = item.Car.AddedBy
                        }
                    });
                }
            }


            return salesDto;
        }

        public SaleDTO GetById(int id)
        {
            SaleDTO saleDto = new SaleDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Sale sale = unitOfWork.SaleRepository.GetByID(id);
                saleDto = new SaleDTO
                {
                    Id = sale.Id,
                    ClientFirstName = sale.ClientFirstName,
                    ClientLastName = sale.ClientLastName,
                    SellerName = sale.SellerName,
                    SaleDate = sale.SaleDate,
                    SalePrice = sale.SalePrice,
                    CarId = sale.CarID,
                    Car = new CarDTO
                    {
                        Id = sale.CarID,
                        Model = sale.Car.Model,
                        Condition = sale.Car.Condition,
                        Color = sale.Car.Color,
                        Power = sale.Car.Power,
                        Price = sale.Car.Price,
                        ManifactureDate = sale.Car.ManifactureDate,
                        Details = sale.Car.Details,
                        AddedBy = sale.Car.AddedBy
                    }
                };
            }


            return saleDto;
        }

        public bool Save(SaleDTO saleDto)
        {
            if (saleDto.Car == null || saleDto.Car.Id == 0)
            {
                return false;
            }

            Car car = new Car
            {
                Id = saleDto.Car.Id,
                Model = saleDto.Car.Model,
                Condition = saleDto.Car.Condition,
                Color = saleDto.Car.Color,
                Power = saleDto.Car.Power,
                Price = saleDto.Car.Price,
                ManifactureDate = saleDto.Car.ManifactureDate,
                Details = saleDto.Car.Details,
                AddedBy = saleDto.Car.AddedBy
            };

            Sale sale = new Sale
            {
                Id = saleDto.Id,
                ClientFirstName = saleDto.ClientFirstName,
                ClientLastName = saleDto.ClientLastName,
                SellerName = saleDto.SellerName,
                SaleDate = saleDto.SaleDate,
                SalePrice = saleDto.SalePrice,
                CarID = saleDto.Car.Id
            };


            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (saleDto.Id == 0)
                    {
                        unitOfWork.SaleRepository.Insert(sale);
                    }
                    else
                    {
                        unitOfWork.SaleRepository.Update(sale);
                    }
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Sale sale = unitOfWork.SaleRepository.GetByID(id);
                    unitOfWork.SaleRepository.Delete(sale);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
