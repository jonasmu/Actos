CREATE PROCEDURE TiposRedesSociales_DevolverTodos

AS

SELECT
	tr.IdTipoRedSocial,
	tr.Nombre
	FROM TiposRedesSociales tr
	ORDER BY tr.Nombre ASC