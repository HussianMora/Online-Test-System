using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Online_Test_System.IDataRepository
{
    public class DataRepository : IDataRepository
    {
        private IDbConnection _con;
        #region Initialize DBConnection
        public DataRepository()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        #endregion
        public void CommonSave(object param, string storedProcedure)
        {
            _con.Execute(storedProcedure, param, commandType: CommandType.StoredProcedure);
        }

        public List<T> CommonGetMethod<T>(string spName)
        {
            return SqlMapper.Query<T>(_con, spName).ToList();
        }
    }
}