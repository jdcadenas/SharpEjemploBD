# EjemploBD con SharpDevelop y Mysql 

## 1 Script SQL para crear la base de datos y la tabla
```Mysql
--
-- Base de datos: `peducativa`
--
CREATE DATABASE IF NOT EXISTS `peducativa` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `peducativa`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL,
  `rol` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
```

## 2 Configurar ShaarpDevelop
### 2.1 4.1. Instalar el conector MySQL para .NET
Descarga `MySql.Data.dll`desde [https://github.com/jdcadenas/SharpEjemploBD/tree/main/LIB_CONEXION/MySql.Data.dll](https://raw.github.com/jdcadenas/SharpEjemploBD/tree/main/LIB_CONEXION/MySql.Data.dll)
