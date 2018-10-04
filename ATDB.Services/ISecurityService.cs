using STM.ATDB.Core;
using STM.ATDB.Core.ComponentModel;
using STM.ATDB.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Services
{
    public interface ISecurityService
    {
        List<ScreenPermissionListResult> GetPermissions(string UserID);
        //IEnumerable<PermissionRecord> GetPermissionsByRole(int roleId);

        //ObjectResult UpdatePermission(IList<PermissionRecord> permissions);

        //ObjectResult DeletesPermission(int roleId);

        User CheckUserLogin(User user);
        ObjectResult ChangePassword(User user);

        void UpdateUser(User user, string listCompany,string listPlant);
        void InsertUser(User user, string listCompany,string listPlant);
        void DeleteUser(string user);
        List<ScreenPermissionListResult> GetScreenPermissionList(ScreenPermissionListCriteria criteria);
        List<ScreenPermissionListTreeResult> GetScreenPermissionListTree(ScreenPermissionListCriteria criteria);
        
        List<UserAndRoleListResult> GetUserAndRoleList(UserCriteria criteria);
        void SavePermission(string UserID,string UserType, List<ScreenPermissionListTreeResult> lPermission, string UpdateBy);

    }
}
