CREATE TABLE [dbo].[Localidades] (
    [IdLocalidad] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
    [CodigoArea]  VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED ([IdLocalidad] ASC)
);

