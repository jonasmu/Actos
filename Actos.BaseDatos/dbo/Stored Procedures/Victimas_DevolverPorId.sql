CREATE PROCEDURE [dbo].[Victimas_DevolverPorId]

@IdVictima INT

AS

SELECT
	v.IdVictima,
	v.Nombre,
	v.Apellido,
	v.Apodo,
	v.Clave,
	v.EstaBorrado
	FROM Victimas v
	WHERE v.IdVictima = @IdVictima