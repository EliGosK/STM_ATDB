using STM.ATDB.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Services
{
    public class CommonService : ICommonService
    {
        private CommonEntities _Context = null;
        public CommonEntities Context
        {

            get
            {
                if (_Context == null)
                {
                    _Context = new CommonEntities();
                }
                return _Context;
            }

            private set
            {
                _Context = value;
            }
        }

        public CommonService()
        {
            Context = new CommonEntities();
        }

        public DateTime? GetProductionDate(DateTime prodDate)
        {
            using (CommonEntities Context = new CommonEntities())
                return Context.GetProductionDate(prodDate).FirstOrDefault();

        }

        public DateTime? GetProductionDate()
        {
            DateTime prodDate = DateTime.Now;
            return GetProductionDate(prodDate);

        }

        public List<EmpComboResult> GetEmp(EmpCriteria criteria)
        {
            using (CommonEntities Context = new CommonEntities())
            {
                var result = Context.GetEmpCombo(
                        prodDateFrom: criteria.ProdDateFrom
                        , prodDateTo: criteria.ProdDateTo
                        , empCode:criteria.EmpCode
                        , isActiveOnly: criteria.IsActiveOnly
                    ).ToList();

                return result;
            }
        }

        public List<DepartmentCombo> GetDepartmentCombo(DepartmentCriteriaCombo criteria)
        {
            using (CommonEntities Context = new CommonEntities())
            {
                var result = Context.GetDepartmentCombo(
                          prodDate: criteria.ProdDate
                        , prodDateFrom: criteria.ProdDateFrom
                        , prodDateTo: criteria.ProdDateTo
                        , divCodeKey: criteria.DivCodeKey
                        , deptCodeKey: criteria.DeptCodeKey
                        , userCode: criteria.userCode
                        , isActiveOnly:  criteria.IsActiveOnly
                    ).ToList();

                return result;
            }
        }

        public List<DivisionCombo> GetDivisionCombo(DivisionCriteriaCombo criteria)
        {
            using (CommonEntities Context = new CommonEntities())
            {
                var result = Context.GetDivisionCombo(
                          prodDate: criteria.ProdDate
                        , prodDateFrom: criteria.ProdDateFrom
                        , prodDateTo: criteria.ProdDateTo
                        , divCodeKey: criteria.DivCodeKey
                        , userCode: criteria.userCode
                        , isActiveOnly: criteria.IsActiveOnly
                    ).ToList();

                return result;
            }
        }

        public List<SectionCombo> GetSectionCombo(SectionCriteriaCombo criteria)
        {
            using (CommonEntities Context = new CommonEntities())
            {
                var result = Context.GetSectionCombo(
                          prodDate: criteria.ProdDate
                        , prodDateFrom: criteria.ProdDateFrom
                        , prodDateTo: criteria.ProdDateTo
                        , deptCodeKey: criteria.DeptCodeKey
                        , secCodeKey: criteria.SecCodeKey
                        , userCode: criteria.userCode
                        , isActiveOnly: criteria.IsActiveOnly
                    ).ToList();

                return result;
            }
        }

        public List<GroupCombo> GetGroupCombo(GroupCriteriaCombo criteria)
        {
            using (CommonEntities Context = new CommonEntities())
            {
                var result = Context.GetGroupCombo(
                          prodDate: criteria.prodDate
                        //, groupCode: criteria.GroupCode
                        , userCode: criteria.UserCode
                    ).ToList();

                return result;
            }
        }

        public List<MiscCombo> GetMiscCombo(MiscCriteria criteria)
        {
            using (CommonEntities Context = new CommonEntities())
            {
                var result = Context.GetMiscCombo(
                          fieldName: criteria.FieldName
                        , isActive: criteria.IsActive
                    ).ToList();

                return result;
            }
        }

        //public Misc GetMisc(MiscCriteria criteria)
        //{
        //    using (CommonEntities Context = new CommonEntities())
        //        return Context.Miscs.Where(d => d.FieldName == criteria.FieldName && d.ValueCode == criteria.ValueCode).FirstOrDefault();

        //}

        //public List<Misc> GetMiscs(MiscCriteria criteria)
        //{
        //    using (CommonEntities Context = new CommonEntities())
        //        return Context.Miscs.Where(d => d.FieldName == criteria.FieldName).OrderBy(d => d.DisplaySeq).ToList();

        //}
        //public List<EmployeeResult> GetEmployee(EmployeeCriteria critreia)
        //{
        //    using (CommonEntities Context = new CommonEntities())
        //        return Context.GetEmployee(pCompanyCode: critreia.CompanyCode).ToList();

        //}

        //public List<WorkShiftResult> GetAllWorkShift()
        //{
        //    using (CommonEntities Context = new CommonEntities())
        //        return Context.GetWorkShift(pShiftCode: null).ToList();

        //}

        //public DocumentNumber GetDocumentRunning(DocumentNumber criteria)
        //{
        //    criteria.RunningResults = Context.GetDocumentNumber(criteria.DocumentKey, criteria.DocumentSystem, criteria.BatchRunning, criteria.RunningDigit).ToList();
        //    return criteria;
        //}
    }
}
