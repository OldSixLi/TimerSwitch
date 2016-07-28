
using CST.ProjectFramework.Common.Attribute;

namespace TimerManage
{
    public enum MissionStateEnum
    { /// <summary>
        /// 正局级
        /// </summary>
        [EnumDescription("show" , "运行中 ")]
        ZhengJu = 1 ,

        /// <summary>
        /// 副局级
        /// </summary>
        [EnumDescription("show" , "未运行 ")]
        Fuju = 2 ,

        /// <summary>
        /// 正处级
        /// </summary>
        [EnumDescription("show" , "暂停 ")]
        ZHengChu = 3 ,

        /// <summary>
        /// 副处级
        /// </summary>
        [EnumDescription("show" , "删除")]
        FuChu = 4 ,
    }

}