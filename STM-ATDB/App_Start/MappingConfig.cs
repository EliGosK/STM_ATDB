using STM.ATDB.Model.Security;
using STM.ATDB.MvcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using STM.ATDB.Model.Transaction;

namespace STM.ATDB.MvcWeb.App_Start
{
    public class MappingConfig
    {
        public static void Register()
        {
            AutoMapper.Mapper.Initialize(
                c =>
                {

                    c.CreateMap<LoginViewModel, User>()
                        .ForMember(m => m.UserCode, opt => opt.MapFrom(src => src.UserName));

                    c.CreateMap<User, UserInformation>()
                        .ForMember(m => m.UserID, opt => opt.MapFrom(src => src.UserCode));

                    c.CreateMap<UserMaintenanceViewModel, User>();

                    c.CreateMap<ScreenPermissionListResult, PermissionViewModel>()
                        .ForMember(m => m.Code, opt => opt.MapFrom(src => src.ScreenCode))
                        .ForMember(m => m.Text, opt => opt.MapFrom(src => src.ScreenName))
                        .ForMember(m => m.Expanded, opt => opt.MapFrom(src => true));

                    c.CreateMap<PermissionViewModel,ScreenPermissionListResult>()
                        .ForMember(m => m.ScreenCode, opt => opt.MapFrom(src => src.Code))
                        .ForMember(m => m.ScreenName, opt => opt.MapFrom(src => src.Text));

                    c.CreateMap<ScreenPermissionListTreeResult, PermissionViewModel>()
                        .ForMember(m => m.Code, opt => opt.MapFrom(src => src.ScreenCode))
                        .ForMember(m => m.Text, opt => opt.MapFrom(src => src.ScreenName))
                        .ForMember(m => m.Expanded, opt => opt.MapFrom(src => true));

                    c.CreateMap<PermissionViewModel, ScreenPermissionListTreeResult>()
                        .ForMember(m => m.ScreenCode, opt => opt.MapFrom(src => src.Code))
                        .ForMember(m => m.ScreenName, opt => opt.MapFrom(src => src.Text));

                    /* =========================================
                     * ADS020
                     * =========================================*/
                    c.CreateMap<GoOutReason, GoOutReasonViewModel>();


                    //MAS010
                    c.CreateMap<EmployeeSetting, EmployeeSettingViewModel>();

                    //MAS020
                    c.CreateMap<HideOrg, HideOrganizationViewModel>();

                    //MAS030
                    c.CreateMap<FixOrgEmp, FixOrganizationViewModel>();

                    //MAS040
                    c.CreateMap<AssignWorkShiftByEmp, AssignWorkShiftViewModel>();
                }
            );
        }
    }
}
