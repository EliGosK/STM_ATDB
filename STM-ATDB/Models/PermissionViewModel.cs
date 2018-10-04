using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{

    public class PermissionViewModel
    {
        public PermissionViewModel()
        {
            this.Expanded = true;
        }
        public string PermissionCode { get; set; }
        public string ParentText { get; set; }
        public string ParentCode { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public bool Expanded { get; set; }
        public bool IsHavePermission { get; set; }
        public List<PermissionViewModel> Items { get; set; }

        public string ItemKey
        {
            get
            {
                if (String.IsNullOrEmpty(ParentText))
                {
                    return string.Concat("","|","","|",this.Code,this.Text);
                }
                else
                {
                    return string.Concat(ParentCode, "|", this.Code, "|", this.Code, this.Text, ParentText);
                }
            }
        }

        public string SearchText
        {
            get
            {
                if (String.IsNullOrEmpty(ParentText))
                {
                    return this.Text;
                }
                else
                {
                    return string.Concat(this.Text, ParentText);
                }
            }
        }

    }

    public class PermissionSaveViewModel
    {
        public string UserID { get; set; }
        //public string PermissionListString { get; set; }
        public List<PermissionViewModel> PermissionList { get; set; }

    }
}
