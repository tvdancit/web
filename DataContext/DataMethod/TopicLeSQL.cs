using DataContext.DataTable;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<TopicLecuter> GetTopicOfLectures(string id)
        {
            var linq = from t in connect.TopicOfLectures
                       join p in connect.PointTables on t.IdP equals p.IdP
                       where t.IdLe == id
                       select new TopicLecuter
                       {
                           IdTp = t.IdTp,
                           Name = t.Name,
                           NameP = p.NameP,
                           DateSt = (DateTime)t.DateSt,
                           Expense = t.Expense,
                           Times = (int)t.Times,
                           Status = (int)t.Status,
                           Process = connect.ProgressLes.Where(x => x.IdTp == t.IdTp).OrderByDescending(x=>x.Date).FirstOrDefault().Status

                       };
            linq.OrderByDescending(x => x.DateSt);
            return linq.ToList();
            
        }
        public detailTopic findTopic(string id)
        {
            var linq = from t in connect.TopicOfLectures join p in connect.PointTables
                       on t.IdP equals p.IdP
                       where t.IdTp == id
                       select new detailTopic
                       {
                           IdTp = t.IdTp,
                           Name = t.Name,
                           name = p.NameP,
                           DateSt = t.DateSt,
                           Status = t.Status,
                           Expense = t.Expense,
                           Times = (int)t.Times

                       };

            return linq.FirstOrDefault();
        }
        public List<ProgressLe> getProcessbyId(string id)
        {
            return connect.ProgressLes.Where(x => x.IdTp == id).ToList();
        }
    }
   
}
