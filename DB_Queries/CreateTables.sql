CREATE TABLE [dbo].[Address](
	Id INT IDENTITY(1,1) NOT NULL,
	Country nvarchar(100) NOT NULL,
	Region nvarchar(100) NOT NULL,
	City nvarchar(100) NOT NULL,
	Street nvarchar(100),
	Building INT,
	Latitude Decimal(8,6),
	Longitude Decimal(9,6),
	
	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [ix_person] ON [dbo].[Address] 
(
            [Country] ASC,
            [Region] ASC,
            [City] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE TABLE [dbo].[Role](
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	
	CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AppUser](
	Id INT IDENTITY(1,1) NOT NULL,
	RoleId INT NOT NULL,
	[Name] NVARCHAR(100),
	[SurName] NVARCHAR(100),
	[Email] NVARCHAR(100),
	[PhoneNumber] NVARCHAR(100),
	[Password] NVARCHAR(100),

	FOREIGN KEY (RoleId)  REFERENCES [dbo].[Role](Id),

	CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

--ALTER TABLE AppUser
--DROP COLUMN RoleId
--ALTER TABLE Lot
--ADD RoleId INT FOREIGN KEY REFERENCES [dbo].[Role](Id)

CREATE NONCLUSTERED INDEX [ix_AppUser] ON [dbo].[AppUser] 
(
            [Name] ASC,
            [SurName] ASC,
			[Email] ASC,
            [Password] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE TABLE [dbo].[LotStatusType](
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL
	
	CONSTRAINT [PK_LotStatusType] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Lot](
	Id INT IDENTITY(1,1) NOT NULL,
	AddressId INT,
	OwnerId INT,
	PublicationDate DATE NOT NULL,
	LotStatusId INT NOT NULL,
	[Square] REAL,
	--ImageUrl nvarchar(500) NOT NULL,
	[Description] TEXT,
	FOREIGN KEY (AddressId)  REFERENCES [dbo].[Address](Id),
	FOREIGN KEY (OwnerId)  REFERENCES [dbo].[AppUser](Id),
	FOREIGN KEY (LotStatusId)  REFERENCES [dbo].[LotStatusType](Id),
	
	CONSTRAINT [PK_Lot] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Image](
	Id INT IDENTITY(1,1) NOT NULL,
	LotId INT NOT NULL,
	[Name] nvarchar(100),
	ImageData VARBINARY(MAX) NOT NULL,

	FOREIGN KEY (LotId)  REFERENCES [dbo].[Lot](Id),
	
	CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


--ALTER TABLE [Image]
--DROP COLUMN [Name]

--ALTER TABLE Lot
--ADD LotStatusId INT FOREIGN KEY REFERENCES LotStatusType(Id)

--ALTER TABLE Lot
--ADD ImageUrl nvarchar(500)
	

--ALTER TABLE [dbo].[Lot]
--ADD [Square] REAL 


CREATE NONCLUSTERED INDEX [ix_LotPublicationDate] ON [dbo].[Lot] 
(
            [PublicationDate] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE TABLE [dbo].[PriceCoef](
	Id INT IDENTITY(1,1) NOT NULL,
	LotId INT NULL,
	DaysCount INT NOT NULL,
	[Value] SMALLMONEY NOT NULL,

	FOREIGN KEY(LotId) REFERENCES [dbo].[Lot](Id),
	
	CONSTRAINT [PK_PriceCoef] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [ix_ValuePriceCoef] ON [dbo].[PriceCoef] 
(
            [Value] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

--DROP INDEX [dbo].[PriceCoef].ix_ValuePriceCoef  

CREATE TABLE [dbo].[Land](
	Id INT IDENTITY(1,1) NOT NULL,
	LotId INT NULL,

	FOREIGN KEY(LotId) REFERENCES [dbo].[Lot](Id),

	CONSTRAINT [PK_Land] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE TABLE [dbo].[House](
	Id INT IDENTITY(1,1) NOT NULL,
	LotId INT NULL,
	Rooms TINYINT,
	[Storeys] TINYINT,
	Person TINYINT,
	Parking BIT,
	Furniture BIT,
	
	FOREIGN KEY(LotId) REFERENCES [dbo].[Lot](Id),

	CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

--ALTER TABLE House
--DROP COLUMN [Floor]

CREATE NONCLUSTERED INDEX [ix_RoomsHouse] ON [dbo].[House] 
(
            [Rooms] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [ix_StoreysHouse] ON [dbo].[House] 
(
            [Storeys] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [ix_PersonHouse] ON [dbo].[House] 
(
            [Person] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [ix_House] ON [dbo].[House] 
(
			[Rooms] ASC,
            [Floor] ASC,
			[Person] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

--DROP INDEX ix_House ON House

CREATE TABLE [dbo].[Bid](
	Id INT IDENTITY(1,1) NOT NULL,
	[Value] MONEY NOT NULL,
	BidderId INT NOT NULL,
	LotId INT NOT NULL,

	FOREIGN KEY(BidderId) REFERENCES [dbo].[AppUser](Id),
	FOREIGN KEY(LotId) REFERENCES [dbo].[Lot](Id),

	CONSTRAINT [PK_Bid] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SellingStatusType](
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [PK_SellingStatusType] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY] 
GO

CREATE TABLE [dbo].[Selling](
	Id INT IDENTITY(1,1) NOT NULL,
	LotId INT NOT NULL,
	ManagerId INT,
	BidWinnerId INT,
	SellingStatusId INT,
	MinPrice MONEY NULL,
	PriceBuyItNow MONEY NULL,
	
	FOREIGN KEY(LotId) REFERENCES [dbo].[Lot](Id),
	FOREIGN KEY(ManagerId) REFERENCES [dbo].[AppUser](Id),
	FOREIGN KEY(BidWinnerId) REFERENCES [dbo].[Bid](Id),
	FOREIGN KEY(SellingStatusId) REFERENCES [dbo].[SellingStatusType](Id),
	CONSTRAINT [PK_Selling] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [ix_MinPriceSelling] ON [dbo].[Selling] 
(
            [MinPrice] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

	
CREATE TABLE [dbo].[RentStatusType](
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	CONSTRAINT [PK_RentStatusType] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Rent](
	Id INT IDENTITY(1,1) NOT NULL,
	LotId INT NOT NULL,
	RentStatusId INT NOT NULL,
	CustomerId INT NOT NULL,
	ManagerId INT NOT NULL,
	BeginDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	Price MONEY,
	
	FOREIGN KEY(LotId) REFERENCES [dbo].[Lot](Id),
	FOREIGN KEY(RentStatusId) REFERENCES [dbo].[RentStatusType](Id),
	FOREIGN KEY(CustomerId) REFERENCES [dbo].[AppUser](Id),
	FOREIGN KEY(ManagerId) REFERENCES [dbo].[AppUser](Id),

	CONSTRAINT [PK_Rent] PRIMARY KEY CLUSTERED(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]
GO