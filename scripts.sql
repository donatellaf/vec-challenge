CREATE DATABASE CARS_DATABASE;


CREATE TABLE  TipoVehiculo(
    IdTipoVehiculo           INTEGER IDENTITY(1,1) PRIMARY KEY,
    Name                       VARCHAR(30) NOT NULL
);

CREATE TABLE  Marca(
    IdMarca           INTEGER IDENTITY(1,1) PRIMARY KEY,
    Name               VARCHAR(30)NOT NULL
);

CREATE TABLE Combustible(
	IdCombustible INTEGER IDENTITY(1,1) PRIMARY KEY,
	Name           VARCHAR(30) NOT NULL
)

CREATE TABLE Transmision(
	IdTransmision INTEGER IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(30) NOT NULL
)

CREATE TABLE  Vehiculo(
	IdVehiculo       INTEGER IDENTITY(1,1) PRIMARY KEY,
    NumeroPatente           VARCHAR(9) NOT NULL UNIQUE,
    NumeroChasis            VARCHAR(17) NOT NULL UNIQUE, 
	ModeloName              VARCHAR(30) NOT NULL,
	IdTipoVehiculo         INTEGER NOT NULL FOREIGN KEY REFERENCES TipoVehiculo(IdTipoVehiculo),
	IdMarca                INTEGER NOT NULL FOREIGN KEY REFERENCES Marca(IdMarca),
	IdCombustible          INTEGER NOT NULL FOREIGN KEY REFERENCES Combustible(IdCombustible),
	IdTransmision          INTEGER NOT NULL FOREIGN KEY REFERENCES Transmision(IdTransmision),
);


INSERT INTO Transmision VALUES ('Automatico');
INSERT INTO Transmision VALUES ('Manual');
INSERT INTO Combustible VALUES ('Nafta');
INSERT INTO Combustible VALUES ('Gasoil');
INSERT INTO TipoVehiculo VALUES ('Hatchback')
INSERT INTO TipoVehiculo VALUES ('Suv')
INSERT INTO TipoVehiculo VALUES ('Coupe')
INSERT INTO TipoVehiculo VALUES ('Pickup')
INSERT INTO TipoVehiculo VALUES ('Minivan')
INSERT INTO TipoVehiculo VALUES ('Sedan')
INSERT INTO Marca VALUES ('Audi')
INSERT INTO Marca VALUES ('Peugeot')
INSERT INTO Marca VALUES ('Renault')
INSERT INTO Marca VALUES ('Fiat')
INSERT INTO Marca VALUES ('Ford')
INSERT INTO Marca VALUES ('Chevrolet')
INSERT INTO Marca VALUES ('Bmw')