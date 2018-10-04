using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using STM.ATDB.Core;
using STM.ATDB.Model.Common;
using STM.ATDB.Model.Transaction;
using STM.ATDB.MvcWeb.App_Helpers;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace STM.ATDB.MvcWeb.Controllers
{

    public class CommonController : SECBaseController
    {
        private ICommonService CommonService;
        private IMasterService MasterService;
        private ITransactionService TransactionService;
        public CommonController(ICommonService commonService, IMasterService masterService, ITransactionService transactionService)
        {
            this.CommonService = commonService;
            this.MasterService = masterService;
            this.TransactionService = transactionService;
        }

        [HttpGet]
        public ActionResult GetEmployee(DataSourceLoadOptions loadOptions, EmpCriteria criteria)
        {
            List<EmpComboResult> employeeCombo = this.CommonService.GetEmp(criteria);

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(employeeCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        #region MAS010

        [HttpGet]
        public ActionResult GetUserStatus(DataSourceLoadOptions loadOptions, MiscCriteria criteria)
        {
            criteria.IsActive = true;
            criteria.FieldName = ConstantValues.Status;
            List<MiscCombo> dataCombo = this.CommonService.GetMiscCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                dataCombo.Insert(0, new MiscCombo() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(dataCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetDisplayStatus(DataSourceLoadOptions loadOptions, MiscCriteria criteria)
        {
            criteria.IsActive = true;
            criteria.FieldName = ConstantValues.DisplayStatus;
            List<MiscCombo> dataCombo = this.CommonService.GetMiscCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                dataCombo.Insert(0, new MiscCombo() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(dataCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        //[HttpGet]
        //public ActionResult GetWorkStatus(DataSourceLoadOptions loadOptions, MiscCriteria criteria)
        //{
        //    criteria.IsActive = true;
        //    criteria.FieldName = ConstantValues.WorkStatus;
        //    List<MiscCombo> dataCombo = this.CommonService.GetMiscCombo(criteria);

        //    if ((criteria.IncludeAll ?? false) == true)
        //        dataCombo.Insert(0, new MiscCombo() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });

        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(dataCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        [HttpGet]
        public ActionResult GetEmpStatus(DataSourceLoadOptions loadOptions, MiscCriteria criteria)
        {
            criteria.IsActive = true;
            criteria.FieldName = ConstantValues.EmpStatus;
            List<MiscCombo> dataCombo = this.CommonService.GetMiscCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                dataCombo.Insert(0, new MiscCombo() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(dataCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetWorkShiftStatus(DataSourceLoadOptions loadOptions, MiscCriteria criteria)
        {
            criteria.IsActive = true;
            criteria.FieldName = ConstantValues.WorkShiftStatus;
            List<MiscCombo> dataCombo = this.CommonService.GetMiscCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                dataCombo.Insert(0, new MiscCombo() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(dataCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetDivision(DataSourceLoadOptions loadOptions, DivisionCriteriaCombo criteria)
        {
            criteria.userCode = UserDetail.UserID;
            List<DivisionCombo> divisionCombo = this.CommonService.GetDivisionCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                divisionCombo.Insert(0, new DivisionCombo() { DivCodeKey = ConstantValues.AllValue, DivName = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(divisionCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetDepartment(DataSourceLoadOptions loadOptions, DepartmentCriteriaCombo criteria)
        {
            criteria.userCode = UserDetail.UserID;
            List<DepartmentCombo> departmentCombo = this.CommonService.GetDepartmentCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                departmentCombo.Insert(0, new DepartmentCombo() { DeptCodeKey = ConstantValues.AllValue, DeptName = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(departmentCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetDepartmentAjax(DataSourceLoadOptions loadOptions, string criteriaText)
        {

            DepartmentCriteriaCombo criteria = CommonUtils.JSONToObject<DepartmentCriteriaCombo>(criteriaText);
            criteria.userCode = UserDetail.UserID;

            var departmentCombo = this.CommonService.GetDepartmentCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                departmentCombo.Insert(0, new DepartmentCombo() { DeptCodeKey = ConstantValues.AllValue, DeptName = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(departmentCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetSection(DataSourceLoadOptions loadOptions, SectionCriteriaCombo criteria)
        {
            criteria.userCode = UserDetail.UserID;
            List<SectionCombo> sectionCombo = this.CommonService.GetSectionCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                sectionCombo.Insert(0, new SectionCombo() { SecCodeKey = ConstantValues.AllValue, SecName = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(sectionCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetSectionAjax(DataSourceLoadOptions loadOptions, string criteriaText)
        {

            SectionCriteriaCombo criteria = CommonUtils.JSONToObject<SectionCriteriaCombo>(criteriaText);
            criteria.userCode = UserDetail.UserID;

            var sectionCombo = this.CommonService.GetSectionCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                sectionCombo.Insert(0, new SectionCombo() { SecCodeKey = ConstantValues.AllValue, SecName = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(sectionCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetGroup(DataSourceLoadOptions loadOptions, GroupCriteriaCombo criteria)
        {
            List<GroupCombo> groupCombo = this.CommonService.GetGroupCombo(criteria);

            if ((criteria.IncludeAll ?? false) == true)
                groupCombo.Insert(0, new GroupCombo() { GroupCode = ConstantValues.AllValue, GroupCodeDisplay = ConstantValues.AllDisplay });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(groupCombo, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        #endregion

        //[HttpGet]
        //public ActionResult GetAllStatus(DataSourceLoadOptions loadOptions, bool? IncludeAll)
        //{
        //    MiscCriteria criteria = new MiscCriteria() { FieldName = ConstantValues.STATUS_MISC_FIELDNAME };
        //    List<Misc> list = CommonService.GetMiscs(criteria);
        //    if ((IncludeAll ?? false) == true)
        //        list.Insert(0, new Misc() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(list, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetTitleName(DataSourceLoadOptions loadOptions, bool? IncludeAll)
        //{
        //    MiscCriteria criteria = new MiscCriteria() { FieldName = ConstantValues.STATUS_MISC_TITLE_NAME };
        //    List<Misc> list = CommonService.GetMiscs(criteria);
        //    if ((IncludeAll ?? false) == true)
        //        list.Insert(0, new Misc() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(list, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}


        //[HttpGet]
        //public ActionResult GetTitleNameForUser(DataSourceLoadOptions loadOptions, bool? IncludeAll)
        //{
        //    MiscCriteria criteria = new MiscCriteria() { FieldName = ConstantValues.STATUS_MISC_TITLE_NAME_USER };
        //    List<Misc> list = CommonService.GetMiscs(criteria);
        //    if ((IncludeAll ?? false) == true)
        //        list.Insert(0, new Misc() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(list, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetUserType(DataSourceLoadOptions loadOptions, bool? IncludeAll)
        //{
        //    MiscCriteria criteria = new MiscCriteria() { FieldName = ConstantValues.STATUS_MISC_USERTYPE };
        //    List<Misc> list = CommonService.GetMiscs(criteria);
        //    if ((IncludeAll ?? false) == true)
        //        list.Insert(0, new Misc() { ValueCode = ConstantValues.AllValue, ValueDisplay = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(list, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}
        //[HttpGet]
        //public ActionResult GetStatusBoolean(DataSourceLoadOptions loadOptions)
        //{
        //    MiscCriteria criteria = new MiscCriteria() { FieldName = ConstantValues.STATUS_MISC_FIELDNAME };
        //    List<Misc> list = this.CommonService.GetMiscs(criteria);
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(list, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetCompany(DataSourceLoadOptions loadOptions, CommonCriteria criteria)
        //{
        //    //criteria.UserSelectedDate = CommonUtils.JSONToObject<DateTime?>(criteria.UserSelectedDateText);
        //    //List<Company> company = this.MasterService.GetCompany(criteria);

        //    //if ((criteria.IncludeAll ?? false) == true)
        //    //    company.Insert(0, new Company() { CompanyCode = ConstantValues.AllValue, CompanyName = ConstantValues.AllDisplay });
        //    //return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(company, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //    return null;
        //}

        //[HttpGet]
        //public ActionResult GetCompanyByUser(DataSourceLoadOptions loadOptions, CommonCriteria criteria)
        //{
        //    //criteria.UserID = UserDetail.UserID;
        //    //criteria.UserSelectedDate = CommonUtils.JSONToObject<DateTime?>(criteria.UserSelectedDateText);
        //    //List<Company> company = this.MasterService.GetCompanyByUser(criteria);


        //    //if(!(criteria.IncludeDelete ?? true))
        //    //{
        //    //    company = company.Where(d => d.DeleteFlag == false).ToList();
        //    //}

        //    //if ((criteria.IncludeAll ?? false) == true)
        //    //    company.Insert(0, new Company() { CompanyCode = ConstantValues.AllValue, CompanyName = ConstantValues.AllDisplay });

        //    //return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(company, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //    return null;
        //}


        //[HttpGet]
        //public ActionResult GetCompanyUser(DataSourceLoadOptions loadOptions, bool? IncludeAll, string Type)
        //{
        //    //List<Company> company = new List<Company>();
        //    //if (Type == "STM")
        //    //{
        //    //    //List<Plant> plants = this.MasterService.GetPlants(new PlantCriteria());
        //    //    //foreach (var p in plants)
        //    //    //{
        //    //    //    company.Add(new Company() { CompanyCode = p.PlantCode, CompanyName = p.PlantName });
        //    //    //}
        //    //}
        //    //else if (Type == "OTS")
        //    //{
        //    //    company = this.MasterService.GetCompany(new CompanyCriteria());
        //    //}
        //    //else
        //    //    company = new List<Company>();
        //    //if ((IncludeAll ?? false) == true)
        //    //    company.Insert(0, new Company() { CompanyCode = ConstantValues.AllValue, CompanyName = ConstantValues.AllDisplay });
        //    //return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(company, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //    return null;
        //}

        //[HttpGet]
        //public ActionResult GetEmployee(DataSourceLoadOptions loadOptions, bool? IncludeAll)
        //{
        //    List<EmployeeResult> employee = this.CommonService.GetEmployee(new EmployeeCriteria());
        //    if ((IncludeAll ?? false) == true)
        //        employee.Insert(0, new EmployeeResult() { StaffID = ConstantValues.AllValue_Int, Display = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(employee, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetEmployeeByCriteria(DataSourceLoadOptions loadOptions, string criteriaText)
        //{
        //    EmployeeCriteria criteria = CommonUtils.JSONToObject<EmployeeCriteria>(criteriaText);
        //    List<EmployeeResult> employee = this.CommonService.GetEmployee(criteria);
        //    if (criteria.includeAll)
        //        employee.Insert(0, new EmployeeResult() { StaffID = ConstantValues.AllValue_Int, Display = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(employee, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetStaffRole(DataSourceLoadOptions loadOptions, bool includeAll, string userSelectedDate)
        //{
        //    //DateTime? UserSelectedDate = CommonUtils.JSONToObject<DateTime?>(userSelectedDate);

        //    //var staffrole = this.MasterService.GetStaffRoles(new StaffRoleCriteria() { UserSelectedDate = UserSelectedDate, UserID = UserDetail.UserID });
        //    //if (includeAll)
        //    //    staffrole.Insert(0, new StaffRole() { RoleCode = ConstantValues.AllValue, RoleName = ConstantValues.AllDisplay });
        //    //return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(staffrole, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //    return null;
        //}

        //[HttpGet]
        //public ActionResult GetAllWorkShift(DataSourceLoadOptions loadOptions, bool includeAll)
        //{
        //    var workshift = this.CommonService.GetAllWorkShift();
        //    if (includeAll)
        //        workshift.Insert(0, new WorkShiftResult() { ShiftCode = ConstantValues.AllValue, ShiftName = ConstantValues.AllDisplay });
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(workshift, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}



    }
}