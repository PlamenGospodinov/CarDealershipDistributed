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
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetBrands(), "Id", "BrandName","FoundedIn");
            }
        }
    }
}