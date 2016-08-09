using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimerClass.Missions;

namespace TimerManage
{
    public partial class Control :System.Web.UI.Page
    {
        readonly MissionControl _control = new MissionControl();
        protected void Page_Load(object sender , EventArgs e)
        {

        }
        /// <summary>
        /// 添加新任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBegin_Click(object sender , EventArgs e)
        {
            string sqlstr = "insert into TimerTests  values('成功',getdate())";
            bool issuccess = _control.AddSqlExecuteJob(sqlstr , DateTime.Now.AddSeconds(1) , DateTime.Now.AddSeconds(1000) , "group1" , "mission2" , 100 , 1);
            if(issuccess)
            {
                UiHelper.Alert(this , "添加成功！");
            }
        }

        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPause_Click(object sender , EventArgs e)
        {
            _control.PauseJob("group1" , "mission2");
        }

        /// <summary>
        /// 任务重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResuse_Click(object sender , EventArgs e)
        {
            _control.ReStart("group1" , "mission2");
        }

        /// <summary>
        /// 删除当前的任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender , EventArgs e)
        {
            _control.DeleteJob("group1" , "mission2");
        }


    }
}