CREATE PROCEDURE AgresoresRedesSociales_Insertar

@IdAgresor INT,
@IdTipoRedSocial INT,
@Nombre VARCHAR(50)

AS

INSERT INTO AgresoresRedesSociales
	(IdAgresor,
	IdTipoRedSocial,
	Nombre)
	VALUES
	(@IdAgresor,
	@IdTipoRedSocial,
	@Nombre)

SELECT SCOPE_IDENTITY()