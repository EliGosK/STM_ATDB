using STM.ATDB.Model.Common;
using STM.ATDB.Model.Security;
using STM.ATDB.Model.Transaction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Services
{
    public interface ITransactionService
    {

        //#region Export Excel File
        //bool CheckExistTimeInOut(TimeInOutReportCriteria exportFileCriteria);
        //byte[] ExportTimeInOut(TimeInOutReportCriteria exportFile);
        //Stream ExportTimeInOutPDF(TimeInOutReportCriteria exportFile);

        //bool CheckExistOutsource(OutsourceReportCriteria exportFileCriteria);
        //byte[] ExportOutsource(OutsourceReportCriteria exportFile);
        //Stream ExportOutsourcePDF(OutsourceReportCriteria exportFileCriteria);
        //#endregion

        List<SearchDashboard_Result> SearchDashboard(DashboardCriteria criteria, ref string strDivName, ref string strWorkHC, ref string strTotalHC, ref string strWorkPercent, ref int? iMaxColumn);
        List<GetDivisionComboResult> GetDivisionCombo(DivisionCriteria criteria);
        List<GetDepartmentComboResult> GetDepartmentCombo(DepartmentCriteria criteria);
        List<GetSectionComboResult> GetSectionCombo(SectionCriteria criteria);


        List<GoOutReason> SearchGoOutReason(GoOutReasonCriteria criteria);
        GoOutReason GetGoOutReasonID(GoOutReasonCriteria criteria);
        SaveGoOutReasonResult SaveGoOutReason(GoOutReason entity, string Mode);
        DeleteGoOutReasonResult DeleteGoOutReason(int ID, string UserCode);

        #region
        //List<TotalEmployeeChartDataResult> GetTotalEmployeeChartData(ChartCriteria criteria);
        //List<TotalEmployeeReplaceChartDataResult> GetTotalEmployeeReplaceChartData(ChartCriteria criteria);
        //List<TotalEmployeeWorkingChartDataResult> GetTotalEmployeeWorkingChartData(ChartCriteria criteria);
        //List<TotalEmployeeWorkingPlantChartDataResult> GetTotalEmployeeWorkingPlantChartData(ChartCriteria criteria);
        #endregion
    }
}
