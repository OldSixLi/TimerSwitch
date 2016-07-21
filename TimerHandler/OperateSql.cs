using System;
using Quartz;

namespace TimerHandler
{
    /// <summary>
    /// 自定义的数据库操作
    /// </summary>
    public class OperateSql :IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("开始执行各种数据库操作 ！" + DateTime.Now.ToLongTimeString());
        }
    }
}