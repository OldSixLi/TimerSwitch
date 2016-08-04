/**************************************************************************************************
 * 描述：
 *       用于添加、暂停、启动、删除需要执行的定时任务
 *       在各个方法的参数中传入相关的参数
 * 变更历史：
 *      作者：马少博  时间：2016年7月21日10:41:31    新建 
**************************************************************************************************/
using System;
using Quartz;
using Quartz.Impl;

namespace TimerClass.Missions
{
    /// <summary>
    /// 用户定时任务的管理
    /// </summary>
    public class MissionControl
    {
        /// <summary>
        /// 调度器
        /// </summary>
        private IScheduler _scheduler = null;

        /// <summary>
        /// 添加数据库定时操作任务（依据时间间隔，执行次数执行任务）
        /// </summary>
        /// <param name="sqlstr">数据库操作语句</param>
        /// <param name="starttime">任务开始时间</param>
        /// <param name="endtime">任务结束时间</param>
        /// <param name="group">任务组名</param>
        /// <param name="missionname">任务名（不可重复）</param>
        /// <param name="repeatCount">执行次数</param>
        /// <param name="intervalInSeconds">执行间隔</param> 
        /// <returns></returns>
        public bool AddSqlExecuteJob(string sqlstr , DateTime starttime , DateTime endtime , string group , string missionname , int repeatCount , int intervalInSeconds)
        {
            try
            {
                _scheduler = GetScheduler();
                //创建一个作业
                IJobDetail job = JobBuilder.Create<TimerClass.Job.SqlOperateJob>()
                    .WithIdentity(group , missionname)
                    .WithDescription(sqlstr)//传入要执行的SQL语句
                    .Build();

                //声明一个触发器
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(group , missionname)
                    .StartAt(starttime)
                    .EndAt(endtime)
                    .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(intervalInSeconds)
                    .WithRepeatCount(repeatCount))
                    .Build();

                //把作业，触发器加入调度器
                _scheduler.ScheduleJob(job , trigger);

                _scheduler.Start();

                //TODO  将现有的任务组名、名称存储进数据库中，防止后期冲突
                return true;
            }
            catch(Exception)
            {
                return false;
                throw;
            }

        }

        /// <summary>
        /// 添加数据库定时操作任务（依据时间调度表达式执行任务）
        /// </summary>
        /// <param name="sqlstr">数据库操作语句</param>
        /// <param name="starttime">任务开始时间</param>
        /// <param name="endtime">任务结束时间</param>
        /// <param name="group">任务组名</param>
        /// <param name="missionname">任务名（不可重复）</param>
        /// <param name="timecorn">时间调度表达式</param>
        /// <returns></returns>
        public bool AddSqlExecuteJob(string sqlstr , DateTime starttime , DateTime endtime , string group , string missionname , string timecorn)
        {
            _scheduler = GetScheduler();
            //创建一个作业
            IJobDetail job = JobBuilder.Create<TimerClass.Job.SqlOperateJob>()
                .WithIdentity(group , missionname)
                .WithDescription(sqlstr)//传入要执行的SQL语句
                .Build();

            //声明一个触发器
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(group , missionname)
                .StartAt(starttime)
                .EndAt(endtime)
                .WithCronSchedule(timecorn)//时间调度表达式
                .Build();

            //把作业，触发器加入调度器
            _scheduler.ScheduleJob(job , trigger);

            _scheduler.Start();

            //TODO  将现有的任务组名、名称存储进数据库中，防止后期冲突
            return true;
        }

        /// <summary>
        /// 暂停定时任务
        /// </summary>
        /// <param name="group">组名</param>
        /// <param name="name">任务名</param>
        /// <returns></returns>
        public bool PauseJob(string group , string name)
        {

            try
            {
                _scheduler = GetScheduler();
                _scheduler.PauseJob(new JobKey(group , name));
                Console.WriteLine("暂停了组名：" + group + "，名称：" + name + "的任务,");
                return true;
            }
            catch(Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// 重新启动定时任务
        /// </summary>
        /// <param name="group">组名</param>
        /// <param name="name">任务名</param>
        /// <returns></returns>
        public bool ReStart(string group , string name)
        {


            try
            {
                _scheduler = GetScheduler();
                _scheduler.ResumeJob(new JobKey(group , name));
                Console.WriteLine("重启组名：" + group + "，名称：" + name + "的任务,");
                return true;
            }
            catch(Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// 删除定时任务
        /// </summary>
        /// <param name="group">组名</param>
        /// <param name="name">任务名</param>
        /// <returns></returns>
        public bool DeleteJob(string group , string name)
        {
            try
            {
                _scheduler = GetScheduler();
                _scheduler.DeleteJob(new JobKey(group , name));
                Console.WriteLine("删除组名：" + group + "，名称：" + name + "的任务,");
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw;
            }
        }


        /// <summary>
        /// 获取一个调度器
        /// </summary>
        /// <returns></returns>
        private IScheduler GetScheduler()
        {
            if(_scheduler != null)
            {
                return _scheduler;
            }
            else
            {
                ISchedulerFactory schedf = new StdSchedulerFactory();
                IScheduler sched = schedf.GetScheduler();
                return sched;

            }
        }
    }
}