Create Database [InventoryTest]

USE [InventoryTest]
GO
/****** Object:  Table [dbo].[MST_Category]    Script Date: 09-05-2021 15:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_Category](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[Created_On] [datetime] NULL,
	[Created_By] [int] NULL,
	[Modified_On] [datetime] NULL,
	[Modified_By] [int] NULL,
 CONSTRAINT [PK_MST_Category] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MST_Product]    Script Date: 09-05-2021 15:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Category_Id] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Weight] [nvarchar](50) NULL,
	[In_Box_Details] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[Created_On] [datetime] NULL,
	[Created_By] [int] NULL,
	[Modified_On] [datetime] NULL,
	[Modified_By] [int] NULL,
 CONSTRAINT [PK_MST_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MST_Product] ADD  CONSTRAINT [DF_MST_Product_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
