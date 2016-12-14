CREATE PROCEDURE AgresoresTelefonos_Insertar

@IdAgresor INT,
@IdLocalidad INT,
@IdTipoTelefono INT,
@Numero VARCHAR(8)

AS

INSERT INTO AgresoresTelefonos
	(IdAgresor,
	IdLocalidad,
	IdTipoTelefono,
	Numero)
	VALUES
	(@IdAgresor,
	@IdLocalidad,
	@IdTipoTelefono,
	@Numero)

SELECT SCOPE_IDENTITY()