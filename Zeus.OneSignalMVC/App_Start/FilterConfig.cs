﻿using System.Web;
using System.Web.Mvc;

namespace Zeus.OneSignalMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
