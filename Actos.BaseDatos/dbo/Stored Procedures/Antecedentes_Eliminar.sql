CREATE PROCEDURE [dbo].[Antecedentes_Eliminar]

@IdAntecedente INT

AS

DELETE
	FROM Antecedentes
	WHERE IdAntecedente = @IdAntecedente