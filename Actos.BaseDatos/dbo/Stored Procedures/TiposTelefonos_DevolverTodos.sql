CREATE PROCEDURE TiposTelefonos_DevolverTodos

AS

SELECT
	tt.IdTipoTelefono,
	tt.Nombre
	FROM TiposTelefonos tt
	ORDER BY tt.Nombre ASC