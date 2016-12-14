CREATE PROCEDURE [dbo].[Agresores_Insertar]

@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@Apodo VARCHAR(50),
@Ocupacion VARCHAR(100),
@Caracteristicas VARCHAR(500),
@Metodos VARCHAR(500),
@EstaBorrado BIT,
@Foto IMAGE = NULL

AS

INSERT INTO Agresores
	(Nombre,
	Apellido,
	Apodo,
	Ocupacion,
	Caracteristicas,
	Metodos,
	EstaBorrado,
	Foto)
	VALUES
	(@Nombre,
	@Apellido,
	@Apodo,
	@Ocupacion,
	@Caracteristicas,
	@Metodos,
	@EstaBorrado,
	@Foto)

SELECT SCOPE_IDENTITY()