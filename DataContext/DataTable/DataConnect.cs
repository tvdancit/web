using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataContext.DataTable
{
    public partial class DataConnect : DbContext
    {
        public DataConnect()
            : base("name=DataConnect")
        {
        }

        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DetailNotifi> DetailNotifis { get; set; }
        public virtual DbSet<DetailStatementLe> DetailStatementLes { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PointTable> PointTables { get; set; }
        public virtual DbSet<ProgressLe> ProgressLes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Statement> Statements { get; set; }
        public virtual DbSet<TopicOfLecture> TopicOfLectures { get; set; }
        public virtual DbSet<TopicOfStudent> TopicOfStudents { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.IdKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<DetailStatementLe>()
                .Property(e => e.IdTp)
                .IsUnicode(false);

            modelBuilder.Entity<Information>()
                .Property(e => e.IdLe)
                .IsUnicode(false);

            modelBuilder.Entity<Information>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Information>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Information>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Information>()
                .Property(e => e.IdKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.MetaTile)
                .IsUnicode(false);

            modelBuilder.Entity<PointTable>()
                .Property(e => e.IdP)
                .IsUnicode(false);

            modelBuilder.Entity<PointTable>()
                .Property(e => e.IdTy)
                .IsUnicode(false);

            modelBuilder.Entity<ProgressLe>()
                .Property(e => e.IdTp)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfLecture>()
                .Property(e => e.IdTp)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfLecture>()
                .Property(e => e.IdLe)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfLecture>()
                .Property(e => e.IdP)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfStudent>()
                .Property(e => e.IdTp)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfStudent>()
                .Property(e => e.IdSV)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfStudent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TopicOfStudent>()
                .Property(e => e.IdP)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.IdTy)
                .IsUnicode(false);
        }
    }
}
