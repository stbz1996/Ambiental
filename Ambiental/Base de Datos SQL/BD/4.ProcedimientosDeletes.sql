USE Proyecto
GO

/*########################*/
CREATE PROC borrarAdministrador(
	@idAdministrador NUMERIC(10),
	@retorno nvarchar(1) out
)AS
BEGIN
set @retorno = 'Eliminado'
DELETE FROM Administrador
WHERE cedulaAdministrador = @idAdministrador
END
GO

/*########################*/
CREATE PROC borrarConsultante(
	@idConsultante NUMERIC(10),
	@retorno nvarchar(1) out
)AS
set @retorno = 'Eliminado'
DELETE FROM Consultante
WHERE cedulaConsultante = @idConsultante
GO

/*########################*/
CREATE PROC borrarDireccion(
	@idDireccion INT
)AS
BEGIN
DELETE FROM Direccion
WHERE idDireccion = @idDireccion
END
GO

/*########################*/
CREATE PROC borrarPersona(
	@cedula NUMERIC(10)
)AS
BEGIN
DELETE FROM Persona
WHERE cedula = @cedula 
END
GO
