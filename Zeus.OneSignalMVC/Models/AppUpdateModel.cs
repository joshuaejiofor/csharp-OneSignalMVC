using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zeus.OneSignalMVC.Models
{
    public class AppUpdateModel : AppCreateModel
    {        
        public string Id { get; set; }
    }
}