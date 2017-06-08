CREATE DATABASE  IF NOT EXISTS `lunasoft` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `lunasoft`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: lunasoft
-- ------------------------------------------------------
-- Server version	5.7.11-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes` (
  `idclientes` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idclientes`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `colores`
--

DROP TABLE IF EXISTS `colores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `colores` (
  `idcolores` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idcolores`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `colores`
--

LOCK TABLES `colores` WRITE;
/*!40000 ALTER TABLE `colores` DISABLE KEYS */;
/*!40000 ALTER TABLE `colores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `componentes`
--

DROP TABLE IF EXISTS `componentes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `componentes` (
  `idcomponentes` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `modelos_idmodelos` int(11) NOT NULL,
  PRIMARY KEY (`idcomponentes`),
  KEY `fk_componentes_modelos1_idx` (`modelos_idmodelos`),
  CONSTRAINT `fk_componentes_modelos1` FOREIGN KEY (`modelos_idmodelos`) REFERENCES `modelos` (`idmodelos`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `componentes`
--

LOCK TABLES `componentes` WRITE;
/*!40000 ALTER TABLE `componentes` DISABLE KEYS */;
/*!40000 ALTER TABLE `componentes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_colores_tallas`
--

DROP TABLE IF EXISTS `detalle_colores_tallas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalle_colores_tallas` (
  `colores_idcolores` int(11) NOT NULL,
  `tallas_idtallas` int(11) NOT NULL,
  PRIMARY KEY (`colores_idcolores`,`tallas_idtallas`),
  KEY `fk_colores_has_tallas_tallas1_idx` (`tallas_idtallas`),
  KEY `fk_colores_has_tallas_colores1_idx` (`colores_idcolores`),
  CONSTRAINT `fk_colores_has_tallas_colores1` FOREIGN KEY (`colores_idcolores`) REFERENCES `colores` (`idcolores`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_colores_has_tallas_tallas1` FOREIGN KEY (`tallas_idtallas`) REFERENCES `tallas` (`idtallas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_colores_tallas`
--

LOCK TABLES `detalle_colores_tallas` WRITE;
/*!40000 ALTER TABLE `detalle_colores_tallas` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_colores_tallas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_materia_prima_modelos`
--

DROP TABLE IF EXISTS `detalle_materia_prima_modelos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalle_materia_prima_modelos` (
  `materia_prima_idmateria_prima` int(11) NOT NULL,
  `modelos_idmodelos` int(11) NOT NULL,
  `porcentaje` double NOT NULL,
  `costo` double DEFAULT NULL,
  PRIMARY KEY (`materia_prima_idmateria_prima`,`modelos_idmodelos`),
  KEY `fk_materia_prima_has_modelos_modelos1_idx` (`modelos_idmodelos`),
  KEY `fk_materia_prima_has_modelos_materia_prima1_idx` (`materia_prima_idmateria_prima`),
  CONSTRAINT `fk_materia_prima_has_modelos_materia_prima1` FOREIGN KEY (`materia_prima_idmateria_prima`) REFERENCES `materia_prima` (`idmateria_prima`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_materia_prima_has_modelos_modelos1` FOREIGN KEY (`modelos_idmodelos`) REFERENCES `modelos` (`idmodelos`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_materia_prima_modelos`
--

LOCK TABLES `detalle_materia_prima_modelos` WRITE;
/*!40000 ALTER TABLE `detalle_materia_prima_modelos` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_materia_prima_modelos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_modelos_pedidospre`
--

DROP TABLE IF EXISTS `detalle_modelos_pedidospre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalle_modelos_pedidospre` (
  `modelos_idmodelos` int(11) NOT NULL,
  `pedidos_pre_idpedidos_pre` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`modelos_idmodelos`,`pedidos_pre_idpedidos_pre`),
  KEY `fk_modelos_has_pedidos_pre_pedidos_pre1_idx` (`pedidos_pre_idpedidos_pre`),
  KEY `fk_modelos_has_pedidos_pre_modelos1_idx` (`modelos_idmodelos`),
  CONSTRAINT `fk_modelos_has_pedidos_pre_modelos1` FOREIGN KEY (`modelos_idmodelos`) REFERENCES `modelos` (`idmodelos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_modelos_has_pedidos_pre_pedidos_pre1` FOREIGN KEY (`pedidos_pre_idpedidos_pre`) REFERENCES `pedidos_pre` (`idpedidos_pre`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_modelos_pedidospre`
--

LOCK TABLES `detalle_modelos_pedidospre` WRITE;
/*!40000 ALTER TABLE `detalle_modelos_pedidospre` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_modelos_pedidospre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_tallas_modelos`
--

DROP TABLE IF EXISTS `detalle_tallas_modelos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalle_tallas_modelos` (
  `tallas_idtallas` int(11) NOT NULL,
  `modelos_idmodelos` int(11) NOT NULL,
  `precio` double DEFAULT NULL,
  PRIMARY KEY (`tallas_idtallas`,`modelos_idmodelos`),
  KEY `fk_tallas_has_modelos_modelos1_idx` (`modelos_idmodelos`),
  KEY `fk_tallas_has_modelos_tallas1_idx` (`tallas_idtallas`),
  CONSTRAINT `fk_tallas_has_modelos_modelos1` FOREIGN KEY (`modelos_idmodelos`) REFERENCES `modelos` (`idmodelos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tallas_has_modelos_tallas1` FOREIGN KEY (`tallas_idtallas`) REFERENCES `tallas` (`idtallas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_tallas_modelos`
--

LOCK TABLES `detalle_tallas_modelos` WRITE;
/*!40000 ALTER TABLE `detalle_tallas_modelos` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_tallas_modelos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(50) NOT NULL,
  `contraseña` varchar(50) NOT NULL,
  `rol` varchar(50) NOT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materia_prima`
--

DROP TABLE IF EXISTS `materia_prima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materia_prima` (
  `idmateria_prima` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idmateria_prima`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materia_prima`
--

LOCK TABLES `materia_prima` WRITE;
/*!40000 ALTER TABLE `materia_prima` DISABLE KEYS */;
/*!40000 ALTER TABLE `materia_prima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modelos`
--

DROP TABLE IF EXISTS `modelos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modelos` (
  `idmodelos` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idmodelos`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modelos`
--

LOCK TABLES `modelos` WRITE;
/*!40000 ALTER TABLE `modelos` DISABLE KEYS */;
/*!40000 ALTER TABLE `modelos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedidos_pre`
--

DROP TABLE IF EXISTS `pedidos_pre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pedidos_pre` (
  `idpedidos_pre` int(11) NOT NULL AUTO_INCREMENT,
  `cliente` varchar(45) NOT NULL,
  `clientes_idclientes` int(11) NOT NULL,
  PRIMARY KEY (`idpedidos_pre`),
  KEY `fk_pedidos_pre_clientes_idx` (`clientes_idclientes`),
  CONSTRAINT `fk_pedidos_pre_clientes` FOREIGN KEY (`clientes_idclientes`) REFERENCES `clientes` (`idclientes`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidos_pre`
--

LOCK TABLES `pedidos_pre` WRITE;
/*!40000 ALTER TABLE `pedidos_pre` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedidos_pre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tallas`
--

DROP TABLE IF EXISTS `tallas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tallas` (
  `idtallas` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idtallas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tallas`
--

LOCK TABLES `tallas` WRITE;
/*!40000 ALTER TABLE `tallas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tallas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-07 19:04:27
