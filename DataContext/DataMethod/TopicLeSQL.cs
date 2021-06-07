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
        // get list topic
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
        //get list by idle
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
                           Process = connect.ProgressLes.Where(x => x.IdTp == t.IdTp).OrderByDescending(x => x.Date).FirstOrDefault().Status

                       };
            linq.OrderByDescending(x => x.DateSt);
            return linq.ToList();





        }
        //find by id of idle
        public detailTopic findTopic(string id)
        {
            var linq = from t in connect.TopicOfLectures
                       join p in connect.PointTables
                       on t.IdP equals p.IdP
                       where t.IdTp == id
                       select new detailTopic
                       {
                           IdTp = t.IdTp,
                           Name = t.Name,
                           name = p.NameP,
                           Target = t.Target,
                           Content = t.Content,
                           DateSt = t.DateSt,
                           Status = t.Status,
                           Expense = t.Expense,
                           Times = (int)t.Times

                       };

            return linq.FirstOrDefault();
        }
        // get qua trinh thực hien by id
        public List<ProgressLe> getProcessbyId(string id)
        {
            return connect.ProgressLes.Where(x => x.IdTp == id).OrderByDescending(x=>x.Date).ToList();
        }
        // get tp
        public TopicOfLecture getTopic(string id)
        {
            return connect.TopicOfLectures.Where(x => x.IdTp == id).FirstOrDefault();
        }
        // get last id by idp
        public int getLastId(string idp)
        {
            var get = connect.TopicOfLectures.Where(x => x.IdP == idp).OrderByDescending(y => y.IdTp).FirstOrDefault();
            if (get == null)
            {
                int id;
                return id = 1;
            }
            else
            {
                string[] str = get.IdP.Split('-');
                int id = (int.Parse(str[str.Length - 1])) + 1;
                return id;
            }
        }
        //insert new data
        public bool create(TopicmdLe topicmd, string id, string idLe)
        {

            try
            {
                string input = topicmd.DateSt.ToShortDateString();
                string[] arr = input.Split('/');
                Array.Reverse(arr);
                string date = string.Join("/", arr);
                TopicOfLecture lecture = new TopicOfLecture();
                lecture.IdTp = id;
                lecture.Name = topicmd.Name;
                lecture.IdP = topicmd.IdP;
                lecture.IdLe = idLe;
                lecture.Target = topicmd.Target;
                lecture.Content = topicmd.Content;
                lecture.DateSt = (DateTime)DateTime.ParseExact(date, "yyyy/MM/dd", null);
                lecture.Expense = topicmd.Expense;
                connect.TopicOfLectures.Add(lecture);
                connect.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpProg(ProgressLe progress)
        {
            try {
                connect.ProgressLes.Add(progress);
                connect.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }

}
