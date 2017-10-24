using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.jxmaker.WebForm.Entity;
using com.jxmaker.WebForm.DBProvider.ADO.NET;

namespace com.jxmaker.WebForm.DAL
{
     public class TeacherDAL
    {
 #region # 单一实例 #

        private static TeacherDAL instance = null;
        private static object objSync = new object();

        private TeacherDAL() { }

        public static TeacherDAL GetInstance()
        {
            if (instance == null)
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new TeacherDAL();
                    }
                }
            }

            return instance;
        }

        #endregion
        public DataTable GetTable(string teacher_id, string cipher)
        {
            string sql = "select * from teacher_info where teacher_id=@teacher_id and cipher=@cipher";
            SqlParameter[] pars = { 
                        new SqlParameter("@teacher_id",       SqlDbType.NVarChar,30)  { Value =teacher_id },
                         new SqlParameter("@cipher",       SqlDbType.NVarChar,30)  { Value =cipher}
                 };
            var res = SQLHelper.ExecuteDataTable(sql, pars);
            return res;
        }
    }
}
