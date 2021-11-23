-- exec sp_rename 'UserParams', 'UserParams2'

-- IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserCalc]') AND type in (N'U'))
-- DROP TABLE [dbo].[UserCalc]
-- GO

-- IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserParams]') AND type in (N'U'))
-- DROP TABLE [dbo].[UserParams]
-- GO

-- DELETE FROM UserCalc
-- DELETE FROM UserParams

drop table test

create table test(
    x int,
    y int
)

create table Authentication(
    Id int not null PRIMARY KEY IDENTITY(1,1),
    Login NCHAR(50) not null,
    Password NCHAR(50) not null,
    Email NCHAR(50) not null,
)

create table UserParams(
    AuthId int not null PRIMARY KEY IDENTITY(1,1),
    -- Id int not null PRIMARY KEY IDENTITY(1,1),
    Weight REAL not null, 
    Height SMALLINT not null,
    Age TINYINT not null,
    Gender TINYINT not null,
    Date DATETIME2 DEFAULT GETDATE() 
    CONSTRAINT [FK_UserParams_Authentication] FOREIGN KEY (AuthId) REFERENCES [Authentication](Id)
    )

CREATE TABLE UserCalc(
    UserParamsId int NOT NULL, 
    BasicCalorie SMALLINT NOT NULL,
    CalculatedCalorie SMALLINT NOT NULL,
    IndexMass REAL NOT NULL,
    -- CONSTRAINT [FK_UserCalc_UserParams] FOREIGN KEY (UserParamsId) REFERENCES [UserParams](Id)
)

insert Authentication([Login], [Password], Email)
VALUES('Aye', 'password', 'mail.ru')

insert UserParams(Weight, Height, Age, Gender)
VALUES(65, 174, 21, 0)

insert UserCalc(UserParamsId, BasicCalorie, CalculatedCalorie, IndexMass)
VALUES(5, 1100, 2000, 21.4)

select * from Authentication
select * from UserParams
select * from UserCalc
