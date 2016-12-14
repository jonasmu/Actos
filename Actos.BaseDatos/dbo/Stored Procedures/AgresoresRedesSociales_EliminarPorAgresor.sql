CREATE PROCEDURE AgresoresRedesSociales_EliminarPorAgresor

@IdAgresor INT

AS

DELETE 
	FROM AgresoresRedesSociales
	WHERE IdAgresor =  @IdAgresor