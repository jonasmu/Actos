CREATE PROCEDURE [dbo].[Victimas_Insertar]

@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@Apodo VARCHAR(50),
@Clave VARCHAR(50),
@EstaBorrado BIT

AS

INSERT INTO Victimas
	(Nombre,
	Apellido,
	Apodo,
	Clave,
	EstaBorrado)
	VALUES
	(@Nombre,
	@Apellido,
	@Apodo,
	@Clave,
	@EstaBorrado)

SELECT SCOPE_IDENTITY()