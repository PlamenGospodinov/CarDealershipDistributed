using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Utils
{
    public static class LoadDataUtil
    {
        public static SelectList LoadBrandData()
        {
            using (MVCAuthentication.ServiceReference1.Service1Client service = new MVCAuthentication.ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetBrands(""), "Id", "BrandName","FoundedIn");
            }
        }

        public static SelectList LoadCarData()
        {
            using (MVCAuthentication.ServiceReference1.Service1Client service = new MVCAuthentication.ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetCars(""), "Id","Model");
            }
        }

        public static SelectList LoadSaleData()
        {
            using (MVCAuthentication.ServiceReference1.Service1Client service = new MVCAuthentication.ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetSales(""), "Id");
            }
        }
    }
}