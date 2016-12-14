CREATE PROCEDURE AgresoresTelefonos_DevolverPorAgresor

@IdAgresor INT

AS

SELECT
	at.IdAgresorTelefono,
	at.IdAgresor,
	at.IdLocalidad,
	at.IdTipoTelefono,
	at.Numero
	FROM AgresoresTelefonos at
	WHERE at.IdAgresor = @IdAgresor
	ORDER BY at.IdTipoTelefono