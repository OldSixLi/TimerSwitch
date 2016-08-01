
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类:TimerMission
    /// </summary>
    public partial class TimerMission
    {
        public TimerMission()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TimerMission");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelper.Exists(strSql.ToString() , parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TimerMission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TimerMission(");
            strSql.Append("ID,MissionName,GroupName,SqlStr,TimeCorn,RepeatCount,InveralTime,StartTime,EndTime,CreateTime,MissionExplain,MissionState,IsDel)");
            strSql.Append(" values (");
            strSql.Append("@ID,@MissionName,@GroupName,@SqlStr,@TimeCorn,@RepeatCount,@InveralTime,@StartTime,@EndTime,@CreateTime,@MissionExplain,@MissionState,@IsDel)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MissionName", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupName", SqlDbType.NChar,50),
					new SqlParameter("@SqlStr", SqlDbType.NVarChar,-1),
					new SqlParameter("@TimeCorn", SqlDbType.NChar,50),
					new SqlParameter("@RepeatCount", SqlDbType.Int,4),
					new SqlParameter("@InveralTime", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@MissionExplain", SqlDbType.NVarChar,-1),
					new SqlParameter("@MissionState", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.MissionName;
            parameters[2].Value = model.GroupName;
            parameters[3].Value = model.SqlStr;
            parameters[4].Value = model.TimeCorn;
            parameters[5].Value = model.RepeatCount;
            parameters[6].Value = model.InveralTime;
            parameters[7].Value = model.StartTime;
            parameters[8].Value = model.EndTime;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.MissionExplain;
            parameters[11].Value = model.MissionState;
            parameters[12].Value = model.IsDel;

            int rows = DbHelper.ExecuteSql(strSql.ToString() , parameters);

            return rows;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.TimerMission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TimerMission set ");
            strSql.Append("MissionName=@MissionName,");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("SqlStr=@SqlStr,");
            strSql.Append("TimeCorn=@TimeCorn,");
            strSql.Append("RepeatCount=@RepeatCount,");
            strSql.Append("InveralTime=@InveralTime,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("MissionExplain=@MissionExplain,");
            strSql.Append("MissionState=@MissionState,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MissionName", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupName", SqlDbType.NChar,50),
					new SqlParameter("@SqlStr", SqlDbType.NVarChar,-1),
					new SqlParameter("@TimeCorn", SqlDbType.NChar,50),
					new SqlParameter("@RepeatCount", SqlDbType.Int,4),
					new SqlParameter("@InveralTime", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@MissionExplain", SqlDbType.NVarChar,-1),
					new SqlParameter("@MissionState", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.MissionName;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.SqlStr;
            parameters[3].Value = model.TimeCorn;
            parameters[4].Value = model.RepeatCount;
            parameters[5].Value = model.InveralTime;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.EndTime;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.MissionExplain;
            parameters[10].Value = model.MissionState;
            parameters[11].Value = model.IsDel;
            parameters[12].Value = model.ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString() , parameters);
            if(rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TimerMission ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString() , parameters);
            if(rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TimerMission ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
            if(rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TimerMission GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MissionName,GroupName,SqlStr,TimeCorn,RepeatCount,InveralTime,StartTime,EndTime,CreateTime,MissionExplain,MissionState,IsDel from TimerMission ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            Model.TimerMission model = new Model.TimerMission();
            DataSet ds = DbHelper.Query(strSql.ToString() , parameters);
            if(ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TimerMission DataRowToModel(DataRow row)
        {
            Model.TimerMission model = new Model.TimerMission();
            if(row != null)
            {
                if(row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if(row["MissionName"] != null)
                {
                    model.MissionName = row["MissionName"].ToString();
                }
                if(row["GroupName"] != null)
                {
                    model.GroupName = row["GroupName"].ToString();
                }
                if(row["SqlStr"] != null)
                {
                    model.SqlStr = row["SqlStr"].ToString();
                }
                if(row["TimeCorn"] != null)
                {
                    model.TimeCorn = row["TimeCorn"].ToString();
                }
                if(row["RepeatCount"] != null && row["RepeatCount"].ToString() != "")
                {
                    model.RepeatCount = int.Parse(row["RepeatCount"].ToString());
                }
                if(row["InveralTime"] != null && row["InveralTime"].ToString() != "")
                {
                    model.InveralTime = int.Parse(row["InveralTime"].ToString());
                }
                if(row["StartTime"] != null && row["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(row["StartTime"].ToString());
                }
                if(row["EndTime"] != null && row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if(row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if(row["MissionExplain"] != null)
                {
                    model.MissionExplain = row["MissionExplain"].ToString();
                }
                if(row["MissionState"] != null && row["MissionState"].ToString() != "")
                {
                    model.MissionState = int.Parse(row["MissionState"].ToString());
                }
                if(row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MissionName,GroupName,SqlStr,TimeCorn,RepeatCount,InveralTime,StartTime,EndTime,CreateTime,MissionExplain,MissionState,IsDel ");
            strSql.Append(" FROM TimerMission ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top , string strWhere , string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if(Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,MissionName,GroupName,SqlStr,TimeCorn,RepeatCount,InveralTime,StartTime,EndTime,CreateTime,MissionExplain,MissionState,IsDel ");
            strSql.Append(" FROM TimerMission ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TimerMission ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.GetSingle(strSql.ToString());
            if(obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere , string orderby , int startIndex , int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if(!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from TimerMission T ");
            if(!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}" , startIndex , endIndex);
            return DbHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "TimerMission";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public bool TestRepeat(string missionName , string groupname)
        {
            string sql = "select * from TimerMission where MissionName='" + missionName + "' and  GroupName='" + groupname +
                         "'";

            DataSet ds = DbHelper.GetDS(sql);
            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }


        public bool TestRepeat(string missionName , string groupname , string id)
        {
            string sql = "select * from TimerMission where MissionName='" + missionName + "' and  GroupName='" + groupname +
                         "' and id!='" + id + "'";

            DataSet ds = DbHelper.GetDS(sql);
            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }

        #endregion  ExtensionMethod
    }
}

