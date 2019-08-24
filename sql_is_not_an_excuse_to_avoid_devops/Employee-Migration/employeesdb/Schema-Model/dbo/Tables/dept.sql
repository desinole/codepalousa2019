CREATE TABLE [dbo].[dept]
(
[deptno] [int] NOT NULL,
[dname] [varchar] (14) NULL,
[loc] [varchar] (13) NULL
)
GO
ALTER TABLE [dbo].[dept] ADD CONSTRAINT [PK_dept_deptno] PRIMARY KEY CLUSTERED  ([deptno])
GO
