CREATE TABLE [dbo].[emp]
(
[empno] [int] NOT NULL,
[ename] [varchar] (10) NULL,
[job] [varchar] (9) NULL,
[mgr] [int] NULL,
[hiredate] [datetime] NULL,
[sal] [numeric] (7, 2) NULL,
[comm] [numeric] (7, 2) NULL,
[dept] [int] NULL
)
GO
ALTER TABLE [dbo].[emp] ADD CONSTRAINT [PK__emp__AF4C318A1BBF6DBD] PRIMARY KEY CLUSTERED  ([empno])
GO
