## 🛠️ Requisitos Previos

1. **.NET SDK 8.0**: Tener instalado el SDK de .NET 8.0.  
2. **Visual Studio 2022**
3. **SQL Server**: Contar con una instancia de SQL Server para la base de datos (por ejemplo, SQL Server Express).

##  Configuracion de base de datos 
1.  Asegurarse que el usuario **'sa'** tenga permisos a la base **'persona_db'**, y su contraseña sea **'admin123'**
2.  Ejecutar el DDl
  ```
-- Crear base de datos
  
CREATE DATABASE persona_db;
GO
USE persona_db;
GO

-- Tabla: persona
CREATE TABLE persona (
    cc INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(45),
    apellido VARCHAR(45),
    genero CHAR(1) CHECK (genero IN ('M','F')),
    edad INT
);
GO

-- Tabla: profesion
CREATE TABLE profesion (
    id INT NOT NULL PRIMARY KEY,
    nom VARCHAR(90),
    des TEXT
);
GO

-- Tabla: estudios
CREATE TABLE estudios (
    id_prof INT NOT NULL,
    cc_per INT NOT NULL,
    fecha DATE,
    univer VARCHAR(50),
    PRIMARY KEY (id_prof, cc_per),
    FOREIGN KEY (id_prof) REFERENCES profesion(id),
    FOREIGN KEY (cc_per) REFERENCES persona(cc)
);
GO

-- Tabla: telefono
CREATE TABLE telefono (
    num VARCHAR(15) NOT NULL PRIMARY KEY,
    oper VARCHAR(45),
    duenio INT,
    FOREIGN KEY (duenio) REFERENCES persona(cc)
);
GO

```

## ⚙️ Compilación y Ejecución

### 1. Compilar el Proyecto
En Visual Studio, selecciona **Compilar > Compilar solución** o presiona `Ctrl + Shift + B`.

### 2. Ejecutar la Aplicación
Presiona `F5` o selecciona **Depurar > Iniciar depuración** para ejecutar la aplicación.  
La API estará disponible en:  
[http://localhost:5150](http://localhost:5150)

### 3. Acceder a Swagger
Navega a:  
[http://localhost:5150/swagger](http://localhost:5150/swagger)  
para acceder a la documentación interactiva de la API proporcionada por **Swagger**.

