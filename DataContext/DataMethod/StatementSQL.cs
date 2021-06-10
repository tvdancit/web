using DataContext.DataTable;
using DataContext.ViewModel;
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
        public Statement GetStatementsId(long id)
        {
            return connect.Statements.Where(x=>x.IdSt==id).SingleOrDefault();
        }
        public List<StatementModel> GetDetailsById(long id)
        {
            var linq = from dt in connect.DetailStatementLes
                       where dt.IdSt == id
                       join tp in connect.TopicOfLectures on dt.IdTp equals tp.IdTp
                       join le in connect.Information on tp.IdLe equals le.IdLe 
                       select new StatementModel
                       {
                           IdDtST= dt.IdDtST,
                           Name = tp.Name,
                           NameLe = le.Name,
                           Status = dt.Status
                       };
            return linq.ToList();
        }
    }
}
