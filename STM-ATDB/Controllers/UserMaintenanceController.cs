using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using STM.ATDB.Core;
using STM.ATDB.Model.Security;
using STM.ATDB.MvcWeb.App_Helpers;
using STM.ATDB.MvcWeb.Models;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class UserMaintenanceController : SECBaseController
    {
        private ISecurityService SecurityService;

        public UserMaintenanceController(ISecurityService securityService)
        {
            this.SecurityService = securityService;
        }
        // GET: UserMaintenance
        [ApplicationAuthorize("ADS010", "VIEW")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchUserMaintenance(DataSourceLoadOptions loadOptions, UserCriteria criteria)
        {
            criteria.UserID = criteria.UserID == "" ? null : criteria.UserID;
            criteria.Name = criteria.Name == "" ? null : criteria.Name;
            criteria.Status = (criteria.StatusCri == ConstantValues.AllValue ? null : (bool?)(criteria.StatusCri == ConstantValues.STATUS_MISC_STATUS_ACTIVE ? true : false));
            List<UserMaintenanceViewModel> userList = new List<UserMaintenanceViewModel>();
            //List<UserMaintenanceViewModel> userList = this.SecurityService.GetUserMaintenance(criteria).ToModels();
            //foreach (UserMaintenanceViewModel user in userList)
            //{
            //    user.Password = CommonUtils.Decrypt(user.Password);
            //}
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(userList, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUserMaintenance(string values)
        {
            UserMaintenanceViewModel userInsert = new UserMaintenanceViewModel();
            JsonConvert.PopulateObject(values, userInsert);

            //check duplicate
            //UserMaintenanceViewModel userDup = this.SecurityService.GetUserMaintenance(new UserCriteria() { UserID = userInsert.UserID }).FirstOrDefault().ToModel();
            //if (userDup != null)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User ID is Duplicate");
            userInsert.Password = CommonUtils.Encrypt(userInsert.Password);
            userInsert.CreatedBy = userInsert.UpdatedBy = UserDetail.UserID;
            userInsert.CreatedDate = userInsert.UpdatedDate = CurrentDateTime;
            ValidateModel(userInsert);
            if (!TryValidateModel(userInsert))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            this.SecurityService.InsertUser(userInsert.ToEntity(), userInsert.CompanyCodeList,userInsert.PlantCodeList);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserMaintenance(string key, string values)
        {
            //Get Data and Merge
            UserMaintenanceViewModel UserUpdate = new UserMaintenanceViewModel();
                //this.SecurityService.GetUserMaintenance(new UserCriteria() { UserID = key}).FirstOrDefault().ToModel();
            JsonConvert.PopulateObject(values, UserUpdate);
            ValidateModel(UserUpdate);
            if (!TryValidateModel(UserUpdate))                           // Validating the updated item
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            UserUpdate.Password = CommonUtils.Encrypt(UserUpdate.Password);
            UserUpdate.UpdatedBy = UserDetail.UserID;
            UserUpdate.UpdatedDate = CurrentDateTime;
            this.SecurityService.UpdateUser(UserUpdate.ToEntity(),UserUpdate.CompanyCodeList,UserUpdate.PlantCodeList);

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        public void DeleteUserMaintenance(string key)
        {
            this.SecurityService.DeleteUser(key);
        }
    }
}