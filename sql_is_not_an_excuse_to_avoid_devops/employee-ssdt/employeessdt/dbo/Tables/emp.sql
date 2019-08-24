CREATE TABLE [dbo].[emp] (
    [empno]    INT            NOT NULL,
    [ename]    VARCHAR (10)   NULL,
    [job]      VARCHAR (9)    NULL,
    [mgr]      INT            NULL,
    [hiredate] DATETIME       NULL,
    [sal]      NUMERIC (7, 2) NULL,
    [comm]     NUMERIC (7, 2) NULL,
    [dept]     INT            NULL,
    PRIMARY KEY CLUSTERED ([empno] ASC)
);

