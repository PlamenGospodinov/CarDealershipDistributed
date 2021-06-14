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
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            List<CarVM> carsVM = new List<CarVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetCars())
                {
                    carsVM.Add(new CarVM(item));
                }
            }
            return View(carsVM);
        }

        // GET: Cars/Details/
        public ActionResult Details(int id)
        {
            CarVM carVM = new CarVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var carDto = service.GetCarByID(id);
                carVM = new CarVM(carDto);
            }

            return View(carVM);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                ViewBag.Brands = new SelectList(service.GetBrands(),"Id","BrandName");
            }
                return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarVM carVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        CarDTO carDto = new CarDTO
                        {
                            Model = carVM.Model,
                            Condition = carVM.Condition,
                            Color = carVM.Color,
                            Power = carVM.Power,
                            Price = carVM.Price,
                            ManifactureDate = carVM.ManifactureDate,
                            Details = carVM.Details,
                            AddedBy = carVM.AddedBy,
                            Brand = new BrandDTO
                            {
                                Id = carVM.BrandId
                            }
                        };
                        
                        service.PostCar(carDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                ViewBag.Brands = LoadDataUtil.LoadBrandData();
                return View();
            }
        }


        // GET: Cars/Edit


        [HttpGet]
        public ActionResult Edit(int id)
        {


            CarVM carVM = new CarVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var carDto = service.GetCarByID(id);
                carVM = new CarVM(carDto);
                
            }
            ViewBag.Brands = LoadDataUtil.LoadBrandData();
            return View(carVM);
        }

        // POST: Cars/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarVM carVM)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        CarDTO carDto = new CarDTO
                        {
                            Model = carVM.Model,
                            Condition = carVM.Condition,
                            Color = carVM.Color,
                            Power = carVM.Power,
                            Price = carVM.Price,
                            ManifactureDate = carVM.ManifactureDate,
                            Details = carVM.Details,
                            AddedBy = carVM.AddedBy,
                            Brand = new BrandDTO
                            {
                                Id = carVM.BrandId
                            }
                        };
                       // service.PostCar(carDto);


                    }



                    return RedirectToAction("Index");
                }

                ViewBag.Cars = LoadDataUtil.LoadBrandData();
                return View();
            }
            catch
            {
                ViewBag.Cars = LoadDataUtil.LoadBrandData();
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteCar(id);
            }
            return RedirectToAction("Index");
        }
    }
}