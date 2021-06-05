using DataContext.DataTable;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataContext.DataMethod
{
    public class TopicStdSQL
    {
        DataConnect connect;
        public TopicStdSQL()
        {
            connect = new DataConnect();
        }
        public int getLastTopicStd(string idp)
        {
            var get = connect.TopicOfStudents.Where(x => x.IdP == idp).OrderByDescending(x => x.IdTp).FirstOrDefault();
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
        public bool AddTopicStd(TopicSt st, string id)
        {

            string input = st.DateSt.ToShortDateString();
            string[] arr = input.Split('/');
            Array.Reverse(arr);
            string date = string.Join("/", arr);
            TopicOfStudent student = new TopicOfStudent();
            student.IdTp = id;
            student.Name = st.Name;
            student.Target = st.Target;
            student.Content = st.Content;
            student.NameSt = st.NameSt;
            student.IdSV = st.IdSV;
            student.IdP = st.IdP;
            student.Email = st.Email;
            student.DateSt = (DateTime)DateTime.ParseExact(date, "yyyy/MM/dd", null);
            student.Times = st.Times;
            try
            {
                connect.TopicOfStudents.Add(student);
                connect.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
