IF DB_ID('BDDesarrollo') IS NULL
    CREATE DATABASE BDDesarrollo;
GO

USE BDDesarrollo;
GO

IF OBJECT_ID('dbo.Rol', 'U') IS NULL
CREATE TABLE dbo.Rol (
    IdRol INT IDENTITY PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL UNIQUE
);

IF OBJECT_ID('dbo.Usuario', 'U') IS NULL
CREATE TABLE dbo.Usuario (
    IdUsuario INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(150) NOT NULL UNIQUE,
    Clave VARCHAR(255) NOT NULL,
    IdRol INT NOT NULL REFERENCES dbo.Rol(IdRol),
    Estado BIT NOT NULL DEFAULT 1
);

IF NOT EXISTS (SELECT 1 FROM dbo.Rol WHERE NombreRol='Administrador')
    INSERT dbo.Rol VALUES ('Administrador');

IF NOT EXISTS (SELECT 1 FROM dbo.Rol WHERE NombreRol='Vendedor')
    INSERT dbo.Rol VALUES ('Vendedor');
GO