using MVCAuthentication.ServiceReference1;
using MVCAuthentication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication.Controllers
{
    public class BrandController : Controller
    {

        // GET: Brands
        public ActionResult Index(string Search_Data = "")
        {
            List<BrandVM> brandsVM = new List<BrandVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetBrands(Search_Data))
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
                if (ModelState.IsValid && AccountController.loggedIn == true)
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


        // GET: Brands/Edit


        [HttpGet]
        public ActionResult Edit(int id)
        {

            BrandVM brandVM = new BrandVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                // service.SetCurrentId(id);
                var brandDto = service.GetBrandByID(id);
                //service.DeleteBrand(id);
                brandVM = new BrandVM(brandDto);

            }

            //ViewBag.Brands = LoadDataUtil.LoadBrandData();

            return View(brandVM);
        }

        // POST: Brands/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandVM brandVM)
        {
            try
            {
                if (ModelState.IsValid && AccountController.loggedIn == true)
                {

                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        //int currentVmId = brandVM.Id;
                        // int idForDto = service.GetCurrentId();
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

                        service.PostBrand(brandDto2);


                    }



                    return RedirectToAction("Index");
                }

                //ViewBag.Brands = LoadDataUtil.LoadBrandData();
                return View();
            }
            catch
            {
                // ViewBag.Brands = LoadDataUtil.LoadBrandData();
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                if(AccountController.loggedIn == true)
                {
                    service.DeleteBrand(id);
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}