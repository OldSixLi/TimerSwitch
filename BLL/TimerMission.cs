
using System;
using System.Data;
using System.Collections.Generic;

namespace BLL
{
	/// <summary>
	/// TimerMission
	/// </summary>
	public partial class TimerMission
	{
        private readonly  DAL.TimerMission dal = new  DAL.TimerMission();
		public TimerMission()
		{}

        ///设置当前的备注信息

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Model.TimerMission model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.TimerMission model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid ID)
		{
			
			return dal.Delete(ID);
		}
		 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.TimerMission GetModel(Guid ID)
		{
			
			return dal.GetModel(ID);
		}
         
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.TimerMission> DataTableToList(DataTable dt)
		{
			List<Model.TimerMission> modelList = new List<Model.TimerMission>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.TimerMission model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

	
	    #endregion  BasicMethod

	    #region  ExtensionMethod

        /// <summary>
        /// 判断当前任务名和组名是否已经存在于任务系统中
        /// </summary>
        /// <param name="missionName"></param>
        /// <param name="groupname"></param>
        /// <returns></returns>
	    public bool  TestRepeat(string missionName , string groupname,string  id )
	    {
	        return dal.TestRepeat(missionName, groupname,id);
	    }

	    public bool TestRepeat(string missionName, string groupname)
	    {
            return dal.TestRepeat(missionName , groupname);
	    }
		#endregion  ExtensionMethod
	}
}

