using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities;
using ApplicationService.DTOs;

namespace ApplicationService.Implementations
{
    public class BrandManagementService
    {
        private CarDealershipDbContext ctx = new CarDealershipDbContext();

        public List<BrandDTO> Get()
        {
            List<BrandDTO> brandsDto = new List<BrandDTO>();

            foreach(var item in ctx.Brands.ToList())
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

            return brandsDto;
        }

        public BrandDTO GetById(int id)
        {
            BrandDTO brandDto = new BrandDTO();
            Brand brand = ctx.Brands.Find(id);
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
                ctx.Brands.Add(brand);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                Console.WriteLine(brand);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Brand brand = ctx.Brands.Find(id);
                ctx.Brands.Remove(brand);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
