
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using STM.ATDB.Core;
using STM.ATDB.Model.Common;
using STM.ATDB.Model.Security;
using STM.ATDB.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace STM.ATDB.Services
{
    public class TransactionService : ITransactionService
    {
        private TransactionEntities _Context = null;

        public TransactionEntities Context
        {

            get
            {
                if (_Context == null)
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

        public TransactionService()
        {
            Context = new TransactionEntities();
        }

        #region Test
        public List<SearchDashboard_Result> SearchDashboard(DashboardCriteria criteria,ref string strDivName, ref string strWorkHC, ref string strTotalHC, ref string strWorkPercent, ref int? iMaxColumn)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var opDivName = new ObjectParameter("DivName", typeof(string));
                var opWorkHC = new ObjectParameter("WorkHC", typeof(string));
                var opTotalHC = new ObjectParameter("TotalHC", typeof(string));
                var opWorkPercent = new ObjectParameter("WorkPercent", typeof(string));
                var opMaxColumn = new ObjectParameter("MaxColumn", typeof(int?));

                var result = Context.SearchDashboard(
                        divCode:criteria.DivCode
                        ,deptCode:criteria.DeptCode
                        ,secCode:criteria.SecCode
                        ,userCode:criteria.UserCode
                        ,divName:opDivName
                        ,workHC:opWorkHC
                        ,totalHC:opTotalHC
                        ,workPercent:opWorkPercent
                        ,maxColumn:opMaxColumn
                    ).ToList();

                strDivName = opDivName.Value == null || opDivName.Value == DBNull.Value ? null : (string)opDivName.Value;
                strWorkHC = opWorkHC.Value == null || opWorkHC.Value == DBNull.Value ? null : (string)opWorkHC.Value;
                strTotalHC = opTotalHC.Value == null || opTotalHC.Value == DBNull.Value ? null : (string)opTotalHC.Value;
                strWorkPercent = opWorkPercent.Value == null || opWorkPercent.Value == DBNull.Value ? null : (string)opWorkPercent.Value;
                iMaxColumn = opMaxColumn.Value == null || opMaxColumn.Value == DBNull.Value ? null : (int?)opMaxColumn.Value;

                return result;
                //if (criteria.UserSelectedDate.HasValue)
                //{
                //    return Context.Companies.Where(d => d.DeleteFlag == (criteria.DeleteFlag ?? d.DeleteFlag))
                //                            .Where(d => d.Status == criteria.Status || criteria.Status == null)
                //                            .Where(d => d.DeleteFlag == false || (d.DeleteFlag == true && d.UpdatedDate > criteria.UserSelectedDate))
                //                            .ToList();
                //}
                //else
                //{
                //    return Context.Companies.Where(d => d.DeleteFlag == (criteria.DeleteFlag ?? d.DeleteFlag)).Where(d => d.Status == criteria.Status || criteria.Status == null).ToList();
                //}
            }

        }
        #endregion

        #region ADS010

        public List<GetDivisionComboResult> GetDivisionCombo(DivisionCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.GetDivisionCombo(
                        prodDate: criteria.ProdDate
                        , userCode: criteria.UserCode
                    ).ToList();

                return result;
            }
        }

        public List<GetDepartmentComboResult> GetDepartmentCombo(DepartmentCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.GetDepartmentCombo(
                        prodDate: criteria.ProdDate
                        , divCode: criteria.DivCode
                        , userCode: criteria.UserCode
                    ).ToList();

                return result;
            }
        }

        public List<GetSectionComboResult> GetSectionCombo(SectionCriteria criteria)
        {
            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.GetSectionCombo(
                        prodDate: criteria.ProdDate
                        , deptCode: criteria.DeptCode
                        , userCode: criteria.UserCode
                    ).ToList();

                return result;
            }
        }

        #endregion

        #region ADS020

        public List<GoOutReason> SearchGoOutReason(GoOutReasonCriteria criteria)
        {

            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.SearchGoOutReason(
                        prodDateFrom: criteria.StartTime
                        , prodDateTo: criteria.EndTime
                        , empCode: criteria.EmpCode
                        , empName: criteria.EmpName
                        , userCode: criteria.UserCode
                    ).ToList();

                return result;
            }
        }

        public GoOutReason GetGoOutReasonID(GoOutReasonCriteria criteria)
        {

            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.GetGoOutReasonID(
                        goOutID: criteria.ID
                    ).FirstOrDefault();

                return result;
            }
        }

        public SaveGoOutReasonResult SaveGoOutReason(GoOutReason entity, string Mode)
        {

            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.SaveGoOutReason(
                        mode: Mode
                        , goOutID: entity.GoOutID
                        , prodDate: entity.ProdDate
                        , empCode: entity.EmpCode
                        , reason: entity.Reason
                        , startTime: entity.StartTime
                        , endTime: entity.EndTime
                        , userCode: entity.UpdateBy
                    ).FirstOrDefault();

                return result;
            }
        }

        public DeleteGoOutReasonResult DeleteGoOutReason(int ID, string UserCode)
        {

            using (TransactionEntities Context = new TransactionEntities())
            {
                var result = Context.DeleteGoOutReason(
                        goOutID: ID
                        , userCode: UserCode
                    ).FirstOrDefault();

                return result;
            }
        }

        #endregion

        

    }
}
