using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class CarManagementService
    {
        private CarDealershipDbContext ctx = new CarDealershipDbContext();

        public List<CarDTO> Get()
        {
            List<CarDTO> carsDto = new List<CarDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CarRepository.Get())
                {
                    carsDto.Add(new CarDTO
                    {
                        Id = item.Id,
                        Model = item.Model,
                        Condition = item.Condition,
                        Color = item.Color,
                        Power = item.Power,
                        Price = item.Price,
                        ManifactureDate = item.ManifactureDate,
                        Details = item.Details,
                        AddedBy = item.AddedBy,
                        BrandId = item.BrandID,
                        Brand = new BrandDTO
                        {
                            Id = item.Brand.Id,
                            BrandName = item.Brand.BrandName,
                            CountryOfOrigin = item.Brand.CountryOfOrigin,
                            FoundedIn = item.Brand.FoundedIn,
                            AddedOn = item.Brand.AddedOn,
                            AddedFrom = item.Brand.AddedFrom,
                            LowestModelPrice = item.Brand.LowestModelPrice
                        }
                    });
                }
            }


            return carsDto;
        }

        public CarDTO GetById(int id)
        {
            CarDTO carDto = new CarDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Car car = unitOfWork.CarRepository.GetByID(id);
                carDto = new CarDTO
                {
                    Id = car.Id,
                    Model = car.Model,
                    Condition = car.Condition,
                    Color = car.Color,
                    Power = car.Power,
                    Price = car.Price,
                    ManifactureDate = car.ManifactureDate,
                    Details = car.Details,
                    AddedBy = car.AddedBy,
                    BrandId = car.BrandID,
                    Brand = new BrandDTO
                    {
                        Id = car.BrandID,
                        BrandName = car.Brand.BrandName,
                        CountryOfOrigin = car.Brand.CountryOfOrigin,
                        FoundedIn = car.Brand.FoundedIn,
                        AddedOn = car.Brand.AddedOn,
                        AddedFrom = car.Brand.AddedFrom,
                        LowestModelPrice = car.Brand.LowestModelPrice
                    }
                };
            }


            return carDto;
        }

        public bool Save(BrandDTO brandDto)
        {
            Brand brand = new Brand
            {
                BrandName = brandDto.BrandName,
                CountryOfOrigin = brandDto.CountryOfOrigin,
                FoundedIn = brandDto.FoundedIn,
                AddedOn = brandDto.AddedOn,
                AddedFrom = brandDto.AddedFrom,
                LowestModelPrice = brandDto.LowestModelPrice
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (brandDto.Id == 0)
                    {
                        unitOfWork.BrandRepository.Insert(brand);
                    }
                    else
                    {
                        unitOfWork.BrandRepository.Update(brand);
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
                    Brand brand = unitOfWork.BrandRepository.GetByID(id);
                    unitOfWork.BrandRepository.Delete(brand);
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
