using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Test_System.Models
{
    public class StudentModel
    {
        public class Test
        {
            public string Subject { get; set; }
            public string TestName { get; set; }
            public string StudentName { get; set; }
            public int TotalQuestions { get; set; }
            public int TestScore { get; set; }
        }
    }
}