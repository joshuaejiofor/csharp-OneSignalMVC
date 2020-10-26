using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zeus.OneSignalMVC.Models
{
    public class AppViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Players")]
        public int Players { get; set; }

        [Display(Name = "Messageable Players")]
        public int Messageable_players { get; set; }

        [Display(Name = "Updated")]
        public DateTime Updated_at { get; set; }

        [Display(Name = "Created")]
        public DateTime Created_at { get; set; }

        [Display(Name = "Gcm Key")]
        public string Gcm_key { get; set; }

        [Display(Name = "Chrome Key")]
        public string Chrome_key { get; set; }

        [Display(Name = "Chrome Web Origin")]
        public string Chrome_web_origin { get; set; }

        [Display(Name = "Chrome Web Gcm Sender Id")]
        public string Chrome_web_gcm_sender_id { get; set; }

        [Display(Name = "Chrome Web Default Notification Icon")]
        public string Chrome_web_default_notification_icon { get; set; }

        [Display(Name = "Chrome Web Sub Domain")]
        public string Chrome_web_sub_domain { get; set; }

        [Display(Name = "Apns Env")]
        public string Apns_env { get; set; }

        [Display(Name = "Apns Certificates")]
        public string Apns_certificates { get; set; }

        [Display(Name = "Safari Apns Certificate")]
        public string Safari_apns_certificate { get; set; }

        [Display(Name = "Safari Site Origin")]
        public string Safari_site_origin { get; set; }

        [Display(Name = "Safari Push Id")]
        public string Safari_push_id { get; set; }

        [Display(Name = "Safari Icon 16x16")]
        public string Safari_icon_16_16 { get; set; }

        [Display(Name = "Safari Icon 32x32")]
        public string Safari_icon_32_32 { get; set; }

        [Display(Name = "Safari Icon 64x64")]
        public string Safari_icon_64_64 { get; set; }

        [Display(Name = "Safari Icon 128x128")]
        public string Safari_icon_128_128 { get; set; }

        [Display(Name = "Safari Icon 256x256")]
        public string Safari_icon_256_256 { get; set; }

        [Display(Name = "Site Name")]
        public string Site_name { get; set; }

        [Display(Name = "Auth Key")]
        public string Basic_auth_key { get; set; }
    }
}