using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
  public  class Bizlog
    {
      private readonly DAL.DataAccess dal = new DAL.DataAccess();

      public DataTable GetAllData(Model.TimerMission model, string orderby, int sort, int page, int pageindex, ref int totalpage, ref int index,
          ref int totalrecord)
      {
          return  dal.GetAllData(model, orderby,  sort,  page,  pageindex, ref  totalpage, ref  index,
          ref  totalrecord);
      }
    }
}
