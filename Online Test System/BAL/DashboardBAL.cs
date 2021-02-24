using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Test_System.Controllers;
using static Online_Test_System.Controllers.DashBoardController;
using Online_Test_System.IDataRepository;
using static Online_Test_System.Models.DashboardModel;

namespace Online_Test_System.BAL
{
    public class DashboardBAL : IDashboardBAL
    {
        private readonly IDataRepository.IDataRepository _dataRepositoty;

        public DashboardBAL()
        {
            _dataRepositoty = new DataRepository();
        }
        public void AddQuestionForTest(QuestionModel model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Question", model.Question);
                param.Add("@Answer1", model.Answer1);
                param.Add("@Answer2", model.Answer2);
                param.Add("@Answer3", model.Answer3);
                param.Add("@Answer4", model.Answer4);
                param.Add("@CorrectAnswer", model.CorrectAnswer);
                _dataRepositoty.CommonSave(param, "USP_AddQuestionsForTest");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TestResult> GetTestResult()
        {
            try
            {
                return _dataRepositoty.CommonGetMethod<TestResult>("USP_GetStudentsTestResult");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}