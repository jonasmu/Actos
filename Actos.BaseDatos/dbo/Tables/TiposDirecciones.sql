CREATE TABLE [dbo].[TiposDirecciones] (
    [IdTipoDireccion] TINYINT      NOT NULL,
    [Nombre]          VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TiposDirecciones] PRIMARY KEY CLUSTERED ([IdTipoDireccion] ASC)
);

