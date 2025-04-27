-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : dim. 27 avr. 2025 à 14:53
-- Version du serveur : 8.3.0
-- Version de PHP : 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `innovationprojet2025`
--

-- --------------------------------------------------------

--
-- Structure de la table `equipement`
--

DROP TABLE IF EXISTS `equipement`;
CREATE TABLE IF NOT EXISTS `equipement` (
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

--
-- Déchargement des données de la table `equipement`
--

INSERT INTO `equipement` (`ID_Equipement`, `ID_Groupe`, `Type_equipement`, `Description_equipement`, `Marque`, `Modele`, `Commentaire`, `Adresse_IP`) VALUES
(1, 1, 'Serveur', 'Serveur HP ou Dell jsp', 'HP', 'OptiPlex', 'c\'est pas un serveur un optiplex', ''),
(2, 1, 'Serveur', 'Le ST250 V2 exploite une puissance de serveur de niveau entreprise avec les processeurs Intel Xeon E-2300.', 'Lenovo', 'ThinkSystem ST250 V2', 'Intel Xeon E-2356G 32 Go Tour (4U) Alimentation 750W', '');

-- --------------------------------------------------------

--
-- Structure de la table `groupemonitoring`
--

DROP TABLE IF EXISTS `groupemonitoring`;
CREATE TABLE IF NOT EXISTS `groupemonitoring` (
  `ID_Groupe` int NOT NULL AUTO_INCREMENT,
  `nom_groupem` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `droits` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`ID_Groupe`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `groupemonitoring`
--

INSERT INTO `groupemonitoring` (`ID_Groupe`, `nom_groupem`, `droits`, `description`) VALUES
(1, 'Clients', 'Création', 'Les utilisateurs principaux du logiciel.'),
(2, 'Administrateurs', 'Tout les droits', 'Gérant de l\'application.');

-- --------------------------------------------------------

--
-- Structure de la table `incident`
--

DROP TABLE IF EXISTS `incident`;
CREATE TABLE IF NOT EXISTS `incident` (
  `ID_Incident` int NOT NULL AUTO_INCREMENT,
  `ID_Equipement` int NOT NULL,
  `Rapport_Incident` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`ID_Incident`),
  KEY `ID_Equipement` (`ID_Equipement`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `incident`
--

INSERT INTO `incident` (`ID_Incident`, `ID_Equipement`, `Rapport_Incident`) VALUES
(1, 1, 'truc');

-- --------------------------------------------------------

--
-- Structure de la table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
CREATE TABLE IF NOT EXISTS `ticket` (
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

--
-- Déchargement des données de la table `ticket`
--

INSERT INTO `ticket` (`ID_Ticket`, `ID_Utilisateur`, `ID_Incident`, `Etat_Ticket`, `nom_ticket`, `Description_ticket`, `Type_de_tickets`, `Commentaire`) VALUES
(1, 1, 1, 'Ouvert', 'Truc', 'AAAAAAA', 'Bug', NULL),
(2, 1, 1, 'Ouvert', 'le ticket', 'numero 1', 'Maintenance', 'sqdqs'),
(3, 1, 1, 'En cours', 'ticket 2', 'dqdqsdqs', 'Maintenance', 'jadore les frites'),
(4, 2, 1, 'Fermé', 'Problème carte mère', 'Problème avec la carte mere', 'Amélioration', 'Test');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `ID_Utilisateur` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `prenom` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Mot_de_pass` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID_Utilisateur`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`ID_Utilisateur`, `nom`, `prenom`, `Email`, `Mot_de_pass`, `Type`) VALUES
(1, 'DIAKITE', 'Balla', 'sonikast@hotmail.com', 'mdp', 'Admin'),
(2, 'diakate', 'balle', 'ballamoussa57@gmail.com', 'mdp', 'Client');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
