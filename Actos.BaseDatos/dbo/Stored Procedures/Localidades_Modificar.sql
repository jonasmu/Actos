CREATE PROCEDURE Localidades_Modificar

@IdLocalidad INT,
@Nombre VARCHAR(50),
@CodigoArea VARCHAR(50)

AS

UPDATE Localidades SET
	Nombre = @Nombre,
	CodigoArea = @CodigoArea
	WHERE IdLocalidad = @IdLocalidad