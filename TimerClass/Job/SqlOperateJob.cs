/**********************************************************************
 * ������
 *      ���ݿ�����
 * �����ʷ��
 *      ���ߣ����ٲ�  ʱ�䣺2016��7��21��10:41:31    �½� 
***********************************************************************/
using System;
using Quartz;
using DAL;

namespace TimerClass.Job
{
    /// <summary>
    /// �Զ�������ݿ����
    /// </summary>
    public class SqlOperateJob :IJob
    {
        private readonly DataAccess _dal = new DataAccess();

        public void Execute(IJobExecutionContext context)
        {
            //��ȡ�û��Զ����SQL���
            string sql = context.JobDetail.Description;
            //ִ��sql���
            bool issuccess = _dal.SqlExecute(sql);

            if(issuccess)
            {
                Console.WriteLine("�������ݳɹ�" + "����ǰʱ�� "
                    + DateTime.Now.ToString("F") + ":�Զ���������Success��");
            }

        }
    }
}