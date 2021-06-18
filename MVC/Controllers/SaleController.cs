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
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            List<SaleVM> salesVM = new List<SaleVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetSales())
                {
                    salesVM.Add(new SaleVM(item));
                }
            }
            return View(salesVM);
        }

        // GET: Sales/Details/
        public ActionResult Details(int id)
        {
            SaleVM saleVM = new SaleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var saleDto = service.GetSaleByID(id);
                saleVM = new SaleVM(saleDto);
            }

            return View(saleVM);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                ViewBag.Cars = new SelectList(service.GetCars(), "Id", "Model");
            }
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleVM saleVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        SaleDTO saleDto = new SaleDTO
                        {
                            ClientFirstName = saleVM.ClientFirstName,
                            ClientLastName = saleVM.ClientLastName,
                            SellerName = saleVM.SellerName,
                            SaleDate = saleVM.SaleDate,
                            SalePrice = saleVM.SalePrice,
                            CarId = saleVM.CarId,
                            
                            Car = new CarDTO
                            {
                                Id = saleVM.CarId
                                
                            }
                        };
                        saleVM.CarModel = saleDto.Car.Color + " " + saleDto.Car.Model;
                        
                        service.PostSale(saleDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                ViewBag.Cars = LoadDataUtil.LoadCarData();
                return View();
            }
        }


        // GET: Sales/Edit


        [HttpGet]
        public ActionResult Edit(int id)
        {


            SaleVM saleVM = new SaleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var saleDto = service.GetSaleByID(id);
                saleVM = new SaleVM(saleDto);

            }
            ViewBag.Cars = LoadDataUtil.LoadCarData();
            return View(saleVM);

            
        }

        // POST: Sales/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleVM saleVM)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        SaleDTO saleDto = new SaleDTO
                        {
                            ClientFirstName = saleVM.ClientFirstName,
                            ClientLastName = saleVM.ClientLastName,
                            SellerName = saleVM.SellerName,
                            SaleDate = saleVM.SaleDate,
                            SalePrice = saleVM.SalePrice,
                            
                            CarId = saleVM.CarId,
                            Car = new CarDTO
                            {
                                Id = saleVM.CarId
                            },
                            


                    };
                        // service.PostCar(carDto);


                    }



                    return RedirectToAction("Index");
                }

                ViewBag.Sales = LoadDataUtil.LoadSaleData();
                return View();
            }
            catch
            {
                ViewBag.Sales = LoadDataUtil.LoadSaleData();
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteSale(id);
            }
            return RedirectToAction("Index");
        }
    }
}