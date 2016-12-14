CREATE PROCEDURE [dbo].[Victimas_Modificar]

@IdVictima INT,
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@Apodo VARCHAR(50),
@Clave VARCHAR(50),
@EstaBorrado BIT

AS

UPDATE Victimas SET
	Nombre = @Nombre,
	Apellido = @Apellido,
	Apodo = @Apodo,
	Clave = @Clave,
	EstaBorrado = @EstaBorrado
	WHERE IdVictima = @IdVictima