CREATE PROCEDURE TiposDirecciones_DevolverTodos

AS

SELECT
	td.IdTipoDireccion,
	td.Nombre
	FROM TiposDirecciones td
	ORDER BY td.Nombre ASC