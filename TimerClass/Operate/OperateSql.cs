/*
 * 数据库的相关操作部分
 */
using System;
using Quartz;
using TimerClass.DAL;

namespace TimerClass.Operate
{
    /// <summary>
    /// 自定义的数据库操作
    /// </summary>
    public class OperateSql :IJob
    {
        private DataAccess dal = new DataAccess();

        public void Execute(IJobExecutionContext context)
        {
            string sql = context.JobDetail.Description;
            //执行sql语句
            bool issuccess = dal.SqlExecute(sql);

            if(issuccess)
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                //string content = dataMap.GetString("");
                Console.WriteLine("插入数据成功" + "，当前时间 " + DateTime.Now.ToString("F") + "jobSays:自定义语句操作Success！");


            }

        }
    }
}