CREATE DATABASE Interview
GO

USE Interview

CREATE SCHEMA Emp
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Emp].[Employees] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (20)  NOT NULL,
    [FirstName]   VARCHAR (50)  NOT NULL,
    [LastName]    VARCHAR (50)  NOT NULL,
    [Sex]         VARCHAR (1)   NOT NULL,
    [DateOfBirth] DATE          NOT NULL,
    [Email]       VARCHAR (100) NOT NULL,
    [Role]        VARCHAR (100) NOT NULL,
    [Salary]      MONEY         NOT NULL
);


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Emp].[sp_AddEmployee]
	@Title varchar(20),
	@FirstName varchar(50),
	@LastName varchar(50),
	@Sex varchar(1),
	@DateOfBirth date,
	@Email varchar(100),
	@Role varchar(100),
	@salary money
AS
	insert into Emp.Employees ([Title], [FirstName], [LastName], [Sex], [DateOfBirth], [Email], [Role], [Salary])
	values (@Title, @FirstName, @LastName, @Sex, @DateOfBirth, @Email, @Role, @Salary)
RETURN 0
