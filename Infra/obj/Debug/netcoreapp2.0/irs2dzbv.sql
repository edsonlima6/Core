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

