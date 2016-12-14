CREATE PROCEDURE Antecedentes_Modificar

@IdAntecedente INT,
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

UPDATE Antecedentes SET
	IdAgresor = @IdAgresor,
	IdVictima = @IdVictima,
	IdEstado = @IdEstado,
	Nombre = @Nombre,
	Fecha = @Fecha,
	Ubicacion = @Ubicacion,
	Latitud = @Latitud,
	Longitud = @Longitud,
	Perjuicios = @Perjuicios,
	Observaciones = @Observaciones
	WHERE IdAntecedente = @IdAntecedente