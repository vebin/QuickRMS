using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;

using QuickRMS.Site.WebUI.Common;
using QuickRMS.Core.Service.SSO;
using QuickRMS.Site.WebUI.Extension.Filters;
using System.Web.Mvc;
using QuickRMS.Domain.Models.SSO;
using QuickRMS.Site.Models.SSO;
using QuickRMS.Site.Models.SSO.Apps;
using Quick.Site.Common.Models;
using System.Linq.Expressions;
using Quick.Framework.Tool;

namespace QuickRMS.Site.WebUI.Areas.SSO.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AppsController : AdminController
    {

        //
        // GET: /SSO/Apps/

        #region 属性
        [Import]
        public IAppsService AppsService { get; set; }

        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
            var model = new AppsModel();
            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            int total = AppsService.Apps.Count(t => t.IsDeleted == false);

            //构建查询表达式
            var expr = BuildSearchCriteria();

            var filterResult = AppsService.Apps.Where(expr).Select(t => new AppsModel
            {
                Id = t.Id,
                APIKey=t.APIKey,
                AppName = t.AppName,
                AppType = t.AppType,
                AppDesc = t.AppDesc,
                CallBackUrl = t.CallBackUrl,
                EncrytKey = t.EncrytKey,
                IsOnline = t.IsOnline
            }).OrderBy(t => t.Id).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.APIKey,
                                 c.AppName,
                                 c.AppType,                            
                                 c.AppDesc, 
                                 c.EncrytKey,
								 c.IsOnlineText,
                                 c.CallBackUrl, 
                                 c.Id.ToString()
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iDisplayStart = param.iDisplayStart,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<Apps, Boolean>> BuildSearchCriteria()
        {
            DynamicLambda<Apps> bulider = new DynamicLambda<Apps>();
            Expression<Func<Apps, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["APIKey"]))
            {
                var data = Request["APIKey"].Trim();
                Expression<Func<Apps, Boolean>> tmp = t => t.APIKey.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["AppName"]))
            {
                var data = Request["AppName"].Trim();
                Expression<Func<Apps, Boolean>> tmp = t => t.AppName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["AppType"]))
            {
                var data = Request["AppType"].Trim();
                Expression<Func<Apps, Boolean>> tmp = t => t.AppName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EncrytKey"]))
            {
                var data = Request["EncrytKey"].Trim();
                Expression<Func<Apps, Boolean>> tmp = t => t.AppName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["IsOnline"] == "0" || Request["IsOnline"] == "1")
            {
                var data = Request["IsOnline"] == "1" ? true : false;
                Expression<Func<Apps, Boolean>> tmp = t => t.IsOnline == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
           

            Expression<Func<Apps, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

        public ActionResult Create()
        {
            var model = new AppsModel();
            //InitParentModule(model);

            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Create(AppsModel model)
        {
            if (ModelState.IsValid)
            {
                OperationResult result = AppsService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    return PartialView(model);
                }
            }
            else
            {
                return PartialView(model);
            }
        }

        public ActionResult Edit(int Id)
        {
            var model = new AppsModel();
            var entity = AppsService.Apps.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new AppsModel
                {
                    Id = entity.Id,
                    
                    AppName = entity.AppName,
                    AppDesc = entity.AppDesc,
                    APIKey = entity.APIKey,
                    AppType = entity.AppType,
                    CallBackUrl = entity.CallBackUrl,
                    EncrytKey = entity.EncrytKey,
                    IsOnline = entity.IsOnline
                };
                

            }
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Edit(AppsModel model)
        {
            if (ModelState.IsValid)
            {
                OperationResult result = AppsService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    return PartialView(model);
                }
            }
            else
            {
                return PartialView(model);
            }
        }

        [AdminOperateLog]
        public ActionResult Delete(int Id)
        {
            OperationResult result = AppsService.Delete(Id);
            return Json(result);
        }

        
    }
}