﻿using System.Web.Mvc;

namespace QuickRMS.Site.WebUI.Areas.Authen
{
    public class SSORegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SSO";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SSO_default",
                "SSO/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "QuickRMS.Site.WebUI.Areas.SSO.Controllers"}
            );
        }
    }
}