using Online_Test_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Online_Test_System.Controllers.DashBoardController;
using static Online_Test_System.Models.DashboardModel;
using static Online_Test_System.Models.StudentModel;

namespace Online_Test_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBAL _IStudentBAL;

        public StudentController()
        {
            _IStudentBAL = new StudentBAL();
        }
        // GET: Student
        public ActionResult Index()
        {
            List<QuestionModel> questions = _IStudentBAL.GetQuestions();
            return View(questions.ToList());
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(StudentLogin model)
        {
            if (model.Username == "test" && model.Password == "123")
            {
                return RedirectToAction("Index", "Student");
            }
            return View();
        }

        public void SaveStudentTestDetails(Test test)
        {
            //Test test = new Test();
            test.StudentName = "Hussain";
            test.Subject = "Maths";
            test.TestName = "Weekly";
            _IStudentBAL.SaveStudentTestDetails(test);
        }

        public ActionResult TestCompleted()
        {
            return View();
        }

        public class StudentLogin
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }
    }
}