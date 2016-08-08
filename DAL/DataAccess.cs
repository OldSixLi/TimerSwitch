using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        /// <summary>
        /// 简单的数据库操作示例
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            string sql = @" insert into TimerTests  values('success',getdate())";
            return DbHelper.ExecuteSql(sql) > 0;
        }

        public bool SqlExecute(string sql)
        {
            return DbHelper.ExecuteSql(sql) > 0;
        }



        /// <summary>
        /// 数据库翻页获得数据
        /// </summary>
        /// <param name="orderby">排序字段</param>
        /// <param name="sort">排序方式，0为升序，1为降序</param>
        /// <param name="page">每页多少条记录</param>
        /// <param name="pageindex">指定当前为第几页</param>
        /// <param name="totalpage">返回总页数</param>
        /// <param name="index">返回当前页数</param>
        /// <param name="totalrecord">总记录数</param>
        /// <returns></returns>
        // TODO  修改用户名称不同步的BUG
        public DataTable GetAllData(Model.TimerMission model , string orderby , int sort , int page , int pageindex , ref int totalpage , ref int index , ref int totalrecord)
        {
            SqlParameter[] paras =
            {
                new SqlParameter("@TableNames ", SqlDbType.VarChar, 2000),
                new SqlParameter("@FieldStr ",SqlDbType.VarChar,4000), 
                new SqlParameter("@SqlWhere ",SqlDbType.VarChar,4000), 
                new SqlParameter("@OrderBy  ",SqlDbType.VarChar,4000),
                new SqlParameter("@Sort ",SqlDbType.Int,1), 
                new SqlParameter("@PageSize ",SqlDbType.Int,40), 
                new SqlParameter("@PageIndex ",SqlDbType.Int,40), 
                new SqlParameter("@TotalPage ",SqlDbType.Int,40), 
                new SqlParameter("@TotalRecord ",SqlDbType.Int,40)
             };


            string condition = " 1=1 and IsDel = 0";

            if(!string.IsNullOrEmpty(model.MissionName) && model.MissionName != "")
            {
                condition += " and MissionName like '%" + model.MissionName + "%'";
            }
            if(!string.IsNullOrEmpty(model.GroupName) && model.GroupName != "")
            {
                condition += " and GroupName like '%" + model.GroupName + "%'";
            }
            if(model.MissionState != 0)
            {
                condition += "  and MissionState ='" + model.MissionState + "'";
            }
            if(!string.IsNullOrEmpty(model.StartTime.ToString()) && model.StartTime.ToString() != "")
            {
                condition += "  and CreateTime >='" + model.StartTime + "'";
            }

            if(!string.IsNullOrEmpty(model.EndTime.ToString()) && model.EndTime.ToString() != "")
            {
                condition += "  and CreateTime <='" + model.EndTime + "'";
            }
            //表名(支持多表)
            paras[0].Value = @"TimerMission";
            //字段名(全部字段为*)
            paras[1].Value = "*";
            //条件语句(不用加where)
            paras[2].Value = condition;
            // 排序字段
            paras[3].Value = orderby;
            //排序方法，0为升序，1为降序
            paras[4].Value = sort;
            //  每页多少条记录
            paras[5].Value = page;
            //指定当前为第几页
            paras[6].Value = pageindex;
            //返回总页数 ,固定值
            paras[7].Value = 0;
            // 返回总条数 ，固定值
            paras[8].Value = 0;
            paras[7].Direction = ParameterDirection.Output;
            paras[8].Direction = ParameterDirection.Output;
            DataTable ds = DbHelper.GetDSer("Proc_PAGING" , paras).Tables[0];
            //return DBHelper.GetDt(_connectionStr, "Proc_PAGING", paras);
            if(ds.Rows.Count > 0)
            {
                totalpage = Convert.ToInt32(paras[7].Value);
                totalrecord = Convert.ToInt32(paras[8].Value);
                index = index;
                return ds;
            }
            else
            {
                return null;
            }
        }


    }
}
