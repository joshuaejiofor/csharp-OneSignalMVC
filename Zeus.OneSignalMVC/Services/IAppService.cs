using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Services
{
    public interface IAppService
    {
        Task<List<AppViewModel>> GetAllApps();
        Task<AppViewModel> GetApp(string Id);
        Task<Boolean> CreateApp(AppCreateModel appCreateModel);
        Task<Boolean> UpdateApp(string Id, AppCreateModel appCreateModel);
    }
}