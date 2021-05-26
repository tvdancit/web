using DataContext.DataTable;
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
            if (id is null)
            {
                return connect.PointTables.ToList();
            }

            return connect.PointTables.Where(x => x.IdTy == id).ToList();
        }
    }
}
