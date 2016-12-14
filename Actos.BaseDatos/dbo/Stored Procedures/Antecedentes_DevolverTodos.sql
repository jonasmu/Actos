CREATE PROCEDURE [dbo].[Antecedentes_DevolverTodos]

AS

SELECT
	a.IdAntecedente,
	a.IdAgresor,
	a.IdVictima,
	a.IdEstado,
	a.Nombre,
	a.Fecha,
	a.Ubicacion,
	a.Latitud,
	a.Longitud,
	a.Perjuicios,
	a.Observaciones
	FROM Antecedentes a
	ORDER BY a.Fecha DESC