-- <Migration ID="841ae6be-fc2b-47f3-b9bd-9f71a6e2af21" />
GO

PRINT N'Creating [dbo].[dept]'
GO
CREATE TABLE [dbo].[dept]
(
[deptno] [int] NOT NULL,
[dname] [varchar] (14) NULL,
[loc] [varchar] (13) NULL
)
GO
PRINT N'Creating primary key [PK_dept_deptno] on [dbo].[dept]'
GO
ALTER TABLE [dbo].[dept] ADD CONSTRAINT [PK_dept_deptno] PRIMARY KEY CLUSTERED  ([deptno])
GO
PRINT N'Creating [dbo].[emp]'
GO
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
PRINT N'Creating primary key [PK__emp__AF4C318A1BBF6DBD] on [dbo].[emp]'
GO
ALTER TABLE [dbo].[emp] ADD CONSTRAINT [PK__emp__AF4C318A1BBF6DBD] PRIMARY KEY CLUSTERED  ([empno])
GO
