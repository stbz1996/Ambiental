USE Proyecto
GO

/*###########################*/
CREATE PROC insertarAporte(
	@fecha datetime,
	@foto varbinary(MAX),
	@valor int,
	@idTipoAporte int,
	@idUsuario numeric(10)
)as
BEGIN
	exec sumarPuntos @idUsuario, @valor
	insert into Aporte(fecha, foto, valor, idTipoAporte, idUsuario)
	values(@fecha, @foto, @valor, @idTipoAporte, @idUsuario)
END
GO

/*###########################*/
CREATE PROC insertarCanton(
	@nombreCanton nvarchar(50), 
	@idProvincia int	
)as
begin
	insert into Canton(nombreCanton, idProvincia)
	values(@nombreCanton, @idProvincia)
end
go

/*###########################*/
CREATE PROC insertarDenuncia(
	@titulo NVARCHAR(40),
	@latitud FLOAT(10),
	@longitud FLOAT(10),
	@descripcion NVARCHAR(500),
	@foto VARBINARY(MAX),
	@idGuardian NUMERIC(10),
	@provincia NVaRCHAR(50),
	@canton NVaRCHAR(50),
	@distrito NVaRCHAR(50),
	@detalle VARCHAR(500)
)as
begin
	/* inserta la denuncia */
	declare @idDistrito int
	declare @idDireccion int
	exec buscarDistrito @provincia, @canton, @distrito, @idDistrito output
	exec insertarDireccion @detalle, @idDistrito
	set @idDireccion = @@IDENTITY
	insert into Denuncia(categoria, titulo, latitud, longitud, estado, descripcion, foto, idGuardian, idDireccion)
	values(NULL, @titulo, @latitud, @longitud, 'Registrado', @descripcion, @foto, @idGuardian,  @idDireccion)
	declare @idDenuncia int = @@IDENTITY
	/* crea la notificacionJuez unica*/
	exec insertarNotificacionJuez @idDenuncia
	declare @idNotificacionJuez int =  @@IDENTITY
	/* Envia notificaciones */
	declare @idcantonDenuncia int
	exec obtenerCantonDenuncia @idDenuncia, @idcantonDenuncia out-- guarda el idcanton de la denuncia
	declare @id numeric(10)
	/* todos los jueces del canton */
	insert into NotificacionJuezXJuez(idNotificacionJuez, idJuez)
		select @idNotificacionJuez, J.idJuez 
		from Juez J
		inner join Persona P on P.cedula = J.idJuez
		inner join Direccion D on D.idDireccion = P.idDireccion
		inner join Distrito dis on dis.idDistrito = D.idDistrito
		where dis.idCanton = @idcantonDenuncia
end
go

/*###########################*/
CREATE PROC insertarDenunciaXJuez(
	@idDenuncia INT,
	@idJuez NUMERIC(10) 
)AS
BEGIN
INSERT INTO DenunciaXJuez(idDenuncia, idJuez)
VALUES(@idDenuncia, @idJuez)
END
GO

/*###########################*/
CREATE PROC insertarDireccion(
	@detalle NVARCHAR (500),
	@idDistrito INT
)as
begin
	insert into Direccion(detalle, idDistrito)
	values(@detalle, @idDistrito)
END 
GO

/*###########################*/
CREATE PROC insertarDistrito(
	@nombreDistrito nvarchar(50),
	@idCanton int
)as
begin
	insert into Distrito(nombreDistrito, idCanton)
	values(@nombreDistrito, @idCanton)
end 
GO

/*###########################*/
CREATE PROC insertarGuardian(
	@cedula NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@fechaNacimiento DATE,
	@username NVARCHAR(35),
	@passw NVARCHAR(35),
	@telefono NUMERIC(8),
	@email NVARCHAR(50),
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@detalle nvarchar(500),
	@mensaje nvarchar(100) out
)as
begin
	exec insertarPersona @cedula, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido,
		 @fechaNacimiento, @username, @passw, @telefono, @email, @provincia, @canton,
		 @distrito, @detalle, @mensaje out
	if @mensaje <> 'La cedula ya está registrada en el sistema'
		begin
		insert into Usuario(puntos, estadoActivo, idUsuario) values(0, 1, @cedula)
		insert into Guardian(idGuardian) values (@cedula)
		set @mensaje = 'registrado'
		end
	else
		set @mensaje = 'no registrado'
end
go

/*###########################*/
CREATE PROC insertarHashtagDenuncia
(
	@idGuardian NUMERIC(10),
	@nombreHashtag NVARCHAR(50)
)AS
BEGIN
	DECLARE @idDenuncia INT
	exec obtenerIdDenuncia @idGuardian, @idDenuncia OUTPUT
	
	INSERT INTO HashtagDenuncia (idDenuncia, hashtag) 
	values(@idDenuncia, @nombreHashtag)
END
GO

/*###########################*/
CREATE PROC insertarHashtagSolucion
(
	@idOficial NUMERIC(10),
	@nombreHashtag NVARCHAR(50)

)AS
BEGIN
	DECLARE @idSolucion INT
	EXEC obtenerIdSolucion @idOficial, @idSolucion OUT
	INSERT INTO HashtagSolucion(idSolucion, hashtag)
	VALUES(@idSolucion, @nombreHashtag)
END
GO

/*###########################*/
CREATE PROC insertarJuez
(
	@cedula NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@fechaNacimiento DATE,
	@username NVARCHAR(35),
	@passw NVARCHAR(35),
	@telefono NUMERIC(8),
	@email NVARCHAR(50),
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@detalle nvarchar(500),
	@mensaje nvarchar(100) out
)as
begin
	exec insertarPersona @cedula, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido,
		 @fechaNacimiento, @username, @passw, @telefono, @email, @provincia, @canton,
		 @distrito, @detalle, @mensaje out
	if @mensaje <> 'La cedula ya está registrada en el sistema'
		begin
		insert into Usuario(puntos, estadoActivo, idUsuario) values(0, 1, @cedula)
		insert into Juez(idJuez) values (@cedula)
		set @mensaje = 'registrado'
		end
	else
		set @mensaje = 'no registrado'
end
GO

/*###########################*/
CREATE PROC insertarNotificacionGuardian(
	@fecha DATE,
	@estado BIT,
	@idDenuncia INT
)as
BEGIN
	insert into NotificacionGuardian(fecha, estado, idDenuncia)
	values(@fecha, @estado, @idDenuncia)
END
GO

/*###########################*/
CREATE PROC insertarNotificacionGuardianXGuardian(
	@idNotificacionGuardian INT,
	@idGuardian NUMERIC(10)
)as
BEGIN
	insert into NotificacionGuardianXGuardian(idNotificacionGuardian, idGuardian)
	values(@idNotificacionGuardian, @idGuardian)
END
GO

/*###########################*/
CREATE PROC insertarNotificacionJuez(
	@idDenuncia INT
)as
BEGIN
	insert into NotificacionJuez(fecha, estado, idDenuncia)
	values(GETDATE(), 1, @idDenuncia)
END
GO

/*###########################*/
CREATE PROC insertarNotificacionSolucionJuez(
	@fecha DATE,
	@estado BIT,
	@idDenuncia INT
)as
BEGIN
	insert into NotificacionSolucionJuez(fecha,estado,idDenuncia)
	values(@fecha,@estado,@idDenuncia)
END
GO

/*###########################*/
CREATE PROC insertarOficial(
	@cedula NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@fechaNacimiento DATE,
	@username NVARCHAR(35),
	@passw NVARCHAR(35),
	@telefono NUMERIC(8),
	@email NVARCHAR(50),
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@detalle nvarchar(500),
	@mensaje nvarchar(100) out
)as
begin
	exec insertarPersona @cedula, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido,
		 @fechaNacimiento, @username, @passw, @telefono, @email, @provincia, @canton,
		 @distrito, @detalle, @mensaje out
	if @mensaje <> 'La cedula ya está registrada en el sistema'
		begin
		insert into Usuario(puntos, estadoActivo, idUsuario) values(0, 1, @cedula)
		insert into Oficial(idOficial) values (@cedula)
		set @mensaje = 'registrado'
		end
	else
		set @mensaje = 'no registrado'
end
GO

/*###########################*/
CREATE PROC insertarPersona(
	@cedula NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@fechaNacimiento DATE,
	@username NVARCHAR(35),
	@passw NVARCHAR(35),
	@telefono NUMERIC(8),
	@email NVARCHAR(50),
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@detalle nvarchar(500),
	@mensaje nvarchar(100) out
)as
begin
	if (exists(select cedula from Persona where cedula = @cedula)) 
		set @mensaje = 'La cedula ya está registrada en el sistema'
	else
		begin
			declare @idDistrito int 
			declare @idDireccion int
			exec buscarDistrito @provincia, @canton, @distrito, @idDistrito output
			exec insertarDireccion @detalle, @idDistrito
			set @idDireccion = @@IDENTITY
			insert into Persona(cedula, primerNombre, segundoNombre, primerApellido, SegundoApellido,
			fechaNacimiento, username, passw, idDireccion, telefono, email)
			values (@cedula, @primerNombre, @segundoNombre, @primerApellido, @SegundoApellido,
			@fechaNacimiento, @username, ENCRYPTBYPASSPHRASE('c@r80n0-n3u7ra1', @passw), @idDireccion, @telefono, @email)
			set @mensaje = 'Registrado correctamente'
		end
end
GO

/*###########################*/
CREATE PROC insertarProvincia(
	@nombreProvincia nvarchar(50)
)as
begin 
	insert into Provincia(nombreProvincia)
	values(@nombreProvincia)
end 
GO

/*###########################*/
CREATE PROC insertarSolucion(
	@titulo NVARCHAR(40),
	@foto varbinary(max),
	@descripcion NVARCHAR(100),
	@idDenuncia INT,
	@idOficial NUMERIC(10)
)as
BEGIN
	insert into Solucion(titulo,foto,validacion,descripcion,fecha,estadoEnvio,idDenuncia,idOficial)
	values(@titulo,@foto,0,@descripcion,getdate(),null,@idDenuncia,@idOficial)
	declare @idsolucion int = @@Identity 
	/* se le envia al juez que confirmo la denuncia */
	declare @idJuez numeric(10)
	select @idJuez = idJuez from DenunciaXJuez
	where idDenuncia = @idDenuncia

	insert into SolucionXJuez(idSolucion, idJuez)
	values(@idsolucion, @idJuez)
END
GO

/*###########################*/
CREATE PROC insertarTipoAporte(
	@nombre nvarchar(50)
)as
BEGIN
	insert into TipoAporte(nombre)
	values(@nombre)
END
GO

/*###########################*/
create proc insertarAdministrador(
	@cedula NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@fechaNacimiento DATE,
	@username NVARCHAR(20),
	@passw NVARCHAR(15),
	@telefono NUMERIC(8),
	@email NVARCHAR(50),
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@detalle nvarchar(500),
	@mensaje nvarchar(100) out
)as
begin
	exec insertarPersona @cedula, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido,
		 @fechaNacimiento, @username, @passw, @telefono, @email, @provincia, @canton,
		 @distrito, @detalle, @mensaje out
	if @mensaje <> 'La cedula ya está registrada en el sistema'
		begin
		insert into Administrador(cedulaAdministrador) values (@cedula)
		set @mensaje = 'registrado'
		end
	else
		set @mensaje = 'no registrado'
end
go

/*###########################*/
create proc insertarConsultante(
	@cedula NUMERIC(10),
	@primerNombre NVARCHAR(20),
	@segundoNombre NVARCHAR(20),
	@primerApellido NVARCHAR(20),
	@segundoApellido NVARCHAR(20),
	@fechaNacimiento DATE,
	@username NVARCHAR(20),
	@passw NVARCHAR(15),
	@telefono NUMERIC(8),
	@email NVARCHAR(50),
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@detalle nvarchar(500),
	@mensaje nvarchar(100) out
)as
begin
	exec insertarPersona @cedula, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido,
		 @fechaNacimiento, @username, @passw, @telefono, @email, @provincia, @canton,
		 @distrito, @detalle, @mensaje out
	if @mensaje <> 'La cedula ya está registrada en el sistema'
		begin
		insert into Consultante(cedulaConsultante) values (@cedula)
		set @mensaje = 'registrado'
		end
	else
		set @mensaje = 'no registrado'
end
go

/*###########################*/
create proc insertarEnBitacora(
	@fecha datetime,
	@descripcion nvarchar(max),
	@idQuienLaRealizó numeric(10),
	@retorno nvarchar(10) out
)as
begin 
	set @retorno = 'Correcto'
	insert into Bitacora(fecha, descripcion, idQuienLaRealizó)
	values(getdate(), @descripcion, @idQuienLaRealizó)
end 
go