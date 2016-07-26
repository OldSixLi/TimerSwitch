/**************************************************************************************
 * 描述：
 *      普通事物处理操作  
 * 变更历史：
 *      作者：马少博  时间：2016年7月21日13:41:02    新建 
***************************************************************************************/

using System;
using Quartz;

namespace TimerClass.Job
{
    public class HandlerJob :IJob
    {
        /// <summary>
        ///  context 可以获取当前Job的各种状态。
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string content = dataMap.GetString("jobSays");
            Console.WriteLine("作业执行成功，完成时间:" + content + DateTime.Now.ToLongTimeString());
        }
    }
}