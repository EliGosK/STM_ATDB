using STM.ATDB.Model.Common;
using STM.ATDB.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Services
{
    public interface IMasterService
    {
        //Company GetOutsourceCompany(OutsourceCompanyCriteria criteria);
        //List<Company> GetOutsourceCompanys(OutsourceCompanyCriteria criteria);
        //int? AddOutsourceCompany(Company rowData);
        //int? EditOutsourceCompany(Company rowData);
        //int? DeleteOutsourceCompany(Company rowData);
        //int CanDeleteCompany(Company item);

        //List<Company> GetCompany(CompanyCriteria criteria);
        //List<Company> GetCompany(CommonCriteria criteria);
        //List<StaffRole> GetStaffRoles(StaffRoleCriteria criteria);
        //List<Company> GetCompanyByUser(CommonCriteria criteria);

        //void InsertStaffRole(StaffRole role);
        //void UpdateStaffRole(StaffRole role);
        //void DeleteStaffRole(StaffRole role);

        List<EmployeeSetting> GetEmployeeSetting(EmployeeSettingCriteria criteria);
        UpdateDisplayStatusResult UpdateDisplayStatus(string empCodeXML, string displayStatus, string userCode);
        UpdateUserStatusResult UpdateUserStatus(string empCodeXML, string userStatus, string userCode);
        ResetPasswordResult ResetPassword(string empCodeXML, string userCode);

        List<HideOrg> SearchHideOrganization(HideOrganizationCriteria criteria);
        SaveHideOrgResult SaveHideorganization(HideOrg entity, string Mode);
        DeleteHideOrgResult DeleteHideOrganization(HideOrg entity);

        List<FixOrgEmp> SearchFixOrganization(FixOrganizationCriteria criteria);
        SaveFixOrgByEmpResult SaveFixOrganization(FixOrgEmp entity, string Mode);
        DeleteFixOrgByEmpResult DeleteFixOrganization(FixOrgEmp entity);

        List<AssignWorkShiftByEmp> SearchAssignWorkShiftByEmp(AssignWorkShiftCriteria criteria);
        InsertWorkShiftByEmpResult InsertAssignWorkShiftByEmp(AssignWorkShiftByEmp entity);
        UpdateWorkShiftByEmpResult UpdateAssignWorkShiftByEmp(AssignWorkShiftByEmp entity);
        DeleteWorkShiftByEmpResult DeleteAssignWorkShiftByEmp(AssignWorkShiftByEmp entity);

    }
}
