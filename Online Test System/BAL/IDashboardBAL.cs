using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Online_Test_System.Controllers.DashBoardController;
using static Online_Test_System.Models.DashboardModel;

namespace Online_Test_System.BAL
{
    interface IDashboardBAL
    {
        void AddQuestionForTest(QuestionModel model);

        IEnumerable<TestResult> GetTestResult();
    }
}
