using STM.ATDB.Core;
using STM.ATDB.Core.ComponentModel;
using STM.ATDB.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace STM.ATDB.Services
{
    public class SecurityService: ISecurityService
    {
        private SecurityEntities _Context = null;
        public SecurityEntities Context
        {

            get
            {
                if (_Context == null)
                {
                    _Context = new SecurityEntities();
                }
                return _Context;
            }

            private set
            {
                _Context = value;
            }
        }

        public SecurityService()
        {
            Context = new SecurityEntities();
        }

        public User CheckUserLogin(User user)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                return context.Users.Where(d => d.UserCode == user.UserCode && d.Password == user.PasswordHash).FirstOrDefault();
            }
        } 

        public List<ScreenPermissionListResult> GetPermissions(string UserID)
        {
            return GetScreenPermissionList(new ScreenPermissionListCriteria() { UserID = UserID,UserRole = null });


        }

        public ObjectResult ChangePassword(User user)
        {
            try
            {
                using (SecurityEntities context = new SecurityEntities())
                {
                    User item = context.Users.Where(d => d.UserCode == user.UserCode).FirstOrDefault();
                    if (item != null)
                    {
                        item.Password = user.PasswordHash;
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        return ObjectResult.Succeed();
                    }
                    else
                    {
                        return ObjectResult.Fail("User doesn't exist.");
                    }

                }
            }
            catch (Exception ex)
            {
                return ObjectResult.Fail(ex);
            }
        }
       
        public void InsertUser(User user, string listCompany, string listPlant)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                Context.Entry(user).State = System.Data.Entity.EntityState.Added;
                //insert new mapping
                
                Context.SaveChanges();
            }
        }

        public List<UserAndRoleListResult> GetUserAndRoleList(UserCriteria criteria)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                var result = new List<UserAndRoleListResult>();
                if(criteria.Type.Equals("User"))
                    result =  context.GetUserAndRoleList(userID: criteria.UserID
                                                        , userRole: null
                                                        ).ToList();
                else
                    result = context.GetUserAndRoleList(userID: null
                                                        , userRole: criteria.UserID
                                                        ).ToList();
                return result;
            }
        }
        public void UpdateUser(User user, string listCompany,string listPlant)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    User entity = Context.Users.Where(d => d.UserCode == user.UserCode).FirstOrDefault();
                    entity = CommonUtils.CopyObjectByPropertyName<User, User>(user, entity);
                    Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    ////delete company mapping
                    //var userCompany = Context.UserCompanyMappings.Where(x => x.UserID == user.UserCode).ToList();
                    //foreach (var company in userCompany)
                    //{
                    //    Context.UserCompanyMappings.Remove(company);
                    //    Context.Entry(company).State = System.Data.Entity.EntityState.Deleted;
                    //}
                    ////delete plant mapping
                    //var userPlant = Context.UserPlantMappings.Where(x => x.UserID == user.UserID).ToList();
                    //foreach (var plant in userPlant)
                    //{
                    //    Context.UserPlantMappings.Remove(plant);
                    //    Context.Entry(plant).State = System.Data.Entity.EntityState.Deleted;
                    //}
                    ////insert new mapping
                    //if (!string.IsNullOrEmpty(listCompany))
                    //{
                    //    List<string> companyList = listCompany.Split(',').ToList<string>();
                    //    foreach (string c in companyList)
                    //    {
                    //        UserCompanyMapping company = new UserCompanyMapping();
                    //        company.UserID = user.UserID;
                    //        company.CompanyCode = c;
                    //        company.CreatedBy = user.UpdatedBy;
                    //        company.CreatedDate = user.UpdatedDate;
                    //        Context.Entry(company).State = System.Data.Entity.EntityState.Added;
                    //    }
                    //}
                    //if (!string.IsNullOrEmpty(listPlant))
                    //{
                    //    List<string> plantList = listPlant.Split(',').ToList<string>();
                    //    foreach (string c in plantList)
                    //    {
                    //        UserPlantMapping plant = new UserPlantMapping();
                    //        plant.UserID = user.UserID;
                    //        plant.PlantCode = c;
                    //        plant.CreatedBy = user.UpdatedBy;
                    //        plant.CreatedDate = user.UpdatedDate;
                    //        Context.Entry(plant).State = System.Data.Entity.EntityState.Added;
                    //    }
                    //}
                    Context.SaveChanges();
                    scope.Complete();
                }
                catch(Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }


        public void DeleteUser(string userID)
        {

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {

                try
                {
                    //delete Security Mapping
                    var userSecurity = Context.SecurityMappings.Where(d => d.UserCode == userID).ToList();
                    foreach(var security in userSecurity)
                    {
                        Context.SecurityMappings.Remove(security);
                        Context.Entry(security).State = System.Data.Entity.EntityState.Deleted;
                    }


                    User user = Context.Users.Where(x => x.UserCode == userID).FirstOrDefault();
                    Context.Entry(user).State = System.Data.Entity.EntityState.Deleted;

                    Context.SaveChanges();

                    scope.Complete();
                }
                catch(Exception ex)
                {
                    scope.Dispose();
                    throw ex;

                }
            }
            
        }

        //public List<ScreenPermissionListResult> GetScreenPermissionList(ScreenPermissionListCriteria criteria)
        //{
        //    using (SecurityEntities context = new SecurityEntities())
        //    {
        //        return context.GetScreenPermissionList(criteria.UserID).ToList();
        //    }
        //}

        public List<ScreenPermissionListResult> GetScreenPermissionList(ScreenPermissionListCriteria criteria)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                return context.GetScreenPermissionList(criteria.UserID).ToList();
            }
        }

        public List<ScreenPermissionListTreeResult> GetScreenPermissionListTree(ScreenPermissionListCriteria criteria)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                return context.GetScreenPermissionListTree(criteria.UserID,criteria.UserRole).ToList();
            }
        }

        public void SavePermission(string UserID, string UserType, List<ScreenPermissionListTreeResult> lPermission, string UpdateBy)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    if (UserType.Equals("User"))
                        Context.SecurityMappings.Where(d => d.UserCode == UserID).ToList().ForEach(d => Context.Entry(d).State = System.Data.Entity.EntityState.Deleted);
                    else
                        Context.SecurityMappings.Where(d => d.Role == UserID).ToList().ForEach(d => Context.Entry(d).State = System.Data.Entity.EntityState.Deleted);
                    Context.SaveChanges();
                    foreach(var screen in lPermission)
                    {
                        foreach(var permission in screen.PermissionList)
                        {
                            if (permission.IsHavePermission ?? false)
                            {
                                if (UserType.Equals("User"))
                                    Context.SecurityMappings.Add(new SecurityMapping()
                                    {
                                        ScreenCode = screen.ScreenCode,
                                        UserCode = UserID,
                                        Role = "",
                                        PermissionCode = permission.PermissionCode,
                                        PermissionType = "",
                                        CreateBy = UpdateBy,
                                        CreateDate = DateTime.Now,
                                        UpdateBy = UpdateBy,
                                        UpdateDate = DateTime.Now
                                    });
                                else
                                    Context.SecurityMappings.Add(new SecurityMapping()
                                    {
                                        ScreenCode = screen.ScreenCode,
                                        UserCode = "",
                                        Role = UserID,
                                        PermissionCode = permission.PermissionCode,
                                        PermissionType = "",
                                        CreateBy = UpdateBy,
                                        CreateDate = DateTime.Now,
                                        UpdateBy = UpdateBy,
                                        UpdateDate = DateTime.Now
                                    });
                            }

                        }
                        Context.SaveChanges();
                    }


                    scope.Complete();
                }
                catch(Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }
    }
}
