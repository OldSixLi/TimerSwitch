//说明：在操作任务期间需要先停止或删除任务后，在进行数据库的数据操作。避免数据库状态更改后，任务却仍存在于线程中。
//后期需要操作部分：在页面上添加按钮，需要根据当前数据库中的任务状态，将任务重新添加至进程中，避免因IIS出故障而导致任务不能继续（将除去未运行状态的任务，其他状态的任务都重新添加至进程中并恢复至相应状态）

using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using CST.ProjectFramework.Common.Extension;
using BLL;
using TimerClass.Missions;

namespace TimerManage
{
    public partial class Manage :System.Web.UI.Page
    {
        /// <summary>
        /// 业务逻辑层
        /// </summary>
        private readonly TimerMission _bll = new TimerMission();
        /// <summary>
        /// 任务操作类
        /// </summary>
        private readonly MissionControl _missionControl = new MissionControl();

        #region 私有属性
        /// <summary>
        /// 当前页
        /// </summary>
        public long Webpageindex
        {
            get
            {
                if(ViewState["Webpageindex"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["Webpageindex"]);
                    }
                    catch
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                ViewState["Webpageindex"] = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public long WebPageCount
        {
            get
            {
                if(ViewState["WebPageCount"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["WebPageCount"]);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["WebPageCount"] = value;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long Webpagerecord
        {
            get
            {
                if(ViewState["Webpagerecord"] != null)
                {
                    try
                    {
                        return Convert.ToInt32(ViewState["Webpagerecord"]);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["Webpagerecord"] = value;
            }
        }
        #endregion

        #region 页面加载

        protected void Page_Load(object sender , EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            if(!IsPostBack)
            {
                DataSet ds = new DataSet();

                if(Webpageindex == 0)
                {
                    Webpageindex = 1;
                }
                NewDatabind(count);
            }//绑定列表
        }

        #endregion

        #region  搜索事件

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnF5_Click(object sender , EventArgs e)
        {
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }

        /// <summary>
        /// 搜索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender , EventArgs e)
        {
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }


        #endregion

        #region 添加模态框

        /// <summary>
        /// 添加任务按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegist_Click(object sender , EventArgs e)
        {
            string str = AddTimerMission();
        }

        /// <summary>
        /// 添加任务并立即执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMissionBeginNow_Click(object sender , EventArgs e)
        {
            try
            {
                string str = AddTimerMission();
                if(str != "")
                {
                    Model.TimerMission model = _bll.GetModel(new Guid(str));
                    bool issuccess = _missionControl.AddSqlExecuteJob(model.SqlStr , Convert.ToDateTime(model.StartTime) , Convert.ToDateTime(model.EndTime) , model.GroupName , model.MissionName , model.TimeCorn);
                    if(issuccess)
                    {
                        UiHelper.Alert(this , "任务运行成功！");
                        model.MissionState = 1;
                        _bll.Update(model);//更新数据

                    }
                    else
                    {
                        UiHelper.Alert(this , "操作失败，请重试！");
                    }

                    NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
                }
            }
            catch(Exception)
            {
                UiHelper.Alert(this , "操作失败，请重试！");
                throw;
            }
        }



        /// <summary>
        /// TimerMission表数据添加
        /// </summary>
        /// <returns></returns>
        private string AddTimerMission()
        {
            try
            {

                #region 校验非空错误提示
                string strErr = "";
                if(this.txtAddMissionName.Text.Trim().Length == 0)
                {
                    strErr += "任务名称不能为空！\\n";
                }
                if(this.txtAddGroupName.Text.Trim().Length == 0)
                {
                    strErr += "组名称不能为空！\\n";
                }
                if(this.txtAddSqlStr.Text.Trim().Length == 0)
                {
                    strErr += "SQL执行语句不能为空！\\n";
                }
                if(this.txtAddTimeCorn.Text.Trim().Length == 0)
                {
                    strErr += "时间调度表达式不能为空！\\n";
                }

                if(this.txtAddMissionStartTime.Text.Trim().Length == 0)
                {
                    strErr += "任务开始时间不能为空！\\n";
                }
                if(this.txtAddMissionEndTime.Text.Trim().Length == 0)
                {
                    strErr += "任务结束时间不能为空！\\n";
                }
                if(Convert.ToDateTime(this.txtAddMissionStartTime.Text.Trim()) >= Convert.ToDateTime(this.txtAddMissionEndTime.Text.Trim()))
                {

                    strErr += "任务开始时间不可大于结束时间\\n";
                }
                if(strErr != "")
                {
                    UiHelper.Alert(this , strErr);
                    return "";
                }
                #endregion

                string missionName = this.txtAddMissionName.Text;
                string groupName = this.txtAddGroupName.Text;
                bool isrepeat = _bll.TestRepeat(missionName , groupName);
                if(isrepeat) //判断当前任务名和组名是否重复
                {

                    UiHelper.Alert(this , "当前已存在重复的任务组名和任务名，请修改后再进行添加！");
                    return "";
                }
                else
                {
                    Model.TimerMission model = new Model.TimerMission {
                        ID = Guid.NewGuid() ,
                        MissionName = missionName ,
                        GroupName = groupName ,
                        SqlStr = this.txtAddSqlStr.Text ,
                        TimeCorn = this.txtAddTimeCorn.Text ,
                        RepeatCount = int.Parse(this.txtAddRepeatCount.Text) ,
                        StartTime = DateTime.Parse(this.txtAddMissionStartTime.Text) ,
                        EndTime = DateTime.Parse(this.txtAddMissionEndTime.Text) ,
                        CreateTime = DateTime.Now ,
                        InveralTime = 0 ,
                        MissionExplain = this.txtAddMissionExplain.Text ,
                        MissionState = 2//默认设置当前的MissionState为空
                    };
                    //数据添加
                    int issuccess = _bll.Add(model);
                    UiHelper.Alert(this , issuccess > 0 ? "保存成功！" : "数据添加失败，请校验数据后重试！");
                    if(issuccess > 0)
                    {
                        //重新进行数据绑定
                        NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
                        //清空原有的输入框数据
                        foreach(object item in this.form1.Controls)
                        {
                            var box = item as TextBox;
                            if(box != null)
                            {
                                TextBox tbx = box; tbx.Text = "";

                            }
                        }
                    }
                    if(issuccess > 0)
                    {
                        return model.ID.ToString();
                    }
                    else
                    {
                        return "";
                    }


                }
            }
            catch(Exception)
            {
                UiHelper.Alert(this , "未知原因，操作失败！");
                return "";
                throw;
            }
        }

        #endregion

        #region 修改模态框

        /// <summary>
        /// 任务修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMissionEdit_Click(object sender , EventArgs e)
        {

            string edit = EditTimerMission();
        }

        /// <summary>
        /// TimerMission表数据修改
        /// </summary>
        /// <returns>返回修改的任务主键</returns>
        private string EditTimerMission()
        {
            try
            {
                #region 校验非空错误提示
                string strErr = "";
                if(this.txtEditMissionName.Text.Trim().Length == 0)
                {
                    strErr += "任务名称不能为空！\\n";
                }
                if(this.txtEditGroupName.Text.Trim().Length == 0)
                {
                    strErr += "组名称不能为空！\\n";
                }
                if(this.txtEditSqlStr.Text.Trim().Length == 0)
                {
                    strErr += "SQL执行语句不能为空！\\n";
                }
                if(this.txtEditTimeCorn.Text.Trim().Length == 0)
                {
                    strErr += "时间调度表达式不能为空！\\n";
                }

                if(this.txtEditMissionStartTime.Text.Trim().Length == 0)
                {
                    strErr += "任务开始时间不能为空！\\n";
                }
                if(this.txtEditMissionEndTime.Text.Trim().Length == 0)
                {
                    strErr += "任务结束时间不能为空！\\n";
                }
                if(Convert.ToDateTime(this.txtEditMissionStartTime.Text.Trim()) >= Convert.ToDateTime(this.txtEditMissionEndTime.Text.Trim()))
                {

                    strErr += "任务开始时间不可大于结束时间\\n";
                }
                if(strErr != "")
                {
                    UiHelper.Alert(this , strErr);
                    return "";
                }
                #endregion

                var model = _bll.GetModel(new Guid(txtHiddenText.Text));
                string missionName = this.txtEditMissionName.Text;
                string groupName = this.txtEditGroupName.Text;
                //判断除去当前数据外是否存在重名数据
                var isrepeat = _bll.TestRepeat(missionName , groupName , model.ID.ToString());
                if(isrepeat) //判断当前任务名和组名是否重复
                {
                    UiHelper.Alert(this , "当前已存在重复的任务组名和任务名，请修改名称后再进行操作！");
                    return "";
                }
                else
                {
                    model.MissionName = missionName;
                    model.GroupName = groupName;
                    model.SqlStr = this.txtEditSqlStr.Text;
                    model.TimeCorn = this.txtEditTimeCorn.Text;
                    model.RepeatCount = int.Parse(this.txtEditRepeatCount.Text);
                    model.StartTime = DateTime.Parse(this.txtEditMissionStartTime.Text);
                    model.EndTime = DateTime.Parse(this.txtEditMissionEndTime.Text);
                    model.CreateTime = DateTime.Now;
                    model.InveralTime = 0;
                    model.MissionExplain = this.txtEditMissionExplain.Text;
                    model.MissionState = 2;//默认设置当前的MissionState为空
                    //数据添加
                    bool issuccess = _bll.Update(model);
                    UiHelper.Alert(this , issuccess ? "修改任务成功，当前任务状态恢复为未执行状态！" : "数据添加失败，请校验数据后重试！");
                    if(issuccess)
                    {
                        //重新进行数据绑定
                        NewDatabind(Convert.ToInt32(countDDL.SelectedValue));

                        //清空原有的输入框数据
                        foreach(TextBox tbx in this.form1.Controls.OfType<TextBox>()) { if(tbx != null) tbx.Text = ""; }
                    }
                    return issuccess ? model.ID.ToString() : "";


                }
            }
            catch
            {
                UiHelper.Alert(this , "未知原因，操作失败！");
                return "";
            }
        }

        /// <summary>
        /// 修改任务并立即执行
        /// 操作步骤：先将当前进程中任务删除，然后再重新添加到进程中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditMissionBeginNow_Click(object sender , EventArgs e)
        {
            try
            {
                string missionid = EditTimerMission();
                if(missionid != "")
                {
                    Model.TimerMission model = _bll.GetModel(new Guid(missionid));
                    _missionControl.DeleteJob(model.GroupName , model.MissionName);
                    bool issuccess = _missionControl.AddSqlExecuteJob(model.SqlStr , Convert.ToDateTime(model.StartTime) ,
                        Convert.ToDateTime(model.EndTime) , model.GroupName , model.MissionName , model.TimeCorn);
                    if(issuccess)
                    {
                        UiHelper.Alert(this , "修改任务成功，当前任务已开启！");
                        model.MissionState = 1;
                        _bll.Update(model); //更新数据
                    }
                    else
                    {
                        UiHelper.Alert(this , "操作失败，请重试！");

                    }
                }
                else
                {
                    UiHelper.Alert(this , "操作失败，请重试！");
                }

            }
            catch(Exception)
            {
                UiHelper.Alert(this , "操作失败，未知错误！");
                throw;
            }

        }
        #endregion

        #region 删除功能
        /// <summary>
        /// 删除任务功能
        /// 先删除当前线程中的任务，然后再删除数据库表中的任务状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Delete(object sender , CommandEventArgs e)
        {
            try
            {
                string missionid = e.CommandArgument.ToString();
                Model.TimerMission model = _bll.GetModel(new Guid(missionid));
                //删除正在执行的任务
                _missionControl.DeleteJob(model.GroupName , model.MissionName);
                //更改存储在数据库中当前的任务状态ISDel=1
                bool isdel = _bll.Delete(new Guid(missionid));
                int count = Convert.ToInt32(countDDL.SelectedValue);
                UiHelper.Alert(this , isdel ? "删除成功" : "删除失败");
                NewDatabind(count);
            }
            catch(Exception)
            {
                UiHelper.Alert(this , "未知错误");
                throw;
            }

        }
        #endregion

        #region 分页绑定

        private void NewDatabind(int count)
        {
            int totalpage = 0;
            int index = Convert.ToInt32(Webpageindex);
            int totalrecord = 0;
            Model.TimerMission model = new Model.TimerMission();
            model.MissionName = txtMissionName.Text.Trim();
            model.GroupName = txtGroupName.Text.Trim();
            model.MissionState = Convert.ToInt32(ddlState.SelectedValue);
            if(txtStartTime.Text.Trim() != "") { model.StartTime = Convert.ToDateTime(txtStartTime.Text.Trim()); }
            if(txtEndTime.Text.Trim() != "")
            {
                model.EndTime = Convert.ToDateTime(txtEndTime.Text.Trim());
            }

            DataTable dt = new BLL.Bizlog().GetAllData(model , "createtime" , 1 , count , Convert.ToInt32(Webpageindex) , ref totalpage , ref  index , ref totalrecord);

            if(dt != null)
            {
                dt.Columns.Add("StateString" , typeof(string));
                foreach(DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["SqlStr"] = dr["SqlStr"].ToString().Replace("\"" , "'");
                        string state = dr["MissionState"].ToString();
                        dr["StateString"] = EnumDescriptionExtension.GetDescription(typeof(MissionStateEnum) , state , "show");
                        dr["TimeCorn"] = dr["TimeCorn"].ToString().Trim();
                    }
                    catch(Exception)
                    {

                        throw;
                    }

                }

                if(totalpage < index)
                {
                    Webpageindex = index;
                }

            }
            WebPageCount = totalpage;
            Webpagerecord = totalrecord;
            Repeatergoods.DataSource = dt;
            Repeatergoods.DataBind();

        }
        #endregion

        #region 选择每页显示数据（下拉菜单）
        protected void countDDL_SelectedIndexChanged(object sender , EventArgs e)
        {
            int count = Convert.ToInt32(countDDL.SelectedValue);
            NewDatabind(count);
        }
        #endregion

        #region 翻页事件
        //回到上一页
        protected void Goup(object sender , CommandEventArgs e)
        {
            Webpageindex = Webpageindex - 1;
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }
        //下一页
        protected void Gonp(object sender , CommandEventArgs e)
        {
            Webpageindex = Webpageindex + 1;
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }
        //前边2页
        protected void GOjian2(object sender , CommandEventArgs e)
        {
            Webpageindex = Webpageindex - 2;
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }
        //前边1页
        protected void GOjian1(object sender , CommandEventArgs e)
        {

            Webpageindex = Webpageindex - 1;
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }
        //后边1页
        protected void GOjia1(object sender , CommandEventArgs e)
        {

            Webpageindex = Webpageindex + 1;
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }
        //后边2页
        protected void GOjia2(object sender , CommandEventArgs e)
        {

            Webpageindex = Webpageindex + 2;
            NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
        }
        #endregion

        #region 任务操作方法（增删改查）

        /// <summary>
        /// 任务添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddJob_Click(object sender , EventArgs e)
        {
            try
            {
                string missionid = txtHiddenText.Text;
                Model.TimerMission model = _bll.GetModel(new Guid(missionid));
                if(model != null)
                {
                    //添加任务操作
                    bool issuccess = _missionControl.AddSqlExecuteJob(model.SqlStr , Convert.ToDateTime(model.StartTime) ,
                        Convert.ToDateTime(model.EndTime) , model.GroupName , model.MissionName , model.TimeCorn);
                    if(issuccess)
                    {
                        UiHelper.Alert(this , "任务运行成功！");
                        model.MissionState = 1;
                        _bll.Update(model); //更新数据
                    }
                    else
                    {
                        UiHelper.Alert(this , "操作失败，请重试！");
                    }

                    NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
                }
                else
                {
                    throw new ArgumentNullException("sender");
                }
            }
            catch
            {
                UiHelper.Alert(this , "操作失败，请重试！");
                throw;
            }
        }

        /// <summary>
        /// 任务暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPauseJob_Click(object sender , EventArgs e)
        {
            try
            {
                string missionid = txtHiddenText.Text;
                Model.TimerMission model = _bll.GetModel(new Guid(missionid));
                bool issuccess = _missionControl.PauseJob(model.GroupName , model.MissionName);
                if(issuccess)
                {
                    UiHelper.Alert(this , "任务已暂停！");
                    model.MissionState = 3;
                    _bll.Update(model);//更新数据

                }
                else
                {
                    UiHelper.Alert(this , "操作失败，请重试！");
                }

                NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
            }
            catch(Exception)
            {
                UiHelper.Alert(this , "操作失败，请重试！");
                throw;
            }
        }

        /// <summary>
        /// 任务重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPauseResume_Click(object sender , EventArgs e)
        {
            try
            {
                string missionid = txtHiddenText.Text;
                Model.TimerMission model = _bll.GetModel(new Guid(missionid));
                bool issuccess = _missionControl.ReStart(model.GroupName , model.MissionName);
                if(issuccess)
                {
                    UiHelper.Alert(this , "任务重启成功！");
                    model.MissionState = 1;
                    _bll.Update(model); //更新数据

                }
                else
                {
                    UiHelper.Alert(this , "操作失败，请重试！");
                }

                NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
            }
            catch(Exception)
            {
                UiHelper.Alert(this , "操作失败，请重试！");
                throw;
            }
        }

        /// <summary>
        /// 任务停止（删除Job）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStopJob_Click(object sender , EventArgs e)
        {
            try
            {
                string missionid = txtHiddenText.Text;
                Model.TimerMission model = _bll.GetModel(new Guid(missionid));
                bool issuccess = _missionControl.DeleteJob(model.GroupName , model.MissionName);
                UiHelper.Alert(this , issuccess ? "任务已停止！" : "操作失败，请重试！");
                if(issuccess)
                {
                    UiHelper.Alert(this , "任务已停止！");
                    model.MissionState = 4;
                    _bll.Update(model);//更新数据
                }
                else
                {
                    UiHelper.Alert(this , "操作失败，请重试！");
                }

                NewDatabind(Convert.ToInt32(countDDL.SelectedValue));
            }
            catch(Exception)
            {
                UiHelper.Alert(this , "操作失败，请重试！");
                throw;
            }
        }

        #endregion

    }
}