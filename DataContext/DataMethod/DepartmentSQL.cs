using DataContext.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.DataMethod
{
    public class DepartmentSQL
    {
        DataConnect connect;
        public DepartmentSQL()
        {
            connect = new DataConnect();
        }
        public List<Department> GetDepartments()
        {
            return connect.Departments.ToList();
        }

    }
}
