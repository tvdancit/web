using DataContext.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.DataMethod
{
    public class StatementSQL
    {
        DataConnect connect = null;
        public StatementSQL()
        {
            connect = new DataConnect();
        }
        public List<Statement> GetStatements()
        {
            return connect.Statements.OrderByDescending(x => x.DateRp).ToList();
        }
        public List<DetailStatementLe> GetDetailsById(long id)
        {
            return connect.DetailStatementLes.Where(m => m.IdSt == id).ToList();
        }
    }
}
