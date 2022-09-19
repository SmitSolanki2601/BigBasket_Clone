--USE [UserDB]
--GO

--/****** Object:  Table [dbo].[UsersRoles]    Script Date: 08-08-2022 14:02:24 ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TABLE [dbo].[UsersRoles](
--	[UserRoleId] [int] IDENTITY(1,1) ,
--	[RoleName] [varchar](10) NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[UserRoleId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]

--create database TrainingProjectDemo;

--use  [bigbasket-2406-smit]




Create table [Types](
	TypeID int identity primary key,
	TypeValue varchar(10),
	TypeAddedDate  datetime default GETDATE(),
	TypeModifiedDate  datetime default GETDATE()
)

Create Table [Objects] (
	ObjectID int identity primary key,
	TypeID int Foreign key references [Types](TypeID),
	ObjectValue varchar(10),
	ObjectAddedDate  datetime default GETDATE(),
	ObjectModifiedDate  datetime default GETDATE()
)

------------ USER REGISTER TABLE----------------
Create table Users (
	UserID int identity primary key,
	FirstName Varchar(10),
	LastName Varchar(20),
	GenderID int Foreign key references [Objects](ObjectID),  --GENDER
	PhoneNumber varchar(11) unique not null,
	Email varchar(30) not null unique,
	PasswordHash varbinary(8000) not null,
	PasswordSalt varbinary(8000) not null,
	UserRegisterDate datetime default GETDATE(),
	UserModifiedDate datetime default GETDATE(),
	ActiveFlag bit default 1
)
--{   "FirstName":"Sahil",
--"LastName":"Solanki",
--"PhoneNumber":"12345678",
--    "Email":"sal.s@gmail.com",
--    "password":"Smit2601"
--}


------------ USER ADDRESS TABLE----------------
Create Table Countries(
	CountryID int identity primary key,
	CountryName varchar(20),
	CountryAddedDate  datetime default GetDate(),
	CountryModifiedDate  datetime default GetDate()
)

Create Table Cities (
	CityID int identity primary key,
	CityName Varchar(20),
	CountryID int Foreign key references Countries(CountryID),
	CityAddedDate  datetime default GetDate(),
	CityModifiedDate datetime default GetDate()

)

Create Table UserAddress(
	AddressID int identity primary key,
	AddressLine varchar(40),
	CityID int Foreign Key references Cities(CityID),
	Zip int,
	UserAddressAddedDate datetime default GetDate(),
	UserAddressModifiedDate  datetime default GetDate()
)

------------ USER PROFILE TABLE----------------
Create Table UserProfiles
(
	ProfileID int identity primary key,
	UserID int foreign key references Users(UserID),
	ProfilePic varchar(max),
	Wallet smallmoney default 0,
	AddressID int foreign key references UserAddress(AddressID),
	ProfileUpdateDate datetime default GetDate(),
	ProfileModifiedDate  datetime default GetDate(),
	ActiveField bit default 1
)

------------ ADMIN TABLE----------------
Create table Admins (
	AdminID int identity primary key,
	FirstName Varchar(10),
	LastName Varchar(20),
	PhoneNumber varchar(11) unique not null,
	Email varchar(30) not null unique,
	GenderID int Foreign key references [Objects](ObjectID),   --FOR GENDER
	PasswordHash varbinary(8000) not null,
	PasswordSalt varbinary(8000) not null,
	AdminRegisterDate datetime default GETDATE(),
	AdminModifiedDate  datetime default GetDate(),
	ActiveField bit default 1
)

--insert into Admins values ('Yash','Manani','7622849030','yash.Manani@gmail.com',0x425C65DFB388164BD7FCABC833C4BE530D5BF20B5CBBB5AEFA7C28D0342A0FE9F555ACF3FBF7348C7D9A0A21FE7C4620C4458EF664CF0A743223F9185708C0CA,
--0x1A50024FC49BDBF97F3CBBC8F24CB0C702A731C7FB0738CAC8B6F525A69F1925C21AEA7B51E031EE88406C32A1865C1CF2CAA5FC2435E58017969D8ADAF725927FB40BA7CF1B4CB010C69E3B136FCB97691411BF2BEBC3DD228E883632707A334E55BC4517FB64189A5D3E5E1D6560D5855F4D8BA1B68D685A8A666F49AA8EA7,default)




-------------------PRODUCT TABLE------------------

Create Table Category(
	CategoryID  int identity primary key,
	CategoryName varchar(20),
	ParentID int foreign key references Category(CategoryID),
	CatAddedDate datetime default GetDate(),
	CatModifiedDate  datetime default GetDate(),
	level int,
	ActiveField bit default 1
)

--Create table Subcategory (
--	SubcategoryID int identity primary key,
--	SubcategoryName varchar(20),
--	CategoryID int foreign key references Category(CategoryID),
--	SubcatAddedDate datetime default GetDate(),
--	SubcatModifiedDate  datetime default GetDate(),
--	ActiveField bit default 1
--)

create table Brands(
	BrandID  int identity primary key,
	BrandName varchar(20),
	BrandAddedDate datetime default GetDate(),
	BrandModifiedDate  datetime default GetDate(),
	ActiveField bit default 1
)

Create Table Products (
	ProductID  int identity primary key,
	ProductName varchar(20),
	CategoryID int foreign key references Category(CategoryID),
	BrandID  int foreign key references Brands(BrandID),
	Price money not null,
	ProductUnitOfWeightID int Foreign key references [Objects](ObjectID),  -- FOR STATUS
	ProductAddedDate datetime default GetDate(),
	ProductModifiedDate  datetime default GetDate(),
	ActiveField bit default 1
)

Create table ProductDetails (
	ProductDetailsID int identity primary key,
	ProductID int foreign key references Products(ProductID),
	ProductDiscription varchar(50),
	ProductImgUrl nvarchar(max),
	ProductColour varchar(10),
	CountryOfOrigin varchar(20),
	StockCount int,
	Season varchar(10)
 )


Create Table Discounts ( 
	DiscountID int identity primary key,
	ProductID  int foreign key references Products(ProductID),
	DiscountAmount smallmoney,
	DiscountStartDate datetime default GetDate(),
	DiscountEndDate  datetime default GetDate(),
	DiscountAddedDate  datetime default GetDate(),
	DiscountsModifiedDate  datetime default GetDate(),
	ActiveField bit default 1
)

-------------------------- ORDER TABLES ----------------------

Create Table Orders (
	OrderID int identity primary key,
	UserID int foreign key references Users(UserID),
	OrderStatusID int Foreign key references [Objects](ObjectID),  -- FOR STATUS
	OrderAmount money,
	OrderDate datetime default GetDate(),
	TotalDiscountAmount smallmoney,
	PayableAmount money,
	PaymentMethod int Foreign key references [Objects](ObjectID),  -- FOR Payment Mode
	OrderModifiedDate datetime default GetDate(),
	ActiveFlag bit default 1
)

Create Table OrderItems (
	OrderItemID int identity primary key,
	OrderID int foreign key references Orders(OrderID),
	ProductID int foreign key references Products(ProductID),
	Qty int,
	TotalAmount smallmoney,
	OrderItemAddedDate datetime default Getdate(),
	OrderModifiedDate datetime default Getdate(),
	ActiveFlag bit default 1
	)



---------------------- UPI TABLES and PAYMENT TABLSE------------------

	Create Table Accounts (
		AccountID int identity primary key,
		AccountNumber varchar(12),
		AccountHolderName varchar(30),
		UserID int foreign key references Users(UserID),
		AccountAddedDate Datetime default GetDate(),
		AccountModifiedDate datetime default Getdate(),
		ActiveFlag bit default 1
	)

	Create table Upis (
		UpiID int identity Primary key,
		AccountID int foreign key references Accounts(AccountID),
		ActiveFlag bit default 1,
		UpiAddedDate datetime default GetDate(),
		UpiModifiedDate datetime default Getdate()
	)

	Create Table Payments (
		PaymentID int identity primary key,
		OrderID int foreign key references Orders(OrderID),
		PaymentDate datetime default GetDate(),
		UpiID int,
		PaymentsAddedDate datetime default Getdate(),
		PaymentsModifiedDate datetime default GetDate()
	)


--------------------------- CART TABLE -----------------------
Create table Carts (
	CartID int identity Primary key,
	UserID int foreign key references Users(UserID),
	CartCreateDate datetime default getDate(),
	CartModifiedDate datetime default GetDate()
)

Create Table CartDetails( 
	CartDetailsID  int identity Primary key,
	CartID int foreign key references Carts(CartID),
	ProductID int foreign key references Products(ProductID),
	Qty int,
	OrderID int foreign key references Orders(OrderID),
	SavedAmount int,
	TotalAmount int
)


Create table ErrorDetailsLog ( 
	ErrorID bigint identity Primary key,
	  	ClassName nvarchar(500),
        [Message] nvarchar(500),
        [Data] nvarchar(500),
        InnerException nvarchar(max),
        HelpURL nvarchar(500),
        StackTraceString nvarchar(max),
        RemoteStackTraceString nvarchar(max),
        RemoteStackIndex bigint,
        ExceptionMethod nvarchar(500),
        HResult bigint,
        [Source] nvarchar(500),
        WatsonBuckets nvarchar(500),
        ErrorDate datetime default Getdate(),
		ErrorResolvedDate datetime default GetDate()
)

------------ STORE PROCEDURE FOR Error Log -------------------

/****** Object:  StoredProcedure [dbo].[SPErrorDetails]    Script Date: 17-08-2022 12:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SPErrorDetails] @error Nvarchar(max)
As
Begin
INSERT INTO dbo.ErrorDetailsLog (ClassName, [Message], [Data], InnerException, HelpURL, StackTraceString, RemoteStackTraceString, RemoteStackIndex, ExceptionMethod, HResult, [Source], WatsonBuckets, ErrorDate)
    SELECT * FROM OPENJSON(@error)
    WITH
    (
        ClassName nvarchar(500),
        [Message] nvarchar(500),
        [Data] nvarchar(500),
        InnerException nvarchar(max),
        HelpURL nvarchar(500),
        StackTraceString nvarchar(max),
        RemoteStackTraceString nvarchar(max),
        RemoteStackIndex bigint,
        ExceptionMethod nvarchar(500),
        HResult bigint,
        [Source] nvarchar(500),
        WatsonBuckets nvarchar(500),
        ErrorDate datetime
    );


End