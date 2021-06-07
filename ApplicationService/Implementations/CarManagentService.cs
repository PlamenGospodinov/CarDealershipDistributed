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

        public bool Save(CarDTO carDto)
        {
            if (carDto.Brand == null || carDto.Brand.Id == 0)
            {
                return false;
            }

            Brand brand = new Brand
            {
                Id = carDto.Brand.Id,
                BrandName = carDto.Brand.BrandName,
                CountryOfOrigin = carDto.Brand.CountryOfOrigin,
                FoundedIn = carDto.Brand.FoundedIn,
                AddedOn = carDto.Brand.AddedOn,
                AddedFrom = carDto.Brand.AddedFrom,
                LowestModelPrice = carDto.Brand.LowestModelPrice
            };

            Car car = new Car
            {
                Id = carDto.Id,
                Model = carDto.Model,
                Condition = carDto.Condition,
                Color = carDto.Color,
                Power = carDto.Power,
                Price = carDto.Price,
                ManifactureDate = carDto.ManifactureDate,
                Details = carDto.Details,
                AddedBy = carDto.AddedBy,
                BrandID = carDto.Brand.Id
            };


            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (carDto.Id == 0)
                    {
                        unitOfWork.CarRepository.Insert(car);
                    }
                    else
                    {
                        unitOfWork.CarRepository.Update(car);
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
                    Car car = unitOfWork.CarRepository.GetByID(id);
                    unitOfWork.CarRepository.Delete(car);
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
