USE [master]
GO
/****** Object:  Database [controlsheet]    Script Date: 12/03/2020 20:43:14 ******/
CREATE DATABASE [controlsheet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'controlsheet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\controlsheet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'controlsheet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\controlsheet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [controlsheet] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [controlsheet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [controlsheet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [controlsheet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [controlsheet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [controlsheet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [controlsheet] SET ARITHABORT OFF 
GO
ALTER DATABASE [controlsheet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [controlsheet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [controlsheet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [controlsheet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [controlsheet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [controlsheet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [controlsheet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [controlsheet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [controlsheet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [controlsheet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [controlsheet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [controlsheet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [controlsheet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [controlsheet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [controlsheet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [controlsheet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [controlsheet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [controlsheet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [controlsheet] SET  MULTI_USER 
GO
ALTER DATABASE [controlsheet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [controlsheet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [controlsheet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [controlsheet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [controlsheet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [controlsheet] SET QUERY_STORE = OFF
GO
USE [controlsheet]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [controlsheet]
GO
/****** Object:  User [admin]    Script Date: 12/03/2020 20:43:14 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/03/2020 20:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[active] [bigint] NULL,
	[license] [int] NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionByProfile]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionByProfile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProfile] [int] NOT NULL,
	[viewName] [nvarchar](50) NULL,
 CONSTRAINT [PK_viewPermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_userGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyect]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[proyectName] [nvarchar](30) NULL,
	[typeRequirement] [int] NULL,
	[dateBegin] [datetime] NULL,
	[dateEnd] [datetime] NULL,
	[active] [bigint] NULL,
	[idUsers] [int] NULL,
	[idCompany] [int] NULL,
 CONSTRAINT [PK_Proyect] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProyectDetail]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProyectDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[moduleName] [nvarchar](50) NULL,
	[descriptions] [nvarchar](100) NULL,
	[hourEstimated] [float] NULL,
	[hourDedicated] [float] NULL,
	[dateCreate] [datetime] NULL,
	[dateEstimated] [datetime] NULL,
	[dateEnd] [datetime] NULL,
	[finaled] [bigint] NULL,
	[idProyect] [int] NOT NULL,
	[idUser] [int] NULL,
 CONSTRAINT [PK_ProyectDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCompany] [int] NOT NULL,
	[idUserProfile] [int] NOT NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[active] [bigint] NULL,
	[creationDate] [datetime] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PermissionByProfile]  WITH CHECK ADD  CONSTRAINT [FK_PermissionByProfile_Profile] FOREIGN KEY([idProfile])
REFERENCES [dbo].[Profiles] ([id])
GO
ALTER TABLE [dbo].[PermissionByProfile] CHECK CONSTRAINT [FK_PermissionByProfile_Profile]
GO
ALTER TABLE [dbo].[Proyect]  WITH CHECK ADD  CONSTRAINT [FK_Proyect_Company] FOREIGN KEY([idCompany])
REFERENCES [dbo].[Company] ([id])
GO
ALTER TABLE [dbo].[Proyect] CHECK CONSTRAINT [FK_Proyect_Company]
GO
ALTER TABLE [dbo].[Proyect]  WITH CHECK ADD  CONSTRAINT [FK_Proyect_Users] FOREIGN KEY([idUsers])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Proyect] CHECK CONSTRAINT [FK_Proyect_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_user_company] FOREIGN KEY([idCompany])
REFERENCES [dbo].[Company] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_user_company]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_user_userGroup] FOREIGN KEY([idUserProfile])
REFERENCES [dbo].[Profiles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_user_userGroup]
GO
/****** Object:  StoredProcedure [dbo].[SpChangePassword]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpChangePassword]
@idUser integer,
@pass  varchar(50)
AS
BEGIN
	
	UPDATE Users SET password = @pass WHERE id = @idUser
	 
END
GO
/****** Object:  StoredProcedure [dbo].[spCountLicense]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCountLicense]
	@idCompany integer
AS
BEGIN
	declare @count as integer;
	declare @result as integer;
	SELECT @count = count(*) FROM Users WHERE idCompany = @idCompany AND idUserProfile = 2
	if @count < 4
	BEGIN 
		SET @result = 1;
	END 
    ELSE
	BEGIN 
		SET @result = 0;
	END

	SELECT @result as result
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateNewProyect]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateNewProyect]
	@proyectName varchar(50), 
	@tipoReq integer,
	@idUser integer,
	@idCompany integer
AS
BEGIN

declare @id as int;

INSERT INTO proyect (proyectName, typeRequirement, dateBegin,active,idUsers, idCompany) VALUES(@proyectName,@tipoReq, GETDATE(), 1, @iduser,@idcompany)

SELECT @id = SCOPE_IDENTITY() 

END
GO
/****** Object:  StoredProcedure [dbo].[spCreateUserAdmin]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateUserAdmin]
@nameCompany as nvarchar(50),
@eMail as nvarchar(50),
@pass as nvarchar(50) 

AS
BEGIN
	
	declare @IdCompany as int;

	INSERT INTO company (name, active, license) VALUES (@nameCompany, 1, 5)

	select @IdCompany = scope_identity()
	
	INSERT INTO Users(idCompany, idUserProfile, email, password, active, creationDate) VALUES (@IdCompany,1, @eMail, @pass, 1,  getdate() )

END
GO
/****** Object:  StoredProcedure [dbo].[SpCreateUserOperator]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpCreateUserOperator]
@eMail varchar(50),
@pass varchar(50),
@idCompany integer
AS
BEGIN
	INSERT INTO Users
	(email, password, idCompany, idUserProfile, creationDate,active) 
	VALUES
	(@Email, @pass ,@idCompany , 2 , GETDATE(), 1)


END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProyect]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteProyect]
	-- Add the parameters for the stored procedure here
@idProyect as integer
AS
BEGIN

	BEGIN TRY
		BEGIN TRANSACTION
			
			delete ProyectDetail where idProyect = @idProyect
			delete Proyect where id = @idProyect
			SELECT 1 as result
		COMMIT
	END TRY
	BEGIN CATCH

		ROLLBACK

		SELECT 0 as result

	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteUser]
	@idUser as integer
AS
BEGIN
	delete Users where id = @idUser
END
GO
/****** Object:  StoredProcedure [dbo].[spEditProyectDetail]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spEditProyectDetail]
@idProyect as integer, 
@idProyectDetail as integer,
@moduleName as varchar(50),
@descriptions as varchar(100),
@dateEstimated as datetime = null,
@hourEstimated as float = 0,
@hourDedicated as float = 0,
@finalizado bit

AS
BEGIN
	


	IF @hourEstimated = 0
	BEGIN
		UPDATE ProyectDetail SET moduleName = @moduleName , descriptions = @descriptions, dateEstimated = @dateEstimated, 
		hourDedicated = @hourDedicated, finaled = @finalizado
		WHERE idProyect = @idProyect AND id = @idProyectDetail 

		IF @finalizado = 1
		BEGIN
			UPDATE ProyectDetail SET finaled = @finalizado, dateEnd = GETDATE() WHERE idProyect = @idProyect AND id = @idProyectDetail 
		END

	END
	ELSE
	BEGIN 
		UPDATE ProyectDetail SET moduleName = @moduleName , descriptions = @descriptions, dateEstimated = @dateEstimated, 
		hourEstimated = @hourEstimated,	 hourDedicated = @hourDedicated, finaled = @finalizado
		WHERE idProyect = @idProyect AND id = @idProyectDetail 

		IF @finalizado = 1
		BEGIN
			UPDATE ProyectDetail SET finaled = @finalizado, dateEnd = GETDATE() WHERE idProyect = @idProyect AND id = @idProyectDetail 
		END

	END

	DECLARE @hasDateNull as integer = (SELECT count(*) as counts  from ProyectDetail 
	WHERE idProyect = @idProyect
		and dateEnd is null);
	select @hasDateNull;

	IF (@hasDateNull = 0)
	BEGIN 
		UPDATE Proyect SET dateEnd = getdate(), active = 0 where id = @idProyect
	END

END

GO
/****** Object:  StoredProcedure [dbo].[spGetLoadEditProyectDetail]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetLoadEditProyectDetail]
@idProyect as integer, 
@idProyectDetail as integer
AS
BEGIN
	
	SELECT [id]   ,[moduleName]  ,[descriptions]  ,[hourEstimated]      ,[hourDedicated]
      ,[dateCreate]  ,CONVERT(VARCHAR(10),[dateEstimated],120) as dateEstimated  ,CONVERT(VARCHAR(10),[dateEnd],120) as dateEnd
      ,[finaled]   ,[idProyect]  ,[idUser]  
	  FROM ProyectDetail WHERE idProyect = @idProyect AND id = @idProyectDetail 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLoadProyectActive]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGetLoadProyectActive]
@idCompany as integer,
@iduser as integer = null
AS
BEGIN
	SELECT p.id, p.proyectName, CASE WHEN typeRequirement = 1 THEN 'Desarrollo' 
	WHEN typeRequirement = 2 THEN 'Incidencia'
	WHEN typeRequirement = 3 THEN 'Mejora'
	WHEN typeRequirement = 4 THEN 'Administración'
    END as typeRequirement,
	CONVERT(VARCHAR(10), dateBegin, 103) AS dateBegin, 	CONVERT(VARCHAR(10), dateEnd,103) AS dateEnd,u.email , p.active
	FROM proyect p
	inner join users u on u.id = p.idUsers
	WHERE /*p.active =1
	AND*/ p.idCompany = @idCompany
	AND (idUsers = @iduser or @iduser is null)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLoadProyectDetail]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetLoadProyectDetail]
@idProyect as integer
AS
BEGIN
	
	SELECT pd.id, moduleName, descriptions, hourEstimated, hourDedicated,CONVERT(VARCHAR(10), dateCreate, 103) AS dateCreate , CONVERT(VARCHAR(10), pd.dateEnd , 103) AS dateEnd, p.proyectName,  CONVERT(VARCHAR(10), dateEstimated,103) as dateEstimated, active, finaled 
	FROM ProyectDetail pd
		INNER JOIN  proyect p on p.id = pd.idProyect
	WHERE idProyect = @idProyect
END



GO
/****** Object:  StoredProcedure [dbo].[spGetPermissionByProfile]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetPermissionByProfile]
	@IdProfile as int 
AS
BEGIN

select *  from permissionByProfile where idProfile = @IdProfile

END
GO
/****** Object:  StoredProcedure [dbo].[spGetUser]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUser]
@userName nvarchar(50)

AS
BEGIN
	SELECT * FROM Users WHERE email = @userName 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUserForIdCompany]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserForIdCompany]
@IdCompany integer

AS
BEGIN
	SELECT id,idCompany,email,password,active, CONVERT(VARCHAR(10), creationDate,103) as creationDate  FROM Users WHERE idCompany = @IdCompany  AND idUserProfile = 2
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertProyectDetail]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertProyectDetail]
@moduleName as varchar(50),
@proyectDescription as varchar(100),
@hourEstimated as float,
@dateEstimatedEnd as datetime,
@idProyect as integer,
@idUser as integer
AS
BEGIN

declare @Id as integer;

INSERT INTO proyectdetail (moduleName, descriptions, dateCreate, hourEstimated, dateEstimated, idProyect, idUser) VALUES (@moduleName, @proyectDescription, getdate(), @hourEstimated, @dateEstimatedEnd, @idProyect, @idUser )

select @Id = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[spRecoveryPassword]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRecoveryPassword]
@Email as varchar(50),
@Password as varchar(50)

AS
BEGIN
	declare @id as integer = null;
	SELECT @id = id FROM Users WHERE email = @Email
	--SELECT @id
	IF @id > 0
	BEGIN 

		UPDATE Users SET password = @Password WHERE id = @id
		SELECT 'OK' Result
	END
	ELSE
	BEGIN
		SELECT 'No existe el EMAIL' Result
	END 

END
GO
/****** Object:  StoredProcedure [dbo].[spReportGraphicByType]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReportGraphicByType]
@dateBegin as datetime = null,
@dateEnd  as datetime = null,
@active as integer = null,
@idCompany as integer = null,
@idUser as integer = null
AS
BEGIN

SELECT (select sum(hourDedicated) from ProyectDetail pd
INNER JOIN Proyect p on p.id = pd.idProyect
 WHERE 	(dateCreate >= @dateBegin or @dateBegin is null)
	AND (dateCreate <= @dateEnd or @dateEnd is null)
	AND (active = @active or @active is null)
	AND idCompany = @idCompany
	AND (idUsers = @idUser OR @idUser IS NULL)
	AND typeRequirement = 1) as HorasDesarrollo,

(SELECT sum(hourDedicated) from ProyectDetail pd
INNER JOIN Proyect p on p.id = pd.idProyect
 WHERE 	(dateCreate >= @dateBegin or @dateBegin is null)
	AND (dateCreate <= @dateEnd or @dateEnd is null)
	AND (active = @active or @active is null)
	AND idCompany = @idCompany
	AND (idUsers = @idUser OR @idUser IS NULL)
	AND typeRequirement = 2) as HorasIncidencia,

(SELECT  sum(hourDedicated) from ProyectDetail pd
INNER JOIN Proyect p on p.id = pd.idProyect
 WHERE 	(dateCreate >= @dateBegin or @dateBegin is null)
	AND (dateCreate <= @dateEnd or @dateEnd is null)
	AND (active = @active or @active is null)
	AND idCompany = @idCompany
	AND (idUsers = @idUser OR @idUser IS NULL)
	AND typeRequirement = 3) as HorasMejora,

(SELECT  sum(hourDedicated) from ProyectDetail pd
INNER JOIN Proyect p on p.id = pd.idProyect
 WHERE 	(dateCreate >= @dateBegin or @dateBegin is null)
	AND (dateCreate <= @dateEnd or @dateEnd is null)
	AND (active = @active or @active is null)
	AND idCompany = @idCompany
	AND (idUsers = @idUser OR @idUser IS NULL)
	AND typeRequirement = 4) as HorasAdministracion

END
GO
/****** Object:  StoredProcedure [dbo].[spReportPrincipal]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReportPrincipal]
@dateBegin datetime = null,
@dateEnd datetime = null ,
@active int = null,
@idCompany datetime = null ,
@idUser int = null
AS
BEGIN

	SELECT proyectName, descriptions, CONVERT(VARCHAR(10),dateCreate, 103) as dateCreate, hourEstimated, hourDedicated, 
	CONVERT(VARCHAR(10), pd.dateEstimated, 103) as dateEstimated, u.email, CASE WHEN p.active = 1 THEN 'Activo' else 'Finalizado' END as active
	FROM Proyect p
	INNER JOIN ProyectDetail pd ON pd.idProyect = p.id
	INNER JOIN Users u ON u.id = p.idUsers and u.id = pd.idUser 
		AND (dateCreate >= @dateBegin or @dateBegin is null)
		AND (dateCreate <= @dateEnd or @dateEnd is null)
		AND (p.active = @active or @active is null)
		AND p.idCompany = @idCompany 
		AND (pd.idUser = @idUser or @idUser is null)
	ORDER BY pd.id

END
GO
/****** Object:  StoredProcedure [dbo].[spReportSumHour]    Script Date: 12/03/2020 20:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReportSumHour]
	@dateBegin datetime = null,
	@dateEnd datetime = null,
	@active int = null,
	@idCompany datetime = null ,
	@idUser int = null
AS
BEGIN

	SELECT  distinct(p.proyectName),(select convert(VARCHAR(10), dateBegin,103) from Proyect where id = p.id) as dateBegin, SUM(hourEstimated) as hourEstimated, SUM(hourDedicated) as hourDedicated , 
	u.email,(CASE WHEN p.active = 1 THEN 'Activo' WHEN p.active = 0 THEN 'Finalizado' END) AS Estado
	
	FROM Proyect p
	INNER JOIN ProyectDetail pd on pd.idProyect = p.id
	INNER JOIN Users u on u.id = p.idUsers and u.id = pd.idUser 
		AND (dateCreate >= @dateBegin or @dateBegin is null)
		AND (dateCreate <= @dateEnd or @dateEnd is null)
		AND (p.active = @active or @active is null)
		AND P.idCompany = @idCompany
		AND (p.idUsers = @idUser OR @idUser IS NULL)
		AND proyectName = p.proyectName

	GROUP BY  p.id,proyectName, u.email, p.active
	ORDER BY 1

END
GO
USE [master]
GO
ALTER DATABASE [controlsheet] SET  READ_WRITE 
GO
