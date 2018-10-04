
using STM.ATDB.Model.Common;
using STM.ATDB.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace STM.ATDB.Services
{
    public class MasterService: IMasterService
    {
        private TransactionEntities _Context = null;
        public TransactionEntities Context
        {

            get
            {
                if(_Context == null)
                {
                    _Context = new TransactionEntities();
                }
                return _Context;
            }

            private set
            {
                _Context = value;
            }
        }

        public MasterService()
        {
            Context = new TransactionEntities();
        }

        public MasterService(TransactionEntities context)
        {
            _Context = context;
        }

        #region MAS010

        public List<EmployeeSetting> GetEmployeeSetting(EmployeeSettingCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.SearchEmpSetting(
                        searchEmpCode: criteria.searchEmpCode
                        , searchEmpName: criteria.searchEmpName
                        , divCodeKey: criteria.divCodeKey
                        , deptCodeKey: criteria.deptCodeKey
                        , secCodeKey: criteria.secCodeKey
                        , empStatus: criteria.empStatus
                        , userStatus: criteria.userStatus
                        , displayStatus: criteria.displayStatus
                        , isViewActiveOrg: criteria.viewActiveOrg
                        , userCode: criteria.userCode
                    ).ToList();

                return result;
            }
        }

        public UpdateDisplayStatusResult UpdateDisplayStatus(string empCodeXML, string displayStatus, string userCode)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.UpdateDisplayStatus(
                        empCodeXML: empCodeXML
                        , displayStatus: displayStatus
                        , userCode: userCode
                    ).FirstOrDefault();

                return result;
            }
        }

        public UpdateUserStatusResult UpdateUserStatus(string empCodeXML, string userStatus, string userCode)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.UpdateUserStatus(
                        empCodeXML: empCodeXML
                        , userStatus: userStatus
                        , userCode: userCode
                    ).FirstOrDefault();

                return result;
            }
        }

        public ResetPasswordResult ResetPassword(string empCodeXML, string userCode)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.ResetPassword(
                        empCodeXML: empCodeXML
                        , userCode: userCode
                    ).FirstOrDefault();

                return result;
            }
        }

        #endregion

        #region MAS020

        public List<HideOrg> SearchHideOrganization(HideOrganizationCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.SearchHideOrg(
                        prodDateFrom: criteria.DateFrom
                        , prodDateTo: criteria.DateTo
                        , divCodeKey: criteria.DivCode
                        , deptCodeKey: criteria.DeptCode
                        , secCodeKey: criteria.SecCode
                        , orgCode: criteria.orgCode
                        , hideDateFrom: criteria.HideDateFrom
                    ).ToList();

                return result;
            }
        }

        public SaveHideOrgResult SaveHideorganization(HideOrg entity, string Mode)
        {

            using (TransactionEntities context = new TransactionEntities())
            {
                var result = context.SaveHideOrg(
                        mode: Mode
                        , hideDateFrom: entity.HideDateFrom
                        , hideDateTo: entity.HideDateTo
                        , orgCode: entity.OrgCode
                        , divCodeKey: entity.DivCodeKey
                        , deptCodeKey: entity.DeptCodeKey
                        , secCodeKey: entity.SecCodeKey
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        public DeleteHideOrgResult DeleteHideOrganization(HideOrg entity)
        {

            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.DeleteHideOrg(
                        orgCode: entity.OrgCode
                        , hideDateFrom: entity.HideDateFrom
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        #endregion

        #region MAS030

        public List<FixOrgEmp> SearchFixOrganization(FixOrganizationCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.SearchFixOrgByEmp(
                        prodDateFrom: criteria.ProdDateFrom
                        , prodDateTo: criteria.ProdDateTo
                        , searchEmpCode: criteria.SearchEmpCode
                        , searchEmpName: criteria.SearchEmpName
                        , empCode: criteria.EmpCode
                        , effectiveDateFrom: criteria.EffectiveDateFrom
                    ).ToList();

                return result;
            }
        }

        public SaveFixOrgByEmpResult SaveFixOrganization(FixOrgEmp entity, string Mode)
        {

            using (TransactionEntities context = new TransactionEntities())
            {
                var result = context.SaveFixOrgByEmp(
                        mode: Mode
                        , empCode: entity.EmpCode
                        , effectiveDateFrom: entity.EffectiveDateFrom
                        , effectiveDateTo: entity.EffectiveDateTo
                        , divCodeKey: entity.DivCodeKey
                        , deptCodeKey: entity.DeptCodeKey
                        , secCodeKey: entity.SecCodeKey
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        public DeleteFixOrgByEmpResult DeleteFixOrganization(FixOrgEmp entity)
        {

            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.DeleteFixOrgByEmp(
                        empCode: entity.EmpCode
                        , effectiveDateFrom: entity.EffectiveDateFrom
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        #endregion

        #region MAS040

        public List<AssignWorkShiftByEmp> SearchAssignWorkShiftByEmp(AssignWorkShiftCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.SearchWorkShiftByEmp(
                        prodDateFrom: criteria.prodDateFrom
                        , prodDateTo: criteria.prodDateTo
                        , searchEmpCode: criteria.srhEmpCode
                        , searchEmpName: criteria.srhEmpName
                        , shiftCode: criteria.shiftCode
                        , prodDate: criteria.prodDate
                        , empCode: criteria.empCode
                    ).ToList();

                return result;
            }
        }

        public InsertWorkShiftByEmpResult InsertAssignWorkShiftByEmp(AssignWorkShiftByEmp entity)
        {

            using (TransactionEntities context = new TransactionEntities())
            {
                var result = context.InsertWorkShiftByEmp(
                        prodDateFrom: entity.ProdDateFrom
                        , prodDateTo: entity.ProdDateTo
                        , empCode: entity.EmpCode
                        , shiftCode: entity.ShiftCode
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        public UpdateWorkShiftByEmpResult UpdateAssignWorkShiftByEmp(AssignWorkShiftByEmp entity)
        {

            using (TransactionEntities context = new TransactionEntities())
            {
                var result = context.UpdateWorkShiftByEmp(
                        prodDate: entity.ProdDate
                        , empCode: entity.EmpCode
                        , shiftCode: entity.ShiftCode
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        public DeleteWorkShiftByEmpResult DeleteAssignWorkShiftByEmp(AssignWorkShiftByEmp entity)
        {

            using (TransactionEntities context = new TransactionEntities())
            {
                var result = context.DeleteWorkShiftByEmp(
                        prodDate: entity.ProdDate
                        , empCode: entity.EmpCode
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        #endregion

        //#region Company
        //public List<Company> GetCompany(CompanyCriteria criteria)
        //{
        //    using (TransactionEntities Context = new TransactionEntities())
        //    {
        //        if (criteria.UserSelectedDate.HasValue)
        //        {
        //            return Context.Companies.Where(d => d.DeleteFlag == (criteria.DeleteFlag ?? d.DeleteFlag))
        //                                    .Where(d => d.Status == criteria.Status || criteria.Status == null)
        //                                    .Where(d => d.DeleteFlag == false || (d.DeleteFlag == true && d.UpdatedDate > criteria.UserSelectedDate))
        //                                    .ToList();
        //        }
        //        else
        //        {
        //            return Context.Companies.Where(d => d.DeleteFlag == (criteria.DeleteFlag ?? d.DeleteFlag)).Where(d => d.Status == criteria.Status || criteria.Status == null).ToList();
        //        }
        //    }

        //}
        //public List<Company> GetCompany(CommonCriteria criteria)
        //{
        //    List<Company> list = new List<Company>();
        //    using (TransactionEntities Context = new TransactionEntities())
        //    {
        //        list = Context.Companies.Where(d => (criteria.IncludeDelete == null || (criteria.IncludeDelete == false && d.DeleteFlag == false))).ToList();
        //    }
        //    if (!string.IsNullOrEmpty(criteria.ValueCode))
        //    {
        //        string[] valueCode = criteria.ValueCode.Split(',');
        //        foreach (string val in valueCode)
        //        {
        //            if (list.Where(x => x.CompanyCode == val).FirstOrDefault() == null)
        //            {
        //                Company companyVal = Context.Companies.Where(x => x.CompanyCode == val).FirstOrDefault();
        //                if (companyVal != null)
        //                    list.Add(companyVal);
        //            }
        //        }
        //    }

        //    if(criteria.UserSelectedDate.HasValue)
        //    {
        //        list = list.Where(d => d.DeleteFlag == false || (d.DeleteFlag == true && d.UpdatedDate > criteria.UserSelectedDate)).ToList();
        //    }

        //    return list;
        //}


        //public List<Company> GetCompanyByUser(CommonCriteria criteria)
        //{
        //    using (TransactionEntities Context = new TransactionEntities())
        //    {
        //        return Context.GetCompanyByUser(criteria.UserID).ToList();
        //    }

        //}


        //#endregion

        //#region StaffRole
        //public List<StaffRole> GetStaffRoles(StaffRoleCriteria criteria)
        //{
        //    using (TransactionEntities Context = new TransactionEntities())
        //    {
        //        return Context.GetRolesByUser(criteria.UserSelectedDate, criteria.Status, criteria.DeleteFlag, criteria.UserID).ToList();
        //        //if (criteria.UserSelectedDate.HasValue)
        //        //{
        //        //    //return Context.StaffRoles.Where(d => d.DeleteFlag == (criteria.DeleteFlag ?? d.DeleteFlag))
        //        //    //                         .Where(d => d.Status == criteria.Status || criteria.Status == null)
        //        //    //                         .Where(d=> d.DeleteFlag == false || (d.DeleteFlag == true && d.UpdatedDate > criteria.UserSelectedDate))
        //        //    //                         .ToList();

        //        //    return Context.GetRolesByUser(criteria.UserSelectedDate, criteria.Status, criteria.DeleteFlag, criteria.UserID).ToList();
        //        //}
        //        //else
        //        //{
        //        //    return Context.StaffRoles.Where(d => d.DeleteFlag == (criteria.DeleteFlag ?? d.DeleteFlag)).Where(d => d.Status == criteria.Status || criteria.Status == null).ToList();
        //        //}
        //    }

        //}

        //public void InsertStaffRole(StaffRole role)
        //{
        //    role.Status = (role.Status.HasValue ? role.Status : false);
        //    Context.Entry(role).State = System.Data.Entity.EntityState.Added;
        //    Context.SaveChanges();
        //}

        //public void UpdateStaffRole(StaffRole role)
        //{
        //    StaffRole item = Context.StaffRoles.Where(d => d.RoleCode == role.RoleCode).FirstOrDefault();
        //    if (item != null)
        //    {
        //        item.RoleName = role.RoleName;
        //        item.Status = role.Status;
        //        item.UpdatedDate = role.UpdatedDate;
        //        item.UpdatedBy = role.UpdatedBy;

        //        Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        //        Context.SaveChanges();
        //    }
        //}

        //public void DeleteStaffRole(StaffRole role)
        //{
        //    StaffRole item = Context.StaffRoles.Where(d => d.RoleCode == role.RoleCode).FirstOrDefault();
        //    if (item != null)
        //    {
        //        item.DeleteFlag = true;
        //        item.UpdatedDate = role.UpdatedDate;
        //        item.UpdatedBy = role.UpdatedBy;

        //        Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        //        Context.SaveChanges();
        //    }
        //}
        //#endregion
    }
}
