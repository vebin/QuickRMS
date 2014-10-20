
using Quick.Site.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuickRMS.Site.Models.SSO.Apps
{
    public class AppsModel : EntityCommon
    {
        public AppsModel() 
        {
            Search = new SearchModel();
			//Enabled = true;
        }

        public SearchModel Search { get; set; }

        public int Id { get; set; }

        //public int AppID { get; set; }
        [Display(Name = "APIKey")]
        [Required(ErrorMessage = "APIKey不能为空")]
        public string APIKey { get; set; }
        [Display(Name = "应用名称")]
        [Required(ErrorMessage = "应用名称不能为空")]
        public string AppName { get; set; }
        [Display(Name = "应用描述")]
        public string AppDesc { get; set; }
        [Display(Name = "是否在线")]
        public bool IsOnline { get; set; }
        public string IsOnlineText
        {
            get
            {
                if (IsOnline == true)
                {
                    return "是";
                }
                else
                {
                    return "否";
                }
            }
            set { }
        }

        [Display(Name = "EncrytKey")]
        public string EncrytKey { get; set; }
        [Display(Name="回调地址")]
        public string CallBackUrl { get; set; }
        [Display(Name="应用类型")]
        [Required(ErrorMessage = "应用类型不能为空")]
        public string AppType { get; set; }


    }

    public class SearchModel
    {
        public SearchModel()
        {
            IsOnlineItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- 请选择 ---", Value = "-1", Selected = true }, 
                new SelectListItem { Text = "是", Value = "1" }, 
                new SelectListItem { Text = "否", Value = "0" }
            };
        }

        //public int AppID { get; set; }
        [Display(Name = "APIKey")]
        public string APIKey { get; set; }
        [Display(Name = "应用名称")]
        public string AppName { get; set; }
        [Display(Name = "应用描述")]
        public string AppDesc { get; set; }
        [Display(Name = "是否在线")]
        public bool IsOnline { get; set; }

        [Display(Name = "EncrytKey")]
        public string EncrytKey { get; set; }
        [Display(Name = "回调地址")]
        public string CallBackUrl { get; set; }
        [Display(Name = "应用类型")]
        public string AppType { get; set; }



        public List<SelectListItem> IsOnlineItems { get; set; }
    }

}
