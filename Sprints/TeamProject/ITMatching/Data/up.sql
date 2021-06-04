-- UP script for SQL Server

CREATE TABLE [ITMUser] (
  [ID]					INT PRIMARY KEY IDENTITY(1, 1),
  [ASPNetUserID]		NVARCHAR(450) NOT NULL,
  [UserName]			VARCHAR(255) NOT NULL,
  [FirstName]			NVARCHAR(30) NOT NULL,
  [LastName]			NVARCHAR(30) NOT NULL,
  [Email]				NVARCHAR(255) NOT NULL,
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
  [WorkSchedule]	NVARCHAR(60),
  [IsAvailable]		BIT NOT NULL
)
GO

CREATE TABLE [Service] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ServiceCategory]	NVARCHAR(100) NOT NULL,
  [ServiceName]		NVARCHAR(100) NOT NULL
)
GO 

CREATE TABLE [ExpertService] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ServiceId]		INT NOT NULL,
  [ExpertId]		INT
)
GO 

CREATE TABLE [RequestService] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ServiceId]		INT NOT NULL,
  [RequestId]		INT
)
GO 

--Now lists HelpRequest object ID instead of ServiceID (which can be obtained through HelpRequestID)
CREATE TABLE [Meeting] (
  [ID]						INT PRIMARY KEY IDENTITY(1, 1),
  [Date]					DATETIME NOT NULL,
  [ClientID]				INT NOT NULL,
  [ExpertID]				INT NOT NULL,
  [HelpRequestID]			INT NOT NULL,
  [Status]					NVARCHAR(20) NOT NULL, 
  [ClientTimestamp]			DATETIME NOT NULL,
  [ExpertTimestamp]			DATETIME NOT NULL,
  [MatchExpireTimestamp]	DATETIME NOT NULL,
  [Feedback]                INT,
  [numOfPotentialMatches]   INT NOT NULL
)
GO

CREATE TABLE [PotentialMatch] (
  [ID]						INT PRIMARY KEY IDENTITY(1, 1),
  [MeetingID]				INT NOT NULL,
  [ExpertID]				INT NOT NULL,
  [MatchingScore]           FLOAT NOT NULL
)
GO

--Should we change feedback text to be at least the length of a tweet?
CREATE TABLE [ExpertFeedback] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [ExpertID]		INT NOT NULL,
  [ClientID]		INT NOT NULL,
  [MeetingID]	    INT NOT NULL,
  [Rating]			INT NOT NULL
)
GO

CREATE TABLE [Faq] (
  [ID]				INT PRIMARY KEY IDENTITY(1, 1),
  [Question]		NVARCHAR(500) NOT NULL,
  [Answer]			NVARCHAR(500) NOT NULL
)
GO

CREATE TABLE [HelpRequest] (
  [ID]					INT PRIMARY KEY IDENTITY(1, 1),
  [ClientID]			INT NOT NULL,
  [RequestTitle]		NVARCHAR(40) NOT NULL,
  [RequestDescription]	NVARCHAR(2000) NOT NULL,
  [IsOpen]				BIT NOT NULL
)
GO
CREATE TABLE [WorkSchedule] (
    [ID]                INT PRIMARY KEY IDENTITY(1,1),
    [ExpertId]          INT	NOT NULL,
    "Day"               NVARCHAR(20),
    "Hour"              INT
)
GO
CREATE TABLE [RequestSchedule](
    [ID]                INT PRIMARY KEY IDENTITY,
    [ClientId]          INT NOT NULL,
    [RequestId]         INT NOT NULL,
    [Day]               NVARCHAR(20),
    [Hour]              INT
)
GO
CREATE TABLE [Message](
    [ID]                INT PRIMARY KEY IDENTITY,
    [MeetingID]         INT NOT NULL,
    [SentBy]            INT NOT NULL,
    [SentTime]          DATETIME,
    [Text]              NVARCHAR(2000),
    [FileUrl]           NVARCHAR(500)
)
GO

ALTER TABLE [dbo].[Client] 
ADD CONSTRAINT [FK_Client_ITMUserID]
    FOREIGN KEY ([ITMUserID]) REFERENCES [ITMUser] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[Expert] 
ADD CONSTRAINT [FK_Expert_ITMUserID]
    FOREIGN KEY ([ITMUserID]) REFERENCES [ITMUser] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[ExpertService] 
ADD CONSTRAINT [FK_ExpertService_ServiceId]
    FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[ExpertService] 
ADD CONSTRAINT [FK_ExpertService_ExpertId]
    FOREIGN KEY ([ExpertId]) REFERENCES [Expert] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[RequestService] 
ADD CONSTRAINT [FK_RequestService_RequestId]
    FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[RequestService] 
ADD CONSTRAINT [FK_RequestService_ServiceId]
    FOREIGN KEY ([RequestId]) REFERENCES [HelpRequest] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[Meeting] 
ADD CONSTRAINT [FK_Meeting_HelpRequestID]
    FOREIGN KEY ([HelpRequestID]) REFERENCES [HelpRequest] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[PotentialMatch] 
ADD CONSTRAINT [FK_PotentialMatch_MeetingID]
    FOREIGN KEY ([MeetingID]) REFERENCES [Meeting] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[PotentialMatch] 
ADD CONSTRAINT [FK_PotentialMatch_ExpertID]
    FOREIGN KEY ([ExpertID]) REFERENCES [Expert] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[ExpertFeedback] 
ADD CONSTRAINT [FK_ExpertFeedback_ExpertID]
    FOREIGN KEY ([ExpertID]) REFERENCES [Expert] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[ExpertFeedback] 
ADD CONSTRAINT [FK_ExpertFeedback_ClientID]
    FOREIGN KEY ([ClientID]) REFERENCES [Client] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[WorkSchedule] 
ADD CONSTRAINT [FK_WorkSchedule_ExpertId]
    FOREIGN KEY ([ExpertID]) REFERENCES [Expert] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[RequestSchedule] 
ADD CONSTRAINT [FK_RequestSchedule_ClientId]
    FOREIGN KEY ([ClientId]) REFERENCES [Client] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[RequestSchedule] 
ADD CONSTRAINT [FK_RequestSchedule_RequestId]
    FOREIGN KEY ([RequestId]) REFERENCES [HelpRequest] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO
ALTER TABLE [dbo].[Message] 
ADD CONSTRAINT [FK_Message_MeetingID]
    FOREIGN KEY ([MeetingId]) REFERENCES [Meeting] ([ID]) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
GO