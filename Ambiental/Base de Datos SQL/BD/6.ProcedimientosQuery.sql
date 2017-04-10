USE Proyecto
GO


/*###########################*/
CREATE PROC cargarCantones(
	@provincia nvarchar(50)
)
as
begin
	select C.nombreCanton from Canton C
	inner join Provincia P
		on P.nombreProvincia = @provincia
	where C.idProvincia = P.idProvincia
end
GO

/*###########################*/
CREATE PROC cargarDistritos(
	@canton nvarchar(50)
)
as
begin
	select D.nombreDistrito from Distrito D
	inner join Canton P
		on P.nombreCanton = @canton
	where D.idCanton = P.idCanton
end
GO

/*###########################*/
CREATE PROC cargarProvincias
as
begin
	select nombreProvincia from Provincia
end
GO

/*###########################*/
CREATE PROC consultaDenunciaEspecifica(
	@idDenuncia INT
)AS
BEGIN
	SELECT D.titulo, D.descripcion, Prov.nombreProvincia, C.nombreCanton, Dis.nombreDistrito, Dir.detalle, D.foto, D.idGuardian, D.estado
	FROM Denuncia D
	INNER JOIN Direccion Dir
		ON D.idDireccion = Dir.idDireccion
	INNER JOIN Distrito Dis
		ON Dir.idDistrito = Dis.idDistrito
	INNER JOIN Canton C
		ON Dis.idCanton = C.idCanton
	INNER JOIN Provincia Prov
		ON C.idProvincia = Prov.idProvincia
	WHERE D.idDenuncia = @idDenuncia
END
GO

/*###########################*/
CREATE PROC consultaDenunciasGuardian(
	@idGuardian NUMERIC(10)
)AS
BEGIN
	SELECT D.idDenuncia, D.titulo, P.nombreProvincia, C.nombreCanton, Dis.nombreDistrito, Dir.detalle, D.estado
	 FROM Denuncia D
	 INNER JOIN Direccion Dir
		ON D.idDireccion = Dir.idDireccion
	INNER JOIN Distrito Dis
		ON Dis.idDistrito = Dir.idDistrito
	INNER JOIN Canton C
		ON C.idCanton = Dis.idCanton
	INNER JOIN Provincia P
		ON P.idProvincia = C.idProvincia
	WHERE D.idGuardian = @idGuardian
END
GO

/*###########################*/
CREATE PROC consultaDenunciasJuez(
	@idJuez NUMERIC(10)
)AS
BEGIN
	DECLARE @nombreProvincia NVARCHAR(50)
	EXEC obtenerProvinciaJuez @idJuez, @nombreProvincia OUTPUT
	
	SELECT D.idDenuncia, D.titulo, NJ.fecha, Prov.nombreProvincia, C.nombreCanton, Dis.nombreDistrito, Dir.detalle
	FROM Denuncia D
	INNER JOIN NotificacionJuez NJ
		ON D.idDenuncia = NJ.idDenuncia
	INNER JOIN Direccion Dir
		ON D.idDireccion = Dir.idDireccion
	INNER JOIN Distrito Dis
		ON Dir.idDistrito = Dis.idDistrito
	INNER JOIN Canton C
		ON Dis.idCanton = C.idCanton
	INNER JOIN Provincia Prov
		ON C.idProvincia = Prov.idProvincia
	WHERE (D.estado = 'Registrado') AND (Prov.nombreProvincia = @nombreProvincia)
	
END
GO

/*###########################*/
CREATE PROC consultaDenunciasOficial
AS
BEGIN
	SELECT D.idDenuncia, D.titulo, NJ.fecha, P.nombreProvincia, C.nombreCanton, Dis.nombreDistrito, Dir.detalle
	FROM Denuncia D
	INNER JOIN NotificacionJuez NJ
		ON NJ.idDenuncia = D.idDenuncia
	INNER JOIN Direccion Dir
		ON Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dis
		ON Dis.idDistrito = Dir.idDistrito
	INNER JOIN Canton C
		ON C.idCanton = Dis.idCanton
	INNER JOIN Provincia P
		ON P.idProvincia = C.idProvincia
	WHERE D.estado = 'En Proceso'
END
GO

/*###########################*/
CREATE PROC consultaPersona(
	@idUsuario NUMERIC(10)
)AS
BEGIN
	SELECT P.cedula, P.primerNombre, P.segundoNombre,
		   P.primerApellido, P.segundoApellido, P.email, P.telefono, Prov.nombreProvincia, C.nombreCanton,
		   Dis.nombreDistrito, Dir.detalle, P.fechaNacimiento,
		   P.username
	FROM Persona P
	INNER JOIN Direccion Dir
		ON P.idDireccion = Dir.idDireccion
	INNER JOIN Distrito Dis
		ON Dir.idDistrito = Dis.idDistrito
	INNER JOIN Canton C
		ON Dis.idCanton = C.idCanton
	INNER JOIN Provincia Prov
		ON C.idProvincia = Prov.idProvincia
	WHERE P.cedula = @idUsuario
END
GO

/*###########################*/
CREATE PROC consultarSolucionesJuez(
	@idJuez NUMERIC(10)
)AS
BEGIN
	SELECT S.idSolucion, S.titulo, S.fecha
	FROM Solucion S
	INNER JOIN SolucionXJuez SJ
		ON S.idSolucion = SJ.idSolucion
	WHERE (SJ.idJuez = @idJuez) AND (S.validacion = 0)
END
GO

/*###########################*/
CREATE PROC consultaSolucionJuez(
	@idSolucion INT
)AS
BEGIN
	SELECT S.titulo, S.descripcion, S.fecha, S.foto
	FROM Solucion S
	WHERE S.idSolucion = @idSolucion
END
GO

/*###########################*/
CREATE PROC consultaTipoAporte
AS
BEGIN
	SELECT nombre
	FROM TipoAporte
END
GO

/*###########################*/
CREATE PROC finalizarDenuncia(
	@idSolucion INT,
	@nuevoEstado NVARCHAR(20),
	@idJuez NUMERIC(10)
)AS
BEGIN
	DECLARE @idDenuncia INT
	SELECT @idDenuncia = idDenuncia
	FROM Solucion
	WHERE idSolucion = @idSolucion
	EXEC cambiarEstadoDenuncia @idDenuncia, @nuevoEstado, @idJuez
END
GO

/*##################################################################################*/
create proc listadoPersonas 
as
begin
	select * from Persona P
	order by P.primerNombre, P.segundoNombre, P.primerApellido, p.segundoApellido
end
go

/*##################################################################################*/
create proc listadoGuardianes
as
begin
	select * from Persona P
	inner join Guardian G
		on G.idGuardian = P.cedula 
	order by P.primerNombre, P.segundoNombre, P.primerApellido, p.segundoApellido
end
go

/*##################################################################################*/
create proc listadoOficiales
as
begin
	select * from Persona P
	inner join Oficial G
		on G.idOficial = P.cedula 
	order by P.primerNombre, P.segundoNombre, P.primerApellido, p.segundoApellido
end
go

/*##################################################################################*/
create proc listadoJueces
as
begin
	select * from Persona P
	inner join Juez G
		on G.idJuez = P.cedula 
	order by P.primerNombre, P.segundoNombre, P.primerApellido, p.segundoApellido
end
go

/*##################################################################################*/
create proc listadoConsultantes
as
begin
	select * from Persona P
	inner join Consultante G
		on G.cedulaConsultante = P.cedula 
	order by P.primerNombre, P.segundoNombre, P.primerApellido, p.segundoApellido
end
go

/*##################################################################################*/
create proc listadoAdministradores
as
begin
	select * from Persona P
	inner join Administrador G
		on G.cedulaAdministrador = P.cedula 
	order by P.primerNombre, P.segundoNombre, P.primerApellido, p.segundoApellido
end
go

/*##################################################################################*/
create proc cargarDistritor(
	@canton nvarchar(50)
)
as
begin
	select D.nombreDistrito from Distrito D
	inner join Canton P
		on P.nombreCanton = @canton
	where D.idCanton = P.idCanton
end
go

/*##################################################################################*/
create proc estaActivado(
	@cedula numeric (10),
	@resultado nvarchar(20) out
)as
begin
	if(exists(select U.estadoActivo from Usuario U where U.idUsuario = @cedula and U.estadoActivo = 1))
		begin
		set @resultado = 'Activo'
		end
	else
		begin
			if(exists(select U.estadoActivo from Usuario U where U.idUsuario = @cedula and U.estadoActivo = 0))
				set @resultado = 'Inactivo'
			else 
				set @resultado = 'Autoridad'
		end	
end

go


 



/*##################################################################################*/
-- Punto 1
CREATE PROC consultaGeneralUsuarios
AS
BEGIN
	SELECT U.idUsuario, P.primerNombre + ' ' +P.primerApellido,
	 P.username, P.telefono , U.estadoActivo, P.email, U.puntos
	FROM Usuario U
	INNER JOIN Persona P
		ON U.idUsuario = P.cedula
	ORDER BY P.primerNombre, P.primerApellido ASC
END
GO

/*#############################################*/
--Esta repitiendo procedimiento consultaGravedadDenuncia y consultaDenuncia
CREATE PROC consultaGravedadDenuncia AS
BEGIN
	Select D.estado, COUNT(D.estado) total,
					 COUNT(case D.categoria WHEN 'L' THEN 1 ELSE NULL END) Leve,
					 COUNT(case D.categoria WHEN 'R' THEN 1 ELSE NULL END) Regular, 
					 COUNT(case D.categoria WHEN 'G' THEN 1 ELSE NULL END) Grave 
	FROM Denuncia D
	GROUP BY D.estado
END 
GO

/*#############################################*/
CREATE PROC consultaDenuncia AS
BEGIN
Select D.estado, COUNT(D.estado) total,
                 COUNT(case D.categoria WHEN 'L' THEN 1 ELSE NULL END) Leve,
                 COUNT(case D.categoria WHEN 'R' THEN 1 ELSE NULL END) Regular, 
				 COUNT(case D.categoria WHEN 'G' THEN 1 ELSE NULL END) Grave 
FROM Denuncia D
GROUP BY D.estado
END
GO

/*#############################################*/
CREATE PROC consultaDenunciaFiltroXFechas (
	@inicial DATE,
	@final DATE
)AS
BEGIN
Select D.estado, COUNT(D.estado) total,
                 COUNT(case D.categoria WHEN 'L' THEN 1 ELSE NULL END) Leve,
                 COUNT(case D.categoria WHEN 'R' THEN 1 ELSE NULL END) Regular, 
				 COUNT(case D.categoria WHEN 'G' THEN 1 ELSE NULL END) Grave 
FROM Denuncia D
INNER JOIN NotificacionJuez NJ
	ON NJ.idDenuncia = D.idDenuncia
WHERE NJ.fecha BETWEEN @inicial and @final 
GROUP BY D.estado
END 
GO

/*#############################################*/
CREATE PROC consultaDenunciaFiltroXProvincia (
	@provincia NVARCHAR(50)
)AS
BEGIN
SELECT D.estado, COUNT(D.estado) total,
                 COUNT(case D.categoria WHEN 'L' THEN 1 ELSE NULL END) Leve,
                 COUNT(case D.categoria WHEN 'R' THEN 1 ELSE NULL END) Regular, 
				 COUNT(case D.categoria WHEN 'G' THEN 1 ELSE NULL END) Grave 
FROM Denuncia D
INNER JOIN Direccion Dir on Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Dis on Dis.idDistrito = Dir.idDistrito
INNER JOIN Canton C on C.idCanton = Dis.idCanton
INNER JOIN Provincia P on P.idProvincia = C.idProvincia
WHERE P.nombreProvincia = @provincia GROUP BY D.estado
END 
GO

/*#############################################*/
CREATE PROC consultaDenunciaFiltroXCanton (
	@canton NVARCHAR(50)
)AS
BEGIN
SELECT D.estado, COUNT(D.estado) total,
                 COUNT(case D.categoria WHEN 'L' THEN 1 ELSE NULL END) Leve,
                 COUNT(case D.categoria WHEN 'R' THEN 1 ELSE NULL END) Regular, 
				 COUNT(case D.categoria WHEN 'G' THEN 1 ELSE NULL END) Grave 
FROM Denuncia D
INNER JOIN Direccion Dir on Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Dis on Dis.idDistrito = Dir.idDistrito
INNER JOIN Canton C on C.idCanton = Dis.idCanton
WHERE C.nombreCanton = @canton GROUP BY D.estado
END 
GO

/*#############################################*/
CREATE PROC consultaDenunciaFiltroXDistrito (
	@distrito NVARCHAR(50)
)AS
BEGIN
SELECT D.estado, COUNT(D.estado) total,
                 COUNT(case D.categoria WHEN 'L' THEN 1 ELSE NULL END) Leve,
                 COUNT(case D.categoria WHEN 'R' THEN 1 ELSE NULL END) Regular, 
				 COUNT(case D.categoria WHEN 'G' THEN 1 ELSE NULL END) Grave 
FROM Denuncia D
INNER JOIN Direccion Dir on Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Dis on Dis.idDistrito = Dir.idDistrito
WHERE Dis.nombreDistrito = @distrito GROUP BY D.estado
END 
GO
/*#############################################*/
--Punto 5
create proc conteoDenunciasRechazadas(
	@cantidad int
)AS
BEGIN
	SELECT P.username usuario, COUNT(case D.estado when 'Rechazada' then 1 else null end) Rechazadas
	FROM Denuncia D
	INNER JOIN Persona P 
		ON P.cedula = D.idGuardian 
	GROUP BY P.username
	HAVING COUNT(case D.estado when 'Rechazada' then 1 else null end) >= @cantidad
END
GO
/* Filtro */
create proc conteoDenunciasRechazadasFiltroXFecha(
	@cantidad int,
	@fecha DATE
)AS
BEGIN
	SELECT P.username usuario, COUNT(case D.estado when 'Rechazada' then 1 else null end) Rechazadas
	FROM Denuncia D
	INNER JOIN Persona P 
		ON P.cedula = D.idGuardian 
	INNER JOIN NotificacionJuez NJ
		on NJ.idDenuncia = D.idDenuncia
	GROUP BY P.username, NJ.fecha
HAVING COUNT(case D.estado when 'Rechazada' then 1 else null end) >= @cantidad and NJ.fecha = @fecha 
END
GO
/*#############################################*/
-- Punto 6
CREATE PROC consultaAportePorMes(
	@fechaInicial DATE,
	@fechaFinal DATE
)AS
BEGIN
	SELECT TA.nombre, COUNT(TA.nombre) Total, YEAR(a.fecha) Año, 
					  MONTH(a.fecha) Mes, DAY(a.fecha) Día
	FROM Aporte A 
	INNER JOIN TipoAporte TA
		on TA.idTipoAporte = A.idTipoAporte
	WHERE A.fecha BETWEEN @fechaInicial and @fechaFinal
	GROUP BY TA.nombre, A.fecha
	ORDER BY A.fecha
END 
GO
/*##################################################################################*/
-- Punto 3
CREATE PROC consultaDenunciasFiltroFecha (
	@inicial DATE,
	@limite DATE
)AS 
BEGIN
	SELECT D.titulo, D.descripcion, NJ.fecha, P.username, Prov.nombreProvincia, 
	Cant.nombreCanton, Dist.nombreDistrito, D.estado, 'ocultos' FROM Denuncia D
	INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
	INNER JOIN Guardian G ON G.idGuardian = D.idGuardian
	INNER JOIN Persona P ON P.cedula = G.idGuardian
	INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dist ON Dist.idDistrito = Dir.idDistrito
	INNER JOIN Canton Cant ON Cant.idCanton = Dist.idCanton
	INNER JOIN Provincia Prov ON Prov.idProvincia = Cant.idProvincia
	WHERE NJ.fecha BETWEEN @inicial AND @limite
END
GO
/*###############################################################*/
CREATE PROC consultaDenunciasFiltroProvincia(
	@provincia NVARCHAR(50)
)AS 
BEGIN
	SELECT D.titulo, D.descripcion, NJ.fecha, P.username, Prov.nombreProvincia, 
	Cant.nombreCanton, Dist.nombreDistrito, D.estado, 'ocultos' FROM Denuncia D
	INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
	INNER JOIN Guardian G ON G.idGuardian = D.idGuardian
	INNER JOIN Persona P ON P.cedula = G.idGuardian
	INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dist ON Dist.idDistrito = Dir.idDistrito
	INNER JOIN Canton Cant ON Cant.idCanton = Dist.idCanton
	INNER JOIN Provincia Prov ON Prov.idProvincia = Cant.idProvincia
	WHERE Prov.nombreProvincia = @provincia
END
GO
/*#########################################################################*/
CREATE PROC consultaDenunciasFiltroCanton(
	@canton nvarchar(50)
)AS 
SELECT D.titulo, D.descripcion, NJ.fecha, P.username, Prov.nombreProvincia, 
Cant.nombreCanton, Dist.nombreDistrito, D.estado, 'ocultos' FROM Denuncia D
INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
INNER JOIN Guardian G ON G.idGuardian = D.idGuardian
INNER JOIN Persona P ON P.cedula = G.idGuardian
INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Dist ON Dist.idDistrito = Dir.idDistrito
INNER JOIN Canton Cant ON Cant.idCanton = Dist.idCanton
INNER JOIN Provincia Prov ON Prov.idProvincia = Cant.idProvincia
where Cant.nombreCanton = @canton
go

/*###############################################################*/
CREATE PROC consultaDenunciasFiltroDistrito(
	@distrito nvarchar(50)
)AS
SELECT D.titulo, D.descripcion, NJ.fecha, P.username, Prov.nombreProvincia, 
Cant.nombreCanton, Dist.nombreDistrito, D.estado, 'ocultos' FROM Denuncia D
INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
INNER JOIN Guardian G ON G.idGuardian = D.idGuardian
INNER JOIN Persona P ON P.cedula = G.idGuardian
INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Dist ON Dist.idDistrito = Dir.idDistrito
INNER JOIN Canton Cant ON Cant.idCanton = Dist.idCanton
INNER JOIN Provincia Prov ON Prov.idProvincia = Cant.idProvincia
where Dist.nombreDistrito = @distrito
GO
/*###############################################################*/

CREATE PROC consultaDenunciasFiltroHashtag(
	@hashtag NVARCHAR(50)
)AS
BEGIN
declare @hash NVARCHAR(50) = RTRIM(@hashtag) + '%'
SELECT D.titulo, D.descripcion, NJ.fecha, P.username, Prov.nombreProvincia, 
       C.nombreCanton, Dis.nombreDistrito, D.estado, H.hashtag
FROM Denuncia D 
	iNNER JOIN NotificacionJuez NJ	ON NJ.idDenuncia = D.idDenuncia
	INNER JOIN Persona P ON P.cedula = D.idGuardian
	INNER JOIN Direccion Dir on Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dis on Dis.idDistrito = Dir.idDistrito
	INNER JOIN Canton C on C.idCanton = Dis.idCanton
	INNER JOIN Provincia Prov ON Prov.idProvincia = C.idProvincia
	INNER JOIN HashtagDenuncia H on H.idDenuncia = D.idDenuncia
	WHERE  H.hashtag like @hash
END 
GO
/*###############################################################*/

--Punto 9
CREATE PROC consultaTopDenuncias(
	@top INT
)AS
BEGIN
SELECT TOP(@top) P.username,
	   COUNT(case D.estado  when 'En Proceso' then 1 else null end) Aceptadas,
	   COUNT(case D.estado  when 'Rechazada' then 1 else null end) Rechazadas  
	FROM Guardian G
	INNER JOIN Persona P
		ON P.cedula	= G.idGuardian
	INNER JOIN Denuncia D
		ON D.idGuardian = G.idGuardian
	GROUP BY P.username
	ORDER BY (COUNT(case D.estado  when 'En Proceso' then 1 else null end) +
	         COUNT(case D.estado  when 'Rechazada' then 1 else null end)) desc
END
GO


/*##################################################################################*/
--Punto 10
CREATE PROC consultaTopSolucion(
	@cantidad INT
)AS
BEGIN
	SELECT TOP(@cantidad) P.username, COUNT(S.idSolucion) Total,
					COUNT(case S.validacion  when 1 then 1 else null end) Aceptadas,
				    COUNT(case S.validacion  when 0 then 1 else null end) Rechazadas
	FROM Oficial O
	INNER JOIN Persona P ON P.cedula = O.idOficial
	INNER JOIN Solucion S ON S.idOficial = O.idOficial
	WHERE S.validacion IS NOT NULL 
	GROUP BY P.username
	ORDER BY Total desc
END
GO


/*##################################################################################*/
--Punto 11
CREATE PROC consultaTopJuezXDenunciaEvaluadas(
	@cantidad INT
)AS
BEGIN
	SELECT TOP(@cantidad) P.username, 
					COUNT(case S.estado  when 'En Proceso' then 1 else null end) Aceptadas,
				    COUNT(case S.estado  when 'Rechazada' then 1 else null end) Rechazadas,
					COUNT(S.estado) Total
	FROM Juez O
	INNER JOIN Persona P ON P.cedula = O.idJuez
	INNER JOIN DenunciaXJuez DJ ON DJ.idJuez = O.idJuez
	INNER JOIN Denuncia S  ON S.idDenuncia = DJ.idDenuncia
	GROUP BY P.username
	ORDER BY Total desc
END
GO
/*##################################################################################*/

--Punto 12
CREATE PROC consultaDenunciasConSolucion 
AS
BEGIN
SELECT D.titulo, D.descripcion, PersonaG.username usuarioGuardian, NJ.fecha, 
       PersonaJ.username usuarioJuez, S.descripcion, S.fecha, S.validacion
FROM Denuncia D
	INNER JOIN (SELECT P.username, G.idGuardian FROM Guardian G
				INNER JOIN Persona P ON P.cedula = G.idGuardian
				)PersonaG
		ON PersonaG.idGuardian = D.idGuardian

	INNER JOIN DenunciaXJuez DJ
		ON DJ.idDenuncia = D.idDenuncia

	INNER JOIN(SELECT P.username, J.idJuez FROM Juez J
			   INNER JOIN Persona P ON P.cedula = J.idJuez
			  )PersonaJ
		ON PersonaJ.idJuez = DJ.idJuez

	INNER JOIN NotificacionJuez NJ
		ON NJ.idDenuncia = D.idDenuncia

	INNER JOIN Solucion S
		ON S.idDenuncia = D.idDenuncia
END
GO

/* Filtros */
CREATE PROC consultaDenunciasConSolucionFiltroPorFecha(
	@fecha DATE
)AS
BEGIN
SELECT D.titulo, D.descripcion, PersonaG.username usuarioGuardian, NJ.fecha, 
       PersonaJ.username usuarioJuez, S.descripcion, S.fecha, S.validacion
FROM Denuncia D
INNER JOIN (SELECT P.username, G.idGuardian FROM Guardian G
			INNER JOIN Persona P ON P.cedula = G.idGuardian
			)PersonaG
	ON PersonaG.idGuardian = D.idGuardian
INNER JOIN DenunciaXJuez DJ
	ON DJ.idDenuncia = D.idDenuncia
INNER JOIN(SELECT P.username, J.idJuez FROM Juez J
		   INNER JOIN Persona P ON P.cedula = J.idJuez
		  )PersonaJ
	ON PersonaJ.idJuez = DJ.idJuez
INNER JOIN NotificacionJuez NJ
	ON NJ.idDenuncia = D.idDenuncia
INNER JOIN Solucion S
	ON S.idDenuncia = D.idDenuncia
WHERE S.fecha = @fecha
END
GO

/* Filtros */
CREATE PROC consultaDenunciasConSolucionFiltroPorProvincia(
	@provincia NVARCHAR(50)
)AS
BEGIN
SELECT D.titulo, D.descripcion, PersonaG.username usuarioGuardian, NJ.fecha, 
       PersonaJ.username usuarioJuez, S.descripcion, S.fecha, S.validacion
FROM Denuncia D
INNER JOIN (SELECT P.username, G.idGuardian FROM Guardian G
			INNER JOIN Persona P ON P.cedula = G.idGuardian
			)PersonaG
	ON PersonaG.idGuardian = D.idGuardian
INNER JOIN DenunciaXJuez DJ
	ON DJ.idDenuncia = D.idDenuncia
INNER JOIN(SELECT P.username, J.idJuez FROM Juez J
		   INNER JOIN Persona P ON P.cedula = J.idJuez
		  )PersonaJ
	ON PersonaJ.idJuez = DJ.idJuez
INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
INNER JOIN Solucion S ON S.idDenuncia = D.idDenuncia
INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Distrit ON Distrit.idDistrito = Dir.idDistrito
INNER JOIN Canton Cant ON Cant.idCanton = Distrit.idCanton
INNER JOIN Provincia P ON P.idProvincia = Cant.idProvincia
WHERE P.nombreProvincia = @provincia
END
GO

/* Filtros */
CREATE PROC consultaDenunciasConSolucionFiltroPorCanton(
	@canton NVARCHAR(50)
)AS
BEGIN
SELECT D.titulo, D.descripcion, PersonaG.username usuarioGuardian, NJ.fecha, 
       PersonaJ.username usuarioJuez, S.descripcion, S.fecha, S.validacion
FROM Denuncia D
INNER JOIN (SELECT P.username, G.idGuardian FROM Guardian G
			INNER JOIN Persona P ON P.cedula = G.idGuardian
			)PersonaG
	ON PersonaG.idGuardian = D.idGuardian
INNER JOIN DenunciaXJuez DJ
	ON DJ.idDenuncia = D.idDenuncia
INNER JOIN(SELECT P.username, J.idJuez FROM Juez J
		   INNER JOIN Persona P ON P.cedula = J.idJuez
		  )PersonaJ
	ON PersonaJ.idJuez = DJ.idJuez
INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
INNER JOIN Solucion S ON S.idDenuncia = D.idDenuncia
INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Distrit ON Distrit.idDistrito = Dir.idDistrito
INNER JOIN Canton Cant ON Cant.idCanton = Distrit.idCanton
WHERE Cant.nombreCanton = @canton
END
GO

/* Filtros */
CREATE PROC consultaDenunciasConSolucionFiltroPorDistrito(
	@distrito NVARCHAR(50)
)AS
BEGIN
SELECT D.titulo, D.descripcion, PersonaG.username usuarioGuardian, NJ.fecha, 
       PersonaJ.username usuarioJuez, S.descripcion, S.fecha, S.validacion
FROM Denuncia D
INNER JOIN (SELECT P.username, G.idGuardian FROM Guardian G
			INNER JOIN Persona P ON P.cedula = G.idGuardian
			)PersonaG
	ON PersonaG.idGuardian = D.idGuardian
INNER JOIN DenunciaXJuez DJ
	ON DJ.idDenuncia = D.idDenuncia
INNER JOIN(SELECT P.username, J.idJuez FROM Juez J
		   INNER JOIN Persona P ON P.cedula = J.idJuez
		  )PersonaJ
	ON PersonaJ.idJuez = DJ.idJuez
INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
INNER JOIN Solucion S ON S.idDenuncia = D.idDenuncia
INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
INNER JOIN Distrito Distrit ON Distrit.idDistrito = Dir.idDistrito
WHERE Distrit.nombreDistrito = @distrito
END
GO

/*filtro*/
CREATE PROC consultaDenunciasConSolucionFiltroPorHashtag(
	@hashtag NVARCHAR(50)
)AS
BEGIN
	declare @hash NVARCHAR(50) = RTRIM(@hashtag) + '%'
	SELECT D.titulo, D.descripcion, PersonaG.username usuarioGuardian, NJ.fecha, 
		   PersonaJ.username usuarioJuez, S.descripcion, S.fecha, S.validacion
	FROM Denuncia D
	INNER JOIN (SELECT P.username, G.idGuardian FROM Guardian G
				INNER JOIN Persona P ON P.cedula = G.idGuardian
				)PersonaG
		ON PersonaG.idGuardian = D.idGuardian
	INNER JOIN DenunciaXJuez DJ
		ON DJ.idDenuncia = D.idDenuncia
	INNER JOIN(SELECT P.username, J.idJuez FROM Juez J
			   INNER JOIN Persona P ON P.cedula = J.idJuez
			  )PersonaJ
		ON PersonaJ.idJuez = DJ.idJuez
	INNER JOIN NotificacionJuez NJ ON NJ.idDenuncia = D.idDenuncia
	INNER JOIN Solucion S ON S.idDenuncia = D.idDenuncia
	INNER JOIN HashtagSolucion HS ON HS.idSolucion = S.idSolucion
	WHERE HS.hashtag like @hash
END
GO
/*##################################################################################*/
--Punto 13
create proc obtenerTextoDireccion(
	@idDireccion int
)as
begin
	select P.nombreProvincia + ', ' + C.nombreCanton + ', ' + dir.nombreDistrito
	from Direccion D
	inner join Distrito dir
		on D.idDistrito = dir.idDistrito
	inner join Canton C
		on C.idCanton = dir.idCanton
	inner join Provincia P
		on P.idProvincia = C.idProvincia
	where D.idDireccion = @idDireccion
end
go

create proc obtenerOficialDenuncia(
	@idOficial numeric(10)
)as
begin 
	select P.username
	from Persona P
	inner join Oficial G
		on G.idOficial = P.cedula
	where G.idOficial = @idOficial
end
go

create proc obtenerGuardianDenuncia(
	@idGuardian numeric(10)
)as
begin 
	select P.username
	from Persona P
	inner join Guardian G
		on G.idGuardian = P.cedula
	where G.idGuardian = @idGuardian
end
go

CREATE PROC MostrarInformacionDenuncia(
	@idDenuncia INT
)AS
IF NOT EXISTS (select * 
			   from Solucion S 
			   where S.idDenuncia = @idDenuncia and S.validacion = 1)
	BEGIN
	SELECT D.* FROM Denuncia D
	WHERE D.idDenuncia = @idDenuncia
	END
ELSE 
	BEGIN
	SELECT D.idDenuncia, D.categoria, D.titulo, D.latitud, D.longitud, D.estado, D.descripcion,
	D.foto, D.idGuardian, D.idDireccion, S.titulo, S.foto, S.validacion, S.descripcion,
	S.fecha, S.idOficial
	FROM Denuncia D
	INNER JOIN Solucion S
		ON S.idDenuncia = D.idDenuncia
	WHERE D.idDenuncia = @idDenuncia
	END
GO

/*##################################################################################*/
create proc buscarUsername(
	@cedula numeric(10)
)as
begin
	select P.primerNombre +  ' ' + P.primerApellido
	from Persona P
	where P.cedula = @cedula
end
go

create proc cargarBitcora as
begin
	select * from Bitacora
end 
go

create proc cargarBitcoraFiltroFecha (
	@inicio date,
	@final date
) as
begin
	select * from Bitacora
	where fecha between @inicio and @final
end 
go
/*##################################################################################*/

--Punto 8
create proc listadoGuardianesOfifialesTotal as
begin
select * 
from
(select 'Guardian' rol, Nombre nombre, total Total
	from 
		(select 'Guardian' rol, (P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total
		from Guardian G
		inner join Aporte A
			on A.idUsuario = G.idGuardian
		inner join Persona P
			on P.cedula = G.idGuardian
		group by G.idGuardian, P.primerNombre, P.primerApellido) aportes
		union

		(select 'Guardian' rol,  (P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total
		from Guardian G
		inner join Denuncia D
			on D.idGuardian = G.idGuardian
		inner join Persona P
			on P.cedula = G.idGuardian
		group by G.idGuardian, P.primerNombre, P.primerApellido)
		) datos
	union
	(select 'Oficial' rol, Nombre nombre, Total
	from
		(select 'Oficial' rol, (P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total 
		from Oficial O
		inner join Solucion S
			on S.idOficial = O.idOficial 
		inner join Persona P
			on P.cedula = O.idOficial
		group by O.idOficial, P.primerNombre, P.primerApellido) oficiales
		union
		(select 'Oficial' rol,(P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total 
		from Oficial O
		inner join Aporte S
			on S.idUsuario = O.idOficial 
		inner join Persona P
			on P.cedula = O.idOficial
		group by O.idOficial, P.primerNombre, P.primerApellido)
		)
end 
go

/* filtro nombre */
create proc listadoGuardianesOfifialesTotalFiltroNombre(
	@nombre NVARCHAR(50)
) as
begin
declare @nom NVARCHAR(50) = RTRIM(@nombre) + '%'
select * 
from
	(select 'Guardian' rol, Nombre nombre, total Total
		from 
			(select 'Guardian' rol, (P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total
			from Guardian G
			inner join Aporte A
				on A.idUsuario = G.idGuardian
			inner join Persona P
				on P.cedula = G.idGuardian
			where (P.primerNombre + ' ' + P.primerApellido) like @nom
			group by G.idGuardian, P.primerNombre, P.primerApellido) aportes
			
			union

			(select 'Guardian' rol,  (P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total
			from Guardian G
			inner join Denuncia D
				on D.idGuardian = G.idGuardian
			inner join Persona P
				on P.cedula = G.idGuardian
			where (P.primerNombre + ' ' + P.primerApellido) like @nom
			group by G.idGuardian, P.primerNombre, P.primerApellido)
			) datos
	union
	(select 'Oficial' rol, Nombre nombre, Total
		from
			(select 'Oficial' rol, (P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total 
			from Oficial O
			inner join Solucion S
				on S.idOficial = O.idOficial 
			inner join Persona P
				on P.cedula = O.idOficial
			where (P.primerNombre + ' ' + P.primerApellido) like @nom
			group by O.idOficial, P.primerNombre, P.primerApellido) oficiales
			union
			(select 'Oficial' rol,(P.primerNombre + ' '+ P.primerApellido) Nombre, count(*) total 
			from Oficial O
			inner join Aporte S
				on S.idUsuario = O.idOficial 
			inner join Persona P
				on P.cedula = O.idOficial
			where (P.primerNombre + ' ' + P.primerApellido) like @nom
			group by O.idOficial, P.primerNombre, P.primerApellido)
			) 
end 
go
/*##################################################################################*/

--Punto 15
CREATE PROC consultaDenunciasXML AS
BEGIN
SELECT D.latitud lat, 
	   D.longitud lng, 
	   D.titulo name,
	   P.nombreProvincia +
	   ', ' + C.nombreCanton +
	   ', ' + Dis.nombreDistrito + 
	   ', ' + Dir.detalle address
FROM Denuncia D
	INNER JOIN Direccion Dir ON Dir.idDireccion = D.idDireccion
	INNER JOIN Distrito Dis ON Dis.idDistrito = Dir.idDistrito
	INNER JOIN Canton C ON C.idCanton = Dis.idCanton
	INNER JOIN Provincia P ON P.idProvincia = C.idProvincia
	FOR XML PATH('marker'), ROOT('markers')
END
GO
/*##################################################################################*/
--Punto 7
create proc promedioAportesPorUsuario(
	@inicio date,
	@final date
)as
begin
	select P.primerNombre + ' ' + P.primerApellido,  
	count(*) / (((year(@final)) - (year(@inicio)))*12) + (month(@inicio)- month(@final)) meses 
	from Usuario U
	inner join Aporte A
		on A.idUsuario = U.idUsuario
	inner join Persona P
		on P.cedula = U.idUsuario
	where A.fecha between @inicio and @final
	group by P.primerNombre, P.primerApellido
	order by meses desc
end
go


/*##################################################################################*/
/*##################################################################################*/
/*##################################################################################*/
/*##################################################################################*/
/*##################################################################################*/
/*##################################################################################*/
/*##################################################################################*/
/*##################################################################################*/
/*#########################################################################*/


/* ############################### */
create proc buscarProvinciaJuez(
	@idJuez numeric(10),
	@retorno Numeric(10) output
)as
begin
select @retorno = Prov.idProvincia 
from Juez J
inner join Persona P
	on P.cedula = @idJuez
inner join Direccion Dir
	on Dir.idDireccion = P.idDireccion
inner join Distrito Dis 
	on Dis.idDistrito = Dir.idDistrito
inner join Canton C
	on C.idCanton = Dis.idCanton
inner join Provincia Prov
	on Prov.idProvincia = C.idProvincia
end 
go

/*###################*/
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
end
go

/*################################################################################*/
--Punto 2
CREATE PROC consultaDistritosGuardianes
AS
BEGIN
	SELECT Dis.nombreDistrito, COUNT(G.idGuardian) Guardianes 
	FROM Distrito Dis
	inner join Direccion Dir
		ON Dir.idDistrito = dis.idDistrito
	inner join Persona P
		ON P.idDireccion = Dir.idDireccion
	inner join Guardian G
		ON G.idGuardian = P.cedula
	GROUP BY dis.nombreDistrito
END
GO
/* ####################################### */
CREATE PROC consultaDistritosficiales
AS
BEGIN
	SELECT Dis.nombreDistrito, COUNT(O.idOficial) Oficiales 
	FROM Distrito Dis
	inner join Direccion Dir
		ON Dir.idDistrito = dis.idDistrito
	inner join Persona P
		ON P.idDireccion = Dir.idDireccion
	inner join Oficial O
		ON O.idOficial = P.cedula
	GROUP BY dis.nombreDistrito
END
GO
/* ####################################### */
CREATE PROC consultaDistritosJueces
AS
BEGIN
	SELECT Dis.nombreDistrito, COUNT(J.idJuez) Oficiales 
	FROM Distrito Dis
	inner join Direccion Dir
		ON Dir.idDistrito = dis.idDistrito
	inner join Persona P
		ON P.idDireccion = Dir.idDireccion
	inner join Juez J
		ON J.idJuez = P.cedula
	GROUP BY dis.nombreDistrito
END
GO





