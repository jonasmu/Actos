CREATE PROCEDURE [dbo].[Victimas_DevolverTodos]

AS

SELECT
	v.IdVictima,
	v.Nombre,
	v.Apellido,
	v.Apodo,
	v.Clave,
	v.EstaBorrado
	FROM Victimas v
	WHERE EstaBorrado = 0
	ORDER BY v.Nombre ASC