using System;
using Quartz;

namespace TimerHandler
{
    public class OperateHandler :IJob
    {
        /// <summary>
        ///  context ���Ի�ȡ��ǰJob�ĸ���״̬��
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string content = dataMap.GetString("jobSays");
            Console.WriteLine("��ҵִ�У�jobSays:" + content + DateTime.Now.ToLongTimeString());
        }
    }
}