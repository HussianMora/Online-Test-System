using Dapper;
using Online_Test_System.IDataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Online_Test_System.Controllers.DashBoardController;
using static Online_Test_System.Models.DashboardModel;
using static Online_Test_System.Models.StudentModel;

namespace Online_Test_System.BAL
{
    public class StudentBAL : IStudentBAL
    {
        private readonly IDataRepository.IDataRepository _dataRepositoty;

        public StudentBAL()
        {
            _dataRepositoty = new DataRepository();
        }
        public List<QuestionModel> GetQuestions()
        {
            try
            {
                List<QuestionModel> getTestQuestions = _dataRepositoty.CommonGetMethod<QuestionModel>("USP_GetQuestions");
                return getTestQuestions;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveStudentTestDetails(Test model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Subject", model.Subject);
                param.Add("@TestName", model.TestName);
                param.Add("@StudentName", model.StudentName);
                param.Add("@TotalQuestions", model.TotalQuestions);
                param.Add("@TestScore", model.TestScore);
                _dataRepositoty.CommonSave(param, "USP_SaveStudentTestDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}