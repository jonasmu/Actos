CREATE PROCEDURE Localidades_DevolverPorId

@IdLocalidad INT

AS

SELECT
	l.IdLocalidad,
	l.Nombre,
	l.CodigoArea
	FROM Localidades l
		WHERE l.IdLocalidad = @IdLocalidad