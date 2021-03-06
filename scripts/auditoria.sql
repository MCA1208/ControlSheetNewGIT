
/****** Object:  Schema [audit]    Script Date: 2/10/2019 08:08:24 ******/
CREATE SCHEMA [audit]
GO
/****** Object:  Table [audit].[Events]    Script Date: 2/10/2019 08:08:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [audit].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssemblyVersion] [varchar](100) NULL,
	[BaseDir] [varchar](100) NULL,
	[CurrentDir] [varchar](100) NULL,
	[CallSite] [varchar](100) NULL,
	[CallSiteLineNumber] [smallint] NULL,
	[EventDate] [datetime] NULL,
	[EventLevel] [varchar](100) NULL,
	[MachineName] [varchar](100) NULL,
	[ProcessName] [varchar](100) NULL,
	[WindowsIdentity] [varchar](100) NULL,
	[Exception] [varchar](max) NULL,
	[Message] [varchar](max) NULL,
	[StackTrace] [varchar](max) NULL,
	[Logger] [varchar](max) NULL,
	[Properties] [varchar](max) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [audit].[spInsertEvents]    Script Date: 2/10/2019 08:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [audit].[spInsertEvents]
	-- Add the parameters for the stored procedure here
	@assemblyversion	varchar(100),
	@basedir			varchar(100),
	@callsite			varchar(100),
	@callsitelinenumber	smallint,
	@currentdir			varchar(100),
	@level				varchar(100),
	@machinename		varchar(100),
	@message			varchar(max),
	@processname		varchar(100),
	@stacktrace			varchar(max),
	@windowsidentity	varchar(100),
	@exception			varchar(max),
	@logger				varchar(max),
	@properties			varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into	[audit].[Events] (
		AssemblyVersion,
		BaseDir,
		CurrentDir,
		CallSite,
		CallSiteLineNumber,
		EventDate,
		EventLevel,
		MachineName,
		ProcessName,
		WindowsIdentity,
		Exception,
		[Message],
		StackTrace,
		Logger,
		Properties
	)
	Values (
		@assemblyversion,
		@basedir,
		@currentdir,
		@callsite,
		@callsitelinenumber,
		GETDATE(),
		@level,
		@machinename,
		@processname,
		@windowsidentity,
		@exception,
		@message,
		@stacktrace,
		@logger,
		@properties
	);
END
GO
