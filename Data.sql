Create Database KPCOSDB
GO
USE KPCOSDB
GO

create table ComponentType
(
    ID   int identity
        primary key,
    Name nvarchar(255) not null
)
go

create table Component
(
    ID              int identity
        primary key,
    Decription      nvarchar(max),
    Name            nvarchar(255)  not null,
    PricePerItem    decimal(10, 2) not null,
    ComponentTypeID int            not null
        references ComponentType,
    Image           nvarchar(max)
)
go

create table Discount
(
    ID                 int identity
        primary key,
    FieldOnDiscount    nvarchar(255),
    DiscountAmount     decimal(10, 2),
    MinRequireDiscount decimal(10, 2),
    MaxTotalDiscount   decimal(10, 2),
    StartTime          datetime,
    FinishTime         datetime,
    Amount             decimal(10, 2),
    RemainingAmount    decimal(10, 2)
)
go

create table Role
(
    ID   int identity
        primary key,
    Type nvarchar(20)
)
go

create table Account
(
    ID       int identity
        primary key,
    UserName nvarchar(20) not null
        unique,
    Password nvarchar(20) not null,
    RoleID   int          not null
        references Role,
    Status   bit          not null
)
go

create table DiscountPound
(
    DiscouID  int            not null
        references Discount,
    AccountID int            not null
        references Account,
    Amount    decimal(10, 2) not null,
    primary key (DiscouID, AccountID)
)
go

create table [Order]
(
    ID         int identity
        primary key,
    CreateOn   datetime       not null,
    AccountID  int            not null
        references Account,
    Status     nvarchar(50)   not null,
    DiscouID   int
        references Discount,
    TotalMoney decimal(10, 2) not null
)
go

create table Pond
(
    ID          int identity
        primary key,
    PondName    nvarchar(255) not null,
    Decription  nvarchar(max),
    PondDepth   decimal(10, 2),
    Area        decimal(10, 2),
    Location    nvarchar(255),
    Shape       nvarchar(255),
    AccountID   int           not null
        references Account,
    DesignImage nvarchar(1000) default NULL
)
go

create table PondComponent
(
    ComponentID int            not null
        references Component,
    PondID      int            not null
        references Pond,
    Amount      decimal(10, 2) not null,
    primary key (ComponentID, PondID)
)
go

create table ServiceType
(
    ID       int           not null
        primary key,
    TypeName nvarchar(255) not null
)
go

create table Service
(
    ID            int identity
        primary key,
    ServiceTypeID int            not null
        references ServiceType,
    Name          nvarchar(255)  not null,
    Decription    nvarchar(max),
    PricePerM2    decimal(10, 2) not null
)
go

create table OrderItem
(
    ID         int identity
        primary key,
    ServiceID  int            not null
        references Service,
    OrderID    int            not null
        references [Order],
    PondID     int
        references Pond,
    TotalPrice decimal(10, 2) not null,
    Status     nvarchar(50)
)
go

create table Rating
(
    RatingID    int identity
        primary key,
    Image       nvarchar(max),
    Title       nvarchar(255),
    Content     nvarchar(max),
    Star        int,
    CreateOn    datetime,
    AccountID   int not null
        references Account,
    OrderItemID int not null
        references OrderItem
)
go

create table UserProfile
(
    UserID    int identity
        primary key,
    LastName  nvarchar(255) not null,
    FirstName nvarchar(255) not null,
    Phone     nvarchar(20),
    Birthday  date,
    Gender    varchar(6),
    Email     nvarchar(255)
        unique,
    AccountID int           not null
        references Account
)
go

