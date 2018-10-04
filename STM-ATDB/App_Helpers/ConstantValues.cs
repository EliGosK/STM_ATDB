using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.App_Helpers
{
    public static class ConstantValues
    {
        #region Misc
        public static string STATUS_MISC_FIELDNAME = "Status";
        public static string STATUS_MISC_STATUS_ACTIVE = "1";
        public static string STATUS_MISC_STATUS_INACTIVE = "0";

        public static string STATUS_MISC_USERTYPE = "UserType";
        public static string STATUS_MISC_TITLE_NAME = "TitleName";
        public static string STATUS_MISC_TITLE_NAME_USER = "TitleNameUser";
        #endregion

        #region ContentType
        public static string JSON_CONTENT_TYPE = "application/json";
        public static string XLSX_CONTENT_TYPE = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public static string PDF_CONTENT_TYPE = "application/pdf";
        #endregion

        #region Validation
        public static string ValidateNotPass = "Require field validate not pass.";
        public static string Success = "Success";
        public static string DuplicateData = "Data is duplicate.";
        #endregion

        #region Column Width
        public static int StatusWidth = 80;
        public static int CreatedByWidth = 140;
        public static int CreatedDateWidth = 120;

        #endregion

        #region Chart
        public static int ChartFontSize = 14;
        public static string ChartFontFamily = "Tahoma";
        #endregion

        public static string TypeInfo = "I";
        public static string TypeWarning = "W";
        public static string TypeError = "E";

        public static string TimeStampFormat = "dd/MM/yyyy HH:mm:ss";
        public static string TimeStampInOutFormat = "dd/MMM/yyyy HH:mm";
        public static string TimeFormat = "HH:mm";
        public static string DateFormat = "dd/MMM/yyyy";
        public static string DateMonthYearFormat = "MMM/yyyy";

        public static int GRID_PAGE_SIZE = 10;
        public static string AllValue = "ALL";
        public static string AllDisplay = "All";
        public static int AllValue_Int = -1;

        public static string ADD = "A";
        public static string EDIT = "E";

        public static int DisplayDurationInfo = 3000;
        public static int DisplayDurationSuccess = 3000;
        public static int DisplayDurationWarning = 6000;
        public static int DisplayDurationError = 6000;
        
        public static string UserType_STM = "01";
        public static string UserType_OTS = "02";

        public static string Select = "--Select--";

        #region Misc
        public static string Status = "Status";
        public static string DisplayStatus = "DisplayStatus";
        //public static string WorkStatus = "WorkStatus";
        public static string EmpStatus = "EmpStatus";
        public static string WorkShiftStatus = "WorkShift";

        #endregion


        #region Grid Command
        public static string EditCommandImageSource = "/Content/images/icon-32-edit.png";
        public static string ViewCommandImageSource = "/Content/images/icon-32-view.png";
        public static string DeleteCommandImageSource = "/Content/images/icon-32-delete.png";
        #endregion


        public static string AdminGroup = "AdminGroup";
    }
}
