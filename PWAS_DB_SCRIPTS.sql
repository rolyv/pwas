USE [master]
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'C:\DOCUMENTS AND SETTINGS\ROLANDOV\MY DOCUMENTS\PWAS\SITE\APP_DATA\PWAS_DB.MDF')
BEGIN
CREATE DATABASE [PWAS_DB.MDF] ON  PRIMARY 
( NAME = N'PWAS_DB', FILENAME = N'C:\PWAS_DB.mdf' , SIZE = 1792KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PWAS_DB_log', FILENAME = N'C:\PWAS_DB_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
EXEC dbo.sp_dbcmptlevel @dbname=N'C:\PWAS_DB.MDF', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\PWAS_DB.mdf].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET ARITHABORT OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET  DISABLE_BROKER 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET  READ_WRITE 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET  MULTI_USER 
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [C:\PWAS_DB.mdf] SET DB_CHAINING OFF 
USE [C:\PWAS_DB.mdf]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintRun]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[roleID] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nchar](25) NOT NULL,
	[role_desc] [text] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RolePermission]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
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
	[roleID] [int] NOT NULL CONSTRAINT [DF_User_roleID]  DEFAULT ((1)),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Order_PrintRun]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_PrintRun] FOREIGN KEY([runID])
REFERENCES [dbo].[PrintRun] ([runID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_PrintRun]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Order_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RolePermission\_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission\_Role] FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([roleID])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission\_Role]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_RolePermission]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [CK_RolePermission] CHECK  (([obj_update]>=(0) AND [obj_update]<(3)))
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [CK_RolePermission]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([roleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
