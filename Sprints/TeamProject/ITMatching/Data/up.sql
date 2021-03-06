-- UP script for SQL Server

CREATE TABLE [ITMUser] (
  [ID]					INT PRIMARY KEY IDENTITY(1, 1),
  [ASPNetUserID]		NVARCHAR(450) NOT NULL,
  [UserName]			VARCHAR(255) NOT NULL,
  [FirstName]			NVARCHAR(30) NOT NULL,
  [LastName]			NVARCHAR(30) NOT NULL,
  [Email]				NVARCHAR(50) NOT NULL,
  [PhoneNumber]			NVARCHAR(13) NOT NULL
)

CREATE TABLE [Client] (
  [ID]			INT PRIMARY KEY IDENTITY(1, 1),
  [ITMUserID]	INT NOT NULL
)
GO

CREATE TABLE [Expert] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ITMUserID]		INT NOT NULL,
  [WorkSchedule]	NVARCHAR(60)
)
GO

CREATE TABLE [Service] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ServiceCategory]	NVARCHAR(100) NOT NULL,
  [ServiceName]		NVARCHAR(100) NOT NULL
)
GO 

--Likely have to rework so that this isn't tied to expert, so that we can use with HelpRequest as well
CREATE TABLE [ServiceTag] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ServiceId]		INT NOT NULL,
  [ExpertId]		INT
)
GO 

--Now lists HelpRequest object ID instead of ServiceID (which can be obtained through HelpRequestID)
CREATE TABLE [Meeting] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ClientID]		INT NOT NULL,
  [ExpertID]		INT NOT NULL,
  [HelpRequestID]	INT NOT NULL
)
GO

--Should we change feedback text to be at least the length of a tweet?
CREATE TABLE [ExpertFeedback] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ExpertID]		INT NOT NULL,
  [ClientID]		INT NOT NULL,
  [FeedbackText]	NVARCHAR(100),
  [Rating]			INT NOT NULL
)
GO

CREATE TABLE [FAQ] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [Question]		NVARCHAR(500) NOT NULL,
  [Answer]			NVARCHAR(500) NOT NULL
)
GO

CREATE TABLE [HelpRequest] (
  [ID]					INT PRIMARY KEY IDENTITY(1, 1),
  [ClientID]			INT NOT NULL,
  [RequestTitle]		NVARCHAR(40),
  [RequestDescription]	NVARCHAR(2000),
  [ServiceTagID]		INT NOT NULL,
)
GO