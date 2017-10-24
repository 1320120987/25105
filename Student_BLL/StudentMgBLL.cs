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
    public class StudentMgBLL
    {
          #region # 单一实例 #

        private static StudentMgBLL instance = null;
        private static object objSync = new object();

        private StudentMgBLL() { }

        public static StudentMgBLL GetInstance()
        {
            if (instance == null)
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new StudentMgBLL();
                    }
                }
            }

            return instance;
        }

        #endregion
        private static readonly StudentMgDAL dal = StudentMgDAL.GetInstance();
        public bool Insert(StudentInfo entity)
        {
            entity.student_id = GeneralHelper.CheckAttackHelper.FilterAttack(entity.student_id);
            entity.admission = GeneralHelper.CheckAttackHelper.FilterAttack(entity.admission);
            entity.name = GeneralHelper.CheckAttackHelper.FilterAttack(entity.name);
            entity.classs = GeneralHelper.CheckAttackHelper.FilterAttack(entity.classs);
            return dal.Insert(entity);
        }
        public bool Update(StudentInfo entity)
        {
            entity.student_id = GeneralHelper.CheckAttackHelper.FilterAttack(entity.student_id);
            entity.admission = GeneralHelper.CheckAttackHelper.FilterAttack(entity.admission);
            entity.name = GeneralHelper.CheckAttackHelper.FilterAttack(entity.name);
            entity.classs = GeneralHelper.CheckAttackHelper.FilterAttack(entity.classs);
            return dal.Update(entity);
        }
        public bool Del(string student_id)
        {
            return dal.Del(student_id);
        }
        public List<StudentInfo> GetList()
        {
            return ConversionHelper.DataTableToGenericList<StudentInfo>(dal.GetTable());
        }
        public bool IsExixts(string student_id)
        {
            student_id = GeneralHelper.CheckAttackHelper.FilterAttack(student_id);
            return dal.IsExixts(student_id);
        }

        public object GetList(string studentid)
        {
            throw new NotImplementedException();
        }
    }
}
