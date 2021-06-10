using DataContext.DataTable;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.DataMethod
{
    public class PointSQL
    {
        DataConnect connect;
        public PointSQL()
        {
            connect = new DataConnect();
        }
        public List<DataTable.Type> GetTypes()
        {

            return connect.Types.ToList();

        }
        public List<PointTable> GetPoints(string id = null)
        {
            connect.Configuration.ProxyCreationEnabled = false;
            if (id is null)
            {
                return connect.PointTables.ToList();
            }

            return connect.PointTables.Where(x => x.IdTy == id).ToList();
        }
        public List<DataPoint> GetPoints()
        {
            var linq = from p in connect.PointTables
                       join t in connect.Types
on p.IdTy equals t.IdTy
                       select new DataPoint
                       {
                           IdP = p.IdP,
                           Name = t.Name,
                           NameP = p.NameP
                       };
            return linq.ToList();
        }
        public List<DataTable.Type> getType()
        {
            return connect.Types.ToList();
        }
        public List<FileData> getFileList()
        {
            return connect.FileDatas.ToList();
        }
        public FileData getFile()
        {
            return connect.FileDatas.Where(x => x.sincedate <= DateTime.Now && x.todate >= DateTime.Now).OrderByDescending(y => y.sincedate).FirstOrDefault();
        }
        public void addFilePoint(FileData data)
        {

            connect.FileDatas.Add(data);
            connect.SaveChanges();

        }

    }
}
