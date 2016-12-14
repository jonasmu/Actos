CREATE PROCEDURE [dbo].[Agresores_Modificar]

@IdAgresor INT,
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@Apodo VARCHAR(50),
@Ocupacion VARCHAR(100),
@Caracteristicas VARCHAR(500),
@Metodos VARCHAR(500),
@EstaBorrado BIT,
@Foto IMAGE = NULL

AS

UPDATE Agresores SET
	Nombre = @Nombre,
	Apellido = @Apellido,
	Apodo = @Apodo,
	Ocupacion = @Ocupacion,
	Caracteristicas = @Caracteristicas,
	Metodos = @Metodos,
	EstaBorrado = @EstaBorrado,
	Foto = @Foto
	WHERE IdAgresor = @IdAgresor