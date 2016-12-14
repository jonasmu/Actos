CREATE PROCEDURE Estados_DevolverTodos

AS

SELECT
	e.IdEstado,
	e.Nombre
	FROM Estados e
	ORDER BY e.Nombre ASC