CREATE TABLE [dbo].[AgresoresRedesSociales] (
    [IdAgresorRedSocial] INT          IDENTITY (1, 1) NOT NULL,
    [IdAgresor]          INT          NOT NULL,
    [IdTipoRedSocial]    TINYINT      NOT NULL,
    [Nombre]             VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AgresoresRedesSociales] PRIMARY KEY CLUSTERED ([IdAgresorRedSocial] ASC),
    CONSTRAINT [FK_AgresoresRedesSociales_Agresores] FOREIGN KEY ([IdAgresor]) REFERENCES [dbo].[Agresores] ([IdAgresor]),
    CONSTRAINT [FK_AgresoresRedesSociales_TiposRedesSociales] FOREIGN KEY ([IdTipoRedSocial]) REFERENCES [dbo].[TiposRedesSociales] ([IdTipoRedSocial])
);

