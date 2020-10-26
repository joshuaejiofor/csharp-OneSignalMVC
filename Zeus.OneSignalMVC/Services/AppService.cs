using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Services
{
    public class AppService : IAppService
    {
        public async Task<List<AppViewModel>> GetAllApps()
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var requestUri = new Uri(WebConfigurationManager.AppSettings["OneSignalEndPoint"]);

                client.BaseAddress = requestUri;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", WebConfigurationManager.AppSettings["AuthToken"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HTTP GET
                var result = await client.GetAsync(requestUri);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<AppViewModel>>(readTask);
                }
                else //web api sent error response 
                {
                    return Enumerable.Empty<AppViewModel>().ToList();
                }                
            }
        }

        public async Task<AppViewModel> GetApp(string Id)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var requestUri = new Uri(WebConfigurationManager.AppSettings["OneSignalEndPoint"] + $"/{Id}");

                client.BaseAddress = requestUri;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", WebConfigurationManager.AppSettings["AuthToken"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HTTP GET
                var result = await client.GetAsync(requestUri);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AppViewModel>(readTask);
                }
                else //web api sent error response 
                {
                    return null;
                }
            }
        }

        public async Task<Boolean> CreateApp(AppCreateModel appCreateModel)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var requestUri = new Uri(WebConfigurationManager.AppSettings["OneSignalEndPoint"]);

                client.BaseAddress = requestUri;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", WebConfigurationManager.AppSettings["AuthToken"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var payload = new StringContent(JsonConvert.SerializeObject(appCreateModel), Encoding.UTF8, "application/json");

                //HTTP POST
                var result = await client.PostAsync(requestUri, payload);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else //web api sent error response 
                {
                    return false;
                }
            }
        }

        public async Task<Boolean> UpdateApp(string Id, AppCreateModel appCreateModel)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var requestUri = new Uri(WebConfigurationManager.AppSettings["OneSignalEndPoint"] + $"/{Id}");

                client.BaseAddress = requestUri;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", WebConfigurationManager.AppSettings["AuthToken"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var payload = new StringContent(JsonConvert.SerializeObject(appCreateModel), Encoding.UTF8, "application/json");

                //HTTP POST
                var result = await client.PutAsync(requestUri, payload);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else //web api sent error response 
                {
                    return false;
                }
            }
        }
    }
}