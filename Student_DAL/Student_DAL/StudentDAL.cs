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
    public class StudentDAL
    {
        #region # 单一实例 #

        private static StudentDAL instance = null;
        private static object objSync = new object();

        private StudentDAL() { }

        public static StudentDAL GetInstance()
        {
            if (instance == null)
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new StudentDAL();
                    }
                }
            }

            return instance;
        }

        #endregion
        public DataTable GetTable(string student_id, string admission)
        {
            string sql = "select  * from student_info where student_id=@student_id and admission=@admission";
            SqlParameter[] pars =
                {
                    new SqlParameter("@student_id",     SqlDbType.VarChar,30)  { Value =student_id},
                    new SqlParameter("@admission",      SqlDbType.VarChar,30)  { Value = admission}
                };
            var res = SQLHelper.ExecuteDataTable(sql, pars);
            return res;
        }
    }
}
