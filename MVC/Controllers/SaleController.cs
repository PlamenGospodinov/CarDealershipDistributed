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
            return View();
        }

        // POST: Cars/Create
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


        // GET: Sales/Edit


        [HttpGet]
        public ActionResult Edit(int id)
        {


            SaleVM saleVM = new SaleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {



            }



            //ViewBag.Cars = LoadDataUtil.LoadCarData();

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
                service.DeleteSale(id);
            }
            return RedirectToAction("Index");
        }
    }
}