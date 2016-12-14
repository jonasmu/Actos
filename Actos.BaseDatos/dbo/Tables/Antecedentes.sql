CREATE TABLE [dbo].[Antecedentes] (
    [IdAntecedente] INT           IDENTITY (1, 1) NOT NULL,
    [IdEstado]      TINYINT       NOT NULL,
    [IdVictima]     INT           NOT NULL,
    [IdAgresor]     INT           NOT NULL,
    [Nombre]        VARCHAR (50)  NOT NULL,
    [Fecha]         SMALLDATETIME NOT NULL,
    [Ubicacion]     VARCHAR (50)  NOT NULL,
    [Latitud]       FLOAT (53)    NOT NULL,
    [Longitud]      FLOAT (53)    NOT NULL,
    [Observaciones] VARCHAR (500) NOT NULL,
    [Perjuicios]    VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Antecedentes] PRIMARY KEY CLUSTERED ([IdAntecedente] ASC),
    CONSTRAINT [FK_Antecedentes_Agresores] FOREIGN KEY ([IdAgresor]) REFERENCES [dbo].[Agresores] ([IdAgresor]),
    CONSTRAINT [FK_Antecedentes_Estados] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[Estados] ([IdEstado]),
    CONSTRAINT [FK_Antecedentes_Victimas] FOREIGN KEY ([IdVictima]) REFERENCES [dbo].[Victimas] ([IdVictima])
);



