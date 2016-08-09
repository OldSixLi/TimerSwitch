using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using BLL;
using CST.ProjectFramework.Common.Extension;

namespace TimerManage.Ajax
{
    /// <summary>
    /// GetMissionDetail 的摘要说明
    /// </summary>
    public class GetMissionDetail :IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            TimerMission bll = new TimerMission();
            context.Response.ContentType = "text/plain";

            //获取当前任务ID，用于查询
            string missionid = HttpContext.Current.Request.Params["missionid"];
            if (missionid == null) throw new ArgumentNullException("context");

            //获取Model
            Model.TimerMission model = bll.GetModel(new Guid(missionid));
            //JSON输出
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            if(model != null)
            {
                var states = EnumDescriptionExtension.GetDescription(typeof(MissionStateEnum) , value: model.MissionState.ToString() , key: "show");

                //只显示状态名称，不显示图标
                model.StateString = states.Substring(states.IndexOf("</i>", StringComparison.Ordinal) + 4);
                model.StartTimeStr = model.StartTime.ToString();
                model.EndTimeStr = model.EndTime.ToString();

                string missionjson = scriptSerializer.Serialize(model);
                //输出JSON
                HttpContext.Current.Response.Write(missionjson);

            }
            HttpContext.Current.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}