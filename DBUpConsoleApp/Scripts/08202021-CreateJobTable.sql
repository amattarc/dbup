CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[EmpName] [varchar](50) NULL,
	[EmpLastName] [varchar](50) NULL,
	[Dept] [varchar](10) NULL
) ON [PRIMARY]
GO
