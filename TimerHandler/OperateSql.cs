using System;
using Quartz;

namespace TimerHandler
{
    /// <summary>
    /// �Զ�������ݿ����
    /// </summary>
    public class OperateSql :IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("��ʼִ�и������ݿ���� ��" + DateTime.Now.ToLongTimeString());
        }
    }
}