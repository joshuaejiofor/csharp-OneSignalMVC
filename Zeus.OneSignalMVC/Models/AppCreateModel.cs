using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zeus.OneSignalMVC.Models
{
    public class AppCreateModel
    {
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Apns Env")]
        public string apns_env { get; set; }

        [Display(Name = "Apns P12")]
        public string apns_p12 { get; set; }

        [Display(Name = "Apns P12 Password")]
        public string apns_p12_password { get; set; }

        [Display(Name = "Gcm Key")]
        public string gcm_key { get; set; }

        [Display(Name = "Android Gcm Sender Id")]
        public string android_gcm_sender_id { get; set; }

        [Display(Name = "Chrome Web Origin")]
        public string chrome_web_origin { get; set; }

        [Display(Name = "Chrome Web Default Notification Icon")]
        public string chrome_web_default_notification_icon { get; set; }

        [Display(Name = "Chrome Web Sub Domain")]
        public string chrome_web_sub_domain { get; set; }

        [Display(Name = "Site Name")]
        public string site_name { get; set; }

        [Display(Name = "Chrome Key")]
        public string chrome_key { get; set; }

        [Display(Name = "Safari Site Origin")]
        public string safari_site_origin { get; set; }

        [Display(Name = "Safari Apns P12")]
        public string safari_apns_p12 { get; set; }

        [Display(Name = "Safari Apns P12 Password")]
        public string safari_apns_p12_password { get; set; }

        [Display(Name = "Safari Icon 256x256")]
        public string safari_icon_256_256 { get; set; }

        [Display(Name = "Additional Data Is Root Payload")]
        public bool additional_data_is_root_payload { get; set; }

        [Display(Name = "Organization Id")]
        public string organization_id { get; set; }
    }
}