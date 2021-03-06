﻿CREATE PROCEDURE [dbo].[Agresores_DevolverTodos]

AS

SELECT
	a.IdAgresor,
	a.Nombre,
	a.Apellido,
	a.Apodo,
	a.Ocupacion,
	a.Caracteristicas,
	a.Metodos,
	a.EstaBorrado,
	a.Foto,
	(SELECT COUNT(*)
		FROM AntecedentesVictimas av
			JOIN Antecedentes a2
				ON av.IdAntecedente = a2.IdAntecedente
		WHERE a2.IdAgresor = a.IdAgresor) AS Puntaje
	FROM Agresores a
	WHERE a.EstaBorrado = 0
	ORDER BY a.Nombre ASC