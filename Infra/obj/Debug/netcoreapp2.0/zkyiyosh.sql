IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clients] (
    [ClientId] int NOT NULL IDENTITY,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181001194944_InitialCreate', N'2.1.3-rtm-32065');

GO

EXEC sp_rename N'[Clients].[ClientId]', N'IdCliente', N'COLUMN';

GO

ALTER TABLE [Clients] ADD [Ativo] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Clients] ADD [Codclie] nvarchar(max) NULL;

GO

ALTER TABLE [Clients] ADD [CpfCnpj] nvarchar(max) NULL;

GO

ALTER TABLE [Clients] ADD [DataAlteracao] datetime2 NULL;

GO

ALTER TABLE [Clients] ADD [DataCadastro] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Clients] ADD [DataNascimento] datetime2 NULL;

GO

ALTER TABLE [Clients] ADD [EstadoCivil] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Clients] ADD [Genero] int NULL;

GO

ALTER TABLE [Clients] ADD [InscricaoEstadual] nvarchar(max) NULL;

GO

ALTER TABLE [Clients] ADD [RazaoSocial] nvarchar(max) NULL;

GO

ALTER TABLE [Clients] ADD [Rg] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181001205432_InitialCreate2', N'2.1.3-rtm-32065');

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'Rg');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Clients] ALTER COLUMN [Rg] varchar(12) NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'RazaoSocial');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Clients] ALTER COLUMN [RazaoSocial] varchar(200) NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'InscricaoEstadual');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Clients] ALTER COLUMN [InscricaoEstadual] varchar(14) NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'CpfCnpj');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Clients] ALTER COLUMN [CpfCnpj] varchar(12) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181001211551_InitialCreate3', N'2.1.3-rtm-32065');

GO

