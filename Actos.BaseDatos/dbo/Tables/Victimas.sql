CREATE TABLE [dbo].[Victimas] (
    [IdVictima]   INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
    [Apellido]    VARCHAR (50) NOT NULL,
    [Apodo]       VARCHAR (50) NOT NULL,
    [Clave]       VARCHAR (50) NOT NULL,
    [EstaBorrado] BIT          NOT NULL,
    CONSTRAINT [PK_Victimas] PRIMARY KEY CLUSTERED ([IdVictima] ASC)
);



