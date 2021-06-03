-- DOWN script for SQL Server

ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_ITMUserID]
ALTER TABLE [Expert] DROP CONSTRAINT [FK_Expert_ITMUserID]
ALTER TABLE [ExpertService] DROP CONSTRAINT [FK_ExpertService_ServiceId]
ALTER TABLE [ExpertService] DROP CONSTRAINT [FK_ExpertService_ExpertId]
ALTER TABLE [RequestService] DROP CONSTRAINT [FK_RequestService_RequestId]
ALTER TABLE [RequestService] DROP CONSTRAINT [FK_RequestService_ServiceId]
ALTER TABLE [Meeting] DROP CONSTRAINT [FK_Meeting_HelpRequestID]
ALTER TABLE [PotentialMatch] DROP CONSTRAINT [FK_PotentialMatch_MeetingID]
ALTER TABLE [PotentialMatch] DROP CONSTRAINT [FK_PotentialMatch_ExpertID]
ALTER TABLE [ExpertFeedback] DROP CONSTRAINT [FK_ExpertFeedback_ExpertID]
ALTER TABLE [ExpertFeedback] DROP CONSTRAINT [FK_ExpertFeedback_ClientID]
ALTER TABLE [WorkSchedule] DROP CONSTRAINT [FK_WorkSchedule_ExpertId]
ALTER TABLE [RequestSchedule] DROP CONSTRAINT [FK_RequestSchedule_ClientId]
ALTER TABLE [RequestSchedule] DROP CONSTRAINT [FK_RequestSchedule_RequestId]
ALTER TABLE [Message] DROP CONSTRAINT [FK_Message_MeetingID]



DROP TABLE [Client];
DROP TABLE [Expert];
DROP TABLE [Service];
DROP TABLE [ExpertService];
DROP TABLE [RequestService];
DROP TABLE [Meeting];
Drop Table [PotentialMatch];
DROP TABLE [ExpertFeedback];
DROP TABLE [FAQ];
DROP TABLE [HelpRequest];
DROP TABLE [WorkSchedule];
DROP TABLE [RequestSchedule];
DROP TABLE [Message];
DROP TABLE [ITMUser];