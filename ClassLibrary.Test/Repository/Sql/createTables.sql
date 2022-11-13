create table Accounts (
	Id nvarchar(128) not null primary key, 
	Name nvarchar (max),
	Password nvarchar (max)
);
 
create table Products(
	Id nvarchar(128) not null primary key,
	[Name] nvarchar(max) null,
	CostPrice float not null,
	RetailPrice float not null,
	[RowVersion] rowversion not null
);
 
create table Orders(
	OrderId int identity(1,1) not null primary key,
	AccountId nvarchar(128) null,
	[Date] datetime2(7) not null,
	OrderStatus int not null
);
 
create table  LineItems(
	Id int identity(1,1) not null,
	OrderId int null,
	ProductId nvarchar(128) null,
	Quantity int not null
);

alter table LineItems add constraint c1 foreign key(OrderId) 
references Orders (OrderId);
alter table LineItems add constraint c2 foreign key(ProductId ) 
references Products (Id);
alter table Orders add constraint c3 foreign key(AccountId) 
references Accounts (Id);
