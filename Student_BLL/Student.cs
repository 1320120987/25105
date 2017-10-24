using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JXMaker.Common;
using com.jxmaker.WebForm.DAL;
using com.jxmaker.WebForm.Entity;



namespace com.jxmaker.WebForm.BLL
{
    public class Student
    {
          #region # 单一实例 #

        private static Student instance = null;
        private static object objSync = new object();

        private Student() { }

        public static Student GetInstance()
        {
            if (instance == null)
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new Student();
                    }
                }
            }

            return instance;
        }

        #endregion
        private static readonly StudentDAL dal = StudentDAL.GetInstance();
        public List<StudentInfo> GetList(string student_id, string admission)
        {
            student_id = GeneralHelper.CheckAttackHelper.FilterAttack(student_id);
            admission = GeneralHelper.CheckAttackHelper.FilterAttack(admission);
            return ConversionHelper.DataTableToGenericList<StudentInfo>(dal.GetTable(student_id, admission));
        }

    }
}
