CREATE PROCEDURE AgresoresDirecciones_DevolverPorAgresor

@IdAgresor INT

AS

SELECT
	ad.IdAgresorDireccion,
	ad.IdAgresor,
	ad.IdTipoDireccion,
	ad.IdLocalidad,
	ad.Calle,
	ad.Numero,
	ad.Departamento,
	ad.Piso
	FROM AgresoresDirecciones ad
	WHERE ad.IdAgresor = @IdAgresor
	ORDER BY ad.IdLocalidad, ad.IdTipoDireccion