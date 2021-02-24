using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Test_System.IDataRepository
{
    interface IDataRepository
    {
        void CommonSave(object param, string storedProcedure);

        List<T> CommonGetMethod<T>(string spName);
    }
}
