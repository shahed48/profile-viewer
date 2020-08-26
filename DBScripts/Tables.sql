IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id=OBJECT_ID('UserProfiles'))
BEGIN
	CREATE TABLE [dbo].[UserProfiles](
		Id BIGINT IDENTITY(1,1) NOT NULL,
		UserId NVARCHAR(128) NOT NULL,
		FirstName VARCHAR(64) NOT NULL,
		LastName VARCHAR(64) NOT NULL,
		AlternateEmailAddress VARCHAR(64) NULL,
		PhoneNumber VARCHAR(16) NOT NULL,
		AlternatePhoneNumber VARCHAR(16) NULL,
		IsActive BIT DEFAULT 1 NOT NULL,

		CONSTRAINT [PK_UserProfiles] PRIMARY KEY(Id),
		CONSTRAINT [FK_UserProfiles_AspNetUsers] FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
	)
END
GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id=OBJECT_ID('Works'))
BEGIN
	CREATE TABLE [dbo].Works(
		Id BIGINT IDENTITY(1,1) NOT NULL,
		WorkType VARCHAR(256) NOT NULL,
		TaskDescription VARCHAR(64) NOT NULL,
		DaysRequired INT NOT NULL,
		IsActive BIT DEFAULT 1 NOT NULL,

		CONSTRAINT [PK_Works] PRIMARY KEY(Id)
	)
END
GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id=OBJECT_ID('UserWorks'))
BEGIN
	CREATE TABLE [dbo].UserWorks(
		Id BIGINT IDENTITY(1,1) NOT NULL,
		WorkId BIGINT NOT NULL,
		UserProfileId BIGINT NOT NULL,
		StartingDate DATETIME NOT NULL,
		NoOfDays INT NOT NULL,
		StatusText VARCHAR(20) NULL,

		CONSTRAINT [PK_UserWorks] PRIMARY KEY(Id),
		CONSTRAINT [FK_UserWorks_Works] FOREIGN KEY (WorkId) REFERENCES Works(Id),
		CONSTRAINT [FK_UserWorks_UserProfiles] FOREIGN KEY (UserProfileId) REFERENCES UserProfiles(Id)
	)
END
GO

