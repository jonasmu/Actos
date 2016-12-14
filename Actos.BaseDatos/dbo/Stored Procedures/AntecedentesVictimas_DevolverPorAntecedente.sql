CREATE PROCEDURE AntecedentesVictimas_DevolverPorAntecedente

@IdAntecedente INT

AS

SELECT
	av.IdAntecedente,
	av.IdVictima
	FROM AntecedentesVictimas av
	WHERE av.IdAntecedente = @IdAntecedente