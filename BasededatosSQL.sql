create database MundoExp


use MundoExp


-- Tabla Clientes
CREATE TABLE Clientes (
    ClienteId INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    -- Otros campos relacionados con el cliente
);

-- Tabla TiposDeProducto
CREATE TABLE TiposDeProducto (
    TipoProductoId INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50) NOT NULL,
    -- Otros campos relacionados con el tipo de producto
);

-- Tabla BodegasAlmacenamientoTerrestre
CREATE TABLE BodegasAlmacenamientoTerrestre (
    BodegaId INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    -- Otros campos relacionados con la bodega
);

-- Tabla PuertosMaritimos
CREATE TABLE PuertosMaritimos (
    PuertoId INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    -- Otros campos relacionados con el puerto
);

-- Tabla EnviosTerrestres
CREATE TABLE EnviosTerrestres (
    EnvioTerrestreId INT PRIMARY KEY IDENTITY,
    TipoProductoId INT,
    Cantidad INT NOT NULL,
    FechaRegistro DATE NOT NULL,
    FechaEntrega DATE NOT NULL,
    BodegaEntregaId INT,
    PrecioEnvio DECIMAL(10, 2),
    PlacaVehiculo NVARCHAR(10),
    NumeroGuia NVARCHAR(10) UNIQUE,
    ClienteId INT,
    FOREIGN KEY (TipoProductoId) REFERENCES TiposDeProducto(TipoProductoId),
    FOREIGN KEY (BodegaEntregaId) REFERENCES BodegasAlmacenamientoTerrestre(BodegaId),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId)
);

-- Tabla EnviosMaritimos
CREATE TABLE EnviosMaritimos (
    EnvioMaritimoId INT PRIMARY KEY IDENTITY,
    TipoProductoId INT,
    Cantidad INT NOT NULL,
    FechaRegistro DATE NOT NULL,
    FechaEntrega DATE NOT NULL,
    PuertoEntregaId INT,
    PrecioEnvio DECIMAL(10, 2),
    NumeroFlota NVARCHAR(10),
    NumeroGuia NVARCHAR(10) UNIQUE,
    ClienteId INT,
    FOREIGN KEY (TipoProductoId) REFERENCES TiposDeProducto(TipoProductoId),
    FOREIGN KEY (PuertoEntregaId) REFERENCES PuertosMaritimos(PuertoId),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId)
);




-- Insertar datos de ejemplo

-- Tabla Clientes
INSERT INTO Clientes (Nombre, Email)
VALUES
    ('Cliente 4', 'mundo@example.com'),
    ('Cliente 2', 'cliente2@example.com'),
    ('Cliente 3', 'cliente3@example.com');

-- Tabla TiposDeProducto
INSERT INTO TiposDeProducto (Nombre)
VALUES
    ('Electrónicos'),
    ('Ropa'),
    ('Alimentos');

-- Tabla BodegasAlmacenamientoTerrestre
INSERT INTO BodegasAlmacenamientoTerrestre (Nombre)
VALUES
    ('Bodega A'),
    ('Bodega B'),
    ('Bodega C');

-- Tabla PuertosMaritimos
INSERT INTO PuertosMaritimos (Nombre)
VALUES
    ('Puerto X'),
    ('Puerto Y'),
    ('Puerto Z');

-- Tabla EnviosTerrestres
INSERT INTO EnviosTerrestres (TipoProductoId, Cantidad, FechaRegistro, FechaEntrega, BodegaEntregaId, PrecioEnvio, PlacaVehiculo, NumeroGuia, ClienteId)
VALUES
    (1, 20, '2023-08-01', '2023-08-15', 1, 150.00, 'ABC123', 'ET001', 1),
    (2, 10, '2023-08-02', '2023-08-16', 2, 80.00, 'DEF456', 'ET002', 2),
    (3, 15, '2023-08-03', '2023-08-17', 3, 120.00, 'GHI789', 'ET003', 3);

-- Tabla EnviosMaritimos
INSERT INTO EnviosMaritimos (TipoProductoId, Cantidad, FechaRegistro, FechaEntrega, PuertoEntregaId, PrecioEnvio, NumeroFlota, NumeroGuia, ClienteId)
VALUES
    (1, 30, '2023-08-05', '2023-08-20', 1, 250.00, 'ABC1234A', 'EM001', 1),
    (2, 12, '2023-08-06', '2023-08-21', 2, 150.00, 'DEF4567B', 'EM002', 2),
    (3, 18, '2023-08-07', '2023-08-22', 3, 200.00, 'GHI7890C', 'EM003', 3);


SELECT * FROM Clientes;

SELECT * FROM TiposDeProducto;

SELECT * FROM TiposDeProducto
SELECT * FROM BodegasAlmacenamientoTerrestre

SELECT * FROM PuertosMaritimos;

SELECT * FROM EnviosTerrestres;

SELECT * FROM EnviosMaritimos;
