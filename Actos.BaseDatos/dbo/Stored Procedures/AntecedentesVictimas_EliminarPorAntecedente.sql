CREATE PROCEDURE AntecedentesVictimas_EliminarPorAntecedente

@IdAntecedente INT

AS

DELETE
	FROM AntecedentesVictimas
	WHERE IdAntecedente = @IdAntecedente