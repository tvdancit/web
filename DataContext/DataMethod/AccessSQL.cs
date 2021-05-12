using DataContext.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.DataMethod
{
    public class AccesSQL
    {
        DataConnect connect;
        public AccesSQL()
        {
            connect = new DataConnect();
        }

        //
        public List<Access> ListAc()
        {
            return connect.Accesses.ToList();
        }
        //
        public int createAccess(Access access)
        {
            connect.Accesses.Add(access);
            return connect.SaveChanges();
        }
        public int getLastAcces()
        {
            var accses = connect.Accesses.OrderByDescending(x => x.id).First();
            int last = accses.id;
            return last;
        }
    }

}
