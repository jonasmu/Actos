CREATE PROCEDURE AntecedentesVictimas_Insertar

@IdAntecedente INT,
@IdVictima INT

AS

INSERT INTO AntecedentesVictimas
	(IdAntecedente,
	IdVictima)
	VALUES
	(@IdAntecedente,
	@IdVictima)