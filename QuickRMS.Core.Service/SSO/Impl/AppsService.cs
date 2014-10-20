using Quick.Framework.Tool;
using Quick.Site.Common.Models;
using QuickRMS.Core.Repository.SSO;
using QuickRMS.Core.Service.SSO;
using QuickRMS.Domain.Models.SSO;
using QuickRMS.Site.Models.SSO;
using QuickRMS.Site.Models.SSO.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickRMS.Core.Service.SSO.Impl
{

    /// <summary>
    /// 服务层实现 —— AppsService
    /// </summary>
    [Export(typeof(IAppsService))]
    public class AppsService : CoreServiceBase, IAppsService
    {

        #region 属性

        [Import]
        public IAppsRepository AppsRepository { get; set; }

        public IQueryable<Apps> Apps
        {
            get { return AppsRepository.Entities; }
        }

        #endregion


        #region 公共方法

        /// <summary>
        /// 复选框数据源
        /// </summary>
        /// <returns></returns>
        public List<KeyValueModel> GetKeyValueList()
        {
            var keyValueList = new List<KeyValueModel>();
            var dataList = Apps.Where(t => t.IsDeleted == false)
                                .OrderBy(t => t.Id)
                                .ToList();
            foreach (var data in dataList)
            {
                keyValueList.Add(new KeyValueModel { Text = data.AppName, Value = data.APIKey.ToString() });
            }
            return keyValueList;
        }

        public OperationResult Insert(AppsModel model)
        {
            var entity = new Apps
            {
                AppName = model.AppName,
                AppDesc = model.AppDesc,
                APIKey = model.APIKey,
                AppType = model.AppType,
                CallBackUrl = model.CallBackUrl,
                EncrytKey = model.EncrytKey,
                IsOnline = model.IsOnline
            };
            AppsRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Update(AppsModel model)
        {
            var entity = Apps.First(t => t.Id == model.Id);
            entity.AppName = model.AppName;
            entity.AppDesc = model.AppDesc;
            entity.APIKey = model.APIKey;
            entity.AppType = model.AppType;
            entity.CallBackUrl = model.CallBackUrl;
            entity.EncrytKey = model.EncrytKey;
            entity.IsOnline = model.IsOnline;

            AppsRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "更新成功");
        }

        public OperationResult Delete(int Id)
        {
            var model = Apps.FirstOrDefault(t => t.Id == Id);
            model.IsDeleted = true;

            AppsRepository.Update(model);
            return new OperationResult(OperationResultType.Success, "删除成功");
        }

        #endregion


    }
}
