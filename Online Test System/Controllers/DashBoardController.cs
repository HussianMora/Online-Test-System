using OfficeOpenXml;
using OfficeOpenXml.Style;
using Online_Test_System.BAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Online_Test_System.Models.DashboardModel;

namespace Online_Test_System.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IDashboardBAL _IDashboardBAL;

        public DashBoardController()
        {
            _IDashboardBAL = new DashboardBAL();
        }
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddQuestions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestions(QuestionModel model)
        {
            _IDashboardBAL.AddQuestionForTest(model);
            return View();
        }

        public ActionResult TestResult()
        {
            return View(_IDashboardBAL.GetTestResult().ToList());
        }

        public void ExportExcel()
        {
            List<TestResult> result = _IDashboardBAL.GetTestResult().ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("TestResult");
            ws.Cells["A1:C1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Yellow")));
            for (int i = 1; i <= result.Count() + 1; i++)
            {
                ws.Cells["A" + i + ":" + "C" + i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells["A" + i + ":" + "C" + i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells["A" + i + ":" + "C" + i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells["A" + i + ":" + "C" + i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            ws.Cells["A1"].Value = "Student Name";
            ws.Cells["B1"].Value = "Total Score";
            ws.Cells["C1"].Value = "Student Score";

            int row = 2;
            foreach (var item in result)
            {
                ws.Cells[string.Format("A{0}", row)].Value = item.StudentName;
                ws.Cells[string.Format("B{0}", row)].Value = item.TestScore;
                ws.Cells[string.Format("C{0}", row)].Value = item.TotalQuestions;
                row++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=StudentTestResult.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

    }
}