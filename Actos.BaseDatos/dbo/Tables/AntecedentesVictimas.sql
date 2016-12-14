CREATE TABLE [dbo].[AntecedentesVictimas] (
    [IdAntecedente] INT NOT NULL,
    [IdVictima]     INT NOT NULL,
    CONSTRAINT [PK_AntecedentesVictimas] PRIMARY KEY CLUSTERED ([IdAntecedente] ASC, [IdVictima] ASC),
    CONSTRAINT [FK_AntecedentesVictimas_Antecedentes] FOREIGN KEY ([IdAntecedente]) REFERENCES [dbo].[Antecedentes] ([IdAntecedente]),
    CONSTRAINT [FK_AntecedentesVictimas_Victimas] FOREIGN KEY ([IdVictima]) REFERENCES [dbo].[Victimas] ([IdVictima])
);

