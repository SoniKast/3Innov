-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: innovationprojet2025
-- ------------------------------------------------------
-- Server version	8.3.0

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
-- Table structure for table `equipement`
--

DROP TABLE IF EXISTS `equipement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipement` (
  `ID_Equipement` int NOT NULL AUTO_INCREMENT,
  `ID_Groupe` int NOT NULL,
  `Type_equipement` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Description_equipement` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `Marque` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Modele` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Commentaire` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `Adresse_IP` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID_Equipement`),
  KEY `ID_Groupe` (`ID_Groupe`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipement`
--

LOCK TABLES `equipement` WRITE;
/*!40000 ALTER TABLE `equipement` DISABLE KEYS */;
INSERT INTO `equipement` VALUES (1,1,'Serveur','Serveur HP ou Dell jsp','HP','OptiPlex','c\'est pas un serveur un optiplex','192.168.204.1'),(2,1,'Serveur','Le ST250 V2 exploite une puissance de serveur de niveau entreprise avec les processeurs Intel Xeon E-2300.','Lenovo','ThinkSystem ST250 V2','Intel Xeon E-2356G 32 Go Tour (4U) Alimentation 750W','');
/*!40000 ALTER TABLE `equipement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groupemonitoring`
--

DROP TABLE IF EXISTS `groupemonitoring`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `groupemonitoring` (
  `ID_Groupe` int NOT NULL AUTO_INCREMENT,
  `nom_groupem` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `droits` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`ID_Groupe`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groupemonitoring`
--

LOCK TABLES `groupemonitoring` WRITE;
/*!40000 ALTER TABLE `groupemonitoring` DISABLE KEYS */;
INSERT INTO `groupemonitoring` VALUES (1,'Clients','Création','Les utilisateurs principaux du logiciel.'),(2,'Administrateurs','Tout les droits','Gérant de l\'application.');
/*!40000 ALTER TABLE `groupemonitoring` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `incident`
--

DROP TABLE IF EXISTS `incident`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `incident` (
  `ID_Incident` int NOT NULL AUTO_INCREMENT,
  `ID_Equipement` int NOT NULL,
  `Rapport_Incident` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`ID_Incident`),
  KEY `ID_Equipement` (`ID_Equipement`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incident`
--

LOCK TABLES `incident` WRITE;
/*!40000 ALTER TABLE `incident` DISABLE KEYS */;
INSERT INTO `incident` VALUES (1,1,'truc');
/*!40000 ALTER TABLE `incident` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticket` (
  `ID_Ticket` int NOT NULL AUTO_INCREMENT,
  `ID_Utilisateur` int NOT NULL,
  `ID_Incident` int NOT NULL,
  `Etat_Ticket` enum('Ouvert','En cours','Fermé') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nom_ticket` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Description_ticket` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `Type_de_tickets` enum('Bug','Maintenance','Amélioration') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Commentaire` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`ID_Ticket`),
  KEY `ID_Utilisateur` (`ID_Utilisateur`),
  KEY `ID_Incident` (`ID_Incident`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket`
--

LOCK TABLES `ticket` WRITE;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
INSERT INTO `ticket` VALUES (1,1,1,'Ouvert','Truc','AAAAAAA','Bug',NULL),(2,1,1,'Ouvert','le ticket','numero 1','Maintenance','sqdqs'),(3,1,1,'En cours','ticket 2','dqdqsdqs','Maintenance','jadore les frites'),(4,2,1,'Fermé','Problème carte mère','Problème avec la carte mere','Amélioration','Test');
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateur` (
  `ID_Utilisateur` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `prenom` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Mot_de_pass` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID_Utilisateur`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur`
--

LOCK TABLES `utilisateur` WRITE;
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
INSERT INTO `utilisateur` VALUES (1,'DIAKITE','Balla','sonikast@hotmail.com','$2a$11$czEAuRD5DNedmJIgbK4cfOCJMpNrUrwNHQVcLtfKVqwjZzqwfW3Ey','Admin'),(2,'diakate','balle','ballamoussa57@gmail.com','$2a$11$p/Kj8rnnL.3UzgsDSN/1ZeIUZVKQSvOOcKruJYMBe23Tv.5.Qqkuu','Client'),
(3,'TERIEUR','Alex','alex.terieur@gmail.com','$2a$11$FbY8HjMEL7INvw6eXVAvlOwH670WN8v9xQjLTNU52HMRzY7wVKF1G','Admin');
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-03  0:31:15
