using STM.ATDB.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Services
{
    public interface ICommonService
    {
        //Misc GetMisc(MiscCriteria criteria);
        //List<Misc> GetMiscs(MiscCriteria criteria);

        //List<EmployeeResult> GetEmployee(EmployeeCriteria criteria);
        //List<WorkShiftResult> GetAllWorkShift();
        //DocumentNumber GetDocumentRunning(DocumentNumber criteria);

        DateTime? GetProductionDate(DateTime prodDate);
        DateTime? GetProductionDate();

        List<EmpComboResult> GetEmp(EmpCriteria criteria);
        List<DepartmentCombo> GetDepartmentCombo(DepartmentCriteriaCombo criteria);
        List<DivisionCombo> GetDivisionCombo(DivisionCriteriaCombo criteria);
        List<SectionCombo> GetSectionCombo(SectionCriteriaCombo criteria);
        List<GroupCombo> GetGroupCombo(GroupCriteriaCombo criteria);
        List<MiscCombo> GetMiscCombo(MiscCriteria criteria);
    }
}
