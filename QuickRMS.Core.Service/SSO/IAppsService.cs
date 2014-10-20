

using Quick.Framework.Tool;
using Quick.Site.Common.Models;
using QuickRMS.Domain.Models.SSO;
using QuickRMS.Site.Models.SSO;
using QuickRMS.Site.Models.SSO.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickRMS.Core.Service.SSO
{
    /// <summary>
    /// 服务层接口 —— IAppsService
    /// </summary>
    public interface IAppsService
    {


        #region 属性

        IQueryable<Apps> Apps { get; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 复选框数据源
        /// </summary>
        /// <returns></returns>
        List<KeyValueModel> GetKeyValueList();

        OperationResult Insert(AppsModel model);

        OperationResult Update(AppsModel model);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(int Id);

        #endregion
    }
}
