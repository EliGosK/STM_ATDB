using STM.ATDB.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Core
{
    public class PermissionRecord
    {

        public string ObjectId { get; set; }
        public string PermissionCode { get; set; }
        public bool IsChecked { get; set; }
    }

    public class PermissionRecordKey
    {
        public string ObjectId { get; set; }
        public string PermissionCode { get; set; }
    }


    public class PermissionName
    {
        public static readonly NameValueOption View = new NameValueOption("View", "VIEW");
        public static readonly NameValueOption Add = new NameValueOption("Add", "ADD");
        public static readonly NameValueOption Edit = new NameValueOption("Edit", "EDIT");
        public static readonly NameValueOption Delete = new NameValueOption("Delete", "DELETE");
        public static readonly NameValueOption Import = new NameValueOption("Import", "IMPORT");

    }
}
