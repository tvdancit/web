using DataContext.DataTable;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.DataMethod
{
    public class TopicLeSQL
    {
        DataConnect connect;
        public TopicLeSQL()
        {
            connect = new DataConnect();
        }
        public List<TopicLeModel> getListAll()
        {
            
            var linq = from t in connect.TopicOfLectures
                       join i in connect.Information on t.IdLe equals i.IdLe
                       join p in connect.PointTables on t.IdP equals p.IdP                       
                       select new TopicLeModel
                       {
                           IdTp = t.IdTp,
                           Name = t.Name,
                           NameLe = i.Name,
                           NameP = p.NameP,
                           DateSt = (DateTime)t.DateSt,
                           Expense = t.Expense,
                           Times = (int)t.Times
                          
                       };
            linq.OrderByDescending(m => m.DateSt);
                   


            return linq.ToList();
        }
    }
}
