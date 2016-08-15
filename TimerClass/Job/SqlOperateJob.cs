/**********************************************************************
 * 描述：
 *      数据库任务
 * 变更历史：
 *      作者：马少博  时间：2016年7月21日10:41:31    新建 
***********************************************************************/
using System;
using Quartz;
using DAL;

namespace TimerClass.Job
{
    /// <summary>
    /// 自定义的数据库操作
    /// </summary>
    public class SqlOperateJob :IJob
    {
        private readonly DataAccess _dal = new DataAccess();

        public void Execute(IJobExecutionContext context)
        {
            //读取用户自定义的SQL语句
            string sql = context.JobDetail.Description;
            //执行sql语句
            bool issuccess = _dal.SqlExecute(sql);

            if(issuccess)
            {
                Console.WriteLine("插入数据成功" + "，当前时间 "
                    + DateTime.Now.ToString("F") + ":自定义语句操作Success！");
            }

        }
    }
}