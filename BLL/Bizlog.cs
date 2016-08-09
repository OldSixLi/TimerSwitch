using System.Data;

namespace BLL
{
    public class Bizlog
    {
        private readonly DAL.DataAccess _dal = new DAL.DataAccess();

        /// <summary>
        /// 分页获取任务管理列表
        /// </summary>
        /// <param name="model">任务模型</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sort">排序方式，0为升序，1为降序</param>
        /// <param name="page">每页多少条记录</param>
        /// <param name="pageindex">指定当前为第几页</param>
        /// <param name="totalpage">返回总页数</param>
        /// <param name="index">返回当前页数</param>
        /// <param name="totalrecord">总记录数</param>
        /// <returns></returns>
        public DataTable GetAllData(Model.TimerMission model , string orderby , int sort , int page , int pageindex , ref int totalpage , ref int index ,
            ref int totalrecord)
        {
            return _dal.GetAllData(model , orderby , sort , page , pageindex , ref  totalpage , ref  index ,
            ref  totalrecord);
        }
    }
}
