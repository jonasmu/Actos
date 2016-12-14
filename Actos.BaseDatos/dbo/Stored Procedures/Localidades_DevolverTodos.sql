CREATE PROCEDURE [dbo].[Localidades_DevolverTodos]

AS

SELECT
	l.IdLocalidad,
	l.Nombre,
	l.CodigoArea
	FROM Localidades l
		ORDER BY l.Nombre ASC