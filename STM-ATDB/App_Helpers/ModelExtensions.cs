using STM.ATDB.Model.Security;
using STM.ATDB.Model.Transaction;
using STM.ATDB.MvcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.App_Helpers
{
    public static partial class ModelExtensions
    {
        #region "Validate Summary"
        public static MvcHtmlString SECValidationSummary(this HtmlHelper helper, string id = "page-validation-summary")
        {
            TagBuilder builder = new TagBuilder("div");
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("class", "alert alert-danger alert-block");
            builder.MergeAttribute("style", "display:none");
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString SECSuccessSummary(this HtmlHelper helper, string id = "page-success-summary")
        {
            TagBuilder builder = new TagBuilder("div");
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("class", "alert alert-success alert-block");
            builder.MergeAttribute("style", "display:none");
            return MvcHtmlString.Create(builder.ToString());
        }
        #endregion

        //#region OutsourceCompany
        //public static Company ToEntity(this OutsourceCompanyViewModel model)
        //{
        //    var entity = AutoMapper.Mapper.Map<Company>(model);
        //    return entity;
        //}

        //public static List<Company> ToEntities(this List<OutsourceCompanyViewModel> models)
        //{
        //    List<Company> entityList = new List<Company>();
        //    foreach (OutsourceCompanyViewModel model in models)
        //    {
        //        entityList.Add(model.ToEntity());
        //    }
        //    return entityList;
        //}


        //public static OutsourceCompanyViewModel ToModel(this Company outsourceCompany)
        //{
        //    var entity = AutoMapper.Mapper.Map<OutsourceCompanyViewModel>(outsourceCompany);
        //    return entity;
        //}

        //public static List<OutsourceCompanyViewModel> ToModels(this List<Company> outsourceCompanys)
        //{
        //    List<OutsourceCompanyViewModel> modelList = new List<OutsourceCompanyViewModel>();
        //    foreach (Company outsourceCompany in outsourceCompanys)
        //    {
        //        modelList.Add(outsourceCompany.ToModel());
        //    }
        //    return modelList;
        //}
        //#endregion

        #region Login
        public static LoginViewModel ToModel(this User view)
        {
            var entity = AutoMapper.Mapper.Map<LoginViewModel>(view);
            return entity;
        }

        public static User ToEntity(this LoginViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<User>(model);
            return entity;
        }

        public static UserInformation ToUserInformation(this User view)
        {
            var entity = AutoMapper.Mapper.Map<UserInformation>(view);
            return entity;
        }

        #endregion

        public static string GetFullErrorMessage(this System.Web.Http.ModelBinding.ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        #region UserMaintenance
        public static User ToEntity(this UserMaintenanceViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<User>(model);
            return entity;
        }

        public static List<User> ToEntities(this List<UserMaintenanceViewModel> models)
        {
            List<User> entityList = new List<User>();
            foreach (UserMaintenanceViewModel model in models)
            {
                entityList.Add(model.ToEntity());
            }
            return entityList;
        }

        #endregion

        //#region Export Excel
        //public static TimeInOutReportCriteria ToEntity(this TimeInOutViewModel model)
        //{
        //    var entity = AutoMapper.Mapper.Map<TimeInOutReportCriteria>(model);
        //    return entity;
        //}
        //#endregion

        #region Permission
        public static PermissionViewModel ToModel(this ScreenPermissionListResult view)
        {
            var entity = AutoMapper.Mapper.Map<PermissionViewModel>(view);
            return entity;
        }

        public static PermissionViewModel ToModel(this ScreenPermissionListTreeResult view)
        {
            var entity = AutoMapper.Mapper.Map<PermissionViewModel>(view);
            return entity;
        }

        public static ScreenPermissionListResult ToEntity(this PermissionViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<ScreenPermissionListResult>(model);
            return entity;
        }
        public static ScreenPermissionListTreeResult ToEntity2(this PermissionViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<ScreenPermissionListTreeResult>(model);
            return entity;
        }
        #endregion

        public static List<GoOutReasonViewModel> ToModels(this List<GoOutReason> models)
        {
            List<GoOutReasonViewModel> modelList = new List<GoOutReasonViewModel>();
            foreach (GoOutReason model in models)
            {
                modelList.Add(model.ToModel());
            }
            return modelList;
        }

        public static GoOutReasonViewModel ToModel(this GoOutReason data)
        {
            var entity = AutoMapper.Mapper.Map<GoOutReasonViewModel>(data);
            //entity.FullName = data.EmpCode;
            return entity;
        }

        //public static GoOutReasonViewModel ToModel(this GoOutReasonByID data)
        //{
        //    var entity = AutoMapper.Mapper.Map<GoOutReasonViewModel>(data);
        //    entity.FullName = data.EmpCode;
        //    return entity;
        //}

        public static GoOutReason ToEntity(this GoOutReasonViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<GoOutReason>(model);
            return entity;
        }

        public static List<EmployeeSettingViewModel> ToModels(this List<EmployeeSetting> models)
        {
            List<EmployeeSettingViewModel> modelList = new List<EmployeeSettingViewModel>();
            foreach (EmployeeSetting model in models)
            {
                modelList.Add(model.ToModel());
            }
            return modelList;
        }

        public static EmployeeSettingViewModel ToModel(this EmployeeSetting data)
        {
            var entity = AutoMapper.Mapper.Map<EmployeeSettingViewModel>(data);
            return entity;
        }

        public static List<HideOrganizationViewModel> ToModels(this List<HideOrg> models)
        {
            List<HideOrganizationViewModel> modelList = new List<HideOrganizationViewModel>();
            foreach (HideOrg model in models)
            {
                modelList.Add(model.ToModel());
            }
            return modelList;
        }

        public static HideOrganizationViewModel ToModel(this HideOrg data)
        {
            var entity = AutoMapper.Mapper.Map<HideOrganizationViewModel>(data);
            return entity;
        }

        public static HideOrg ToEntity(this HideOrganizationViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<HideOrg>(model);

            if (entity.DivCodeKey == ConstantValues.AllValue)
                entity.DivCodeKey = null;

            if (entity.DeptCodeKey == ConstantValues.AllValue)
                entity.DeptCodeKey = null;

            if (entity.SecCodeKey == ConstantValues.AllValue)
                entity.SecCodeKey = null;

            return entity;
        }

        public static List<FixOrganizationViewModel> ToModels(this List<FixOrgEmp> models)
        {
            List<FixOrganizationViewModel> modelList = new List<FixOrganizationViewModel>();
            foreach (FixOrgEmp model in models)
            {
                modelList.Add(model.ToModel());
            }
            return modelList;
        }

        public static FixOrganizationViewModel ToModel(this FixOrgEmp data)
        {
            var entity = AutoMapper.Mapper.Map<FixOrganizationViewModel>(data);
            return entity;
        }

        public static FixOrgEmp ToEntity(this FixOrganizationViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<FixOrgEmp>(model);

            entity.DivCodeKey = (entity.DivCodeKey == ConstantValues.AllValue) ? null : entity.DivCodeKey;
            entity.DeptCodeKey = (entity.DeptCodeKey == ConstantValues.AllValue) ? null : entity.DeptCodeKey;
            entity.SecCodeKey = (entity.SecCodeKey == ConstantValues.AllValue) ? null : entity.SecCodeKey;

            return entity;
        }

        public static List<AssignWorkShiftViewModel> ToModels(this List<AssignWorkShiftByEmp> models)
        {
            List<AssignWorkShiftViewModel> modelList = new List<AssignWorkShiftViewModel>();
            foreach (AssignWorkShiftByEmp model in models)
            {
                modelList.Add(model.ToModel());
            }
            return modelList;
        }

        public static AssignWorkShiftViewModel ToModel(this AssignWorkShiftByEmp data)
        {
            var entity = AutoMapper.Mapper.Map<AssignWorkShiftViewModel>(data);
            return entity;
        }

        public static AssignWorkShiftByEmp ToEntity(this AssignWorkShiftViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<AssignWorkShiftByEmp>(model);
            return entity;
        }
    }
}
