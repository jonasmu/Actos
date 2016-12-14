CREATE PROCEDURE Localidades_Insertar

@Nombre VARCHAR(50),
@CodigoArea VARCHAR(50)

AS

INSERT INTO Localidades
	(Nombre,
	CodigoArea)
	VALUES
	(@Nombre,
	@CodigoArea)

SELECT SCOPE_IDENTITY()