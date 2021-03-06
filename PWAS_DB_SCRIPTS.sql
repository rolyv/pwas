USE [PWAS_DB]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/22/2009 15:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleID] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nchar](25) NOT NULL,
	[role_desc] [text] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrintRun]    Script Date: 11/22/2009 15:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrintRun](
	[runID] [int] IDENTITY(1,1) NOT NULL,
	[height] [float] NOT NULL,
	[width] [float] NOT NULL,
	[quantity] [int] NOT NULL,
	[stock_finish] [nchar](30) NOT NULL,
	[stock_weight] [nchar](30) NOT NULL,
 CONSTRAINT [PK_PrintRun] PRIMARY KEY CLUSTERED 
(
	[runID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/22/2009 15:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userID] [int] IDENTITY(1000,1) NOT NULL,
	[firstName] [nchar](25) NOT NULL,
	[lastName] [nchar](30) NOT NULL,
	[company] [nchar](20) NULL,
	[email] [nchar](50) NOT NULL,
	[homePhone] [nchar](12) NOT NULL,
	[otherPhone] [nchar](12) NULL,
	[s_address1] [nchar](50) NOT NULL,
	[s_address2] [nchar](50) NULL,
	[s_city] [nchar](30) NOT NULL,
	[s_state] [nchar](2) NOT NULL,
	[s_zip] [nchar](5) NOT NULL,
	[cc_num] [nchar](20) NULL,
	[cc_type] [nchar](2) NULL,
	[exp_date] [nchar](6) NULL,
	[b_address1] [nchar](50) NOT NULL,
	[b_address2] [nchar](50) NULL,
	[b_city] [nchar](30) NOT NULL,
	[b_state] [nchar](2) NOT NULL,
	[b_zip] [nchar](5) NOT NULL,
	[roleID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 11/22/2009 15:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[permissionID] [int] IDENTITY(1,1) NOT NULL,
	[roleID] [int] NOT NULL,
	[object] [nchar](5) NOT NULL,
	[obj_update] [int] NOT NULL,
	[obj_view] [int] NOT NULL,
	[obj_create] [int] NOT NULL,
	[obj_delete] [int] NOT NULL,
 CONSTRAINT [PK_RolePermission\] PRIMARY KEY CLUSTERED 
(
	[permissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/22/2009 15:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderID] [int] NOT NULL,
	[userID] [int] NOT NULL,
	[runID] [int] NULL,
	[job_name] [nchar](50) NOT NULL,
	[width] [float] NOT NULL,
	[height] [float] NOT NULL,
	[quantity] [int] NOT NULL,
	[stock_finish] [nchar](30) NOT NULL,
	[stock_weight] [nchar](30) NOT NULL,
	[two_sided] [bit] NOT NULL,
	[folded] [bit] NOT NULL,
	[ship] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_User_roleID]    Script Date: 11/22/2009 15:46:01 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_roleID]  DEFAULT ((1)) FOR [roleID]
GO
/****** Object:  Check [CK_RolePermission]    Script Date: 11/22/2009 15:46:01 ******/
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [CK_RolePermission] CHECK  (([obj_update]>=(0) AND [obj_update]<(3)))
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [CK_RolePermission]
GO
/****** Object:  ForeignKey [FK_Order_PrintRun]    Script Date: 11/22/2009 15:46:01 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_PrintRun] FOREIGN KEY([runID])
REFERENCES [dbo].[PrintRun] ([runID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_PrintRun]
GO
/****** Object:  ForeignKey [FK_Order_User]    Script Date: 11/22/2009 15:46:01 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
/****** Object:  ForeignKey [FK_RolePermission\_Role]    Script Date: 11/22/2009 15:46:01 ******/
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission\_Role] FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([roleID])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission\_Role]
GO
/****** Object:  ForeignKey [FK_User_Role]    Script Date: 11/22/2009 15:46:01 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([roleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
