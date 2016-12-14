CREATE PROCEDURE Antecedentes_Insertar

@IdAgresor INT,
@IdVictima INT,
@IdEstado TINYINT,
@Nombre VARCHAR(50),
@Fecha SMALLDATETIME,
@Ubicacion VARCHAR(50),
@Latitud FLOAT,
@Longitud FLOAT,
@Perjuicios VARCHAR(500),
@Observaciones VARCHAR(500)

AS

INSERT INTO Antecedentes
	(IdAgresor,
	IdVictima,
	IdEstado,
	Nombre,
	Fecha,
	Ubicacion,
	Latitud,
	Longitud,
	Perjuicios,
	Observaciones)
	VALUES
	(@IdAgresor,
	@IdVictima,
	@IdEstado,
	@Nombre,
	@Fecha,
	@Ubicacion,
	@Latitud,
	@Longitud,
	@Perjuicios,
	@Observaciones)

SELECT SCOPE_IDENTITY()