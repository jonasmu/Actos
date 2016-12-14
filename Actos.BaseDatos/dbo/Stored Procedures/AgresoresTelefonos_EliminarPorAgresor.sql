CREATE PROCEDURE AgresoresTelefonos_EliminarPorAgresor

@IdAgresor INT

AS

DELETE 
	FROM AgresoresTelefonos
	WHERE IdAgresor =  @IdAgresor