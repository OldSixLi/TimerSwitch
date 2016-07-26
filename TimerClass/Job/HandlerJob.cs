/**************************************************************************************
 * ������
 *      ��ͨ���ﴦ�����  
 * �����ʷ��
 *      ���ߣ����ٲ�  ʱ�䣺2016��7��21��13:41:02    �½� 
***************************************************************************************/

using System;
using Quartz;

namespace TimerClass.Job
{
    public class HandlerJob :IJob
    {
        /// <summary>
        ///  context ���Ի�ȡ��ǰJob�ĸ���״̬��
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string content = dataMap.GetString("jobSays");
            Console.WriteLine("��ҵִ�гɹ������ʱ��:" + content + DateTime.Now.ToLongTimeString());
        }
    }
}