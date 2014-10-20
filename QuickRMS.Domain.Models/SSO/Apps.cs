using Quick.Framework.Tool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickRMS.Domain.Models.SSO
{
    public class Apps :EntityBase<int>
    {
        public Apps()
        {
        }


        //public int AppID { get; set; }
        public string APIKey { get; set; }
        public string AppName { get; set; }
        public string AppDesc { get; set; }
        public bool IsOnline { get; set; }
        public string EncrytKey { get; set; }
        public string CallBackUrl { get; set; }
        public string AppType { get; set; }

        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }

    }
}
