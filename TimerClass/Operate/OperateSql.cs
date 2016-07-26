/*
 * ���ݿ����ز�������
 */
using System;
using Quartz;
using TimerClass.DAL;

namespace TimerClass.Operate
{
    /// <summary>
    /// �Զ�������ݿ����
    /// </summary>
    public class OperateSql :IJob
    {
        private DataAccess dal = new DataAccess();

        public void Execute(IJobExecutionContext context)
        {
            string sql = context.JobDetail.Description;
            //ִ��sql���
            bool issuccess = dal.SqlExecute(sql);

            if(issuccess)
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                //string content = dataMap.GetString("");
                Console.WriteLine("�������ݳɹ�" + "����ǰʱ�� " + DateTime.Now.ToString("F") + "jobSays:�Զ���������Success��");


            }

        }
    }
}