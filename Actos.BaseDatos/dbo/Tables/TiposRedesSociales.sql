CREATE TABLE [dbo].[TiposRedesSociales] (
    [IdTipoRedSocial] TINYINT      NOT NULL,
    [Nombre]          VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TiposRedesSociales] PRIMARY KEY CLUSTERED ([IdTipoRedSocial] ASC)
);

