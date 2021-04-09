using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CircularManagementSystem.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//to handle user-friendly error
            filters.Add(new ExceptionHandlerAttribute());//to handle exception globally
        }
    }
}