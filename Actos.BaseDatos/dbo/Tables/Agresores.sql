CREATE TABLE [dbo].[Agresores] (
    [IdAgresor]       INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]          VARCHAR (50)  NOT NULL,
    [Apellido]        VARCHAR (50)  NOT NULL,
    [Apodo]           VARCHAR (50)  NOT NULL,
    [Ocupacion]       VARCHAR (100) NOT NULL,
    [Caracteristicas] VARCHAR (500) NOT NULL,
    [Metodos]         VARCHAR (500) NOT NULL,
    [EstaBorrado]     BIT           NOT NULL,
    [Foto]            IMAGE         NULL,
    CONSTRAINT [PK_Agresores] PRIMARY KEY CLUSTERED ([IdAgresor] ASC)
);

