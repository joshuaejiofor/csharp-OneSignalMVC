using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Mappers
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<AppUpdateModel, AppCreateModel>();
            CreateMap<AppViewModel, AppUpdateModel>();
        }

    }
}