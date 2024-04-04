create database newaspdb
go
use newaspdb
go
create table Product
(
Id int primary key identity,
Name varchar(50),
Price decimal,
ImagePath varchar(200),
CreatedDate datetime
)
go
create proc uspCreateProduct
@Name varchar(50), @Price decimal, @Imagepath varchar(200),
@Status bit output
as
begin
	begin try
	insert into Product values (@Name, @Price, @Imagepath, getdate())
	set @Status = 1
	end try
	begin catch
	set @Status = 0
	end catch

end