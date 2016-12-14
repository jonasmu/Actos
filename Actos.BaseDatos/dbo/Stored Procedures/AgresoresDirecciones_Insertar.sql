CREATE PROCEDURE AgresoresDirecciones_Insertar

@IdAgresor INT,
@IdLocalidad INT,
@IdTipoDireccion INT,
@Calle VARCHAR(50),
@Numero VARCHAR(50),
@Departamento VARCHAR(4),
@Piso VARCHAR(3)

AS

INSERT INTO AgresoresDirecciones
	(IdAgresor,
	IdLocalidad,
	IdTipoDireccion,
	Calle,
	Numero,
	Departamento,
	Piso)
	VALUES
	(@IdAgresor,
	@IdLocalidad,
	@IdTipoDireccion,
	@Calle,
	@Numero,
	@Departamento,
	@Piso)

SELECT SCOPE_IDENTITY()