/**************************************************************************************************
 * 描述：
 *      定时任务管理
 *       在系统中，主要分为两大部分：操作的事件（Operate）以及定时执行的任务（Mission）
 *       事件为具体的数据库操作、邮件定时发送等操作事件
 *       任务为管理员设置定时执行的标准
 * 变更历史：
 *      作者：马少博  时间：2016年7月20日13:41:02    新建 
**************************************************************************************************/
using System;
using System.Collections.Specialized;
using System.Threading;
using Common.Logging;
using CrystalQuartz.WebFramework;
using Quartz;
using Quartz.Impl;
using  TimerClass.Missions;

namespace TimerHandler
{
    public class Program
    {

        static void Main(string[] args)
        {
            
            #region 固定设置部分
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "RemoteServerSchedulerClient";

            // 设置线程池
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";

            // 远程输出配置
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            properties["quartz.scheduler.exporter.port"] = "556";
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
            properties["quartz.scheduler.exporter.channelType"] = "tcp";
            //从工厂中获取一个调度器实例化
            var schedulerFactory = new StdSchedulerFactory(properties);
            var scheduler = schedulerFactory.GetScheduler();
            #endregion

            #region 例子1（简单使用）

            IJobDetail job1 = JobBuilder.Create<TimerClass.Operate.OperateSql>()  //创建一个作业
                .WithIdentity("作业名称" , "作业组")
                .Build();
            ITrigger trigger1 = TriggerBuilder
                                        .Create() //声明一个触发器
                                        .WithIdentity("触发器名称" , "触发器组")
                                        .StartNow()                        //现在开始
                                        .WithSimpleSchedule(x => x         //触发时间，5秒一次。
                                        .WithIntervalInSeconds(5)
                                        .RepeatForever())              //不间断重复执行
                                        .Build();
            scheduler.ScheduleJob(job1 , trigger1);      //把作业，触发器加入调度器。
            #endregion

            #region 例子2 (执行时 作业数据传递，时间表达式使用）

            IJobDetail job2 = JobBuilder.Create<TimerClass.Operate.OperateHandler>()
                                        .WithIdentity("myJob" , "group1")
                                        .UsingJobData("jobSays" , "在此处执行一些普通的事物操作")
                                        .Build();
            ITrigger trigger2 = TriggerBuilder.Create()
                                        .WithIdentity("mytrigger" , "group1")
                                        .StartNow()
                                        .WithCronSchedule("/10 * * ? * *")//时间调度表达式每整十秒执行一次
                                        .Build();
            scheduler.ScheduleJob(job2 , trigger2);
            #endregion

            scheduler.Start();//开启调度器

            #region 任务操作的例子

            MissionControl control = new MissionControl();

            //control.AddScheduleJob("111111111组！" , "好啊1");
            //control.AddScheduleJob("222222222组！" , "好啊2");
            //control.AddScheduleJob("333333333组！" , "好啊3");
            //control.AddScheduleJob("444444444组！" , "好啊4");


            //control.AddScheduleJob("1组", "2任务", "insert into TimerTests  values('success',getdate())");
            //new MissionControl().PauseJob("222222222组！" , "好啊2");
            #endregion
            
            Thread.Sleep(20000);
            //new MissionControl().ReStart("222222222组！" , "好啊2");

            scheduler.Shutdown(true);//关闭调度器。
            Console.ReadLine();

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
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string content = dataMap.GetString("好啊4");
            Console.WriteLine("新加任务测试" + content + DateTime.Now.ToLongTimeString() + "\r\n");
        }
    }

    #endregion
}
