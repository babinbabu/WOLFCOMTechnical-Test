CREATE DATABASE WOLFCOMTechnicalTest
GO
USE [WOLFCOMTechnicalTest]
GO
/****** Object:  Table [dbo].[PromoCodeDetails]    Script Date: 2/6/2019 12:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromoCodeDetails](
	[PromoCodeId] [bigint] IDENTITY(1,1) NOT NULL,
	[PromoCode] [nvarchar](50) NULL,
	[PromoCodeRule] [nvarchar](max) NULL,
	[PromoCodeDiscount] [nvarchar](max) NULL,
	[CanAvailWithoutPromoCode] [bit] NULL,
	[PromoCodeDescription] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_PromoCodeDetails] PRIMARY KEY CLUSTERED 
(
	[PromoCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PromoCodeDetails] ON 

INSERT [dbo].[PromoCodeDetails] ([PromoCodeId], [PromoCode], [PromoCodeRule], [PromoCodeDiscount], [CanAvailWithoutPromoCode], [PromoCodeDescription], [Status], [CreatedDate]) VALUES (1, N'DIS10', N'{Price}>=2000', N'{Price}*10/100', 1, N'Discount 10% when customer present coupon code "DIS10" or price is more/equal than 2000', 1, NULL)
INSERT [dbo].[PromoCodeDetails] ([PromoCodeId], [PromoCode], [PromoCodeRule], [PromoCodeDiscount], [CanAvailWithoutPromoCode], [PromoCodeDescription], [Status], [CreatedDate]) VALUES (2, N'STARCARD', N'{NoofCustomers}=2', N'{Price}*30/100', 0, N'Discount 30% when customer present coupon code "STARCARD" for 2 customers', 1, NULL)
INSERT [dbo].[PromoCodeDetails] ([PromoCodeId], [PromoCode], [PromoCodeRule], [PromoCodeDiscount], [CanAvailWithoutPromoCode], [PromoCodeDescription], [Status], [CreatedDate]) VALUES (3, N'STARCARD', N'{NoofCustomers}=4', N'{Price}/{NoofCustomers}', 0, N'Come 4 pay 3 when customer present coupon code "STARCARD"', 1, NULL)
INSERT [dbo].[PromoCodeDetails] ([PromoCodeId], [PromoCode], [PromoCodeRule], [PromoCodeDiscount], [CanAvailWithoutPromoCode], [PromoCodeDescription], [Status], [CreatedDate]) VALUES (4, NULL, N'{Price}>=2500', N'{Price}*25/100', 1, N'Discount 25% when price more/equal that 2500 baht.', 1, NULL)
INSERT [dbo].[PromoCodeDetails] ([PromoCodeId], [PromoCode], [PromoCodeRule], [PromoCodeDiscount], [CanAvailWithoutPromoCode], [PromoCodeDescription], [Status], [CreatedDate]) VALUES (5, N'DIS10', NULL, N'{Price}*10/100', 0, N'Discount 10% when customer present coupon code "DIS10" or price is more/equal than 2000', 1, NULL)
SET IDENTITY_INSERT [dbo].[PromoCodeDetails] OFF
