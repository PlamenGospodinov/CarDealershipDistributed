using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities;
using ApplicationService.DTOs;
using Repository.Implementations;

namespace ApplicationService.Implementations
{
    public class BrandManagementService
    {
        private CarDealershipDbContext ctx = new CarDealershipDbContext();

        public List<BrandDTO> Get()
        {
            List<BrandDTO> brandsDto = new List<BrandDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.BrandRepository.Get())
                {
                    brandsDto.Add(new BrandDTO
                    {
                        Id = item.Id,
                        BrandName = item.BrandName,
                        CountryOfOrigin = item.CountryOfOrigin,
                        FoundedIn = item.FoundedIn,
                        AddedOn = item.AddedOn,
                        AddedFrom = item.AddedFrom,
                        LowestModelPrice = item.LowestModelPrice
                    });
                }
            }


            return brandsDto;
        }

        public BrandDTO GetById(int id)
        {
            BrandDTO brandDto = new BrandDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Brand brand = unitOfWork.BrandRepository.GetByID(id);
                brandDto = new BrandDTO
                {
                    Id = brand.Id,
                    BrandName = brand.BrandName,
                    CountryOfOrigin = brand.CountryOfOrigin,
                    FoundedIn = brand.FoundedIn,
                    AddedOn = brand.AddedOn,
                    AddedFrom = brand.AddedFrom,
                    LowestModelPrice = brand.LowestModelPrice
                };
            }


            return brandDto;
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
