CREATE TABLE [dbo].[Meta] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (50)  NOT NULL,
    [FechaCreacion] DATETIME       CONSTRAINT [DF_Meta_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [TareasCompletadas]   INT            CONSTRAINT [DF_Meta_TareasCompletadas] DEFAULT ((0)) NOT NULL,
    [TotalTareas]   INT            CONSTRAINT [DF_Meta_TotalTareas] DEFAULT ((0)) NOT NULL,
    [Cumplimiento]  DECIMAL (5, 2) CONSTRAINT [DF_Meta_Cumplimiento] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Meta] PRIMARY KEY CLUSTERED ([Id] ASC)
);

