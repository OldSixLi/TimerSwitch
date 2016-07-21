using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Quartz;
using Quartz.Impl;

namespace TimerHandler
{
    public class Program
    {

        static void Main(string[] args)
        {
            //从工厂中获取一个调度器实例化
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //开启调度器
            scheduler.Start();
            #region ==========例子1（简单使用）===========

            IJobDetail job1 = JobBuilder.Create<OperateSql>()  //创建一个作业
                .WithIdentity("作业名称" , "作业组")
                .Build();
            ITrigger trigger1 = TriggerBuilder.Create() //声明一个触发器
                                        .WithIdentity("触发器名称" , "触发器组")
                                        .StartNow()                        //现在开始
                                        .WithSimpleSchedule(x => x         //触发时间，5秒一次。
                                            .WithIntervalInSeconds(5)
                                            .RepeatForever())              //不间断重复执行
                                        .Build();
            scheduler.ScheduleJob(job1 , trigger1);      //把作业，触发器加入调度器。
            #endregion

            #region ==========例子2 (执行时 作业数据传递，时间表达式使用)===========

            IJobDetail job2 = JobBuilder.Create<OperateHandler>()
                                        .WithIdentity("myJob" , "group1")
                                        .UsingJobData("jobSays" , "在作业组中定义的任务！")
                                        .Build();
            ITrigger trigger2 = TriggerBuilder.Create()
                                        .WithIdentity("mytrigger" , "group1")
                                        .StartNow()
                                        .WithCronSchedule("/10 * * ? * *")    //时间调度表达式 ,每整十秒执行一次
                                        .Build();
            scheduler.ScheduleJob(job2 , trigger2);
            #endregion

            //scheduler.Shutdown();         //关闭调度器。

        }

    }

    #region 定义不同的任务，都需要继承IJob接口
    /// <summary>
    /// 具体的事物操作
    /// </summary>
    public class JobHandler :IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(JobHandler));
        /// <summary>
        /// 这里是作业调度每次定时执行方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("JobHandler测试");
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }

    #endregion
}
