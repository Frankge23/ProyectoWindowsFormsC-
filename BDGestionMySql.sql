CREATE DATABASE GestionInventario;

CREATE TABLE Trabajador (
    IdTrabajador INT AUTO_INCREMENT PRIMARY KEY,
    Nombres VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    Sexo VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    Direccion VARCHAR(50),
    Telefono VARCHAR(50)
);

CREATE TABLE Proveedor (
    IdProveedor INT AUTO_INCREMENT PRIMARY KEY,
	NombreProveedor VARCHAR (50) NOT NULL, -- Agregado
    SectorComercial VARCHAR(50) NOT NULL,
    TipoDocumento VARCHAR(50) NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    Direccion VARCHAR(50),
    Telefono VARCHAR(50)
);

CREATE TABLE Categoria (
    IdCategoria INT AUTO_INCREMENT PRIMARY KEY,
	TipoCategoria VARCHAR(50),
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(50)
);

CREATE TABLE Cliente (
    IdCliente INT AUTO_INCREMENT PRIMARY KEY,
    Nombres VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50),
    Sexo VARCHAR(50),
    FechaNacimiento DATE,
    TipoDocumento VARCHAR(50) NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    Direccion VARCHAR(50),
    Telefono VARCHAR(50)
);

CREATE TABLE Articulo (
    IdArticulo INT AUTO_INCREMENT PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(50),
    Precio DECIMAL(10, 2),  -- Cambiado a DECIMAL
    IdCategoria INT NOT NULL,
    FOREIGN KEY (IdCategoria) REFERENCES Categoria (IdCategoria)
);

CREATE TABLE Ingreso (
    IdIngreso INT AUTO_INCREMENT PRIMARY KEY,
    IdTrabajador INT NOT NULL,
    IdProveedor INT NOT NULL,
    FechaIngreso DATE NOT NULL,
    TipoComprobante VARCHAR(50) NOT NULL,
    Serie VARCHAR(50) NOT NULL,
    Correlativo VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (IdProveedor) REFERENCES Proveedor (IdProveedor),
    FOREIGN KEY (IdTrabajador) REFERENCES Trabajador (IdTrabajador)
);

CREATE TABLE Venta (
    IdVenta INT AUTO_INCREMENT PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdTrabajador INT NOT NULL,
    FechaVenta DATE NOT NULL,
    TipoComprobante VARCHAR(50) NOT NULL,
    Serie VARCHAR(50) NOT NULL,
    Correlativo VARCHAR(50) NOT NULL,
    PrecioTotal DECIMAL(10, 2) NOT NULL,  -- Agregado
    FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente),
    FOREIGN KEY (IdTrabajador) REFERENCES Trabajador (IdTrabajador)
);

CREATE TABLE DetalleIngreso (
    IdDetalleIngreso INT AUTO_INCREMENT PRIMARY KEY,
    IdIngreso INT NOT NULL,
    IdArticulo INT NOT NULL,
    PrecioCompra DECIMAL(10, 2) NOT NULL,
    StockInicial INT NOT NULL,
    StockActual INT NOT NULL,
	Descuento DECIMAL(10, 2), -- Agregado
    FOREIGN KEY (IdArticulo) REFERENCES Articulo (IdArticulo),
    FOREIGN KEY (IdIngreso) REFERENCES Ingreso (IdIngreso) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE DetalleVenta (
    IdDetalleVenta INT AUTO_INCREMENT PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdDetalleIngreso INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioVenta DECIMAL(10, 2) NOT NULL,
	Descuento DECIMAL(10, 2),  -- Agregado
    FOREIGN KEY (IdVenta) REFERENCES Venta (IdVenta) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (IdDetalleIngreso) REFERENCES DetalleIngreso (IdDetalleIngreso)
);

CREATE TABLE Kardex (
    IdKardex INT AUTO_INCREMENT PRIMARY KEY,
    IdArticulo INT NOT NULL,
    FechaMovimiento DATE NOT NULL,
    TipoMovimiento VARCHAR(50) NOT NULL,  -- 'Entrada' o 'Salida'
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    StockFinal INT NOT NULL,
    FOREIGN KEY (IdArticulo) REFERENCES Articulo (IdArticulo)
);




-- Insertar datos en la tabla Trabajador
INSERT INTO Trabajador (Nombres, Apellidos, Sexo, FechaNacimiento, NumeroDocumento, Direccion, Telefono) VALUES 
('Juan', 'Pérez', 'Masculino', '1985-06-15', '12345678', 'Calle Falsa 123', '987654321'),
('Ana', 'Gómez', 'Femenino', '1990-12-01', '87654321', 'Avenida Siempre Viva 742', '912345678'),
('Luis', 'Martínez', 'Masculino', '1978-03-22', '11223344', 'Boulevard Central 456', '998877665');

-- Insertar datos en la tabla Proveedor
INSERT INTO Proveedor (NombreProveedor, SectorComercial, TipoDocumento, NumeroDocumento, Direccion, Telefono) VALUES 
('Proveedora S.A.', 'Electrónica', 'DUI', '20123456789', 'Calle Comercio 100', '987654320'),
('Distribuciones Globales', 'Alimentos', 'RUC', '20234567890', 'Avenida Progreso 200', '912345679'),
('Importaciones y Exportaciones', 'Ropa', 'RUC', '20345678901', 'Calle Central 300', '998877664');

-- Insertar datos en la tabla Ingreso
INSERT INTO Ingreso (IdTrabajador, IdProveedor, FechaIngreso, TipoComprobante, Serie, Correlativo, Estado) VALUES 
(1, 1, '2023-05-20', 'Factura', 'F001', '000123', 'Activo'),
(2, 2, '2023-06-15', 'Boleta', 'B001', '000456', 'Activo'),
(3, 3, '2023-07-10', 'Factura', 'F002', '000789', 'Inactivo');
