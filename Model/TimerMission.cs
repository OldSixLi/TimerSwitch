/**  版本信息模板在安装目录下，可自行修改。
* TimerMission.cs
*
* 功 能： N/A
* 类 名： TimerMission
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/28 15:36:40   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace  Model
{
	/// <summary>
	/// TimerMission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TimerMission
	{
		public TimerMission()
		{}
		#region Model
		private Guid _id;
		private string _missionname;
		private string _groupname;
		private string _sqlstr;
		private string _timecorn;
		private int? _repeatcount;
		private int? _inveraltime;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private DateTime? _createtime;
		private string _missionexplain;
		private int _missionstate;
		private int _isdel;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 任务名称
		/// </summary>
		public string MissionName
		{
			set{ _missionname=value;}
			get{return _missionname;}
		}
		/// <summary>
		/// 组名称
		/// </summary>
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// SQL执行语句
		/// </summary>
		public string SqlStr
		{
			set{ _sqlstr=value;}
			get{return _sqlstr;}
		}
		/// <summary>
		/// 时间调度表达式
		/// </summary>
		public string TimeCorn
		{
			set{ _timecorn=value;}
			get{return _timecorn;}
		}
		/// <summary>
		/// 执行次数
		/// </summary>
		public int? RepeatCount
		{
			set{ _repeatcount=value;}
			get{return _repeatcount;}
		}
		/// <summary>
		/// 间隔时间（秒）
		/// </summary>
		public int? InveralTime
		{
			set{ _inveraltime=value;}
			get{return _inveraltime;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 任务创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MissionExplain
		{
			set{ _missionexplain=value;}
			get{return _missionexplain;}
		}
		/// <summary>
		/// 任务状态：1：运行;2：未运行;3：暂停;4：删除;
		/// </summary>
		public int MissionState
		{
			set{ _missionstate=value;}
			get{return _missionstate;}
		}
		/// <summary>
		/// 是否删除：1：已删除;0：未删除;
		/// </summary>
		public int IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

