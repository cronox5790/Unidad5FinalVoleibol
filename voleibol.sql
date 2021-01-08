CREATE DATABASE  IF NOT EXISTS `bdvoleibol` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bdvoleibol`;
-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: bdvoleibol
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrador`
--

DROP TABLE IF EXISTS `administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administrador` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Contrasena` varchar(100) NOT NULL COMMENT 'root',
  `Clave` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrador`
--

LOCK TABLES `administrador` WRITE;
/*!40000 ALTER TABLE `administrador` DISABLE KEYS */;
INSERT INTO `administrador` VALUES (14,'Cronox','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',5555);
/*!40000 ALTER TABLE `administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `directortecnico`
--

DROP TABLE IF EXISTS `directortecnico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `directortecnico` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Contrasena` varchar(100) NOT NULL,
  `Activo` bit(1) DEFAULT b'1',
  `Clave` int(11) NOT NULL,
  `Equipo` varchar(45) NOT NULL,
  `InternacionalesGanados` int(11) NOT NULL,
  `InternacionalesPerdidos` int(11) NOT NULL,
  `NacionalesGanados` int(11) NOT NULL,
  `NacionalesPerdidos` int(11) NOT NULL,
  `Seleccion` varchar(45) NOT NULL,
  `Tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `directortecnico`
--

LOCK TABLES `directortecnico` WRITE;
/*!40000 ALTER TABLE `directortecnico` DISABLE KEYS */;
INSERT INTO `directortecnico` VALUES (1,'Mario Cholin','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',_binary '',1234,'España',3,2,5,1,'Varonil','Sala'),(2,'Renan Dal Zotto','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',_binary '',2436,'Brasil',3,1,3,2,'Varonil','Sala'),(3,'Vital Heynen','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',_binary '',6215,'Alemania',4,2,1,3,'Varonil','Sala'),(4,'Laurent Tillie','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',_binary '',5131,'Francia',4,1,1,2,'Varonil','Sala'),(5,'Marcelo Mendez','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',_binary '',6138,'Argentina',1,3,2,4,'Varonil','Sala'),(6,'Carlos','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',_binary '',8131,'Mexico',2,3,2,3,'Varonil','Sala'),(7,'Belin','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',_binary '',8888,'Inglaterra',12,10,12,10,'Varonil','Playero');
/*!40000 ALTER TABLE `directortecnico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `integrantes`
--

DROP TABLE IF EXISTS `integrantes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `integrantes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Genero` varchar(45) NOT NULL,
  `Edad` int(10) NOT NULL,
  `IdDt` int(11) NOT NULL,
  `NumCamiseta` varchar(45) NOT NULL,
  `Posicion` varchar(45) NOT NULL,
  `Estado` varchar(45) NOT NULL,
  `Remate` int(10) NOT NULL,
  `Saque` int(10) NOT NULL,
  `Fuerza` int(10) NOT NULL,
  `Recepcion` int(10) NOT NULL,
  `Bloqueo` int(10) NOT NULL,
  `Salto` int(10) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_IdDt_idx` (`IdDt`),
  CONSTRAINT `fk_IdDt` FOREIGN KEY (`IdDt`) REFERENCES `directortecnico` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `integrantes`
--

LOCK TABLES `integrantes` WRITE;
/*!40000 ALTER TABLE `integrantes` DISABLE KEYS */;
INSERT INTO `integrantes` VALUES (7,'Alejandro Vigil','Hombre',27,1,'9','Central','titular',4,4,7,4,6,7),(8,'Andres Villena','Hombre',27,1,'13','Central','Titular',5,7,6,4,4,6),(9,'Miguel Formes','Hombre',27,1,'14','Central','Titular',4,7,3,3,5,6),(10,'Carlos Mora','Hombre',30,1,'23','Libero','Titular',5,6,4,3,4,5),(11,'Daniel Rocamora','Hombre',32,1,'9','Opuesto','suplente',4,3,4,5,3,4),(12,'Miguel Fernandez','Hombre',25,1,'35','Libero','suplente',4,4,3,5,2,3),(16,'Thaisa menez','Mujer',33,2,'5','Libero','Titular',4,4,4,3,5,2),(17,'Camila Brait','Mujer',32,2,'18','Opuesto','Titular',4,3,2,7,6,4),(18,'Tandara Caixeta','Mujer',32,2,'11','Central','Titular',3,5,2,4,4,4),(19,'Muriel Endres','Mujer',24,2,'3','Central','Titular',4,4,3,5,6,7),(20,'Luisa Endres','Mujer',25,2,'6','Libero','suplente',2,4,4,3,5,6),(21,'Sofia Cortez','Mujer',27,2,'8','Lateral Izquierdo','suplente',5,3,4,6,6,4),(22,'Maria Rodriguez','Mujer',26,2,'23','Colocador','Titular',4,2,2,5,3,3),(23,'Kathy Ramos','Mujer',21,2,'14','Lateral Izquierdo','Titular',2,4,4,4,4,5),(25,'Jenia Grebennikov','Hombre',29,4,'2','Central','Titular',7,6,3,5,2,4),(26,'Benjamin Toniutti','Hombre',31,4,'6','Central','suplente',7,8,3,5,6,7),(27,'Stéphen Boyer','Hombre',24,4,'13','Opuesto','Titular',5,5,3,4,6,3),(28,'Kévin Le Roux','Hombre',26,4,'15','Lateral Izquierdo','Titular',3,3,2,4,1,2),(29,'Trévor Clévenot','Hombre',26,4,'7','Libero','Titular',5,2,3,7,4,4),(30,'Louis Ventre','Hombre',25,4,'13','Colocador','Titular',4,5,2,5,7,6),(32,'Maten brinker','Mujer',34,3,'4','Central','Titular',2,3,2,3,4,5),(33,'Louisa Lippmann','Mujer',26,3,'11','Opuesto','Titular',4,5,3,1,5,3),(34,' Margareta Kozuch','Mujer',34,3,'14','Central','Titular',4,4,2,3,7,4),(35,'Saskia Hippe','Mujer',29,3,'15','Libero','Titular',3,5,2,7,6,7),(36,'Lenka Dürr','Mujer',30,3,'8','Lateral Izquierdo','Titular',4,5,6,3,7,4),(37,' Mareen Apitz','Mujer',30,3,'2','Central','suplente',4,4,3,6,4,5),(38,'Tere Muller','Mujer',23,3,'17','Lateral Izquierdo','Titular',3,3,2,4,5,6),(39,'Liz Vandik','Mujer',25,3,'17','Colocador','suplente',4,5,3,2,5,4),(40,'Facundo Conte','Hombre',31,5,'7','Central','Titular',4,5,2,6,5,4),(41,'Luciano De Cecco','Hombre',32,5,'18','Opuesto','Titular',4,5,3,5,2,4),(42,'Santiago Danani','Hombre',25,5,'9','Libero','Titular',5,5,2,7,8,4),(43,'Bruno Lima','Hombre',24,5,'12','Lateral Izquierdo','Titular',7,5,5,6,7,6),(44,'Nicolás Uriarte','Hombre',30,5,'5','Central','Titular',5,3,5,3,7,5),(45,'Matías Sánchez','Hombre',24,5,'1','Colocador','Titular',8,8,5,6,4,8),(46,'Ansu Fatti','Hombre',28,5,'14','Libero','suplente',5,6,4,7,3,4),(47,'Enzo Perez','Hombre',26,5,'20','Opuesto','suplente',2,6,5,3,1,3),(48,'Luis Antonio','Hombre',21,6,'5','Colocador','Titular',9,9,9,9,3,6),(49,'Roberto','Hombre',22,6,'67','Lateral Izquierdo','Titular',8,8,9,8,8,8),(54,'Carlos','Hombre',19,6,'76','Central','Titular',6,6,6,6,6,6),(55,'chiko','Hombre',19,6,'43','Opuesto','Titular',3,6,4,4,5,6),(56,'CarlosC ','Hombre',19,6,'32','Libero','Titular',3,3,4,4,3,5),(57,'Juan Bartoli','Hombre',19,6,'23','Central','Titular',5,9,4,6,7,8);
/*!40000 ALTER TABLE `integrantes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NomUser` varchar(45) NOT NULL,
  `Correo` varchar(45) NOT NULL,
  `Contraseña` tinytext NOT NULL,
  `Codigo` int(11) NOT NULL,
  `Activo` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Luis Antonio Aguilar Garza','chronoxone@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1312,_binary ''),(2,'Roberto Herrera','robertingostar@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',934,_binary ''),(3,'Roberto Herrera','robcar_he@hotmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1163,_binary ''),(8,'carlos','portangel_99@hotmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',903,_binary '\0');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-08  5:38:01
