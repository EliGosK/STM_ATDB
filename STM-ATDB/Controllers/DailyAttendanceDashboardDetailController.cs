using Newtonsoft.Json;
using STM.ATDB.Model.Transaction;
using STM.ATDB.MvcWeb.Models;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class DailyAttendanceDashboardDetailController : SECBaseController
    {
        private ITransactionService TransactionService;
        string keyDetail;

        public DailyAttendanceDashboardDetailController(ITransactionService transactionService)
        {
            this.TransactionService = transactionService;
        }


        // GET: DailyAttendanceDashboardDetail
        public ActionResult Index()
        {
            keyDetail = this.Request.QueryString["id"];
            DailyAttendanceDashboardViewModel temp = (DailyAttendanceDashboardViewModel)TempData["ADS010ViewModel"];
            if (temp != null)
            {
                Session[keyDetail] = temp;
            }
            //string tempKey = temp.Division + temp.Department + temp.Section;
            //keyDetail = tempKey;
            
            Session[keyDetail+"count"] = 0;
            ViewBag.id = keyDetail;

            return View();
        }

        //public MvcHtmlString CallDisplayFrist(string values)
        //{
        //    DailyAttendanceDashboardViewModel viewModel = new DailyAttendanceDashboardViewModel();
        //    JsonConvert.PopulateObject(values, viewModel);
        //    TempData["viewModel"] = viewModel;
        //    return CallDisplay();
        //}

        [HttpPost]
        public MvcHtmlString CallDisplay(string id)
        {
            string urlB = this.Url.Action("Index", "SearchDashboard", null);
            string divLink = @"<div>Session Expire </div>
                               <a href=""/Home"" ><span> Back </span></a> ";

            keyDetail = id;

            if (string.IsNullOrWhiteSpace(keyDetail))
                return new MvcHtmlString(divLink);
            DailyAttendanceDashboardViewModel temp = (DailyAttendanceDashboardViewModel)Session[keyDetail];

            if (temp == null)
                return new MvcHtmlString(divLink);

            //Get Data
            DashboardCriteria cri = new DashboardCriteria
            {
                DivCode = temp.Division
                ,DeptCode = temp.Department
                ,SecCode = temp.Section
                ,UserCode = UserDetail.UserID
            };

            int? MaxColumn = 4;
            string strDivHeader = "";
            string strDateTimeNow = String.Format("{0:dddd, dd MMMM yyyy HH:mm}", DateTime.Now);
            string strWorkHC = "-";
            string strTotalHC = "-";
            string strWorkPercent = "-";

            List<SearchDashboard_Result> rowData = TransactionService.SearchDashboard(cri, ref strDivHeader, ref strWorkHC, ref strTotalHC, ref strWorkPercent, ref MaxColumn);

            string tableMain = string.Empty;
            int rowCount = rowData.Count;
                        
            //table "Main"
            tableMain = @"<div class=""col-md-12 Table_Main"">";

            // table Division Header (Row of Division Name, CurrentDatetime, TotalHC, TotalPercent)
            tableMain += @"
                                <div class=""row Fix_Font Header_Row"">
                                        <span class=""Header_Name"">" + strDivHeader + @"</span>
                                        <span class=""Clock_Total"">
                                            <span class=""Clock"">" + strDateTimeNow + @"</span>
                                            <br/>
                                            <span class=""Header_Total"">
                                                <span class=""Header_Total_Label"">จำนวน</span>							
                                                <span class=""Header_Total"">" + strWorkHC + " / " + strTotalHC + @"</span>							
                                                <span class=""Header_Total_Label"">คน</span>
                                                <span class=""Header_Total""> ( " + strWorkPercent + @"% )</span>
                                            </span>
                                        </span>
                                </div>
                           ";

            // table Detail all level
            if (rowCount > 0)
            {
                //Prepare Image of status and default EmpImage
                string imgPath = Server.MapPath(@"\Content\images\");
                string defaultEmpPath = imgPath + "Default_Emp.png";
                string defaultEmpImage = "";
                try
                {
                    Byte[] bytes = System.IO.File.ReadAllBytes(defaultEmpPath);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    defaultEmpImage = "data:image/png;base64," + base64String;

                }
                catch (Exception)
                {
                    defaultEmpImage = "";
                }
                
                
                int i = 0;
                while (i < rowCount)
                {
                    if (i == 0 || rowData[i].SecCode != rowData[i - 1].SecCode) //รอบแรก หรือ Change Org
                    {
                        if (i > 0) //ปิด Tag กรณีไม่ใช่รอบแรก
                        {
                            //Modify 9/Jul/2018 Change to do not fix 4 column in 1 row
                            //if (rowData[i - 1].EmpColumn < MaxColumn)				//เติม cell ให้เต็ม 4 คน (4 div)	
                            //{
                            //    int c = rowData[i - 1].EmpColumn.Value + 1;
                            //    while (c <= MaxColumn)
                            //    {
                            //        tableMain += @"<div class=""col-md-3""></div>";
                            //        c++;
                            //    }
                            //    tableMain += @"</div>"; //Write tag </div Class=Row>  ปิด row ของ Emp
                            //}
                            tableMain += @"</div>"; //Write tag </div Class=Row>  ปิด row ของ Emp ( 1 row : 1 Section)
                            //End Modify 9/Jul/2018

                            if (rowData[i - 1].OrgLevel.Equals("SEC"))
                            {
                                tableMain += @"</div>"; // Write tag  </ DIV Sec ID = "{Row[@i-1].SecCode}" > Hide ทั้ง Section
                            }
                        }

                        if (i == 0 || rowData[i].DeptCode != rowData[i - 1].DeptCode) ////รอบแรก หรือ เปลี่ยน Dept >> Create Table Dept
                        {
                            ////ปิด Row Dept/Div เก่า
                            if (i > 0)
                            {
                                tableMain += @"</div>"; //Write tag </Div Dept > สำหรับ Hide ทั้ง Dept / Div
                                tableMain += @"</div>"; //Write tag  </Div Class=Col-12>  สำหรับ Dept/Div ที่มี border
                            }
                            //เปิด Row Dept/Div ใหม่	
                            string hName = rowData[i].OrgLevel.Equals("DEPT0") ? rowData[i].DivName : rowData[i].DeptName;
                            tableMain += @"<div class=""row dx-field Dept_Row"">
                                            <div class=""col-md-12 Dept_Table"">
                                                <div class=""row dx-field Dept_Header_Row Fix_Font"">
                                                     <div class=""col-md-12 text-left Dept_Header_Col_Left"">
                                                        <input type=""button"" id= ""button-" + rowData[i].DeptCode + @""" class = ""PanelToggleUp Dept_Toggle""/>
                                                        <span class=""Dept_Label_Header_Left"">" + hName + @"</span>
                                                        <span class=""Dept_Label""> จำนวน </span>
                                                        <span class=""Dept_Total"">&nbsp;&nbsp;" + rowData[i].TotalByDept + @"&nbsp;&nbsp;</span >
                                                        <span class=""Dept_Label"">คน&nbsp;</span >
                                                        <span class=""Dept_Percent"">(&nbsp;" + rowData[i].PercentByDept + @"% ) </span >
                                                        <span class=""Dept_Label_Header_Right"">
                                                            <span class=""Dept_Label"" > มา </Span>							
                                                            <span class=""Dept_Come"">&nbsp;&nbsp;" + rowData[i].HCByDept + @"&nbsp;&nbsp;</span >
                                                            <span class=""Dept_Label"" > ลา </span >
                                                            <span class=""Dept_Leave"">&nbsp;&nbsp;" + rowData[i].LeaveByDept + @"&nbsp;&nbsp;</span >
                                                        </span >
                                                     </div>  
                                                </div>
                                                <div id=""toggle-div-" + rowData[i].DeptCode + @""">
                                            ";
                        }

                        if (rowData[i].OrgLevel.Equals("SEC") && (i == 0 || rowData[i].SecCode != rowData[i - 1].SecCode))    //Level="SEC" และ (เปลี่ยน Section หรือรอบแรก)
                        {
                            //ใส่ Sec Header
                            tableMain += @"<div class=""row dx-field Sec_Header_Row Fix_Font"">
                                                <div class=""col-md-12 Sec_Header_Col"">
                                                    <input type=""button"" id= ""button-" + rowData[i].SecCode + @""" class = ""PanelToggleUp Sec_Toggle""/>
                                                    <span class=""Sec_Label_Header"">" + rowData[i].SecName + @"</span> 
                                                    <span class=""Sec_Label_Total""> (&nbsp;" + rowData[i].HCBySec + @"&nbsp;/&nbsp;" + rowData[i].TotalBySec + @"&nbsp;)</span>
                                                </div>
                                            </div> 
                                            ";
                            //Write tag  <DIV Sec ID = "{Row[@i].SecCode}" > Hide ทั้ง Section
                            tableMain += @"<div id=""toggle-div-" + rowData[i].SecCode + @""">";
                        }

                        tableMain += @"<div class=""row dx-field Emp_Row Fix_Font"">";

                    }//change Org
                    //=========================================================
                    //Comment 9/Jul/2018 Change to do not fix 4 column in 1 row so no need to gen. column
                    //else
                    //{
                    //    //กรณีเปลี่ยนการเรียงเป็นจากบนลงล่างแล้วค่อยซ้ายไปขวา column จะไม่ครบ 4 จะต้องเพิ่มจนครบ 4 แล้วปิด row ก่อนเปิด row ใหม่
                    //    if ((rowData[i].EmpColumn == 1) && (rowData[i - 1].EmpColumn < MaxColumn))
                    //    {
                    //        int c = rowData[i - 1].EmpColumn.Value + 1;
                    //        while (c <= MaxColumn)
                    //        {
                    //            tableMain += @"<div class=""col-md-3""></div>";
                    //            c++;
                    //        }
                    //        tableMain += @"</div>";
                    //    }
                    //}
                    //=========================================================

                    //Comment 9/Jul/2018 Change to do not fix 4 column in 1 row but have 1 row : 1 Section
                    //if (rowData[i].EmpColumn == 1)
                    //{
                    //    tableMain += @"<div class=""row dx-field Emp_Row Fix_Font"">";
                    //}
                    
                    string empImage = defaultEmpImage;
                    if (System.IO.File.Exists(rowData[i].EmpImageFullPath))
                    {
                        Byte[] bytes = System.IO.File.ReadAllBytes(rowData[i].EmpImageFullPath);
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        empImage = "data:image/png;base64," + base64String;
                    }
                    
                    string statusImage = "";
                    string filePath = imgPath+rowData[i].StatusImageFileName;
                    try {
                        Byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        statusImage = "data:image/png;base64," + base64String;
                    }
                    catch (Exception)
                    {
                        statusImage = "";
                    }

                    tableMain += @"
                                <div class=""col-md-3 Emp_Col Fix_Font"">
                                    <table class=""Emp_Table""><tr>
                                    <td class=""Emp_Img""><img src=""" + empImage + @""" width=""25"" height=""25""/></td>    
                                    <td class=""Emp_Name""><span class=""Emp_Name_Fix_Width"">" + rowData[i].EmpName + @"</span></td>
                                    <td class=""Emp_Status""><img class=""img-responsive"" src=""" + statusImage + @""" width=""20"" height=""20""/></td>
                                    <td class=""Emp_Reason"">" + rowData[i].Reason + @"</td>
                                    </tr></table>
                                </div>
                        ";
                    
                    //Comment 9/Jul/2018 Change to do not fix 4 column in 1 row but have 1 row : 1 Section
                    //if (rowData[i].EmpColumn == MaxColumn)
                    //{
                    //    tableMain += @"</div>"; //Write tag </Div Class=Row > สำหรับ Emp คนสุดท้ายของ row ต้องปิด row ด้วย
                    //}

                    i++;
                }//end While

                i = i - 1;
                //Modify 9/Jul/2018 Change to do not fix 4 column in 1 row but have 1 row : 1 Section
                //if (rowData[i].EmpColumn < MaxColumn)               //เติม cell ให้เต็ม 4 คน (16 column)	
                //{
                //    int c = rowData[i].EmpColumn.Value + 1;
                //    while (c <= MaxColumn)
                //    {
                //        tableMain += @"<div class=""col-md-3""></div>";
                //        c++;
                //    }
                //    tableMain += @"</div>"; //Write tag </Div Class=Row >  ปิด row ของ Emp
                //}
                tableMain += @"</div>"; //Write tag </Div Class=Row >  ปิด row ของ Emp ( 1 row : 1 Section)
                //End Modify

                if (rowData[i].OrgLevel.Equals("SEC"))
                {
                    tableMain += @"</div>"; //Write tag </DIV Sec  ID = "{Row[@i].SecCode}">  Hide ทั้ง Section
                }

                tableMain += @"</div>";//Write tag </Div Dept>  สำหรับ Hide ทั้ง Dept/Div
                tableMain += @"</div>";//Write tag </Div Class=Col-12>  สำหรับ Dept/Div
                tableMain += @"</div>";//Write tag </Div Class=Row>  สำหรับ Dept/Div
            }

            tableMain += @"</div>";
            return new MvcHtmlString(tableMain);
        }
    }
}