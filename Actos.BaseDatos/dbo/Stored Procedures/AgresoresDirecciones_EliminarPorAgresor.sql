CREATE PROCEDURE AgresoresDirecciones_EliminarPorAgresor

@IdAgresor INT

AS

DELETE 
	FROM AgresoresDirecciones
	WHERE IdAgresor =  @IdAgresor