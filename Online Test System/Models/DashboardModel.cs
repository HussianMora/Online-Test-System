using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Online_Test_System.Models
{
    public class DashboardModel
    {
        public class TestResult
        {
            [DisplayName("Student")]
            public string StudentName { get; set; }
            [DisplayName("Total Score")]
            public int TotalQuestions { get; set; }
            [DisplayName("Student Score")]
            public int TestScore { get; set; }
        }

        public class QuestionModel
        {
            public int Question_Id { get; set; }
            public string Question { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Answer4 { get; set; }
            public int CorrectAnswer { get; set; }

        }
    }
}