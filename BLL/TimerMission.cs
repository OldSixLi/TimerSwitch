
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
        private readonly  DAL.TimerMission _dal = new  DAL.TimerMission();
		public TimerMission()
		{}

        ///设置当前的备注信息

		#region  BasicMethod
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Model.TimerMission model)
		{
			return _dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.TimerMission model)
		{
			return _dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid id)
		{
			
			return _dal.Delete(id);
		}
		 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.TimerMission GetModel(Guid ID)
		{
			
			return _dal.GetModel(ID);
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
	        return _dal.TestRepeat(missionName, groupname,id);
	    }

	    public bool TestRepeat(string missionName, string groupname)
	    {
            return _dal.TestRepeat(missionName , groupname);
	    }
		#endregion  ExtensionMethod
	}
}

