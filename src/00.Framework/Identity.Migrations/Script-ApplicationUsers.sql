/****** Object:  Table [dbo].[ApplicationUsers]    Script Date: 2020-08-11 12:43:34 ******/
SET
ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUsers]
(
    [
    Id] [
    nvarchar]
(
    455
) NOT NULL,
    [UserName] [nvarchar]
(
    50
) NOT NULL UNIQUE,
    [NormalizedUserName] [nvarchar]
(
    50
) NOT NULL,
    [PasswordHash] [nvarchar]
(
    max
) NOT NULL,
    [SecurityStamp] [nvarchar]
(
    max
) NULL,
    [ConcurrencyStamp] [nvarchar]
(
    max
) NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEnd] [datetimeoffset]
(
    7
) NULL,
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [CountryCallingCode] [varchar]
(
    20
) NULL,
    [PhoneNumber] [varchar]
(
    20
) NULL,
    [Email] [varchar]
(
    255
) NOT NULL,
    [NormalizedEmail] [varchar]
(
    255
) NOT NULL,
    [EmailConfirmed] [bit] NOT NULL,
    [CreationDate] [datetime2] NOT NULL,
    CONSTRAINT [PK_ApplicationUsers] PRIMARY KEY CLUSTERED
(
[
    Id] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO


/****** Object:  Table [dbo].[RoleClaims]    Script Date: 2020-08-11 12:43:34 ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[ApplicationRoleClaims]
(
    [
    Id] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [RoleId] [nvarchar]
(
    455
) NOT NULL,
    [ClaimType] [nvarchar]
(
    max
) NULL,
    [ClaimValue] [nvarchar]
(
    max
) NULL,
    CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED
(
[
    Id] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 2020-08-11 12:43:34 ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[ApplicationRoles]
(
    [
    Id] [
    nvarchar]
(
    455
) NOT NULL,
    [Name] [nvarchar]
(
    256
) NOT NULL,
    [NormalizedName] [nvarchar]
(
    256
) NOT NULL,
    [ConcurrencyStamp] [nvarchar]
(
    max
) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED
(
[
    Id] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 2020-08-11 12:43:34 ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[ApplicationUserClaims]
(
    [
    Id] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [UserId] [nvarchar]
(
    455
) NOT NULL,
    [ClaimType] [nvarchar]
(
    max
) NULL,
    [ClaimValue] [nvarchar]
(
    max
) NULL,
    CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED
(
[
    Id] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 2020-08-11 12:43:34 ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[ApplicationUserLogins]
(
    [
    LoginProvider] [
    nvarchar]
(
    450
) NOT NULL,
    [ProviderKey] [nvarchar]
(
    450
) NOT NULL,
    [ProviderDisplayName] [nvarchar]
(
    max
) NULL,
    [UserId] [nvarchar]
(
    455
) NOT NULL,
    CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED
(
    [
    LoginProvider]
    ASC,
[
    ProviderKey]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2020-08-11 12:43:34 ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[ApplicationUserRoles]
(
    [
    UserId] [
    nvarchar]
(
    455
) NOT NULL,
    [RoleId] [nvarchar]
(
    455
) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED
(
    [
    UserId]
    ASC,
[
    RoleId]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 2020-08-11 12:43:34 ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[ApplicationUserTokens]
(
    [
    UserId] [
    nvarchar]
(
    455
) NOT NULL,
    [LoginProvider] [nvarchar]
(
    450
) NOT NULL,
    [Name] [nvarchar]
(
    450
) NOT NULL,
    [Value] [nvarchar]
(
    max
) NULL,
    CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED
(
    [
    UserId]
    ASC, [
    LoginProvider]
    ASC,
[
    Name]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
ALTER TABLE [dbo].[ApplicationRoleClaims] WITH CHECK ADD CONSTRAINT [FK_ApplicationRoleClaims_ApplicationRoles_RoleId] FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[ApplicationRoles] ([Id])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[ApplicationRoleClaims] CHECK CONSTRAINT [FK_ApplicationRoleClaims_ApplicationRoles_RoleId]
    GO
ALTER TABLE [dbo].[ApplicationUserClaims] WITH CHECK ADD CONSTRAINT [FK_ApplicationUserClaims_ApplicationUsers_UserId] FOREIGN KEY ([UserId])
    REFERENCES [dbo].[ApplicationUsers] ([Id])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserClaims] CHECK CONSTRAINT [FK_ApplicationUserClaims_ApplicationUsers_UserId]
    GO
ALTER TABLE [dbo].[ApplicationUserLogins] WITH CHECK ADD CONSTRAINT [FK_ApplicationUserLogins_ApplicationUsers_UserId] FOREIGN KEY ([UserId])
    REFERENCES [dbo].[ApplicationUsers] ([Id])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserLogins] CHECK CONSTRAINT [FK_ApplicationUserLogins_ApplicationUsers_UserId]
    GO
ALTER TABLE [dbo].[ApplicationUserRoles] WITH CHECK ADD CONSTRAINT [FK_ApplicationUserRoles_ApplicationUsers_UserId] FOREIGN KEY ([UserId])
    REFERENCES [dbo].[ApplicationUsers] ([Id])
    ON
DELETE
CASCADE
	GO
ALTER TABLE [dbo].[ApplicationUserRoles] CHECK CONSTRAINT [FK_ApplicationUserRoles_ApplicationUsers_UserId]
    GO
ALTER TABLE [dbo].[ApplicationUserRoles] WITH CHECK ADD CONSTRAINT [FK_ApplicationUserRoles_ApplicationRoles_RoleId] FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[ApplicationRoles] ([Id])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserRoles] CHECK CONSTRAINT [FK_ApplicationUserRoles_ApplicationRoles_RoleId]
    GO
ALTER TABLE [dbo].[ApplicationUserTokens] WITH CHECK ADD CONSTRAINT [FK_ApplicationUserTokens_ApplicationUsers_UserId] FOREIGN KEY ([UserId])
    REFERENCES [dbo].[ApplicationUsers] ([Id])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserTokens] CHECK CONSTRAINT [FK_ApplicationUserTokens_ApplicationUsers_UserId]
    GO