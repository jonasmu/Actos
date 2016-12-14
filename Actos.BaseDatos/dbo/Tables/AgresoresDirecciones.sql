CREATE TABLE [dbo].[AgresoresDirecciones] (
    [IdAgresorDireccion] INT          IDENTITY (1, 1) NOT NULL,
    [IdAgresor]          INT          NOT NULL,
    [IdLocalidad]        INT          NOT NULL,
    [IdTipoDireccion]    TINYINT      NOT NULL,
    [Calle]              VARCHAR (50) NOT NULL,
    [Numero]             VARCHAR (50) NOT NULL,
    [Departamento]       VARCHAR (4)  NOT NULL,
    [Piso]               VARCHAR (3)  NOT NULL,
    CONSTRAINT [PK_AgresoresDirecciones] PRIMARY KEY CLUSTERED ([IdAgresorDireccion] ASC),
    CONSTRAINT [FK_AgresoresDirecciones_Agresores] FOREIGN KEY ([IdAgresor]) REFERENCES [dbo].[Agresores] ([IdAgresor]),
    CONSTRAINT [FK_AgresoresDirecciones_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_AgresoresDirecciones_TiposDirecciones] FOREIGN KEY ([IdTipoDireccion]) REFERENCES [dbo].[TiposDirecciones] ([IdTipoDireccion])
);



