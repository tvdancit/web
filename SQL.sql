create  database nckh_dhdn
go 
use nckh_dhdn
create table Account
(
UserName varchar(20) primary key,
PassWord varchar(32),
Access int
)
go 
create table Department
(
IdKhoa varchar(10) primary key,
Name text
)
go
create table Notifications
(IdNo int identity primary key,
DateCreat date default getdate(),
PersonCreat ntext default N'Phòng Nghiên Cứu Khoa Học',
Title ntext,
MetaTitle text,
Content ntext,
FileName text
)
go
create table DetailNotifi
(
Id int identity primary key,
IdNo int,
DetalContent text
foreign key (IdNo) references Notifications(IdNo)
)
go
create table Statements
(
IdSt int Identity  primary key,
DateRp date,
Status ntext
)
go


go
create table Information
(IdLe varchar(10) primary key,
Name nvarchar(50),
UserName varchar(20),
Email varchar(30),
Phone char(10),
IdKhoa varchar(10)
foreign key (UserName) references Account(UserName),
foreign key (IdKhoa) references Department(IdKhoa)
)
go
 create table Types
 (IdTy varchar(10) primary key,
 Name ntext
 )
 go 
 create table PointTable
 (
 IdP varchar(10) primary key,
 IdTy varchar(10),
 NameP ntext,
 File ntext 
 foreign key (IdTy) references Types(IdTy)
 )
 go 
 create table TopicOfLecture
 (
 IdTp varchar(10) primary key,
 Name ntext,
 IdLe varchar(10),
 IdP varchar(10),
 DateSt date,
 Times int,
 Expense float,
 Status ntext default 'Pending', --1 Pending, 2 Accept, 3 Reject
 Progress ntext
 foreign key (IdLe) references Information(IdLe),
 foreign key (IdP) references PointTable(IdP)
 )
 go
 create table DetailStatementLe
(
IdDtST int  identity primary key,
IdSt int,
IdTp varchar(10),
Times int ,-- lần báo cáo
Status ntext default N'Chưa báo cáo' -- 
foreign key (IdTP) references  TopicOfLecture(IdTp),
foreign key (IdSt) references   Statements(IdSt)

)
 go
 create table  ProgressLe
 (
 IdPr int identity primary key,
 IdTp varchar(10),
 Date date,
 Status ntext
 foreign key (IdTp) references TopicOfLecture(IdTp)
 )

 go
 create table TopicOfStudent
 (
 IdTp varchar(10) primary key,
 Name ntext,
 NameSt ntext,
 IdSV varchar(12),
 Emmail varchar(30),
 IdP varchar(10),
 DateSt date,
 Times int,
 Expense float,
 Status Text default N'Đang Chờ',
 Progress text
 foreign key (IdP) references PointTable(IdP)
 )
 go
  create table  ProgressSt
 (
 IdPr int identity primary key,
 IdTp varchar(10),
 Date date,
 Status ntext
 foreign key (IdTp) references TopicOfStudent(IdTp)
 )
 go
  create table DetailStatementSt
(
IdDtST int  identity primary key,
IdSt int,
IdTp varchar(10),
Times int, -- lần báo cáo
Status ntext default N'Chưa báo cáo' -- 
foreign key (IdTP) references TopicOfStudent(IdTp),
foreign key (IdSt) references   Statements(IdSt)

)

go
 insert into dbo.Account
 values
 ('admin','admin',0),
 ('pnckh','pnckh',1),
 ('gvttd0192','yeuem',2)
 go
 create proc ListNotification
 as 
	select * from dbo.Notifications order by DateCreat desc
 go
 create proc ListDetailNotifi @IdNo int

 as 
	select N.IdNo,N.DateCreat,PersonCreat, Title, Content, FileName,DetalContent from dbo.DetailNotifi,dbo.Notifications as N where dbo.DetailNotifi.IdNo= N.IdNo and N.IdNo=+@IdNo
go


select * from dbo.Types,dbo.PointTable

create proc getListDataTable
 as 
	select IdP,t.Name,p.NameP from dbo.PointTable as p,dbo.Types as t where t.IdTy=p.IdTy
go
create proc getAllTopic
as
select t.IdP,t.Name,i.Name,p.NameP,DateSt,Times,Status,Expense from dbo.TopicOfLecture as t, dbo.Information as i, dbo.PointTable as p where t.IdLe= i.IdLe and t.IdP=p.IdP
go