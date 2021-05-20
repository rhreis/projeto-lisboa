
CREATE TABLE Items (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [Types](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [Properties](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [TypePropertySet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaTypeId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_TypePropertySet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TypePropertySet]  WITH CHECK ADD  CONSTRAINT [FK_TypePropertySet_Properties] FOREIGN KEY([PropertyId])
REFERENCES [Properties] ([Id])
GO

ALTER TABLE [TypePropertySet] CHECK CONSTRAINT [FK_TypePropertySet_Properties]
GO

ALTER TABLE [TypePropertySet]  WITH CHECK ADD  CONSTRAINT [FK_TypePropertySet_Types] FOREIGN KEY([MediaTypeId])
REFERENCES [Types] ([Id])
GO

ALTER TABLE [TypePropertySet] CHECK CONSTRAINT [FK_TypePropertySet_Types]
GO

CREATE TABLE [ItemPhotos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[TypeId] [int] NOT NULL,
	[FileName] [nvarchar](50) NULL,
	[Position] [int] NULL,
	[Alt] [nvarchar](500) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ItemPhotos_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ItemPhotos] ADD  CONSTRAINT [DF_ItemPhotos_Active]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [ItemPhotos]  WITH CHECK ADD  CONSTRAINT [FK_ItemPhotos_Items] FOREIGN KEY([ItemId])
REFERENCES [Items] ([Id])
GO

ALTER TABLE [ItemPhotos] CHECK CONSTRAINT [FK_ItemPhotos_Items]
GO

ALTER TABLE [ItemPhotos]  WITH CHECK ADD  CONSTRAINT [FK_ItemPhotos_Types] FOREIGN KEY([TypeId])
REFERENCES [Types] ([Id])
GO

ALTER TABLE [ItemPhotos] CHECK CONSTRAINT [FK_ItemPhotos_Types]
GO

CREATE TABLE [ItemPhotoPropertySet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemPhotoId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemPhotoPropertySet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ItemPhotoPropertySet]  WITH CHECK ADD  CONSTRAINT [FK_ItemPhotoPropertySet_ItemPhotoPropertySet] FOREIGN KEY([PropertyId])
REFERENCES [Properties] ([Id])
GO

ALTER TABLE [ItemPhotoPropertySet] CHECK CONSTRAINT [FK_ItemPhotoPropertySet_ItemPhotoPropertySet]
GO

ALTER TABLE [ItemPhotoPropertySet]  WITH NOCHECK ADD  CONSTRAINT [FK_ItemPhotoPropertySet_ItemPhotos] FOREIGN KEY([ItemPhotoId])
REFERENCES [ItemPhotos] ([Id])
GO

ALTER TABLE [ItemPhotoPropertySet] NOCHECK CONSTRAINT [FK_ItemPhotoPropertySet_ItemPhotos]
GO


INSERT INTO Items (Name) VALUES ('Engagement ring')
INSERT INTO Items (Name) VALUES ('Wedding ring')

INSERT INTO Types (Id, Name) VALUES (1, 'Photo')
INSERT INTO Types (Id, Name) VALUES (2, 'Thumb')

INSERT INTO Properties (Id, Name) VALUES (1, 'Metal')
INSERT INTO Properties (Id, Name) VALUES (2, 'Shape')

INSERT INTO TypePropertySet (MediaTypeId, PropertyId) VALUES (1, 1)
INSERT INTO TypePropertySet (MediaTypeId, PropertyId) VALUES (1, 2)
INSERT INTO TypePropertySet (MediaTypeId, PropertyId) VALUES (2, 1)
INSERT INTO TypePropertySet (MediaTypeId, PropertyId) VALUES (2, 2)

INSERT INTO ItemPhotos (ItemId, TypeId, FileName, Position, CreatedAt, IsActive) VALUES (1, 1, 'Photo1.jpg', 1, GETDATE(), 1)
INSERT INTO ItemPhotos (ItemId, TypeId, FileName, Position, CreatedAt, IsActive) VALUES (1, 1, 'Photo2.jpg', 2, GETDATE(), 1)
INSERT INTO ItemPhotos (ItemId, TypeId, FileName, Position, CreatedAt, IsActive) VALUES (1, 2, 'Thumb1.jpg', 1, GETDATE(), 1)
INSERT INTO ItemPhotos (ItemId, TypeId, FileName, Position, CreatedAt, IsActive) VALUES (1, 2, 'Thumb2.jpg', 2, GETDATE(), 1)

INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (1, 1, 'Yellow Gold')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (1, 2, 'Round')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (2, 1, 'Yellow Gold')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (2, 2, 'Cushion')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (3, 1, 'Rose Gold')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (3, 2, 'Round')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (4, 1, 'Rose Gold')
INSERT INTO ItemPhotoPropertySet (ItemPhotoId, PropertyId, Value) VALUES (4, 2, 'Cushion')