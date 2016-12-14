CREATE PROCEDURE AgresoresRedesSociales_DevolverPorAgresor

@IdAgresor INT

AS

SELECT
	ars.IdAgresorRedSocial,
	ars.IdAgresor,
	ars.IdTipoRedSocial,
	ars.Nombre
	FROM AgresoresRedesSociales ars
	WHERE ars.IdAgresor = @IdAgresor
	ORDER BY ars.IdTipoRedSocial