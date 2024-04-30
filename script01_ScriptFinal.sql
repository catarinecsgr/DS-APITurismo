IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AtrativoTuristicos] (
    [IdAtrativo] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [Foto] varbinary(max) NULL,
    [Gratuidade] nvarchar(max) NOT NULL,
    [DiaGratuidade] nvarchar(max) NOT NULL,
    [Regiao] int NOT NULL,
    CONSTRAINT [PK_AtrativoTuristicos] PRIMARY KEY ([IdAtrativo])
);
GO

CREATE TABLE [TipoTuristicos] (
    [IdTipo] int NOT NULL IDENTITY,
    [Segmento] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TipoTuristicos] PRIMARY KEY ([IdTipo])
);
GO

CREATE TABLE [AtrativoTipos] (
    [IdAtrativo] int NOT NULL,
    [IdTipo] int NOT NULL,
    CONSTRAINT [PK_AtrativoTipos] PRIMARY KEY ([IdAtrativo], [IdTipo]),
    CONSTRAINT [FK_AtrativoTipos_AtrativoTuristicos_IdAtrativo] FOREIGN KEY ([IdAtrativo]) REFERENCES [AtrativoTuristicos] ([IdAtrativo]) ON DELETE CASCADE,
    CONSTRAINT [FK_AtrativoTipos_TipoTuristicos_IdTipo] FOREIGN KEY ([IdTipo]) REFERENCES [TipoTuristicos] ([IdTipo]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAtrativo', N'DiaGratuidade', N'Endereco', N'Foto', N'Gratuidade', N'Nome', N'Regiao') AND [object_id] = OBJECT_ID(N'[AtrativoTuristicos]'))
    SET IDENTITY_INSERT [AtrativoTuristicos] ON;
INSERT INTO [AtrativoTuristicos] ([IdAtrativo], [DiaGratuidade], [Endereco], [Foto], [Gratuidade], [Nome], [Regiao])
VALUES (1, N'Terça e 1ª Quinta de cada mês', N'Av. Paulista, 1578, Bela Vista, São Paulo - SP', NULL, N'V', N'MASP', 5),
(2, N'Todos os dias', N'Av. Rio Branco, 1269, Campos Elíseos, São Paulo - SP', NULL, N'V', N'Museu das Favelas', 5),
(3, N'Sábado', N'Praça da Luz, 2, Luz, São Paulo - SP', NULL, N'V', N'Pinacoteca do Estado', 5),
(4, N'Sábado', N'Praça da Luz, s/n, Luz, São Paulo - SP', NULL, N'V', N'Museu da Língua Portuguesa', 5),
(5, N'Todos os dias', N'R. Álvares Penteado, 112, Centro Histórico de São Paulo, São Paulo - SP', NULL, N'V', N'CCBB SP', 5),
(6, N'Todos os dias', N'Av. Pedro Álvares Cabral, 5300, Vila Mariana, São Paulo - SP', NULL, N'V', N'Parque do Ibirapuera', 4),
(7, N'Todos os dias', N'Av. Prof. Fonseca Rodrigues, 2001, Alto de Pinheiros, São Paulo - SP', NULL, N'V', N'Parque Villa-Lobos', 3),
(8, N'Todos os dias', N'Av. Afonso de Sampaio e Sousa, 951, Itaquera, São Paulo - SP', NULL, N'V', N'Parque do Carmo', 2),
(9, N'Todos os dias', N'Av. Francisco Matarazzo, 455, Água Branca, São Paulo - SP', NULL, N'V', N'Parque da Água Branca', 3),
(10, N'Todos os dias', N'Av. Henrique Chamma, 420, Pinheiros, São Paulo - SP', NULL, N'V', N'Parque do Povo', 3),
(11, N' ', N'R. Américo de Campos, 36, Liberdade, São Paulo - SP', NULL, N'F', N'Alteza Doceria', 5),
(12, N' ', N'Av. São Luís, 187, piso 02, lj 02, República, São Paulo - SP', NULL, N'F', N'Gatcha (Cat Café/Cat Matcha Café)', 5),
(13, N' ', N'R. Maria Cândida, 1153, Vila Guilherme, São Paulo - SP', NULL, N'F', N'Antique Café', 1),
(14, N' ', N'Av. Ipiranga, 200-21, Centro Histórico de São Paulo, São Paulo - SP', NULL, N'F', N'Café Floresta', 5),
(15, N' ', N'R. Silveira Martins, 86, lj 02, Sé, São Paulo - SP', NULL, N'F', N'Cafeteria Gosto de Grão', 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAtrativo', N'DiaGratuidade', N'Endereco', N'Foto', N'Gratuidade', N'Nome', N'Regiao') AND [object_id] = OBJECT_ID(N'[AtrativoTuristicos]'))
    SET IDENTITY_INSERT [AtrativoTuristicos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTipo', N'Segmento') AND [object_id] = OBJECT_ID(N'[TipoTuristicos]'))
    SET IDENTITY_INSERT [TipoTuristicos] ON;
INSERT INTO [TipoTuristicos] ([IdTipo], [Segmento])
VALUES (1, N'Museu'),
(2, N'Parque'),
(3, N'Cafeteria');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTipo', N'Segmento') AND [object_id] = OBJECT_ID(N'[TipoTuristicos]'))
    SET IDENTITY_INSERT [TipoTuristicos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAtrativo', N'IdTipo') AND [object_id] = OBJECT_ID(N'[AtrativoTipos]'))
    SET IDENTITY_INSERT [AtrativoTipos] ON;
INSERT INTO [AtrativoTipos] ([IdAtrativo], [IdTipo])
VALUES (1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(6, 2),
(7, 2),
(8, 2),
(9, 2),
(10, 2),
(11, 3),
(12, 3),
(13, 3),
(14, 3),
(15, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAtrativo', N'IdTipo') AND [object_id] = OBJECT_ID(N'[AtrativoTipos]'))
    SET IDENTITY_INSERT [AtrativoTipos] OFF;
GO

CREATE INDEX [IX_AtrativoTipos_IdTipo] ON [AtrativoTipos] ([IdTipo]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240429114141_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

