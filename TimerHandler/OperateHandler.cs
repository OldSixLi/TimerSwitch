using System;
using Quartz;

namespace TimerHandler
{
    public class OperateHandler :IJob
    {
        /// <summary>
        ///  context 可以获取当前Job的各种状态。
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string content = dataMap.GetString("jobSays");
            Console.WriteLine("作业执行，jobSays:" + content + DateTime.Now.ToLongTimeString());
        }
    }
}