## 🛠️ Requisitos Previos

1. **.NET SDK 8.0**
2. **SQL Server**

##  Configuracion de base de datos 
1.  Asegurarse que el usuario **'sa'** tenga permisos a la base **'persona_db'**, y su contraseña sea **'admin123'**
2.   Ejecutar el DML 
   Archivo DML
```
-- Habilitar login 'sa' si está deshabilitado (solo si usas autenticación SQL Server)
ALTER LOGIN sa ENABLE;
GO

-- Establecer o cambiar contraseña del usuario 'sa'
ALTER LOGIN sa WITH PASSWORD = 'admin123!';
GO

-- Otorgar el rol db_owner al usuario 'sa'
ALTER ROLE db_owner ADD MEMBER sa;
GO


```
4.   Ejecutar el DDl


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



## ⚙️ cambiar conexion a base de datos si es nesesario
Ir al **Release.zip** **bin\Release\net8.0** ir **appsettings.json** cambiar "Server=localhost\\SQLEXPRESS...." por su cadena de conexion a base de datos , asegurarse de que tenga Id y contraseña  con permisos para la base.  
  **appsettings.json**
```
    "ConnectionStrings": {
        "PersonaDb": "Server=localhost\\SQLEXPRESS;Database=persona_db;User Id=sa;Password=admin123;Trusted_Connection=True;TrustServerCertificate=true"
    }
```
### 1. Ejecutar la Aplicación
Ir a **bin\Release\net8.0** ejecutar **personapi-dotnet.exe**

### 2. Navegar hasta para acceder al servicio

[http://localhost:5150](http://localhost:5150)

### 3. Acceder a Swagger
Navega a:  
[http://localhost:5150/swagger](http://localhost:5150/swagger)  
para acceder a la documentación interactiva de la API proporcionada por **Swagger**.

