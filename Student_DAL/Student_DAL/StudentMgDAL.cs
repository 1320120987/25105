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

    public class StudentMgDAL
    {
         #region # 单一实例 #

        private static StudentMgDAL instance = null;
        private static object objSync = new object();

        private StudentMgDAL() { }

        public static StudentMgDAL GetInstance()
        {
            if (instance == null)
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new StudentMgDAL();
                    }
                }
            }

            return instance;
        }

        #endregion
        public DataTable GetTable()
        {
            string sql = "select  * from student_info";
            return SQLHelper.ExecuteDataTable(sql);
        }
        public bool Insert(StudentInfo entity)
        {
            string sql = "insert into student_info values(@student_id,@admission,@name,@achivement,@classs)";
            SqlParameter[] pars =
                {
                    new SqlParameter("@student_id",        SqlDbType.NVarChar,30)          { Value = entity.student_id },
                    new SqlParameter("@admission",         SqlDbType.NVarChar,30)          { Value = entity.admission },
                    new SqlParameter("@name",         SqlDbType.NVarChar,30)               { Value = entity.name },
                    new SqlParameter("@achivement",        SqlDbType.Int)                  { Value = entity.achivement },
                    new SqlParameter("@classs",            SqlDbType.NChar,20)             { Value = entity.classs },
                };
            return SQLHelper.ExecuteNonQuery(sql, pars) > 0;
        }
        public bool Update(StudentInfo entity)
        {
            string sql = "update  student_info Set admission=@admission,name=@name,achivement=@achivement,classs=@classs  where student_id=@student_id";
            SqlParameter[] pars ={
                    new SqlParameter("@student_id",          SqlDbType.NVarChar,30)               { Value =entity.@student_id},
                    new SqlParameter("@admission",           SqlDbType.NVarChar,30)                   { Value =entity.@admission},
                     new SqlParameter("@name",               SqlDbType.NVarChar,30)                   { Value =entity.@name},
                    new SqlParameter("@achivement",          SqlDbType.Int)                         { Value =entity.@achivement},
                    new SqlParameter("@classs",              SqlDbType.NChar,20)                     { Value =entity.@classs},
                                     };
            return SQLHelper.ExecuteNonQuery(sql, pars) > 0;
        }
        public bool Del(string student_id)
        {
            string sql = "delete from student_info where student_id=@student_id";
            SqlParameter[] pars = { 
                        new SqlParameter("@student_id",       SqlDbType.NVarChar,30)  { Value = student_id},
                                  };
            return SQLHelper.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool IsExixts(string student_id)
        {
            string sql = "select count(*) from student_info where student_id=@student_id";
            SqlParameter[] pars = { 
                        new SqlParameter("@student_id",       SqlDbType.NVarChar,30)  { Value =student_id },
                 };
            return SQLHelper.ExecuteScalarInt(sql, pars) > 0;
        }

    }
}
