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
     
   public class TeacherBLL
    {
       private static readonly TeacherDAL del = TeacherDAL.GetInstance();
        #region # 单一实例 #

        private static TeacherBLL instance = null;
        private static object objSync = new object();

        private TeacherBLL() { }

        public static TeacherBLL GetInstance()
        {
            if (instance == null)
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new TeacherBLL();
                    }
                }
            }

            return instance;
        }

        #endregion
        public List<TeacherInfo> GetList(string teacher_id, string cipher)
        {
            teacher_id = GeneralHelper.CheckAttackHelper.FilterAttack(teacher_id);
            cipher = GeneralHelper.CheckAttackHelper.FilterAttack(cipher);
            return ConversionHelper.DataTableToGenericList<TeacherInfo>(del.GetTable(teacher_id, cipher));
        }

    }
}
