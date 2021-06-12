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
            return View();
        }

        // POST: Cars/Create
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

                        
                        //service.PostCar(carDTO);
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


        // GET: Cars/Edit


        [HttpGet]
        public ActionResult Edit(int id)
        {


            CarVM carVM = new CarVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                
                

            }



            ViewBag.Brands = LoadDataUtil.LoadBrandData();

            return View(brandVM);
        }

        // POST: Cars/Edit/
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
                        
                       // service.PostCar(carDto);


                    }



                    return RedirectToAction("Index");
                }

                //ViewBag.Cars = LoadDataUtil.LoadCarData();
                return View();
            }
            catch
            {
                //ViewBag.Cars = LoadDataUtil.LoadCarData();
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