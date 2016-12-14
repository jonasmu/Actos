CREATE PROCEDURE Localidades_Eliminar

@IdLocalidad INT

AS

DELETE
	FROM Localidades
	WHERE IdLocalidad = @IdLocalidad