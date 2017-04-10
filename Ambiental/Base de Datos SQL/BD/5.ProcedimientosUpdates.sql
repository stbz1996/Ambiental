USE Proyecto
GO

/*##############################*/
CREATE PROC actualizarDireccion(
	@idUsuario NUMERIC(10),
	@idDistrito INT,
	@detalle NVARCHAR(500)
)AS
BEGIN
	UPDATE Dir SET Dir.idDistrito = @idDistrito,
				   Dir.detalle = @detalle 
	FROM Direccion Dir
	INNER JOIN Persona P
		ON Dir.idDireccion = P.idDireccion
	WHERE P.cedula = @idUsuario
END
GO

/*##############################*/
CREATE PROC agregarGradoDenuncia(
	@idDenuncia INT,
	@grado char(1)

)AS
BEGIN
	UPDATE Denuncia 
	SET categoria = @grado
	WHERE idDenuncia = @idDenuncia

END
GO

/*##############################*/
CREATE PROC cambiarDatosDenuncia(
	@idDenuncia INT,
	@titulo NVARCHAR(30),
	@descripcion NVARCHAR(500),
	@foto VARBINARY(MAX)
)AS
BEGIN
	UPDATE Denuncia SET titulo = @titulo,
						descripcion = @descripcion,
						foto = @foto
	WHERE idDenuncia = @idDenuncia
END
GO

/*##############################*/
CREATE PROC cambiarDatosUsuario(
	@idUsuario NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@email NVARCHAR(50),
	@telefono NUMERIC(8),
	@provincia NVARCHAR(50),
	@canton NVARCHAR(50),
	@distrito NVARCHAR(50),
	@detalle NVARCHAR(500),
	@fechaNacimiento DATE,
	@username NVARCHAR(20)
)AS
BEGIN
	DECLARE @idDistrito INT
	exec buscarDistrito @provincia, @canton, @distrito, @idDistrito output
	exec actualizarDireccion @idUsuario, @idDistrito, @detalle
	UPDATE P SET P.primerNombre = @primerNombre,
				 P.segundoNombre = @segundoNombre,
				 P.primerApellido = @primerApellido,
				 P.segundoApellido = @segundoApellido,
				 P.email = @email,
				 P.telefono = @telefono,
				 P.fechaNacimiento = @fechaNacimiento,
				 P.username = @username
	FROM Persona P
	WHERE P.cedula = @idUsuario
END
GO

/*##############################*/
CREATE PROC cambiarEstadoDenuncia(
	@idDenuncia int,
	@nuevoEstado nvarchar(20),
	@idJuez numeric(10)
)as
BEGIN
	UPDATE D SET D.estado = @nuevoEstado
	FROM Denuncia D
	WHERE idDenuncia = @idDenuncia
	if(@nuevoEstado = 'En Proceso')
		begin
			/* crea la notificacioGuardian*/
			declare @fecha DATE = GETDATE()
			exec insertarNotificacionguardian @fecha, 1, @idDenuncia
			declare @idNotificacion int =  @@IDENTITY
			/* Obtiene canton denunci */
			declare @idDistritoDenuncia int
			exec obtenerDistritoDenuncia @idDenuncia, @idDistritoDenuncia out
			/* Envia Notificaciones */
			insert into NotificacionGuardianXGuardian(idNotificacionGuardian, idGuardian)
				select @idNotificacion, G.idGuardian 
			from Guardian G
			inner join Persona P on P.cedula = G.idGuardian
			inner join Direccion D on D.idDireccion = P.idDireccion
			inner join Distrito dis on dis.idDistrito = D.idDistrito
			where dis.idDistrito = @idDistritoDenuncia
			/* inserta en la tabla denunciaXjuez para tener el registro de cual juez edito la denuncia*/
			exec insertarDenunciaXJuez @idDenuncia, @idJuez
		end
END
GO

/*##############################*/
CREATE PROC cambiarEstadoSolucion(
	@idSolucion INT
)AS
BEGIN
	UPDATE Solucion SET validacion = 1
	WHERE idSolucion = @idSolucion 
END
GO

/*##############################*/
CREATE PROC sumarPuntos(
	@idUsuario NUMERIC(10),
	@valor INT
)AS
BEGIN
	UPDATE Usuario set puntos = puntos + @valor
	WHERE idUsuario = @idUsuario
END
GO

/*##############################*/
CREATE PROC cambiarEstadoActivo(
	@idUsuario NUMERIC(10),
	@retorno nvarchar(10) out
)AS
begin
	UPDATE Usuario SET estadoActivo = 1
	WHERE idUsuario = @idUsuario
end
GO

/*##############################*/
CREATE PROC cambiarEstadoDesactivo(
	@idUsuario NUMERIC(10),
	@retorno nvarchar(10) out
)AS
begin
	UPDATE Usuario SET estadoActivo = 0
	WHERE idUsuario = @idUsuario
end
GO

