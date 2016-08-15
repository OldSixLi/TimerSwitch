//任务状态枚举类
using CST.ProjectFramework.Common.Attribute;

namespace TimerManage
{
    public enum MissionStateEnum
    { /// <summary>
        /// 任务状态：运行中
        /// </summary>
        [EnumDescription("show" , " <i  class='glyphicon glyphicon-ok-sign'></i>运行中 ")]
        YunXingZhong = 1 ,

        /// <summary>
        /// 任务状态：未运行
        /// </summary>
        [EnumDescription("show" , "<i  class='glyphicon glyphicon-time'></i>未运行 ")]
        WeiYunXing = 2 ,

        /// <summary>
        /// 任务状态：暂停
        /// </summary>
        [EnumDescription("show" , "<i  class='glyphicon glyphicon-pause'></i>暂停 ")]
        ZanTing = 3 ,

        /// <summary>
        /// 任务状态：已停止
        /// </summary>
        [EnumDescription("show" , "  <i  class='glyphicon glyphicon-exclamation-sign'></i>已停止")]
        YiTingZhi = 4 ,
    }

}