CREATE DATABASE  IF NOT EXISTS `beltexam4` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `beltexam4`;
-- MySQL dump 10.13  Distrib 5.7.12, for osx10.9 (x86_64)
--
-- Host: 127.0.0.1    Database: beltexam4
-- ------------------------------------------------------
-- Server version	5.6.33

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
-- Table structure for table `ideas`
--

DROP TABLE IF EXISTS `ideas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ideas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idea` varchar(45) DEFAULT NULL,
  `likes` varchar(45) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `users_id` int(11) NOT NULL,
  `alias` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ideas_users_idx` (`users_id`),
  CONSTRAINT `fk_ideas_users` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ideas`
--

LOCK TABLES `ideas` WRITE;
/*!40000 ALTER TABLE `ideas` DISABLE KEYS */;
INSERT INTO `ideas` VALUES (6,'dylan is gonna give michael a blackbelt even ','2','2017-02-03 16:54:05','2017-02-03 16:54:05',3,'dylan'),(7,'dylan rocks','2','2017-02-03 16:54:11','2017-02-03 16:54:11',3,'dylan'),(8,'dylan is gonna have really good dreams tonigh','2','2017-02-03 16:54:21','2017-02-03 16:54:21',3,'dylan'),(9,'michael is clearly the least wittiest person ','1','2017-02-03 16:54:33','2017-02-03 16:54:33',3,'dylan'),(10,'first post','1','2017-02-03 17:20:46','2017-02-03 17:20:46',4,'oli'),(11,'second post','0','2017-02-03 17:21:08','2017-02-03 17:21:08',4,'oli'),(12,'third post','0','2017-02-03 17:21:22','2017-02-03 17:21:22',4,'oli'),(13,'fourth post','0','2017-02-03 17:21:51','2017-02-03 17:21:51',4,'oli'),(14,'fifth post','0','2017-02-03 17:22:05','2017-02-03 17:22:05',4,'oli'),(15,'sixth post','1','2017-02-03 17:22:13','2017-02-03 17:22:13',4,'oli'),(17,'get some balls','0','2017-02-03 17:52:07','2017-02-03 17:52:07',6,'balls'),(18,'i love balls','0','2017-02-03 17:52:14','2017-02-03 17:52:14',6,'balls'),(19,'balls . balls balls','0','2017-02-03 17:52:19','2017-02-03 17:52:19',6,'balls');
/*!40000 ALTER TABLE `ideas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likes`
--

DROP TABLE IF EXISTS `likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `likes` (
  `users_id` int(11) NOT NULL,
  `ideas_id` int(11) NOT NULL,
  `like_count` int(11) DEFAULT NULL,
  PRIMARY KEY (`users_id`,`ideas_id`),
  KEY `fk_users_has_ideas_ideas1_idx` (`ideas_id`),
  KEY `fk_users_has_ideas_users1_idx` (`users_id`),
  CONSTRAINT `fk_users_has_ideas_ideas1` FOREIGN KEY (`ideas_id`) REFERENCES `ideas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_users_has_ideas_users1` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likes`
--

LOCK TABLES `likes` WRITE;
/*!40000 ALTER TABLE `likes` DISABLE KEYS */;
INSERT INTO `likes` VALUES (1,7,1),(1,8,1),(3,6,1),(3,9,1),(4,10,1),(4,15,1),(6,6,1),(6,7,1),(6,8,1);
/*!40000 ALTER TABLE `likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `alias` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `posts` int(11) DEFAULT NULL,
  `likes` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Michael','MJ','mj@gmail.com','AQAAAAEAACcQAAAAEKjCrsnNGSKU9RVF0qLE/UyvHJTn3zQU/+dznMabd48muvtmSGfoIeKPMIfubItcNg==','2017-02-03 16:13:10','2017-02-03 16:13:10',0,2),(2,'bob','bobby','bob@gmail.com','AQAAAAEAACcQAAAAEChPR3Cb3lKfSd1JJBA8PYV2fp8MObdwMvv+9yrA1OoJWhi+J0S8Ms3GyOYATdjVxQ==','2017-02-03 16:46:17','2017-02-03 16:46:17',0,2),(3,'Dylan','dylan','dylan@gmail.com','AQAAAAEAACcQAAAAEE5wF+UhTgZpFGPyCPoSiXX36EPM3IPwjh7vNS4SDCyV801P1CkBI41HvHAnLqwTOg==','2017-02-03 16:53:33','2017-02-03 16:53:33',4,4),(4,'oli','oli','oli@gmail.com','AQAAAAEAACcQAAAAEPHqf0u8EhaaPn1g/Rra8wCzZ3+UrhqdlWp0V8ftyhqrtDng2r8nTTpOhgp9o9cslA==','2017-02-03 17:20:26','2017-02-03 17:20:26',6,3),(5,'derp','derp','derpderp@gmail.com','AQAAAAEAACcQAAAAEH/cY/6Qyr5Klx2v/U/PKXUIhmcX0+O787ovKQk1mx+x65JiP5GKCT/BKp/brvEoSg==','2017-02-03 17:50:22','2017-02-03 17:50:22',0,0),(6,'balls','balls','balls@gmail.com','AQAAAAEAACcQAAAAEKq4TdWT73NN1luZsgr/3ucgLByUZQx85d20Sbv6RQG42Y5b/92VrWOflUfZ3RBfgA==','2017-02-03 17:52:01','2017-02-03 17:52:01',3,3);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-03 18:12:57
