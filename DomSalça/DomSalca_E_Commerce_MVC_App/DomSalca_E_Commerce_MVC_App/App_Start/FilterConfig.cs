﻿using System.Web;
using System.Web.Mvc;

namespace DomSalca_E_Commerce_MVC_App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
