using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*项目类型业务逻辑层*/
    public class bllProjectType{
        /*添加项目类型*/
        public static bool AddProjectType(ENTITY.ProjectType projectType)
        {
            return DAL.dalProjectType.AddProjectType(projectType);
        }

        /*根据typeId获取某条项目类型记录*/
        public static ENTITY.ProjectType getSomeProjectType(int typeId)
        {
            return DAL.dalProjectType.getSomeProjectType(typeId);
        }

        /*更新项目类型*/
        public static bool EditProjectType(ENTITY.ProjectType projectType)
        {
            return DAL.dalProjectType.EditProjectType(projectType);
        }

        /*删除项目类型*/
        public static bool DelProjectType(string p)
        {
            return DAL.dalProjectType.DelProjectType(p);
        }

        /*查询项目类型*/
        public static System.Data.DataSet GetProjectType(string strWhere)
        {
            return DAL.dalProjectType.GetProjectType(strWhere);
        }

        /*根据条件分页查询项目类型*/
        public static System.Data.DataTable GetProjectType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProjectType.GetProjectType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的项目类型*/
        public static System.Data.DataSet getAllProjectType()
        {
            return DAL.dalProjectType.getAllProjectType();
        }
    }
}
