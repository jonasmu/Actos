CREATE TABLE [dbo].[TiposTelefonos] (
    [IdTipoTelefono] TINYINT      NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TiposTelefonos] PRIMARY KEY CLUSTERED ([IdTipoTelefono] ASC)
);

