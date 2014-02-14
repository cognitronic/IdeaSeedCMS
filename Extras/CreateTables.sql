USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[ApplicationView]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ApplicationView](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](512) NULL,
	[Path] [varchar](2056) NOT NULL,
	[AccessLevel] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationView] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[BannerImage]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BannerImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Path] [varchar](256) NOT NULL,
	[ToolTip] [varchar](256) NULL,
	[SubText] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BannerImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[Blog]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Blog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](128) NOT NULL,
	[PostType] [int] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[BlogContent] [varchar](max) NOT NULL,
	[SEOKeywords] [varchar](2048) NULL,
	[SEODescription] [varchar](5000) NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Blog_2] UNIQUE NONCLUSTERED 
(
	[Title] ASC,
	[PostType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[Campaign]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Campaign](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [varchar](256) NOT NULL,
	[Description] [varchar](512) NULL,
	[CampaignTemplateID] [int] NOT NULL,
	[SentBy] [int] NOT NULL,
	[TotalRecipients] [int] NOT NULL,
	[EmailSubject] [varchar](256) NOT NULL,
	[EmailBody] [varchar](max) NOT NULL,
	[DateTimeSent] [datetime] NOT NULL,
	[EmailFrom] [varchar](128) NOT NULL,
 CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Campaign_2] UNIQUE NONCLUSTERED 
(
	[CampaignName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignForwardToAFriend]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CampaignForwardToAFriend](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriberID] [int] NOT NULL,
	[CampaignID] [int] NOT NULL,
	[DateForwarded] [datetime] NOT NULL,
	[emails] [varchar](max) NOT NULL,
 CONSTRAINT [PK_CampaignForwardToAFriend] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignLink]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CampaignLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](256) NULL,
	[NavigateURL] [nvarchar](512) NOT NULL,
	[CampaignID] [int] NOT NULL,
	[IsImage] [bit] NOT NULL,
	[ImageURL] [nvarchar](512) NULL,
 CONSTRAINT [PK_CampaignLink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignOptOut]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CampaignOptOut](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriberID] [int] NOT NULL,
	[CampaignID] [int] NOT NULL,
	[DateUnsubscribed] [datetime] NOT NULL,
 CONSTRAINT [PK_CampaignOptOut] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignSubscriber]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CampaignSubscriber](
	[ID] [uniqueidentifier] NOT NULL,
	[CampaignID] [int] NOT NULL,
	[SubscriberID] [int] NOT NULL,
 CONSTRAINT [PK_CampaignSubscriber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignSubscriberLinkRequest]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CampaignSubscriberLinkRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CampaignSubscriberID] [uniqueidentifier] NOT NULL,
	[CampaignLinkID] [int] NOT NULL,
	[IP] [varchar](50) NULL,
	[Browser] [varchar](50) NULL,
	[UserAgent] [varchar](256) NULL,
	[DateClicked] [datetime] NOT NULL,
	[Referrer] [varchar](256) NULL,
	[OperatingSystem] [varchar](128) NULL,
	[HostName] [varchar](50) NULL,
 CONSTRAINT [PK_CampaignSubscriberLinkRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignSubscriberRequest]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CampaignSubscriberRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CampaignSubscriberID] [uniqueidentifier] NOT NULL,
	[IP] [varchar](50) NULL,
	[Browser] [varchar](50) NULL,
	[UserAgent] [varchar](256) NULL,
	[DateRequested] [datetime] NOT NULL,
	[OperatingSystem] [varchar](50) NULL,
	[HostName] [varchar](128) NULL,
 CONSTRAINT [PK_CampaignSubscriberRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignTag]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CampaignTag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [varchar](512) NOT NULL,
 CONSTRAINT [PK_CampaignTag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_CampaignTag] UNIQUE NONCLUSTERED 
(
	[Tag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[CampaignTemplate]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CampaignTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [varchar](128) NOT NULL,
	[Description] [varchar](128) NULL,
	[EmailSubject] [varchar](256) NOT NULL,
	[EmailBody] [varchar](max) NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_CampaignTemplate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_CampaignTemplate] UNIQUE NONCLUSTERED 
(
	[TemplateName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[Page]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Page](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[DisplayName] [varchar](128) NULL,
	[SEOTitle] [varchar](128) NOT NULL,
	[SEOKeywords] [varchar](1024) NOT NULL,
	[SEODescription] [varchar](5000) NOT NULL,
	[AccessLevel] [int] NOT NULL,
	[URLRoute] [varchar](800) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ParentID] [int] NULL,
	[SortOrder] [int] NOT NULL,
	[NavigationTypeID] [int] NOT NULL,
	[IsManageable] [bit] NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Page] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[AccessLevel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[PageApplicationView]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PageApplicationView](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NOT NULL,
	[ApplicationViewID] [int] NOT NULL,
	[ApplicationViewLayout] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[ViewProperties] [varchar](max) NULL,
 CONSTRAINT [PK_PageApplicationView] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[PageContent]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PageContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[SubTitle] [varchar](128) NULL,
	[PageContent] [varchar](max) NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_PageContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[PageLink]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PageLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NOT NULL,
	[ImagePath] [varchar](128) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[URL] [varchar](256) NULL,
	[LinkContent] [varchar](512) NULL,
 CONSTRAINT [PK_PageLinks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[Subscriber]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Subscriber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Subscriber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Subscriber] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[SubscriberCampaignTag]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubscriberCampaignTag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriberID] [int] NOT NULL,
	[CampaignTagID] [int] NOT NULL,
 CONSTRAINT [PK_SubscriberCampaignTag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_SubscriberCampaignTag] UNIQUE NONCLUSTERED 
(
	[CampaignTagID] ASC,
	[SubscriberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [IdeaSeedCMS]
GO

/****** Object:  Table [dbo].[User]    Script Date: 10/12/2011 06:00:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[PasswordAnswer] [varchar](50) NOT NULL,
	[PasswordQuestion] [varchar](1024) NOT NULL,
	[MarkedForDeletion] [bit] NOT NULL,
	[AccessLevel] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_User] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_User] FOREIGN KEY([EnteredBy])
REFERENCES [dbo].[User] ([ID])
GO

ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_User]
GO

ALTER TABLE [dbo].[Campaign]  WITH CHECK ADD  CONSTRAINT [FK_Campaign_CampaignTemplate] FOREIGN KEY([CampaignTemplateID])
REFERENCES [dbo].[CampaignTemplate] ([ID])
GO

ALTER TABLE [dbo].[Campaign] CHECK CONSTRAINT [FK_Campaign_CampaignTemplate]
GO

ALTER TABLE [dbo].[CampaignLink]  WITH CHECK ADD  CONSTRAINT [FK_CampaignLink_Campaign] FOREIGN KEY([CampaignID])
REFERENCES [dbo].[Campaign] ([ID])
GO

ALTER TABLE [dbo].[CampaignLink] CHECK CONSTRAINT [FK_CampaignLink_Campaign]
GO

ALTER TABLE [dbo].[CampaignSubscriber]  WITH CHECK ADD  CONSTRAINT [FK_CampaignSubscriber_Campaign] FOREIGN KEY([CampaignID])
REFERENCES [dbo].[Campaign] ([ID])
GO

ALTER TABLE [dbo].[CampaignSubscriber] CHECK CONSTRAINT [FK_CampaignSubscriber_Campaign]
GO

ALTER TABLE [dbo].[CampaignSubscriber]  WITH CHECK ADD  CONSTRAINT [FK_CampaignSubscriber_Subscriber] FOREIGN KEY([SubscriberID])
REFERENCES [dbo].[Subscriber] ([ID])
GO

ALTER TABLE [dbo].[CampaignSubscriber] CHECK CONSTRAINT [FK_CampaignSubscriber_Subscriber]
GO

ALTER TABLE [dbo].[CampaignSubscriber] ADD  CONSTRAINT [DF_CampaignSubscriber_ID]  DEFAULT (newid()) FOR [ID]
GO

ALTER TABLE [dbo].[CampaignSubscriberLinkRequest]  WITH CHECK ADD  CONSTRAINT [FK_CampaignSubscriberLinkRequest_CampaignLink] FOREIGN KEY([CampaignLinkID])
REFERENCES [dbo].[CampaignLink] ([ID])
GO

ALTER TABLE [dbo].[CampaignSubscriberLinkRequest] CHECK CONSTRAINT [FK_CampaignSubscriberLinkRequest_CampaignLink]
GO

ALTER TABLE [dbo].[CampaignSubscriberLinkRequest]  WITH CHECK ADD  CONSTRAINT [FK_CampaignSubscriberLinkRequest_CampaignSubscriber] FOREIGN KEY([CampaignSubscriberID])
REFERENCES [dbo].[CampaignSubscriber] ([ID])
GO

ALTER TABLE [dbo].[CampaignSubscriberLinkRequest] CHECK CONSTRAINT [FK_CampaignSubscriberLinkRequest_CampaignSubscriber]
GO

ALTER TABLE [dbo].[CampaignSubscriberRequest]  WITH CHECK ADD  CONSTRAINT [FK_CampaignSubscriberRequest_CampaignSubscriber] FOREIGN KEY([CampaignSubscriberID])
REFERENCES [dbo].[CampaignSubscriber] ([ID])
GO

ALTER TABLE [dbo].[CampaignSubscriberRequest] CHECK CONSTRAINT [FK_CampaignSubscriberRequest_CampaignSubscriber]
GO

ALTER TABLE [dbo].[PageContent]  WITH CHECK ADD  CONSTRAINT [FK_PageContent_Page] FOREIGN KEY([PageID])
REFERENCES [dbo].[Page] ([ID])
GO

ALTER TABLE [dbo].[PageContent] CHECK CONSTRAINT [FK_PageContent_Page]
GO

ALTER TABLE [dbo].[PageLink]  WITH CHECK ADD  CONSTRAINT [FK_PageLink_Page] FOREIGN KEY([PageID])
REFERENCES [dbo].[Page] ([ID])
GO

ALTER TABLE [dbo].[PageLink] CHECK CONSTRAINT [FK_PageLink_Page]
GO

ALTER TABLE [dbo].[Subscriber] ADD  CONSTRAINT [DF_Subscriber_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO

ALTER TABLE [dbo].[SubscriberCampaignTag]  WITH CHECK ADD  CONSTRAINT [FK_SubscriberCampaignTag_CampaignTag] FOREIGN KEY([CampaignTagID])
REFERENCES [dbo].[CampaignTag] ([ID])
GO

ALTER TABLE [dbo].[SubscriberCampaignTag] CHECK CONSTRAINT [FK_SubscriberCampaignTag_CampaignTag]
GO

ALTER TABLE [dbo].[SubscriberCampaignTag]  WITH CHECK ADD  CONSTRAINT [FK_SubscriberCampaignTag_Subscriber] FOREIGN KEY([SubscriberID])
REFERENCES [dbo].[Subscriber] ([ID])
GO

ALTER TABLE [dbo].[SubscriberCampaignTag] CHECK CONSTRAINT [FK_SubscriberCampaignTag_Subscriber]
GO

