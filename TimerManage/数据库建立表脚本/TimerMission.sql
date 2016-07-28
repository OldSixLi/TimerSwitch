USE [TjCopMaintain]
GO

/****** Object:  Table [dbo].[TimerMission]    Script Date: 07/27/2016 09:10:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimerMission](
	[ID] [uniqueidentifier] NOT NULL,
	[MissionName] [nvarchar](50) NOT NULL,
	[GroupName] [nchar](50) NOT NULL,
	[SqlStr] [nvarchar](max) NULL,
	[TimeCorn] [nchar](50) NULL,
	[RepeatCount] [int] NULL,
	[InveralTime] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[MissionState] [int] NOT NULL,
	[IsDel] [int] NOT NULL,
 CONSTRAINT [PK_TimerMission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'MissionName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'GroupName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQLִ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'SqlStr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ����ȱ��ʽ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'TimeCorn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ִ�д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'RepeatCount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʱ�䣨�룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'InveralTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'StartTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'EndTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���񴴽�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����״̬��1������;2��δ����;3����ͣ;4��ɾ��;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'MissionState'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ����1����ɾ��;0��δɾ��;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimerMission', @level2type=N'COLUMN',@level2name=N'IsDel'
GO

ALTER TABLE [dbo].[TimerMission] ADD  CONSTRAINT [DF_TimerMission_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[TimerMission] ADD  CONSTRAINT [DF_TimerMission_MissionState]  DEFAULT ((2)) FOR [MissionState]
GO

ALTER TABLE [dbo].[TimerMission] ADD  CONSTRAINT [DF_TimerMission_IsDel]  DEFAULT ((0)) FOR [IsDel]
GO


