using ApplicationService.DTOs;
using MVC.Utils;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            List<BrandVM> brandsVM = new List<BrandVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetBrands())
                {
                    brandsVM.Add(new BrandVM(item));
                }
            }
            return View(brandsVM);
        }

        // GET: Brands/Details/
        public ActionResult Details(int id)
        {
            BrandVM brandVM = new BrandVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var brandDto = service.GetBrandByID(id);
               brandVM = new BrandVM(brandDto);
            }

            return View(brandVM);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandVM brandVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        BrandDTO brandDTO = new BrandDTO
                        {
                            BrandName = brandVM.BrandName,
                            CountryOfOrigin = brandVM.CountryOfOrigin,
                            FoundedIn = brandVM.FoundedIn,
                            AddedOn = brandVM.AddedOn,
                            AddedFrom = brandVM.AddedFrom,
                            LowestModelPrice = brandVM.LowestModelPrice
                        };
                        service.PostBrand(brandDTO);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: Brands/Edit/

        
        BrandDTO brandDto;
        int currentId;
        BrandDTO helperDto;
        BrandDTO helperDto2;
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            currentId = id;
            BrandVM brandVM = new BrandVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                brandDto = service.GetBrandByID(id);
                helperDto = service.GetBrandByID(id);
                brandVM = new BrandVM(brandDto);
                if (id != 0)
                {
                    currentId = id;
                }
                else
                {
                    currentId +=0;
                }
                
            }
            helperDto2 = helperDto;
            ViewBag.Brands = LoadDataUtil.LoadBrandData();
            
            return View(brandVM);
        }

        // POST: Brands/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandVM brandVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        
                        
                        BrandDTO brandDto2 = new BrandDTO
                        {
                            Id = brandVM.Id,
                            BrandName = brandVM.BrandName,
                            CountryOfOrigin = brandVM.CountryOfOrigin,
                            FoundedIn = brandVM.FoundedIn,
                            AddedOn = brandVM.AddedOn,
                            AddedFrom = brandVM.AddedFrom,
                            LowestModelPrice = brandVM.LowestModelPrice,
                        };
                        service.DeleteBrand(currentId);
                        service.PostBrand(brandDto2);
                        
                        
                    }



                    return RedirectToAction("Index");
                }

                ViewBag.Brands = LoadDataUtil.LoadBrandData();
                return View();
            }
            catch
            {
                ViewBag.Brands = LoadDataUtil.LoadBrandData();
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteBrand(id);
            }
            return RedirectToAction("Index");
        }
    }
}