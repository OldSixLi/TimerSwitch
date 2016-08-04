using System;
using System.Web.UI;
using  BLL;

namespace TimerManage
{
    public partial class WebForm1 :Page
    {

        protected void Page_Load(object sender , EventArgs e)
        {
             
        }

        public void AddData()
        {
            for(int i = 100; i <= 100; i++)
            {
                Guid id = Guid.NewGuid();
                string sqlstr = @" insert into TimerMission(ID ,MissionName ,GroupName ,SqlStr ,TimeCorn ,RepeatCount,InveralTime  ,StartTime ,EndTime ,CreateTime  ,MissionState ) values ('" + id + "','任务" + i + "'," + "'Group1'," + "\'insert into TimerTests  values(\"成功\",getdate())\'," + "'/3 * * ? * *',0,0,'" + DateTime.Now.AddSeconds(1) + "','" + DateTime.Now.AddSeconds(100) + "','" + DateTime.Now + "',2)";
               

                //DbHelper.ExecuteSql(sqlstr);
            }
        }
    }
}