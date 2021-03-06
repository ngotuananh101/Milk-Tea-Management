USE [MilkTea]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[EmployeeDob] [nvarchar](50) NOT NULL,
	[EmployeeEmail] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[ManagerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[ManagerId] [int] IDENTITY(1,1) NOT NULL,
	[ManagerName] [nvarchar](50) NOT NULL,
	[ManagerDob] [nvarchar](50) NOT NULL,
	[ManagerEmail] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](10) NOT NULL,
	[Total] [money] NOT NULL,
	[DateCreate] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersDetail]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetail](
	[OrderId] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Origin] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/15/2021 1:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Username], [Password], [RoleId], [UserId]) VALUES (N'user01', N'123', 2, 1)
INSERT [dbo].[Account] ([Username], [Password], [RoleId], [UserId]) VALUES (N'admin01', N'123', 1, 2)
INSERT [dbo].[Account] ([Username], [Password], [RoleId], [UserId]) VALUES (N'admin02', N'123', 1, 3)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Milk Teas')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Teas')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Foods')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Fruits')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'Others')
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeeDob], [EmployeeEmail], [Phone], [Address], [Gender], [ManagerId], [UserId]) VALUES (1, N'Nguyen Van A', N'2000', N'kxs@gmail.com', N'092222222', N'Ha Noi', 1, 1, 1)
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeeDob], [EmployeeEmail], [Phone], [Address], [Gender], [ManagerId], [UserId]) VALUES (2, N'Le Thi C', N'2000', N'gga@gmail.com', N'091234567', N'Lang Son', 0, 1, 1)
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeeDob], [EmployeeEmail], [Phone], [Address], [Gender], [ManagerId], [UserId]) VALUES (3, N'Nguyen Trung Kien', N'1999', N'he@gmail.com', N'091213121', N'Lao Cai', 1, 1, 1)
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeeDob], [EmployeeEmail], [Phone], [Address], [Gender], [ManagerId], [UserId]) VALUES (4, N'Ong Cao Thang', N'1983', N'mn@gmail.com', N'099999999', N'Cao Bang', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Manager] ON 

INSERT [dbo].[Manager] ([ManagerId], [ManagerName], [ManagerDob], [ManagerEmail], [Phone], [Address], [Gender], [UserId]) VALUES (1, N'TUan Anh', N'2000', N'nta@gmail.com', N'0396902252', N'HN', 1, 1)
SET IDENTITY_INSERT [dbo].[Manager] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [EmployeeId], [Total], [DateCreate]) VALUES (11, N'1', 145000.0000, CAST(N'2021-11-15' AS Date))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[OrdersDetail] ([OrderId], [ProductName], [Quantity], [Price]) VALUES (11, N'10', 2, 20000.0000)
INSERT [dbo].[OrdersDetail] ([OrderId], [ProductName], [Quantity], [Price]) VALUES (11, N'11', 2, 20000.0000)
INSERT [dbo].[OrdersDetail] ([OrderId], [ProductName], [Quantity], [Price]) VALUES (11, N'1', 1, 15000.0000)
INSERT [dbo].[OrdersDetail] ([OrderId], [ProductName], [Quantity], [Price]) VALUES (11, N'12', 1, 25000.0000)
INSERT [dbo].[OrdersDetail] ([OrderId], [ProductName], [Quantity], [Price]) VALUES (11, N'13', 1, 25000.0000)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'1', N'Apple', 10, 15000.0000, N'US', 4, N'C:\Users\ngotu\Downloads\General\mau-lo-go-tra-sua-cute.jpg')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'10', N'Tra Vai', 10, 20000.0000, N'VN', 2, N'C:\Users\ngotu\Downloads\General\mau-lo-go-tra-sua-cute.jpg')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'11', N'Tra Chanh', 15, 20000.0000, N'VN', 2, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'12', N'Tra O Long', 15, 25000.0000, N'VN', 2, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'13', N'Tra Thai Tu ', 15, 25000.0000, N'VN', 2, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'14', N'Pizza', 15, 100000.0000, N'US', 3, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'15', N'Xuc Xich', 15, 10000.0000, N'GER', 3, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'16', N'Hamburger', 15, 50000.0000, N'VN', 3, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'17', N'Banh My', 15, 25000.0000, N'VN', 3, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'18', N'Ca Phe', 15, 25000.0000, N'VN', 4, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'2', N'Mango', 15, 20000.0000, N'US', 4, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'3', N'Orange', 15, 15000.0000, N'US', 4, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'4', N'Tran Chau Duong Den', 15, 60000.0000, N'VN', 1, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'5', N'Tra Hong', 15, 30000.0000, N'VN', 1, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'6', N'Tra Dau', 15, 35000.0000, N'VN', 1, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'7', N'Tra Sua Oreo', 15, 70000.0000, N'VN', 1, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'8', N'Tra Sua Matcha', 15, 35000.0000, N'VN', 1, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [Price], [Origin], [CategoryId], [Image]) VALUES (N'9', N'Tra Dao', 15, 20000.0000, N'VN', 2, N'C:\Users\ngotu\Downloads\0fce5c73752bf2850f9481f4b66abc8c.png')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Manager')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Employee')
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Account] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([UserId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Account]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Manager] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Manager] ([ManagerId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Manager]
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager_Account] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([UserId])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager_Account]
GO
ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetail_Orders1] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrdersDetail] CHECK CONSTRAINT [FK_OrdersDetail_Orders1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
