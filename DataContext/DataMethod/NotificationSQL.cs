using DataContext.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataContext.DataMethod
{
    public class NotificationSQL
    {
        DataConnect connect = null;
        //
        public NotificationSQL()
        {
            connect = new DataConnect();
        }
        // danh sach thong bao
        public List<Notification> getListNoti()
        {
            return connect.Notifications.OrderByDescending(x => x.DateCreat).ToList();
        }
        public List<Notification> NotificationById(long id)
        {
            return connect.Notifications.Where(x => x.IdNo == id).ToList();
        }
        public List<DetailNotifi> GetDetails(long id)
        {
            return connect.DetailNotifis.Where(x => x.IdNo == id).ToList();
        }
        public bool addNoti(Notification data)
        {
            data.DateCreat = DateTime.Now;
            data.PersonCreat = "Phòng Quản Lý Nghiên Cứu Khoa Học";
            data.Title.Trim();
            string tile = new Regex(@"\s\s+").Replace(data.Title, " ");
            data.Title = tile;
            string[] arrtile = tile.Split(' ');
            data.MetaTile = string.Join("-",arrtile);
            try
            {
                connect.Notifications.Add(data);

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
