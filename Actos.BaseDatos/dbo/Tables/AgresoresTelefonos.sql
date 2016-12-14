CREATE TABLE [dbo].[AgresoresTelefonos] (
    [IdAgresorTelefono] INT         IDENTITY (1, 1) NOT NULL,
    [IdAgresor]         INT         NOT NULL,
    [IdTipoTelefono]    TINYINT     NOT NULL,
    [IdLocalidad]       INT         NOT NULL,
    [Numero]            VARCHAR (8) NOT NULL,
    CONSTRAINT [PK_AgresoresTelefonos] PRIMARY KEY CLUSTERED ([IdAgresorTelefono] ASC),
    CONSTRAINT [FK_AgresoresTelefonos_Agresores] FOREIGN KEY ([IdAgresor]) REFERENCES [dbo].[Agresores] ([IdAgresor]),
    CONSTRAINT [FK_AgresoresTelefonos_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_AgresoresTelefonos_TiposTelefonos] FOREIGN KEY ([IdTipoTelefono]) REFERENCES [dbo].[TiposTelefonos] ([IdTipoTelefono])
);

