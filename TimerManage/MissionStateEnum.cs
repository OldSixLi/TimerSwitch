//任务状态枚举类
using CST.ProjectFramework.Common.Attribute;

namespace TimerManage
{
    public enum MissionStateEnum
    { /// <summary>
        /// 正局级
        /// </summary>
        [EnumDescription("show" , " <i  class='glyphicon glyphicon-ok-sign'></i>运行中 ")]
        ZhengJu = 1 ,

        /// <summary>
        /// 副局级
        /// </summary>
        [EnumDescription("show" , "<i  class='glyphicon glyphicon-time'></i>未运行 ")]
        Fuju = 2 ,

        /// <summary>
        /// 正处级
        /// </summary>
        [EnumDescription("show" , "<i  class='glyphicon glyphicon-pause'></i>暂停 ")]
        ZHengChu = 3 ,

        /// <summary>
        /// 副处级
        /// </summary>
        [EnumDescription("show" , "  <i  class='glyphicon glyphicon-exclamation-sign'></i>已停止")]
        FuChu = 4 ,
    }

}