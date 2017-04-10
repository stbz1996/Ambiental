use Proyecto
go

/* Carga Fotos */
UPDATE Denuncia
SET foto = (SELECT *
     FROM OPENROWSET(BULK 'C:\Users\Jorge González\Desktop\Base de Datos Final\Base de Datos SQL\imagenes\boti17.jpg', SINGLE_BLOB) AS a)
WHERE idDenuncia  between 1 and 3000
go

UPDATE Denuncia
SET foto = (SELECT *
     FROM OPENROWSET(BULK 'C:\Users\Jorge González\Desktop\Base de Datos Final\Base de Datos SQL\imagenes\ffsd.jpg', SINGLE_BLOB) AS a)
WHERE idDenuncia between 3001 and 6000
go

UPDATE Denuncia
SET foto = (SELECT *
     FROM OPENROWSET(BULK 'C:\Users\Jorge González\Desktop\Base de Datos Final\Base de Datos SQL\imagenes\EnvironmentalIssues.jpg', SINGLE_BLOB) AS a)
WHERE idDenuncia between 6001 and 10999
go

UPDATE Solucion
SET foto = (SELECT *
     FROM OPENROWSET(BULK 'C:\Users\Jorge González\Desktop\Base de Datos Final\Base de Datos SQL\imagenes\boti17.jpg', SINGLE_BLOB) AS a)
go
