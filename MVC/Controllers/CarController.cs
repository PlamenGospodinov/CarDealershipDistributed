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
    }
}