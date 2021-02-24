using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Online_Test_System.Controllers.DashBoardController;
using static Online_Test_System.Models.DashboardModel;
using static Online_Test_System.Models.StudentModel;

namespace Online_Test_System.BAL
{
    interface IStudentBAL
    {
        List<QuestionModel> GetQuestions();
        void SaveStudentTestDetails(Test model);
    }
}
