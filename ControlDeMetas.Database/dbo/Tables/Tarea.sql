CREATE TABLE [dbo].[Tarea] (
    [Id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [IdMeta]       BIGINT        NOT NULL,
    [Importante] BIT  DEFAULT ((0)) NOT NULL,
    [Nombre]        NVARCHAR (50) NOT NULL,
    [FechaCreacion] DATETIME      CONSTRAINT [DF_Tarea_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [Estatus]       INT           CONSTRAINT [DF_Tarea_Estatus] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tarea_Meta] FOREIGN KEY ([IdMeta]) REFERENCES [dbo].[Meta] ([Id])
);

