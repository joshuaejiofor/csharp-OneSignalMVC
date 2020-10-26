using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Mappers
{
    public class AppMap : Profile
    {
        public static IMapper AppMapConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AppUpdateModel, AppCreateModel>();
                cfg.CreateMap<AppViewModel, AppUpdateModel>();
            });
            return config.CreateMapper();            
        }
    }
}