USE Proyecto
GO
/*Procedimientos necesarios para solicitar datos*/

/*###########################################*/
--Procedimiento que retorna el id del distrito
create proc buscarDistrito(
	@provincia nvarchar(50),
	@canton nvarchar(50),
	@distrito nvarchar(50),
	@retorno int output
)as
begin
	declare @idProv int
	SELECT @idProv = P.idProvincia FROM Provincia P where P.nombreProvincia = @provincia 
		
	declare @idCant int
	select @idCant = C.idCanton from Canton C 
	where C.nombreCanton = @canton and C.idProvincia = @idProv
		
	select @retorno =  D.idDistrito 
	from Distrito D where D.nombreDistrito = @distrito and D.idCanton = @idCant
end
go

/*###########################################*/
--Procedimiento que retorna el rol de una persona
create proc buscarRolAdmin(
	@cedula numeric(10),
	@retorno nvarchar(20) out
)as
begin 
	if(exists(select cedulaAdministrador from Administrador where cedulaAdministrador = @cedula))
		set @retorno = 'administrador'
	else
		begin
		if(exists(select cedulaConsultante from Consultante where cedulaConsultante = @cedula))
			set @retorno = 'consultante'
		else
			begin
				if(exists(select idGuardian from Guardian where idGuardian = @cedula))
					set @retorno = 'Guardian'
				else 
					begin
						if(exists(select idOficial from Oficial where idOficial = @cedula))
							set @retorno = 'Oficial'
						else
							begin
								if(exists(select idJuez from Juez where idJuez = @cedula))
									set @retorno = 'Juez'
								else 
									begin 
										set @retorno = 'Oculto'
									end
							end
					end
			end
		end
end
go

/*##############################################################################################################################*/
--Procedimiento para verificar la informacion brindada por el administrador

Create Procedure LoginAdmin(
    @user nvarchar(35), 
    @Pass nvarchar(1250),
    @Result nvarchar(10) Out
)As
    Declare @PassEncode nvarchar(400)
    Declare @PassDecode nvarchar(50)
Begin
    Select @PassEncode = passw, @Result = cedula From Persona Where username = @user
    Set @PassDecode = DECRYPTBYPASSPHRASE('c@r80n0-n3u7ra1', @PassEncode)
End 
Begin
    If @PassDecode <> @Pass
		Set @Result = 'Incorrecto'
End
Go

/*###########################################*/
--Procedimiento para verificar la informacion brindada por el usuario
create Procedure LoginUsuario(
    @user nvarchar(35), 
    @Pass nvarchar(1250),
    @Result nvarchar(10) Out
)As
    Declare @PassEncode nvarchar(400)
    Declare @PassDecode nvarchar(50)
Begin
    Select @PassEncode = passw, @Result = cedula From Persona Where username = @user
    Set @PassDecode = DECRYPTBYPASSPHRASE('c@r80n0-n3u7ra1', @PassEncode)
End 
Begin
	
    If @PassDecode <> @Pass
		Set @Result = 'Incorrecto'
	else
		begin
			declare @estado BIT
			exec obtenerEstadoUsuario @user, @estado output
			if @estado <> 1
				set @Result = 'Desactivado'
		end
End
GO

/*###########################################*/
--Procedimiento que retorna el id de un canton
CREATE PROC obtenerCantonDenuncia
(
	@idDenuncia INT,
	@idCanton INT OUT
)AS
BEGIN 
	SELECT @idCanton = C.idCanton
	FROM Denuncia D
	INNER JOIN Direccion Dir
		ON Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dis
		ON Dis.idDistrito = Dir.idDistrito
	INNER JOIN Canton C
		ON C.idCanton = Dis.idCanton
	WHERE D.idDenuncia = @idDenuncia
END
GO

--No estoy seguro si estamos usando este procedimiento
/*
create proc obtenerDenunciasPorProvincia(
	@idJuez numeric(10)
)as
begin
	declare @idProvinciaDeluez int 
	exec buscarProvinciaJuez @idJuez, @idProvinciaDeluez output
	select *
	from Denuncia D
	inner join Direccion Dir
		on Dir.idDireccion = D.idDireccion
	inner join Distrito Dis
		on Dis.idDistrito = Dir.idDireccion
	inner join Canton C
		on C.idCanton = Dis.idCanton
	inner join Provincia P
		on P.idProvincia = @idProvinciaDeluez
end*/



/*###########################################*/
--Procedimiento que retorna el id del distrito
CREATE PROC obtenerDistritoDenuncia
(
	@idDenuncia INT,
	@idDistrito INT OUT
)AS
BEGIN 
	SELECT @idDistrito = dis.idDistrito
	FROM Denuncia D
	INNER JOIN Direccion Dir
		ON Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dis
		ON Dis.idDistrito = Dir.idDistrito
	where D.idDenuncia = @idDenuncia
END
GO

/*###########################################*/
--Procedimiento que retorna el estado de una Denuncia
CREATE PROC obtenerEstadoUsuario(
	@user nvarchar(20),
	@estado BIT OUTPUT
)AS
BEGIN 
	SELECT @estado = U.estadoActivo
	FROM Usuario U
	INNER JOIN Persona P
		ON U.idUsuario = P.cedula
	WHERE P.username = @user
END
GO

/*###########################################*/
--Procedimiento que retorna el id de la ultima denuncia creada
CREATE PROC obtenerIdDenuncia(
	@idGuardian NUMERIC(10),
	@retorno INT OUT
)AS
BEGIN
	select top 1 @retorno = idDenuncia
	from Denuncia 
	where idGuardian = @idGuardian
	order by idDenuncia DESC
END
GO

/*###########################################*/
--Procedimiento que retorna el id de la ultima solucion creada
CREATE PROC obtenerIdSolucion(
	@idOficial NUMERIC(10),
	@retorno INT OUT
)AS
BEGIN
	SELECT TOP 1 @retorno = idSolucion
	FROM Solucion
	WHERE idOficial = @idOficial
	ORDER BY idSolucion DESC
END
GO

/*###########################################*/
--Procedimiento que retorna el nombre de la provincia del juez
CREATE PROC obtenerProvinciaJuez(
	@idJuez NUMERIC (10),
	@nombreProvincia NVARCHAR(50) OUT
)AS
BEGIN
	SELECT @nombreProvincia = Prov.nombreProvincia
	FROM Juez J
	INNER JOIN Persona P
		ON J.idJuez = P.cedula
	INNER JOIN Direccion Dir
		ON P.idDireccion = Dir.idDireccion
	INNER JOIN Distrito Dis
		ON Dir.idDistrito = Dis.idDistrito
	INNER JOIN Canton C
		ON Dis.idCanton = C.idCanton
	INNER JOIN Provincia Prov
		ON C.idProvincia = Prov.idProvincia
	WHERE J.idJuez = @idJuez
END
GO

/*###########################################*/
--Procedimiento que retorna los puntos de un usuario
CREATE PROC obtenerPuntos(
	@idUsuario NUMERIC(10)
)AS
BEGIN
	SELECT U.puntos 
	FROM Usuario U
    WHERE U.idUsuario = @idUsuario
END
GO

/*###########################################*/
CREATE PROC evaluarProvinciaJuez(
	@idJuez NUMERIC (10)
)AS
BEGIN
	DECLARE @nombreProvincia NVARCHAR(50)
	EXEC obtenerProvinciaJuez @idJuez, @nombreProvincia OUTPUT
	SELECT @nombreProvincia
END
