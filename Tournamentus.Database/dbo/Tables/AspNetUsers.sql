create table dbo.AspNetUsers
(
    Id int identity(1,1) not null,
    FirstName nvarchar(16) not null,
	LastName nvarchar(32) not null,
	UserName nvarchar(256) null,
	NormalizedUserName nvarchar(256) null,
	Email nvarchar(256) null,
	NormalizedEmail nvarchar(256) null,
	EmailConfirmed bit not null,
	PasswordHash nvarchar(max) null,
	SecurityStamp nvarchar(max) null,
	ConcurrencyStamp nvarchar(max) null,
	PhoneNumber nvarchar(max) null,
	PhoneNumberConfirmed bit not null,
	TwoFactorEnabled bit not null,
	LockoutEnd datetimeoffset(7) null,
	LockoutEnabled bit not null,
	AccessFailedCount int not null
)
go

-- primary key
alter table dbo.AspNetUsers
    add constraint PK_AspNetUsers primary key clustered (Id)
go
