-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.40-community


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema lamolinventory
--

CREATE DATABASE IF NOT EXISTS lamolinventory;
USE lamolinventory;

--
-- Definition of table `barcodes`
--

DROP TABLE IF EXISTS `barcodes`;
CREATE TABLE `barcodes` (
  `bartype` varchar(20) NOT NULL,
  `types` varchar(45) NOT NULL,
  PRIMARY KEY (`bartype`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barcodes`
--

/*!40000 ALTER TABLE `barcodes` DISABLE KEYS */;
INSERT INTO `barcodes` (`bartype`,`types`) VALUES 
 ('1','barcode');
/*!40000 ALTER TABLE `barcodes` ENABLE KEYS */;


--
-- Definition of table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE `categories` (
  `categ_id` varchar(100) NOT NULL,
  `categ` varchar(100) NOT NULL,
  PRIMARY KEY (`categ_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categories`
--

/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` (`categ_id`,`categ`) VALUES 
 ('ACC201212612354','Accessories'),
 ('BOO201212612352','Book'),
 ('CAR201229223911921','Card'),
 ('CLO201212612355','Clothings'),
 ('ELE201212612358','Electronics'),
 ('FOO201212612359','Food & Beverages'),
 ('HOU20122112114785','Housewares'),
 ('NOT201212612351','Notebook'),
 ('OTH201212612357','Other School Materials'),
 ('PAP2012126206','Papers'),
 ('PEN201212612353','Pens'),
 ('SHO201212612356','Shoes');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;


--
-- Definition of table `itemlist`
--

DROP TABLE IF EXISTS `itemlist`;
CREATE TABLE `itemlist` (
  `item_no` varchar(100) NOT NULL,
  `item_name` varchar(300) NOT NULL,
  `categ` varchar(100) NOT NULL,
  `origprice` decimal(10,0) NOT NULL,
  `srp` decimal(10,2) NOT NULL,
  `unit` varchar(100) NOT NULL,
  `quan` int(10) unsigned NOT NULL,
  `supp` varchar(100) DEFAULT NULL,
  `oprice` decimal(10,2) NOT NULL,
  PRIMARY KEY (`item_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `itemlist`
--

/*!40000 ALTER TABLE `itemlist` DISABLE KEYS */;
INSERT INTO `itemlist` (`item_no`,`item_name`,`categ`,`origprice`,`srp`,`unit`,`quan`,`supp`,`oprice`) VALUES 
 ('00000','STABILO BOSS','Pens','50','24.00','PCS',49,'VENDO','11.00'),
 ('00001','E MACHINES D725','Electronics','5','25000.00','PCS',0,'ACER','20000.00'),
 ('00003','PELICAN GRIEF J GRISHAM','Book','75','275.00','PCS',99,'RICKIS','111.00'),
 ('00004','GERALDS GAME S KING','Book','100','275.00','PCS',99,'RICKIS','200.00'),
 ('00005','J BLUME SMART WOMEN','Book','100','250.50','PCS',6,'RICKIS','120.00'),
 ('00006','TOM PALO','Papers','90','16.90','PCS',38,'PILOT','13.00'),
 ('00007','CHELSEA LAADIES SANDALS BLUE','Shoes','20','999.99','PCS',24,'CHELSEA','400.00'),
 ('00009','SKIN WHITE SPF 20','Other School Materials','20','80.00','PCS',75,'VENDO','30.00'),
 ('00010','BAYGON SCENTED COIL','Housewares','20','20.00','YARD',24,'VENDO','8.00'),
 ('00011','OFF FOR KIDS','Accessories','20','17.00','PCS',198,'VENDO','2.00'),
 ('00012','REPSODA','Notebook','100','9.00','PCS',96,'VENDO','2.00'),
 ('00017','SEABISCUIT A. LEGEND  L HILLENBRAND','Book','60','199.00','PCS',235,'RICKIS','199.00'),
 ('00018','WRITING AND REPORTING NEWS','Book','50','380.00','PCS',84,'VENDO','278.00'),
 ('00019','MALAYAN JACKET BLUE S','Clothing','50','550.00','PCS',1,'VENDO','333.00'),
 ('00021','YELLOW PAPER 5S','Papers','100','3.50','PCS',19096,'VV','0.50'),
 ('00022','PILOT GTECH 0.3','Pens','50','70.00','PCS',107,'PILOT','22.00'),
 ('00023','SASA','Pens','10','13.00','PCS',13,'PILOT','10.00'),
 ('00024','BUDDHA BEAD 1','Accessories','3','3.90','BUNDLES',32,'PILOT','3.00'),
 ('00027','SAMSUNG','Electronics','10','6498.70','PCS',20,'RICKIS','4999.00'),
 ('00028','GTECH BLACK','Pens','50','87.10','PCS',100,'PILOT','67.00'),
 ('00029','GTECH RED','Pens','50','87.10','PCS',100,'','67.00'),
 ('00030','PENCIL','Pens','20','7.80','PCS',50,'PILOT','6.00'),
 ('00033','POTIE PEN','Pens','50','13.00','PCS',37,'PILOT','10.00'),
 ('00034','HBW BLACK','Pens','100','6.50','BUNDLES',124,'PILOT','5.00'),
 ('00035','BOOKLET SMALL','Papers','50','6.50','PCS',95,'PAPERS CO.','5.00'),
 ('00036','RIDA','Pens','40','26.00','PCS',200,'PILOT','20.00'),
 ('00037','POTIBOOK','Book','20','78.00','YARD',100,'POTIE','60.00'),
 ('00038','DAFFU DOCK','Accessories','100','26.00','BUNDLES',200,'PAPERS CO.','20.00');
/*!40000 ALTER TABLE `itemlist` ENABLE KEYS */;


--
-- Definition of table `logs`
--

DROP TABLE IF EXISTS `logs`;
CREATE TABLE `logs` (
  `user_code` varchar(100) NOT NULL,
  `userna` varchar(100) NOT NULL,
  `passw` varchar(300) NOT NULL,
  `names` varchar(200) NOT NULL,
  `addr` varchar(400) NOT NULL,
  `connum` varchar(50) NOT NULL,
  `eadd` varchar(100) NOT NULL,
  `types` varchar(50) NOT NULL,
  PRIMARY KEY (`user_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `logs`
--

/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
INSERT INTO `logs` (`user_code`,`userna`,`passw`,`names`,`addr`,`connum`,`eadd`,`types`) VALUES 
 ('U2012128237','rblaserna','rblaserna','RACHEL B. LASERNA','345 GOLDEN RD., STA ROSA, LAGUNA','09349939393','RBLASERNA@MCL.EDU.PH','USER'),
 ('U2012128957','s','s','LESLIE G. MOLINYAWE','PUROK 3, CELESTINA HMS, BANLIC, CABUYAO','09239993838','lgmolinyawe@mcl.edu.ph','ADMIN'),
 ('U201227464','a','a','PATRICK POTESTAD','GOLDEN CITY','0920-300-3432','BANTHONY@GMAIL.COM','USER');
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;


--
-- Definition of table `security`
--

DROP TABLE IF EXISTS `security`;
CREATE TABLE `security` (
  `ids` varchar(100) NOT NULL,
  `notes` varchar(300) NOT NULL,
  `dates` varchar(100) NOT NULL,
  `users` varchar(100) NOT NULL,
  `term` varchar(100) NOT NULL,
  PRIMARY KEY (`ids`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `security`
--

/*!40000 ALTER TABLE `security` DISABLE KEYS */;
INSERT INTO `security` (`ids`,`notes`,`dates`,`users`,`term`) VALUES 
 ('3/10/2012 4:16:06 PM(162)_s','The user logged in.','3/10/2012 4:16:06 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 4:16:08 PM(85)_LESLIE G. MOLINYAWE','The user logged out.','3/10/2012 4:16:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 4:16:09 PM(927)_a','The user logged in.','3/10/2012 4:16:09 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 4:16:49 PM(634)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012310618','3/10/2012 4:16:49 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 4:17:03 PM(120)_PATRICK POTESTAD','The user logged out.','3/10/2012 4:17:03 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 4:25:08 PM(177)_a','The user logged in.','3/10/2012 4:25:08 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 4:25:34 PM(444)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012310435','3/10/2012 4:25:34 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 6:23:47 PM(529)_a','The user logged in.','3/10/2012 6:23:47 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 6:24:17 PM(285)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012310231','3/10/2012 6:24:17 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 7:01:23 PM(402)_a','The user logged in.','3/10/2012 7:01:23 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 7:01:45 PM(875)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012310865','3/10/2012 7:01:45 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 7:52:00 PM(802)_a','The user logged in.','3/10/2012 7:52:00 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 7:52:24 PM(36)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS201231027','3/10/2012 7:52:24 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:13:09 PM(286)_a','The user logged in.','3/10/2012 8:13:09 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:18:24 PM(722)_a','The user logged in.','3/10/2012 8:18:24 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:20:20 PM(351)_a','The user logged in.','3/10/2012 8:20:20 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:23:52 PM(802)_a','The user logged in.','3/10/2012 8:23:52 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:26:13 PM(969)_s','The user logged in.','3/10/2012 8:26:13 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 8:26:18 PM(2)_LESLIE G. MOLINYAWE','The user logged out.','3/10/2012 8:26:18 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 8:26:19 PM(903)_a','The user logged in.','3/10/2012 8:26:19 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:26:34 PM(301)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012310292','3/10/2012 8:26:34 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:43:35 PM(557)_a','The user logged in.','3/10/2012 8:43:35 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:43:54 PM(898)_PATRICK POTESTAD','Voided Transaction ID: TRANS2012310292','3/10/2012 8:43:54 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 8:58:26 PM(0)_s','The user logged in.','3/10/2012 8:58:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 8:59:51 PM(8)_s','The user logged in.','3/10/2012 8:59:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:00:31 PM(161)_s','The user logged in.','3/10/2012 9:00:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:04:46 PM(200)_s','The user logged in.','3/10/2012 9:04:46 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:08:22 PM(207)_s','The user logged in.','3/10/2012 9:08:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:09:02 PM(120)_s','The user logged in.','3/10/2012 9:09:02 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:14:43 PM(966)_s','The user logged in.','3/10/2012 9:14:43 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:17:47 PM(990)_s','The user logged in.','3/10/2012 9:17:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:18:16 PM(649)_s','The user logged in.','3/10/2012 9:18:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:22:47 PM(664)_s','The user logged in.','3/10/2012 9:22:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:29:03 PM(624)_s','The user logged in.','3/10/2012 9:29:03 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:32:29 PM(1)_s','The user logged in.','3/10/2012 9:32:29 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:34:44 PM(802)_s','The user logged in.','3/10/2012 9:34:44 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:35:17 PM(993)_s','The user logged in.','3/10/2012 9:35:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/10/2012 9:38:46 PM(757)_a','The user logged in.','3/10/2012 9:38:46 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 9:39:07 PM(976)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012310963','3/10/2012 9:39:07 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 9:39:40 PM(530)_PATRICK POTESTAD','Voided Transaction ID: TRANS2012310963','3/10/2012 9:39:40 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 9:39:54 PM(666)_PATRICK POTESTAD','The user logged out.','3/10/2012 9:39:54 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/10/2012 9:39:59 PM(32)_s','The user logged in.','3/10/2012 9:39:59 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 11:30:44 AM(612)_a','The user logged in.','3/12/2012 11:30:44 AM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/12/2012 11:31:00 AM(185)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012312122','3/12/2012 11:31:00 AM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/12/2012 1:52:26 PM(190)_s','The user logged in.','3/12/2012 1:52:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 1:55:01 PM(455)_s','Added item bag','3/12/2012 1:55:01 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 4:24:57 PM(396)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/12/2012 4:24:57 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:25:07 PM(90)_ANONYMOUS','Someone is trying to log-in a username [ ssssss ] but failed.','3/12/2012 4:25:07 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:25:13 PM(418)_ANONYMOUS','Someone is trying to log-in a username [ ssssss ] but failed.','3/12/2012 4:25:13 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:25:31 PM(778)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/12/2012 4:25:31 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:25:41 PM(669)_ANONYMOUS','Someone is trying to log-in a username [ admin ] but failed.','3/12/2012 4:25:41 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:25:46 PM(546)_s','The user logged in.','3/12/2012 4:25:46 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 4:26:56 PM(854)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/12/2012 4:26:56 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:27:06 PM(712)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/12/2012 4:27:06 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:27:17 PM(764)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/12/2012 4:27:17 PM','ANONYMOUS','2011-2012/3T'),
 ('3/12/2012 4:28:10 PM(335)_rblaserna','The user logged in.','3/12/2012 4:28:10 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 4:34:51 PM(444)_s','Added item Bond Paper','3/12/2012 4:34:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 4:36:30 PM(805)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012312769','3/12/2012 4:36:30 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 4:38:14 PM(397)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012312387','3/12/2012 4:38:14 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 4:40:54 PM(35)_RACHEL B. LASERNA','Voided Transaction ID: trans2012312387','3/12/2012 4:40:54 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 5:15:21 PM(373)_s','The user logged in.','3/12/2012 5:15:21 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 6:12:30 PM(592)_s','The user logged in.','3/12/2012 6:12:30 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 7:52:10 PM(132)_LESLIE G. MOLINYAWE','The user logged out.','3/12/2012 7:52:10 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 7:52:20 PM(708)_rblaserna','The user logged in.','3/12/2012 7:52:20 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 8:02:50 PM(830)_s','The user logged in.','3/12/2012 8:02:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 8:04:17 PM(722)_s','Added item mini notebook','3/12/2012 8:04:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 8:05:51 PM(273)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012312214','3/12/2012 8:05:51 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 8:07:16 PM(822)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012312814','3/12/2012 8:07:16 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 8:08:39 PM(101)_s','Updated item MINI NOTEBOOK','3/12/2012 8:08:39 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 8:09:14 PM(97)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS201231287','3/12/2012 8:09:14 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 8:19:47 PM(324)_RACHEL B. LASERNA','The user logged out.','3/12/2012 8:19:47 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/12/2012 8:19:47 PM(954)_LESLIE G. MOLINYAWE','The user logged out.','3/12/2012 8:19:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 8:19:50 PM(947)_s','The user logged in.','3/12/2012 8:19:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 8:37:12 PM(615)_s','The user logged in.','3/12/2012 8:37:12 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/12/2012 8:37:23 PM(220)_LESLIE G. MOLINYAWE','The user logged out.','3/12/2012 8:37:23 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 11:52:36 AM(960)_s','The user logged in.','3/13/2012 11:52:36 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 11:53:09 AM(18)_LESLIE G. MOLINYAWE','The user logged out.','3/13/2012 11:53:09 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 11:53:18 AM(408)_rblaserna','The user logged in.','3/13/2012 11:53:18 AM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/13/2012 11:57:57 AM(288)_s','The user logged in.','3/13/2012 11:57:57 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 12:02:56 PM(370)_LESLIE G. MOLINYAWE','The user logged out.','3/13/2012 12:02:56 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 12:03:01 PM(392)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/13/2012 12:03:01 PM','ANONYMOUS','2011-2012/3T'),
 ('3/13/2012 12:03:12 PM(81)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/13/2012 12:03:12 PM','ANONYMOUS','2011-2012/3T'),
 ('3/13/2012 12:03:19 PM(799)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/13/2012 12:03:19 PM','ANONYMOUS','2011-2012/3T'),
 ('3/13/2012 12:03:34 PM(539)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/13/2012 12:03:34 PM','ANONYMOUS','2011-2012/3T'),
 ('3/13/2012 12:03:52 PM(634)_ANONYMOUS','Someone is trying to log-in a username [ rb laserna ] but failed.','3/13/2012 12:03:52 PM','ANONYMOUS','2011-2012/3T'),
 ('3/13/2012 12:04:09 PM(332)_rblaserna','The user logged in.','3/13/2012 12:04:09 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/13/2012 12:04:45 PM(232)_RACHEL B. LASERNA','The user logged out.','3/13/2012 12:04:45 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/13/2012 12:04:51 PM(350)_s','The user logged in.','3/13/2012 12:04:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 12:05:20 PM(763)_s','The user logged in.','3/13/2012 12:05:20 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 12:09:12 PM(541)_s','The user logged in.','3/13/2012 12:09:12 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 12:12:08 PM(534)_s','The user logged in.','3/13/2012 12:12:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 12:13:55 PM(78)_s','The user logged in.','3/13/2012 12:13:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 1:50:26 PM(377)_s','The user logged in.','3/13/2012 1:50:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 1:53:27 PM(805)_s','Added item Pencil','3/13/2012 1:53:27 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 1:54:23 PM(14)_LESLIE G. MOLINYAWE','The user logged out.','3/13/2012 1:54:23 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/13/2012 1:54:33 PM(840)_rblaserna','The user logged in.','3/13/2012 1:54:33 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/13/2012 1:58:58 PM(688)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012313626','3/13/2012 1:58:58 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/13/2012 1:59:51 PM(490)_RACHEL B. LASERNA','The user logged out.','3/13/2012 1:59:51 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/13/2012 1:59:55 PM(460)_s','The user logged in.','3/13/2012 1:59:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:20:20 PM(313)_s','The user logged in.','3/15/2012 1:20:20 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:21:11 PM(626)_s','The user logged in.','3/15/2012 1:21:11 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:23:16 PM(977)_s','The user logged in.','3/15/2012 1:23:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:24:06 PM(114)_s','Added item 30 Days Of Summer','3/15/2012 1:24:06 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:26:54 PM(49)_s','The user logged in.','3/15/2012 1:26:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:27:03 PM(123)_s','Updated item BOND PAPER','3/15/2012 1:27:03 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:27:28 PM(922)_s','Updated item BOND PAPER','3/15/2012 1:27:28 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:27:39 PM(866)_s','Updated item BOND PAPER','3/15/2012 1:27:39 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:28:33 PM(729)_s','The user logged in.','3/15/2012 1:28:33 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:28:53 PM(10)_s','Updated item 30 DAYS OF SUMMER','3/15/2012 1:28:53 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:37:16 PM(450)_s','The user logged in.','3/15/2012 1:37:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:38:13 PM(806)_s','The user logged in.','3/15/2012 1:38:13 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:48:46 PM(930)_s','The user logged in.','3/15/2012 1:48:46 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:48:50 PM(698)_LESLIE G. MOLINYAWE','The user logged out.','3/15/2012 1:48:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:48:52 PM(932)_a','The user logged in.','3/15/2012 1:48:52 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 1:50:15 PM(858)_a','The user logged in.','3/15/2012 1:50:15 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 1:51:27 PM(60)_s','The user logged in.','3/15/2012 1:51:27 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:51:30 PM(186)_LESLIE G. MOLINYAWE','The user logged out.','3/15/2012 1:51:30 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 1:51:32 PM(201)_a','The user logged in.','3/15/2012 1:51:32 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 1:53:28 PM(299)_a','The user logged in.','3/15/2012 1:53:28 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 1:55:41 PM(603)_a','The user logged in.','3/15/2012 1:55:41 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:33:17 PM(370)_s','The user logged in.','3/15/2012 2:33:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 2:33:21 PM(889)_LESLIE G. MOLINYAWE','The user logged out.','3/15/2012 2:33:21 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 2:33:24 PM(596)_a','The user logged in.','3/15/2012 2:33:24 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:33:36 PM(671)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012315662','3/15/2012 2:33:36 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:36:40 PM(514)_s','The user logged in.','3/15/2012 2:36:40 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 2:38:41 PM(866)_s','The user logged in.','3/15/2012 2:38:41 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 2:45:18 PM(625)_a','The user logged in.','3/15/2012 2:45:18 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:46:01 PM(722)_s','The user logged in.','3/15/2012 2:46:01 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 2:46:04 PM(916)_LESLIE G. MOLINYAWE','The user logged out.','3/15/2012 2:46:04 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/15/2012 2:46:06 PM(745)_a','The user logged in.','3/15/2012 2:46:06 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:46:37 PM(299)_a','The user logged in.','3/15/2012 2:46:37 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:47:35 PM(691)_a','The user logged in.','3/15/2012 2:47:35 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:56:38 PM(563)_a','The user logged in.','3/15/2012 2:56:38 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:57:20 PM(546)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012315536','3/15/2012 2:57:20 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:57:52 PM(573)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012315565','3/15/2012 2:57:52 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:58:40 PM(498)_a','The user logged in.','3/15/2012 2:58:40 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/15/2012 2:59:01 PM(203)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012315192','3/15/2012 2:59:01 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 12:23:31 PM(424)_s','The user logged in.','3/16/2012 12:23:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 12:23:54 PM(293)_LESLIE G. MOLINYAWE','The user logged out.','3/16/2012 12:23:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 12:23:55 PM(991)_a','The user logged in.','3/16/2012 12:23:55 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:37:30 PM(797)_a','The user logged in.','3/16/2012 2:37:30 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:38:29 PM(394)_a','The user logged in.','3/16/2012 2:38:29 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:39:33 PM(888)_s','The user logged in.','3/16/2012 2:39:33 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 2:39:42 PM(62)_LESLIE G. MOLINYAWE','The user logged out.','3/16/2012 2:39:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 2:39:43 PM(897)_a','The user logged in.','3/16/2012 2:39:43 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:40:23 PM(10)_a','The user logged in.','3/16/2012 2:40:23 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:42:31 PM(468)_a','The user logged in.','3/16/2012 2:42:31 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:43:22 PM(184)_s','The user logged in.','3/16/2012 2:43:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 2:43:26 PM(427)_LESLIE G. MOLINYAWE','The user logged out.','3/16/2012 2:43:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 2:43:27 PM(812)_a','The user logged in.','3/16/2012 2:43:27 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:45:18 PM(765)_a','The user logged in.','3/16/2012 2:45:18 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:47:21 PM(60)_a','The user logged in.','3/16/2012 2:47:21 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:48:24 PM(379)_a','The user logged in.','3/16/2012 2:48:24 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 2:49:26 PM(844)_s','The user logged in.','3/16/2012 2:49:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 2:50:39 PM(722)_a','The user logged in.','3/16/2012 2:50:39 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/16/2012 5:22:01 PM(272)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/16/2012 5:22:01 PM','ANONYMOUS','2011-2012/3T'),
 ('3/16/2012 5:22:13 PM(736)_rblaserna','The user logged in.','3/16/2012 5:22:13 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 5:25:01 PM(248)_rblaserna','The user logged in.','3/16/2012 5:25:01 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 5:26:45 PM(535)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316473','3/16/2012 5:26:45 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 5:27:33 PM(642)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316642','3/16/2012 5:27:33 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 5:32:18 PM(451)_RACHEL B. LASERNA','The user logged out.','3/16/2012 5:32:18 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 5:32:28 PM(740)_ANONYMOUS','Someone is trying to log-in a username [ ssssss ] but failed.','3/16/2012 5:32:28 PM','ANONYMOUS','2011-2012/3T'),
 ('3/16/2012 5:32:35 PM(237)_s','The user logged in.','3/16/2012 5:32:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 6:12:32 PM(348)_rblaserna','The user logged in.','3/16/2012 6:12:32 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:29:17 PM(944)_rblaserna','The user logged in.','3/16/2012 6:29:17 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:32:59 PM(622)_rblaserna','The user logged in.','3/16/2012 6:32:59 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:37:27 PM(85)_rblaserna','The user logged in.','3/16/2012 6:37:27 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:38:42 PM(557)_rblaserna','The user logged in.','3/16/2012 6:38:42 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:40:03 PM(899)_rblaserna','The user logged in.','3/16/2012 6:40:03 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:43:58 PM(941)_rblaserna','The user logged in.','3/16/2012 6:43:58 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:45:24 PM(593)_rblaserna','The user logged in.','3/16/2012 6:45:24 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 6:58:50 PM(129)_s','The user logged in.','3/16/2012 6:58:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:02:18 PM(841)_s','Added item Damet','3/16/2012 7:02:18 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:03:31 PM(581)_s','Updated item DAMET','3/16/2012 7:03:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:04:57 PM(913)_LESLIE G. MOLINYAWE','The user logged out.','3/16/2012 7:04:57 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:05:05 PM(506)_ANONYMOUS','Someone is trying to log-in a username [ aaaaaa ] but failed.','3/16/2012 7:05:05 PM','ANONYMOUS','2011-2012/3T'),
 ('3/16/2012 7:05:32 PM(770)_rblaserna','The user logged in.','3/16/2012 7:05:32 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:07:22 PM(347)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316338','3/16/2012 7:07:22 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:09:03 PM(90)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS201231682','3/16/2012 7:09:03 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:21:26 PM(593)_rblaserna','The user logged in.','3/16/2012 7:21:26 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:24:03 PM(996)_ANONYMOUS','Someone is trying to log-in a username [ rblserna ] but failed.','3/16/2012 7:24:03 PM','ANONYMOUS','2011-2012/3T'),
 ('3/16/2012 7:24:19 PM(613)_rblaserna','The user logged in.','3/16/2012 7:24:19 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:25:23 PM(303)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316233','3/16/2012 7:25:23 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:29:16 PM(582)_rblaserna','The user logged in.','3/16/2012 7:29:16 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:35:00 PM(989)_rblaserna','The user logged in.','3/16/2012 7:35:00 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:36:37 PM(47)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS201231637','3/16/2012 7:36:37 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:40:39 PM(457)_RACHEL B. LASERNA','The user logged out.','3/16/2012 7:40:39 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 7:40:46 PM(842)_s','The user logged in.','3/16/2012 7:40:46 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:49:31 PM(692)_s','The user logged in.','3/16/2012 7:49:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:50:50 PM(732)_s','The user logged in.','3/16/2012 7:50:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:55:31 PM(707)_s','The user logged in.','3/16/2012 7:55:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:57:08 PM(62)_s','The user logged in.','3/16/2012 7:57:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 7:57:44 PM(139)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS201231682','3/16/2012 7:57:44 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 8:02:58 PM(176)_s','Added item pOTIE pEN','3/16/2012 8:02:58 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/16/2012 8:19:31 PM(517)_rblaserna','The user logged in.','3/16/2012 8:19:31 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 8:21:19 PM(251)_RACHEL B. LASERNA','The user logged out.','3/16/2012 8:21:19 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 8:21:30 PM(30)_rblaserna','The user logged in.','3/16/2012 8:21:30 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 8:30:49 PM(406)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316396','3/16/2012 8:30:49 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 8:31:00 PM(827)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316819','3/16/2012 8:31:00 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 8:31:16 PM(31)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS20123166','3/16/2012 8:31:16 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/16/2012 8:33:06 PM(259)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012316251','3/16/2012 8:33:06 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 10:45:00 PM(292)_a','The user logged in.','3/17/2012 10:45:00 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/17/2012 10:45:28 PM(18)_PATRICK POTESTAD','The user logged out.','3/17/2012 10:45:28 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/17/2012 10:45:31 PM(524)_s','The user logged in.','3/17/2012 10:45:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 10:46:34 PM(142)_s','Added item AVON LOTION','3/17/2012 10:46:34 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 10:47:56 PM(472)_a','The user logged in.','3/17/2012 10:47:56 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/17/2012 10:48:25 PM(947)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012317937','3/17/2012 10:48:25 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/17/2012 1:32:58 PM(715)_rblaserna','The user logged in.','3/17/2012 1:32:58 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 1:34:42 PM(987)_RACHEL B. LASERNA','The user logged out.','3/17/2012 1:34:42 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 1:34:45 PM(617)_s','The user logged in.','3/17/2012 1:34:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:36:21 PM(203)_rblaserna','The user logged in.','3/17/2012 1:36:21 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 1:36:28 PM(365)_RACHEL B. LASERNA','The user logged out.','3/17/2012 1:36:28 PM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 1:36:32 PM(655)_s','The user logged in.','3/17/2012 1:36:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:55:15 PM(38)_s','The user logged in.','3/17/2012 1:55:15 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:56:02 PM(858)_s','Deleted item BAG','3/17/2012 1:56:02 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:56:33 PM(980)_s','Deleted item MINI NOTEBOOK','3/17/2012 1:56:33 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:57:06 PM(678)_s','Deleted item 30 DAYS OF SUMMER','3/17/2012 1:57:06 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:57:52 PM(664)_s','The user logged in.','3/17/2012 1:57:52 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 1:58:32 PM(54)_s','Deleted item BOND PAPER','3/17/2012 1:58:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:03:25 PM(975)_s','The user logged in.','3/17/2012 2:03:25 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:04:55 PM(504)_s','Deleted item NATA DE COKI','3/17/2012 2:04:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:06:29 PM(814)_s','The user logged in.','3/17/2012 2:06:29 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:06:42 PM(650)_s','Deleted item CD-R KING BARCODE SCANNER BLACK','3/17/2012 2:06:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:06:56 PM(446)_s','Deleted item MARLEY & ME J GROGAN','3/17/2012 2:06:56 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:09:01 PM(539)_s','The user logged in.','3/17/2012 2:09:01 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:10:06 PM(483)_s','The user logged in.','3/17/2012 2:10:06 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:12:52 PM(314)_s','The user logged in.','3/17/2012 2:12:52 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:15:22 PM(10)_s','The user logged in.','3/17/2012 2:15:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:18:32 PM(63)_s','The user logged in.','3/17/2012 2:18:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:19:51 PM(512)_s','The user logged in.','3/17/2012 2:19:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:32:28 PM(777)_s','The user logged in.','3/17/2012 2:32:28 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:34:13 PM(793)_s','The user logged in.','3/17/2012 2:34:13 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:34:24 PM(157)_s','Deleted item BUDDHA BEAD 3','3/17/2012 2:34:24 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:35:48 PM(34)_s','The user logged in.','3/17/2012 2:35:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:35:56 PM(982)_s','Deleted item CRAYOLA 16S','3/17/2012 2:35:56 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:36:09 PM(540)_s','Deleted item CRAYOLA 16S','3/17/2012 2:36:09 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:36:22 PM(286)_s','Deleted item LOST WORLD M CRICHTON','3/17/2012 2:36:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:40:53 PM(826)_a','The user logged in.','3/17/2012 2:40:53 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/17/2012 2:44:57 PM(409)_s','The user logged in.','3/17/2012 2:44:57 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 2:45:44 PM(591)_s','Deleted item SUN CELLULAR WINNER SIM','3/17/2012 2:45:44 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 3:31:30 PM(413)_s','The user logged in.','3/17/2012 3:31:30 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 3:31:47 PM(544)_s','Deleted item DAMET','3/17/2012 3:31:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 3:32:31 PM(765)_s','Added item jkkjkk','3/17/2012 3:32:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 3:34:02 PM(683)_s','Added item samsung','3/17/2012 3:34:02 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 3:35:45 PM(519)_s','Added item GTECH BLACK','3/17/2012 3:35:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 3:36:27 PM(795)_s','Added item GTECH red','3/17/2012 3:36:27 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 4:20:21 PM(676)_a','The user logged in.','3/17/2012 4:20:21 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/17/2012 8:08:28 AM(33)_s','The user logged in.','3/17/2012 8:08:28 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:11:39 AM(629)_LESLIE G. MOLINYAWE','The user logged out.','3/17/2012 8:11:39 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:11:54 AM(175)_ANONYMOUS','Someone is trying to log-in a username [ rblaaserna ] but failed.','3/17/2012 8:11:54 AM','ANONYMOUS','2011-2012/3T'),
 ('3/17/2012 8:12:04 AM(625)_rblaserna','The user logged in.','3/17/2012 8:12:04 AM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 8:14:50 AM(627)_RACHEL B. LASERNA','Created a transaction w/ the ID: TRANS2012317565','3/17/2012 8:14:50 AM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 8:17:01 AM(502)_RACHEL B. LASERNA','The user logged out.','3/17/2012 8:17:01 AM','RACHEL B. LASERNA','2011-2012/3T'),
 ('3/17/2012 8:17:04 AM(600)_s','The user logged in.','3/17/2012 8:17:04 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:18:27 AM(924)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012317565','3/17/2012 8:18:27 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:27:30 AM(793)_s','Updated item CD-R KING BARCODE SCANNER BLACK','3/17/2012 8:27:30 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:28:05 AM(223)_s','Deleted item SAKKAKU','3/17/2012 8:28:05 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:30:29 AM(480)_s','The user logged in.','3/17/2012 8:30:29 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:31:37 AM(811)_s','The user logged in.','3/17/2012 8:31:37 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:32:21 AM(354)_s','The user logged in.','3/17/2012 8:32:21 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/17/2012 8:36:48 AM(169)_s','The user logged in.','3/17/2012 8:36:48 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/18/2012 12:08:52 AM(850)_s','The user logged in.','3/18/2012 12:08:52 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 10:00:35 PM(186)_s','The user logged in.','3/19/2012 10:00:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 10:01:32 PM(169)_s','Added item booklet small','3/19/2012 10:01:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 10:02:25 PM(194)_LESLIE G. MOLINYAWE','The user logged out.','3/19/2012 10:02:25 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 10:03:32 PM(337)_a','The user logged in.','3/19/2012 10:03:32 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 10:05:24 PM(217)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS201231979','3/19/2012 10:05:24 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 10:05:53 PM(969)_PATRICK POTESTAD','The user logged out.','3/19/2012 10:05:53 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 10:06:03 PM(321)_s','The user logged in.','3/19/2012 10:06:03 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 10:57:35 PM(553)_s','The user logged in.','3/19/2012 10:57:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 10:58:14 PM(152)_s','The user logged in.','3/19/2012 10:58:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 11:26:46 PM(786)_s','The user logged in.','3/19/2012 11:26:46 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 11:30:17 PM(850)_s','The user logged in.','3/19/2012 11:30:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 8:42:49 PM(759)_s','The user logged in.','3/19/2012 8:42:49 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 8:46:49 PM(460)_s','The user logged in.','3/19/2012 8:46:49 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 8:47:13 PM(589)_s','Deleted item BUDDHA BEAD 2','3/19/2012 8:47:13 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 8:47:55 PM(324)_s','Deleted item JKKJKK','3/19/2012 8:47:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 8:57:52 PM(205)_s','The user logged in.','3/19/2012 8:57:52 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 8:58:39 PM(461)_s','Deleted item AVON LOTION','3/19/2012 8:58:39 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:06:08 PM(317)_s','The user logged in.','3/19/2012 9:06:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:07:42 PM(579)_s','Added item HBW Black','3/19/2012 9:07:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:08:51 PM(322)_LESLIE G. MOLINYAWE','The user logged out.','3/19/2012 9:08:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:09:07 PM(544)_ANONYMOUS','Someone is trying to log-in a username [ rblaserrna ] but failed.','3/19/2012 9:09:07 PM','ANONYMOUS','2011-2012/3T'),
 ('3/19/2012 9:09:22 PM(589)_a','The user logged in.','3/19/2012 9:09:22 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:26:00 PM(826)_s','The user logged in.','3/19/2012 9:26:00 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:26:41 PM(233)_s','The user logged in.','3/19/2012 9:26:41 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:27:22 PM(387)_s','Deleted item HBW BLACK','3/19/2012 9:27:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:27:47 PM(692)_s','The user logged in.','3/19/2012 9:27:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:29:00 PM(4)_s','Added item HBW Black','3/19/2012 9:29:00 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:30:04 PM(554)_LESLIE G. MOLINYAWE','The user logged out.','3/19/2012 9:30:04 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:30:13 PM(645)_a','The user logged in.','3/19/2012 9:30:13 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:31:05 PM(318)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012319813','3/19/2012 9:31:05 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:32:01 PM(770)_PATRICK POTESTAD','The user logged out.','3/19/2012 9:32:01 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:32:06 PM(580)_s','The user logged in.','3/19/2012 9:32:06 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:38:38 PM(321)_s','The user logged in.','3/19/2012 9:38:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:39:31 PM(478)_s','The user logged in.','3/19/2012 9:39:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:39:38 PM(433)_s','Deleted item HBW BLACK','3/19/2012 9:39:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:40:19 PM(785)_s','The user logged in.','3/19/2012 9:40:19 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:41:26 PM(482)_s','Added item HBW BLACK','3/19/2012 9:41:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:41:43 PM(585)_s','Added item ','3/19/2012 9:41:43 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:44:14 PM(712)_s','The user logged in.','3/19/2012 9:44:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:44:22 PM(489)_s','Deleted item HBW BLACK','3/19/2012 9:44:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:44:54 PM(362)_s','The user logged in.','3/19/2012 9:44:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:45:48 PM(113)_s','Added item HBW BLACK','3/19/2012 9:45:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:46:23 PM(96)_LESLIE G. MOLINYAWE','The user logged out.','3/19/2012 9:46:23 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:49:46 PM(850)_a','The user logged in.','3/19/2012 9:49:46 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:50:34 PM(350)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012319266','3/19/2012 9:50:34 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:51:37 PM(278)_PATRICK POTESTAD','The user logged out.','3/19/2012 9:51:37 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/19/2012 9:52:12 PM(761)_s','The user logged in.','3/19/2012 9:52:12 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:52:43 PM(719)_LESLIE G. MOLINYAWE','The user logged out.','3/19/2012 9:52:43 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:53:10 PM(86)_s','The user logged in.','3/19/2012 9:53:10 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:53:48 PM(169)_s','The user logged in.','3/19/2012 9:53:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:56:16 PM(656)_s','The user logged in.','3/19/2012 9:56:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:58:32 PM(185)_s','Added item Booklet Small','3/19/2012 9:58:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/19/2012 9:59:25 PM(9)_s','Deleted item BOOKLET SMALL','3/19/2012 9:59:25 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:23:21 PM(124)_s','The user logged in.','3/20/2012 11:23:21 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:23:55 PM(464)_s','The user logged in.','3/20/2012 11:23:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:29:29 PM(860)_s','The user logged in.','3/20/2012 11:29:29 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:32:17 PM(515)_s','The user logged in.','3/20/2012 11:32:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:32:42 PM(2)_s','The user logged in.','3/20/2012 11:32:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:33:15 PM(417)_s','The user logged in.','3/20/2012 11:33:15 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 11:35:11 PM(718)_s','The user logged in.','3/20/2012 11:35:11 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:19:47 PM(476)_s','The user logged in.','3/20/2012 12:19:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:19:55 PM(653)_s','Added item ','3/20/2012 12:19:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:19:57 AM(869)_a','The user logged in.','3/20/2012 12:19:57 AM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 12:21:25 PM(795)_s','The user logged in.','3/20/2012 12:21:25 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:21:31 PM(13)_s','Added item ','3/20/2012 12:21:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:21:35 PM(356)_s','Added item ','3/20/2012 12:21:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:23:10 PM(596)_s','The user logged in.','3/20/2012 12:23:10 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:24:25 PM(267)_s','The user logged in.','3/20/2012 12:24:25 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:28:01 PM(86)_s','The user logged in.','3/20/2012 12:28:01 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:36:50 PM(972)_s','The user logged in.','3/20/2012 12:36:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:38:35 PM(236)_s','The user logged in.','3/20/2012 12:38:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:39:19 PM(210)_s','The user logged in.','3/20/2012 12:39:19 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:40:05 PM(109)_s','The user logged in.','3/20/2012 12:40:05 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:43:14 PM(387)_s','The user logged in.','3/20/2012 12:43:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:44:22 PM(545)_s','The user logged in.','3/20/2012 12:44:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:49:08 PM(235)_s','The user logged in.','3/20/2012 12:49:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:50:11 PM(601)_s','The user logged in.','3/20/2012 12:50:11 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:51:40 PM(836)_s','The user logged in.','3/20/2012 12:51:40 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 12:54:59 PM(628)_s','The user logged in.','3/20/2012 12:54:59 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:02:03 PM(364)_s','The user logged in.','3/20/2012 1:02:03 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:03:41 PM(932)_s','The user logged in.','3/20/2012 1:03:41 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:03:59 PM(502)_s','Updated item HBW BLACK','3/20/2012 1:03:59 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:04:12 PM(206)_s','Updated item HBW BLACK','3/20/2012 1:04:12 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:05:42 PM(45)_s','The user logged in.','3/20/2012 1:05:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:06:14 PM(813)_s','Updated item BAYGON SCENTED COIL','3/20/2012 1:06:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:10:27 PM(732)_s','The user logged in.','3/20/2012 1:10:27 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:10:39 PM(538)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012313626','3/20/2012 1:10:39 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:12:34 PM(720)_s','The user logged in.','3/20/2012 1:12:34 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:12:58 PM(595)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012312122','3/20/2012 1:12:58 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:16:12 PM(13)_s','The user logged in.','3/20/2012 1:16:12 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:16:23 PM(732)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012312214','3/20/2012 1:16:23 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:18:39 AM(961)_a','The user logged in.','3/20/2012 1:18:39 AM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:19:31 PM(380)_s','The user logged in.','3/20/2012 1:19:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:20:05 PM(648)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012317565','3/20/2012 1:20:05 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:22:48 PM(135)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012316819','3/20/2012 1:22:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:24:15 PM(504)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012316819','3/20/2012 1:24:15 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:24:56 PM(516)_a','The user logged in.','3/20/2012 1:24:56 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:25:22 PM(557)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012320547','3/20/2012 1:25:22 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:25:40 PM(810)_PATRICK POTESTAD','The user logged out.','3/20/2012 1:25:40 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:25:42 PM(827)_s','The user logged in.','3/20/2012 1:25:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:25:56 PM(424)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320547','3/20/2012 1:25:56 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:27:00 PM(606)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320547','3/20/2012 1:27:00 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:36:22 PM(93)_s','The user logged in.','3/20/2012 1:36:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:36:38 PM(85)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320547','3/20/2012 1:36:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:37:54 PM(852)_s','The user logged in.','3/20/2012 1:37:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:38:22 PM(685)_s','The user logged in.','3/20/2012 1:38:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:38:37 PM(81)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320547','3/20/2012 1:38:37 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:39:45 PM(748)_s','The user logged in.','3/20/2012 1:39:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:40:16 PM(565)_a','The user logged in.','3/20/2012 1:40:16 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:40:37 PM(462)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012320452','3/20/2012 1:40:37 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:41:01 PM(275)_PATRICK POTESTAD','The user logged out.','3/20/2012 1:41:01 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:41:05 PM(888)_s','The user logged in.','3/20/2012 1:41:05 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:41:26 PM(650)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320452','3/20/2012 1:41:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:41:48 PM(773)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320452','3/20/2012 1:41:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:42:32 PM(187)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012320452','3/20/2012 1:42:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:44:31 PM(388)_s','The user logged in.','3/20/2012 1:44:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:50:01 PM(732)_s','The user logged in.','3/20/2012 1:50:01 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:51:50 PM(142)_LESLIE G. MOLINYAWE','The user logged out.','3/20/2012 1:51:50 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:51:52 PM(68)_a','The user logged in.','3/20/2012 1:51:52 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:52:06 PM(538)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS2012320528','3/20/2012 1:52:06 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:52:10 PM(514)_PATRICK POTESTAD','The user logged out.','3/20/2012 1:52:10 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/20/2012 1:52:15 PM(123)_s','The user logged in.','3/20/2012 1:52:15 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 1:54:03 PM(770)_LESLIE G. MOLINYAWE','Voided Transaction ID: TRANS2012312387','3/20/2012 1:54:03 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:05:10 PM(765)_s','The user logged in.','3/20/2012 2:05:10 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:05:37 PM(981)_s','Added item RIDA','3/20/2012 2:05:37 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:07:18 PM(389)_s','The user logged in.','3/20/2012 2:07:18 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:07:43 PM(502)_s','Added item potibook','3/20/2012 2:07:43 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:08:30 PM(860)_s','The user logged in.','3/20/2012 2:08:30 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:08:43 PM(869)_s','Added item sdfsd','3/20/2012 2:08:43 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:09:13 PM(133)_s','The user logged in.','3/20/2012 2:09:13 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:09:17 PM(157)_s','Deleted item xxxxxxxxx','3/20/2012 2:09:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:09:29 PM(918)_s','Deleted item SDFSD','3/20/2012 2:09:29 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 2:10:11 PM(308)_LESLIE G. MOLINYAWE','The user logged out.','3/20/2012 2:10:11 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 6:17:51 PM(959)_s','The user logged in.','3/20/2012 6:17:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/20/2012 6:18:32 PM(347)_s','Added item Daffu dock','3/20/2012 6:18:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/21/2012 11:44:59 AM(570)_s','The user logged in.','3/21/2012 11:44:59 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/21/2012 12:45:31 PM(775)_ANONYMOUS','Someone is trying to log-in a username [ S ] but failed.','3/21/2012 12:45:31 PM','ANONYMOUS','2011-2012/3T'),
 ('3/21/2012 12:45:37 PM(623)_ANONYMOUS','Someone is trying to log-in a username [ S ] but failed.','3/21/2012 12:45:37 PM','ANONYMOUS','2011-2012/3T'),
 ('3/21/2012 12:45:54 PM(550)_s','The user logged in.','3/21/2012 12:45:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/21/2012 8:54:55 AM(32)_s','The user logged in.','3/21/2012 8:54:55 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/21/2012 8:56:02 AM(502)_s','The user logged in.','3/21/2012 8:56:02 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/21/2012 8:57:43 AM(827)_s','The user logged in.','3/21/2012 8:57:43 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/21/2012 9:02:10 AM(530)_s','The user logged in.','3/21/2012 9:02:10 AM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:03:42 PM(569)_s','The user logged in.','3/6/2012 10:03:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:04:34 PM(40)_s','The user logged in.','3/6/2012 10:04:34 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:05:17 PM(288)_s','The user logged in.','3/6/2012 10:05:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:05:54 PM(608)_s','The user logged in.','3/6/2012 10:05:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:08:42 PM(672)_s','The user logged in.','3/6/2012 10:08:42 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:12:00 PM(352)_s','The user logged in.','3/6/2012 10:12:00 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:19:49 PM(855)_s','The user logged in.','3/6/2012 10:19:49 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:23:01 PM(903)_LESLIE G. MOLINYAWE','The user logged out.','3/6/2012 10:23:01 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 10:23:04 PM(695)_a','The user logged in.','3/6/2012 10:23:04 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/6/2012 10:26:04 PM(792)_a','The user logged in.','3/6/2012 10:26:04 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/6/2012 10:26:17 PM(645)_PATRICK POTESTAD','Created a transaction w/ the ID: TRANS201236630','3/6/2012 10:26:17 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/6/2012 10:26:45 PM(862)_PATRICK POTESTAD','The user logged out.','3/6/2012 10:26:45 PM','PATRICK POTESTAD','2011-2012/3T'),
 ('3/6/2012 10:26:51 PM(55)_s','The user logged in.','3/6/2012 10:26:51 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 9:57:48 PM(376)_s','The user logged in.','3/6/2012 9:57:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 9:58:19 PM(140)_LESLIE G. MOLINYAWE','The user logged out.','3/6/2012 9:58:19 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 9:58:23 PM(312)_s','The user logged in.','3/6/2012 9:58:23 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 9:58:56 PM(984)_s','The user logged in.','3/6/2012 9:58:56 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/6/2012 9:59:32 PM(500)_LESLIE G. MOLINYAWE','The user logged out.','3/6/2012 9:59:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/7/2012 10:24:47 PM(944)_s','The user logged in.','3/7/2012 10:24:47 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/7/2012 11:03:24 PM(2)_s','The user logged in.','3/7/2012 11:03:24 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 10:58:13 PM(206)_s','The user logged in.','3/8/2012 10:58:13 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:01:39 PM(838)_s','The user logged in.','3/8/2012 11:01:39 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:03:14 PM(357)_s','The user logged in.','3/8/2012 11:03:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:06:08 PM(533)_s','The user logged in.','3/8/2012 11:06:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:07:28 PM(518)_s','The user logged in.','3/8/2012 11:07:28 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:16:08 PM(806)_s','The user logged in.','3/8/2012 11:16:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:17:16 PM(951)_s','The user logged in.','3/8/2012 11:17:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:18:38 PM(518)_s','The user logged in.','3/8/2012 11:18:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:21:30 PM(479)_s','The user logged in.','3/8/2012 11:21:30 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:23:30 PM(215)_s','The user logged in.','3/8/2012 11:23:30 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:27:32 PM(246)_s','The user logged in.','3/8/2012 11:27:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:27:55 PM(406)_s','The user logged in.','3/8/2012 11:27:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:29:12 PM(895)_s','The user logged in.','3/8/2012 11:29:12 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:29:59 PM(853)_s','The user logged in.','3/8/2012 11:29:59 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:31:52 PM(855)_s','The user logged in.','3/8/2012 11:31:52 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:34:00 PM(143)_s','The user logged in.','3/8/2012 11:34:00 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:35:23 PM(814)_s','The user logged in.','3/8/2012 11:35:23 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:38:36 PM(614)_s','The user logged in.','3/8/2012 11:38:36 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 11:39:39 PM(521)_s','Updated item NATA DE COKI','3/8/2012 11:39:39 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:43:59 PM(168)_s','The user logged in.','3/8/2012 4:43:59 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:47:11 PM(872)_s','The user logged in.','3/8/2012 4:47:11 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:48:14 PM(960)_s','The user logged in.','3/8/2012 4:48:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:48:38 PM(633)_s','The user logged in.','3/8/2012 4:48:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:49:43 PM(112)_s','The user logged in.','3/8/2012 4:49:43 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:51:17 PM(872)_s','The user logged in.','3/8/2012 4:51:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:51:49 PM(881)_s','The user logged in.','3/8/2012 4:51:49 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:52:29 PM(132)_s','The user logged in.','3/8/2012 4:52:29 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:53:52 PM(169)_s','The user logged in.','3/8/2012 4:53:52 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:55:45 PM(143)_s','The user logged in.','3/8/2012 4:55:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 4:56:57 PM(392)_s','The user logged in.','3/8/2012 4:56:57 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:04:38 PM(329)_s','Added item ','3/8/2012 5:04:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:16:17 PM(1)_s','The user logged in.','3/8/2012 5:16:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:17:29 PM(1)_s','The user logged in.','3/8/2012 5:17:29 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:18:49 PM(753)_s','The user logged in.','3/8/2012 5:18:49 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:19:27 PM(328)_s','The user logged in.','3/8/2012 5:19:27 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:20:35 PM(328)_s','Added item ','3/8/2012 5:20:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:26:03 PM(104)_s','The user logged in.','3/8/2012 5:26:03 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:27:04 PM(224)_s','The user logged in.','3/8/2012 5:27:04 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:32:16 PM(448)_s','The user logged in.','3/8/2012 5:32:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:33:45 PM(865)_s','The user logged in.','3/8/2012 5:33:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:34:24 PM(145)_s','The user logged in.','3/8/2012 5:34:24 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:36:14 PM(296)_s','The user logged in.','3/8/2012 5:36:14 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:38:09 PM(529)_s','The user logged in.','3/8/2012 5:38:09 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:39:26 PM(56)_s','The user logged in.','3/8/2012 5:39:26 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:39:38 PM(554)_s','Added item ','3/8/2012 5:39:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:40:22 PM(496)_s','The user logged in.','3/8/2012 5:40:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:42:06 PM(441)_s','The user logged in.','3/8/2012 5:42:06 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:43:28 PM(961)_s','The user logged in.','3/8/2012 5:43:28 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:43:59 PM(170)_s','Added item ','3/8/2012 5:43:59 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:45:54 PM(0)_s','The user logged in.','3/8/2012 5:45:54 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:46:38 PM(304)_s','The user logged in.','3/8/2012 5:46:38 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:47:45 PM(217)_s','The user logged in.','3/8/2012 5:47:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:51:34 PM(266)_s','The user logged in.','3/8/2012 5:51:34 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:53:24 PM(114)_s','The user logged in.','3/8/2012 5:53:24 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:54:45 PM(754)_s','The user logged in.','3/8/2012 5:54:45 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:56:11 PM(119)_s','The user logged in.','3/8/2012 5:56:11 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:57:48 PM(276)_s','The user logged in.','3/8/2012 5:57:48 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 5:59:17 PM(41)_s','The user logged in.','3/8/2012 5:59:17 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:00:08 PM(689)_s','The user logged in.','3/8/2012 6:00:08 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:03:04 PM(337)_s','The user logged in.','3/8/2012 6:03:04 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:04:33 PM(497)_s','The user logged in.','3/8/2012 6:04:33 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:05:24 PM(313)_s','The user logged in.','3/8/2012 6:05:24 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:07:22 PM(42)_s','The user logged in.','3/8/2012 6:07:22 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:09:09 PM(737)_s','The user logged in.','3/8/2012 6:09:09 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:12:16 PM(110)_s','The user logged in.','3/8/2012 6:12:16 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:23:58 PM(233)_s','The user logged in.','3/8/2012 6:23:58 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:24:31 PM(442)_s','The user logged in.','3/8/2012 6:24:31 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:26:19 PM(929)_s','The user logged in.','3/8/2012 6:26:19 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:27:46 PM(473)_s','The user logged in.','3/8/2012 6:27:46 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:33:27 PM(164)_s','The user logged in.','3/8/2012 6:33:27 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:33:44 PM(746)_s','Added item ','3/8/2012 6:33:44 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:34:35 PM(402)_s','The user logged in.','3/8/2012 6:34:35 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:34:55 PM(778)_s','Added item ','3/8/2012 6:34:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:36:32 PM(353)_s','The user logged in.','3/8/2012 6:36:32 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:36:52 PM(18)_s','Added item ','3/8/2012 6:36:52 PM','LESLIE G. MOLINYAWE','2011-2012/3T'),
 ('3/8/2012 6:37:55 PM(250)_s','The user logged in.','3/8/2012 6:37:55 PM','LESLIE G. MOLINYAWE','2011-2012/3T');
/*!40000 ALTER TABLE `security` ENABLE KEYS */;


--
-- Definition of table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE `suppliers` (
  `supplier` varchar(100) NOT NULL,
  `con` varchar(100) NOT NULL,
  `addresss` varchar(300) NOT NULL,
  `supp_id` varchar(100) NOT NULL,
  PRIMARY KEY (`supp_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suppliers`
--

/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` (`supplier`,`con`,`addresss`,`supp_id`) VALUES 
 ('VENDO','049-300-569','THE HEIGHTS, BINAN, LAGUNA','SUPP201226131'),
 ('RICKIS','049-832-1942','MARINIG, CABUYAO','SUPP2012261339854'),
 ('PILOT','945-565-456','CONSUELO, DASMARINAS, CAVITE','SUPP20122613559226'),
 ('SAFARY','090-2939-2039','MUNOZ, M\r\nANILA','SUPP201226195011351'),
 ('POTIE','0998878691','STA. ROSA LAGUNA','SUPP201231783750462'),
 ('PAPERS CO.','888-8888','MANDALUYONG CITY','SUPP2012319215658337');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;


--
-- Definition of table `systime`
--

DROP TABLE IF EXISTS `systime`;
CREATE TABLE `systime` (
  `timeleft` datetime NOT NULL,
  `tleft` varchar(45) NOT NULL,
  PRIMARY KEY (`timeleft`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `systime`
--

/*!40000 ALTER TABLE `systime` DISABLE KEYS */;
/*!40000 ALTER TABLE `systime` ENABLE KEYS */;


--
-- Definition of table `totaltrans`
--

DROP TABLE IF EXISTS `totaltrans`;
CREATE TABLE `totaltrans` (
  `total_trans_id` varchar(300) NOT NULL DEFAULT '',
  `categ` varchar(100) DEFAULT NULL,
  `item_name` varchar(300) DEFAULT NULL,
  `quan` int(10) unsigned DEFAULT NULL,
  `time_sum` datetime DEFAULT NULL,
  `item_id` varchar(300) NOT NULL,
  `sum_amount` decimal(10,2) NOT NULL,
  `typex` varchar(45) NOT NULL,
  PRIMARY KEY (`total_trans_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `totaltrans`
--

/*!40000 ALTER TABLE `totaltrans` DISABLE KEYS */;
INSERT INTO `totaltrans` (`total_trans_id`,`categ`,`item_name`,`quan`,`time_sum`,`item_id`,`sum_amount`,`typex`) VALUES 
 ('TIAN2012310202634316','Book','SEABISCUIT A. LEGEND  L HILLENBRAND',9,'2012-03-10 20:26:34','00017','1791.00','annual'),
 ('TIAN201231021397992','Other School Materials','SKIN WHITE SPF 20',14,'2012-03-10 21:39:07','00009','1120.00','annual'),
 ('TIAN20123102139849','Other School Materials','CRAYOLA 16S',3,'2012-03-10 21:39:08','00020','48.00','annual'),
 ('TIAN201231211310278','Pens','SASA',7,'2012-03-12 11:31:00','00023','91.00','annual'),
 ('TIAN2012312163630829','Papers','BOND PAPER',8,'2012-03-12 16:36:30','00028','-40.30','annual'),
 ('TIAN201231220551295','Notebook','MINI NOTEBOOK',6,'2012-03-12 20:05:51','00029','2642.90','annual'),
 ('TIAN2012313135858735','Papers','TOM PALO',12,'2012-03-13 13:58:58','00006','202.80','annual'),
 ('TIAN201231514591219','Shoes','CHELSEA LAADIES SANDALS BLUE',7,'2012-03-15 14:59:01','00007','6999.93','annual'),
 ('TIAN201231619722406','Book','30 DAYS OF SUMMER',2,'2012-03-16 19:07:22','00031','520.00','annual'),
 ('TIAN201231619722432','Pens','DAMET',3,'2012-03-16 19:07:22','00032','479.70','annual'),
 ('TIAN2012316203049423','Pens','POTIE PEN',3,'2012-03-16 20:30:49','00033','39.00','annual'),
 ('TIAN2012317224825987','Other School Materials','AVON LOTION',4,'2012-03-17 22:48:25','40810140','520.00','annual'),
 ('TIAN201231781450721','Book','GERALDS GAME S KING',1,'2012-03-17 08:14:50','00004','275.00','annual'),
 ('TIAN201231781450752','Electronics','CD-R KING BARCODE SCANNER BLACK',2,'2012-03-17 08:14:50','00002','3160.00','annual'),
 ('TIAN201231921315459','Pens','HBW BLACK',31,'2012-03-19 21:31:05','00034','201.50','annual'),
 ('TIAN201231922524256','Papers','BOOKLET SMALL',5,'2012-03-19 22:05:24','00035','32.50','annual'),
 ('TIAN201232013526555','Pens','STABILO BOSS',2,'2012-03-20 13:52:06','00000','48.00','annual'),
 ('TIDA2012310202634319','Book','SEABISCUIT A. LEGEND  L HILLENBRAND',3,'2012-03-10 20:26:34','00017','597.00','daily'),
 ('TIDA201231021397994','Other School Materials','SKIN WHITE SPF 20',2,'2012-03-10 21:39:07','00009','160.00','daily'),
 ('TIDA201231211310294','Pens','SASA',7,'2012-03-12 11:31:00','00023','91.00','daily'),
 ('TIDA2012312163630833','Papers','BOND PAPER',8,'2012-03-12 16:36:30','00028','-40.30','daily'),
 ('TIDA201231220551298','Notebook','MINI NOTEBOOK',6,'2012-03-12 20:05:51','00029','2642.90','daily'),
 ('TIDA2012313135858735','Papers','TOM PALO',12,'2012-03-13 13:58:58','00006','202.80','daily'),
 ('TIDA2012315143336696','Other School Materials','SKIN WHITE SPF 20',3,'2012-03-15 14:33:36','00009','240.00','daily'),
 ('TIDA2012315145720570','Pens','SASA',3,'2012-03-15 14:57:20','00023','39.00','daily'),
 ('TIDA2012315145752587','Book','SEABISCUIT A. LEGEND  L HILLENBRAND',3,'2012-03-15 14:57:52','00017','597.00','daily'),
 ('TIDA201231514591223','Shoes','CHELSEA LAADIES SANDALS BLUE',3,'2012-03-15 14:59:01','00007','2999.97','daily'),
 ('TIDA2012316172645644','Papers','TOM PALO',9,'2012-03-16 17:26:45','00006','152.10','daily'),
 ('TIDA2012316172645707','Book','J BLUME SMART WOMEN',3,'2012-03-16 17:26:45','00005','751.50','daily'),
 ('TIDA201231619722409','Book','30 DAYS OF SUMMER',2,'2012-03-16 19:07:22','00031','520.00','daily'),
 ('TIDA201231619722434','Pens','DAMET',3,'2012-03-16 19:07:22','00032','479.70','daily'),
 ('TIDA2012316203049427','Pens','POTIE PEN',3,'2012-03-16 20:30:49','00033','39.00','daily'),
 ('TIDA2012316203049479','Papers','BOND PAPER',3,'2012-03-16 20:30:49','00028','15.60','daily'),
 ('TIDA2012316203049529','Notebook','BAG',6,'2012-03-16 20:30:49','00027','3900.00','daily'),
 ('TIDA2012316203049553','Accessories','BUDDHA BEAD 3',6,'2012-03-16 20:30:49','00026','351.00','daily'),
 ('TIDA2012316203049616','Accessories','BUDDHA BEAD 2',3,'2012-03-16 20:30:49','00025','132.60','daily'),
 ('TIDA2012316203049681','Accessories','BUDDHA BEAD 1',2,'2012-03-16 20:30:49','00024','7.80','daily'),
 ('TIDA2012316203049735','Pens','SASA',3,'2012-03-16 20:30:49','00023','39.00','daily'),
 ('TIDA2012316203049760','Pens','PILOT GTECH 0.3',3,'2012-03-16 20:30:49','00022','210.00','daily'),
 ('TIDA2012316203049789','Papers','YELLOW PAPER 5S',3,'2012-03-16 20:30:49','00021','10.50','daily'),
 ('TIDA2012316203049848','Other School Materials','CRAYOLA 16S',3,'2012-03-16 20:30:49','00020','48.00','daily'),
 ('TIDA2012316203049906','Book','WRITING AND REPORTING NEWS',3,'2012-03-16 20:30:49','00018','1140.00','daily'),
 ('TIDA2012316203049932','Clothing','MALAYAN JACKET BLUE S',6,'2012-03-16 20:30:49','00019','3300.00','daily'),
 ('TIDA2012316203049957','Book','SEABISCUIT A. LEGEND  L HILLENBRAND',3,'2012-03-16 20:30:49','00017','597.00','daily'),
 ('TIDA2012316203050109','Notebook','REPSODA',2,'2012-03-16 20:30:50','00012','18.00','daily'),
 ('TIDA2012316203050132','Accessories','OFF FOR KIDS',2,'2012-03-16 20:30:50','00011','34.00','daily'),
 ('TIDA2012316203050159','Housewares','BAYGON SCENTED COIL',2,'2012-03-16 20:30:50','00010','40.00','daily'),
 ('TIDA2012316203050185','Other School Materials','SKIN WHITE SPF 20',2,'2012-03-16 20:30:50','00009','160.00','daily'),
 ('TIDA2012316203050210','Accessories','SAKKAKU',2,'2012-03-16 20:30:50','00008','26.00','daily'),
 ('TIDA201231620305031','Book','MARLEY & ME J GROGAN',3,'2012-03-16 20:30:50','00015','600.00','daily'),
 ('TIDA201231620305056','Book','NATA DE COKI',3,'2012-03-16 20:30:50','00014','210.00','daily'),
 ('TIDA20123162030507','Book','LOST WORLD M CRICHTON',3,'2012-03-16 20:30:50','00016','750.00','daily'),
 ('TIDA201231620305085','Card','SUN CELLULAR WINNER SIM',3,'2012-03-16 20:30:50','00013','30.00','daily'),
 ('TIDA2012317224825990','Other School Materials','AVON LOTION',4,'2012-03-17 22:48:25','40810140','520.00','daily'),
 ('TIDA201231781450721','Book','GERALDS GAME S KING',1,'2012-03-17 08:14:50','00004','275.00','daily'),
 ('TIDA201231781450752','Electronics','CD-R KING BARCODE SCANNER BLACK',2,'2012-03-17 08:14:50','00002','3160.00','daily'),
 ('TIDA201231921315470','Pens','HBW BLACK',31,'2012-03-19 21:31:05','00034','201.50','daily'),
 ('TIDA201231922524293','Papers','BOOKLET SMALL',5,'2012-03-19 22:05:24','00035','32.50','daily'),
 ('TIDA2012320132522607','Shoes','CHELSEA LAADIES SANDALS BLUE',1,'2012-03-20 13:25:22','00007','999.99','daily'),
 ('TIDA2012320132522683','Other School Materials','SKIN WHITE SPF 20',7,'2012-03-20 13:25:22','00009','560.00','daily'),
 ('TIDA201232013526558','Pens','STABILO BOSS',2,'2012-03-20 13:52:06','00000','48.00','daily'),
 ('TIMN2012310202634324','Book','SEABISCUIT A. LEGEND  L HILLENBRAND',9,'2012-03-10 20:26:34','00017','1791.00','month'),
 ('TIMN201231021397997','Other School Materials','SKIN WHITE SPF 20',14,'2012-03-10 21:39:07','00009','1120.00','month'),
 ('TIMN20123102139856','Other School Materials','CRAYOLA 16S',3,'2012-03-10 21:39:08','00020','48.00','month'),
 ('TIMN201231211310325','Pens','SASA',7,'2012-03-12 11:31:00','00023','91.00','month'),
 ('TIMN2012312163630837','Papers','BOND PAPER',8,'2012-03-12 16:36:30','00028','-40.30','month'),
 ('TIMN201231220551303','Notebook','MINI NOTEBOOK',6,'2012-03-12 20:05:51','00029','2642.90','month'),
 ('TIMN2012313135858766','Papers','TOM PALO',12,'2012-03-13 13:58:58','00006','202.80','month'),
 ('TIMN201231514591226','Shoes','CHELSEA LAADIES SANDALS BLUE',7,'2012-03-15 14:59:01','00007','6999.93','month'),
 ('TIMN201231619722411','Book','30 DAYS OF SUMMER',2,'2012-03-16 19:07:22','00031','520.00','month'),
 ('TIMN201231619722437','Pens','DAMET',3,'2012-03-16 19:07:22','00032','479.70','month'),
 ('TIMN2012316203049430','Pens','POTIE PEN',3,'2012-03-16 20:30:49','00033','39.00','month'),
 ('TIMN2012317224825993','Other School Materials','AVON LOTION',4,'2012-03-17 22:48:25','40810140','520.00','month'),
 ('TIMN201231781450721','Book','GERALDS GAME S KING',1,'2012-03-17 08:14:50','00004','275.00','month'),
 ('TIMN201231781450752','Electronics','CD-R KING BARCODE SCANNER BLACK',2,'2012-03-17 08:14:50','00002','3160.00','month'),
 ('TIMN201231921315537','Pens','HBW BLACK',31,'2012-03-19 21:31:05','00034','201.50','month'),
 ('TIMN201231922524353','Papers','BOOKLET SMALL',5,'2012-03-19 22:05:24','00035','32.50','month'),
 ('TIMN201232013526561','Pens','STABILO BOSS',2,'2012-03-20 13:52:06','00000','48.00','month');
/*!40000 ALTER TABLE `totaltrans` ENABLE KEYS */;


--
-- Definition of table `trans_items`
--

DROP TABLE IF EXISTS `trans_items`;
CREATE TABLE `trans_items` (
  `trans_item_id` varchar(100) NOT NULL,
  `item_id` varchar(100) NOT NULL,
  `item_name` varchar(300) NOT NULL,
  `trans_id` varchar(100) NOT NULL,
  `quan` int(10) unsigned DEFAULT NULL,
  `sum_amount` decimal(10,2) NOT NULL,
  `notes` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`trans_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trans_items`
--

/*!40000 ALTER TABLE `trans_items` DISABLE KEYS */;
INSERT INTO `trans_items` (`trans_item_id`,`item_id`,`item_name`,`trans_id`,`quan`,`sum_amount`,`notes`) VALUES 
 ('ITEM2012310213980','00009','SKIN WHITE SPF 20','TRANS2012310963',2,'160.00',''),
 ('ITEM20123102139887','00017','SEABISCUIT A. LEGEND  L HILLENBRAND','TRANS2012310963',3,'597.00',''),
 ('ITEM201231211310325','00023','SASA','TRANS2012312122',1,'13.00',''),
 ('ITEM2012312163630841','00028','BOND PAPER','TRANS2012312769',5,'26.00',''),
 ('ITEM201231220716896','00029','MINI NOTEBOOK','TRANS2012312814',2,'780.00',''),
 ('ITEM201231220914145','00029','MINI NOTEBOOK','TRANS201231287',4,'1560.00',''),
 ('ITEM2012313135858782','00006','TOM PALO','TRANS2012313626',3,'50.70',''),
 ('ITEM2012315143336703','00009','SKIN WHITE SPF 20','TRANS2012315662',3,'240.00',''),
 ('ITEM2012315145720576','00023','SASA','TRANS2012315536',3,'39.00',''),
 ('ITEM2012315145752601','00017','SEABISCUIT A. LEGEND  L HILLENBRAND','TRANS2012315565',3,'597.00',''),
 ('ITEM201231514591229','00007','CHELSEA LAADIES SANDALS BLUE','TRANS2012315192',3,'2999.97',''),
 ('ITEM2012316172645644','00006','TOM PALO','TRANS2012316473',5,'84.50',''),
 ('ITEM2012316172645707','00005','J BLUME SMART WOMEN','TRANS2012316473',3,'751.50',''),
 ('ITEM2012316172733689','00006','TOM PALO','TRANS2012316642',1,'16.90',''),
 ('ITEM2012316192523335','00032','DAMET','TRANS2012316233',1,'159.90',''),
 ('ITEM2012316193637120','00006','TOM PALO','TRANS201231637',1,'16.90',''),
 ('ITEM201231619722414','00031','30 DAYS OF SUMMER','TRANS2012316338',1,'260.00',''),
 ('ITEM201231619722440','00032','DAMET','TRANS2012316338',2,'319.80',''),
 ('ITEM2012316203049433','00033','POTIE PEN','TRANS2012316396',1,'13.00',''),
 ('ITEM2012316203049486','00028','BOND PAPER','TRANS2012316396',1,'5.20',''),
 ('ITEM2012316203049534','00027','BAG','TRANS2012316396',2,'1300.00',''),
 ('ITEM2012316203049558','00026','BUDDHA BEAD 3','TRANS2012316396',2,'117.00',''),
 ('ITEM2012316203049622','00025','BUDDHA BEAD 2','TRANS2012316396',1,'44.20',''),
 ('ITEM2012316203049686','00024','BUDDHA BEAD 1','TRANS2012316396',1,'3.90',''),
 ('ITEM2012316203049741','00023','SASA','TRANS2012316396',1,'13.00',''),
 ('ITEM2012316203049765','00022','PILOT GTECH 0.3','TRANS2012316396',1,'70.00',''),
 ('ITEM2012316203049794','00021','YELLOW PAPER 5S','TRANS2012316396',1,'3.50',''),
 ('ITEM2012316203049887','00020','CRAYOLA 16S','TRANS2012316396',1,'16.00',''),
 ('ITEM2012316203049911','00018','WRITING AND REPORTING NEWS','TRANS2012316396',1,'380.00',''),
 ('ITEM2012316203049937','00019','MALAYAN JACKET BLUE S','TRANS2012316396',2,'1100.00',''),
 ('ITEM2012316203049987','00017','SEABISCUIT A. LEGEND  L HILLENBRAND','TRANS2012316396',1,'199.00',''),
 ('ITEM2012316203050114','00012','REPSODA','TRANS2012316396',1,'9.00',''),
 ('ITEM201231620305012','00016','LOST WORLD M CRICHTON','TRANS2012316396',1,'250.00',''),
 ('ITEM2012316203050138','00011','OFF FOR KIDS','TRANS2012316396',1,'17.00',''),
 ('ITEM2012316203050165','00010','BAYGON SCENTED COIL','TRANS2012316396',1,'20.00',''),
 ('ITEM2012316203050191','00009','SKIN WHITE SPF 20','TRANS2012316396',1,'80.00',''),
 ('ITEM2012316203050214','00008','SAKKAKU','TRANS2012316396',1,'13.00',''),
 ('ITEM201231620305036','00015','MARLEY & ME J GROGAN','TRANS2012316396',1,'200.00',''),
 ('ITEM201231620305065','00014','NATA DE COKI','TRANS2012316396',1,'70.00',''),
 ('ITEM201231620305090','00013','SUN CELLULAR WINNER SIM','TRANS2012316396',1,'10.00',''),
 ('ITEM201231620310878','00028','BOND PAPER','TRANS2012316819',1,'5.20',''),
 ('ITEM201231620310902','00027','BAG','TRANS2012316819',2,'1300.00',''),
 ('ITEM201231620310926','00026','BUDDHA BEAD 3','TRANS2012316819',2,'117.00',''),
 ('ITEM201231620310952','00025','BUDDHA BEAD 2','TRANS2012316819',1,'44.20',''),
 ('ITEM201231620311163','00021','YELLOW PAPER 5S','TRANS2012316819',1,'3.50',''),
 ('ITEM201231620311190','00020','CRAYOLA 16S','TRANS2012316819',1,'16.00',''),
 ('ITEM201231620311237','00018','WRITING AND REPORTING NEWS','TRANS2012316819',1,'380.00',''),
 ('ITEM201231620311261','00019','MALAYAN JACKET BLUE S','TRANS2012316819',2,'1100.00',''),
 ('ITEM201231620311291','00017','SEABISCUIT A. LEGEND  L HILLENBRAND','TRANS2012316819',1,'199.00',''),
 ('ITEM201231620311317','00016','LOST WORLD M CRICHTON','TRANS2012316819',1,'250.00',''),
 ('ITEM201231620311341','00015','MARLEY & ME J GROGAN','TRANS2012316819',1,'200.00',''),
 ('ITEM201231620311416','00014','NATA DE COKI','TRANS2012316819',1,'70.00',''),
 ('ITEM201231620311484','00013','SUN CELLULAR WINNER SIM','TRANS2012316819',1,'10.00',''),
 ('ITEM201231620311512','00012','REPSODA','TRANS2012316819',1,'9.00',''),
 ('ITEM20123162031156','00022','PILOT GTECH 0.3','TRANS2012316819',1,'70.00',''),
 ('ITEM201231620311568','00011','OFF FOR KIDS','TRANS2012316819',1,'17.00',''),
 ('ITEM201231620311593','00010','BAYGON SCENTED COIL','TRANS2012316819',1,'20.00',''),
 ('ITEM2012316203116','00023','SASA','TRANS2012316819',1,'13.00',''),
 ('ITEM2012316203116104','00027','BAG','TRANS20123166',2,'1300.00',''),
 ('ITEM2012316203116132','00026','BUDDHA BEAD 3','TRANS20123166',2,'117.00',''),
 ('ITEM2012316203116157','00025','BUDDHA BEAD 2','TRANS20123166',1,'44.20',''),
 ('ITEM2012316203116181','00024','BUDDHA BEAD 1','TRANS20123166',1,'3.90',''),
 ('ITEM201231620311620','00009','SKIN WHITE SPF 20','TRANS2012316819',1,'80.00',''),
 ('ITEM2012316203116228','00023','SASA','TRANS20123166',1,'13.00',''),
 ('ITEM2012316203116252','00022','PILOT GTECH 0.3','TRANS20123166',1,'70.00',''),
 ('ITEM2012316203116276','00021','YELLOW PAPER 5S','TRANS20123166',1,'3.50',''),
 ('ITEM2012316203116303','00020','CRAYOLA 16S','TRANS20123166',1,'16.00',''),
 ('ITEM2012316203116329','00018','WRITING AND REPORTING NEWS','TRANS20123166',1,'380.00',''),
 ('ITEM2012316203116353','00019','MALAYAN JACKET BLUE S','TRANS20123166',2,'1100.00',''),
 ('ITEM2012316203116386','00017','SEABISCUIT A. LEGEND  L HILLENBRAND','TRANS20123166',1,'199.00',''),
 ('ITEM2012316203116410','00016','LOST WORLD M CRICHTON','TRANS20123166',1,'250.00',''),
 ('ITEM201231620311643','00008','SAKKAKU','TRANS2012316819',1,'13.00',''),
 ('ITEM2012316203116435','00015','MARLEY & ME J GROGAN','TRANS20123166',1,'200.00',''),
 ('ITEM2012316203116490','00014','NATA DE COKI','TRANS20123166',1,'70.00',''),
 ('ITEM2012316203116514','00013','SUN CELLULAR WINNER SIM','TRANS20123166',1,'10.00',''),
 ('ITEM201231620311652','00033','POTIE PEN','TRANS20123166',1,'13.00',''),
 ('ITEM201231620311679','00028','BOND PAPER','TRANS20123166',1,'5.20',''),
 ('ITEM201231620336284','00006','TOM PALO','TRANS2012316251',2,'33.80',''),
 ('ITEM201231620336310','00031','30 DAYS OF SUMMER','TRANS2012316251',1,'260.00',''),
 ('ITEM201231620336337','00033','POTIE PEN','TRANS2012316251',1,'13.00',''),
 ('ITEM2012317224825996','40810140','AVON LOTION','TRANS2012317937',4,'520.00',''),
 ('ITEM201231781450736','00004','GERALDS GAME S KING','TRANS2012317565',1,'275.00',''),
 ('ITEM201231781450752','00002','CD-R KING BARCODE SCANNER BLACK','TRANS2012317565',2,'3160.00',''),
 ('ITEM201231921315542','00034','HBW BLACK','TRANS2012319813',5,'32.50',''),
 ('ITEM2012319215034630','00034','HBW BLACK','TRANS2012319266',26,'169.00',''),
 ('ITEM201231922524384','00035','BOOKLET SMALL','TRANS201231979',5,'32.50',''),
 ('ITEM2012320132522638','00018','WRITING AND REPORTING NEWS','TRANS2012320547',2,'0.00',''),
 ('ITEM2012320132522662','00000','STABILO BOSS','TRANS2012320547',2,'48.00',''),
 ('ITEM2012320132522690','00009','SKIN WHITE SPF 20','TRANS2012320547',3,'240.00',''),
 ('ITEM2012320134037554','00000','STABILO BOSS','TRANS2012320452',2,'0.00',''),
 ('ITEM2012320134037582','00007','CHELSEA LAADIES SANDALS BLUE','TRANS2012320452',1,'999.99',''),
 ('ITEM2012320134037610','00009','SKIN WHITE SPF 20','TRANS2012320452',4,'320.00',''),
 ('ITEM201232013526564','00000','STABILO BOSS','TRANS2012320528',2,'48.00','');
/*!40000 ALTER TABLE `trans_items` ENABLE KEYS */;


--
-- Definition of table `trans_misc`
--

DROP TABLE IF EXISTS `trans_misc`;
CREATE TABLE `trans_misc` (
  `trans_id` varchar(100) NOT NULL,
  `change` decimal(10,2) NOT NULL,
  `payment` decimal(10,2) NOT NULL,
  PRIMARY KEY (`trans_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trans_misc`
--

/*!40000 ALTER TABLE `trans_misc` DISABLE KEYS */;
INSERT INTO `trans_misc` (`trans_id`,`change`,`payment`) VALUES 
 ('TRANS2012310292','2000.00','2000.00'),
 ('TRANS2012310963','43.00','800.00'),
 ('TRANS2012312122','17.00','30.00'),
 ('TRANS2012312214','400.00','400.00'),
 ('TRANS2012312387','20.00','20.00'),
 ('TRANS2012312769','4.00','30.00'),
 ('TRANS2012312814','20.00','800.00'),
 ('TRANS201231287','440.00','2000.00'),
 ('TRANS2012313626','49.30','100.00'),
 ('TRANS2012315192','0.03','3000.00'),
 ('TRANS2012315536','6.50','45.50'),
 ('TRANS2012315565','3.00','600.00'),
 ('TRANS2012315662','60.00','300.00'),
 ('TRANS2012316233','200.00','200.00'),
 ('TRANS2012316251','193.20','500.00'),
 ('TRANS2012316338','600.00','600.00'),
 ('TRANS201231637','100.00','100.00'),
 ('TRANS2012316396','513.11','10000.00'),
 ('TRANS2012316473','9164.00','10000.00'),
 ('TRANS20123166','990513.11','1000000.00'),
 ('TRANS2012316642','3.10','20.00'),
 ('TRANS2012316819','6083.10','10000.00'),
 ('TRANS201231682','160.00','160.00'),
 ('TRANS2012317565','6565.00','10000.00'),
 ('TRANS2012317937','80.00','600.00'),
 ('TRANS2012319266','31.00','200.00'),
 ('TRANS201231979','17.50','50.00'),
 ('TRANS2012319813','7.50','40.00'),
 ('TRANS2012320452','2180.01','3500.00'),
 ('TRANS2012320528','2.00','50.00'),
 ('TRANS2012320547','1912.00','2200.00');
/*!40000 ALTER TABLE `trans_misc` ENABLE KEYS */;


--
-- Definition of table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
CREATE TABLE `transaction` (
  `trans_id` varchar(100) NOT NULL,
  `dat_trans` datetime NOT NULL,
  `user_code` varchar(200) NOT NULL,
  PRIMARY KEY (`trans_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction`
--

/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
INSERT INTO `transaction` (`trans_id`,`dat_trans`,`user_code`) VALUES 
 ('TRANS2012310292','2012-03-10 20:26:34','a'),
 ('TRANS2012310963','2012-03-10 21:39:07','a'),
 ('TRANS2012312122','2012-03-12 11:31:00','a'),
 ('TRANS2012312214','2012-03-12 20:05:51','rblaserna'),
 ('TRANS2012312387','2012-03-12 16:38:14','rblaserna'),
 ('TRANS2012312769','2012-03-12 16:36:30','rblaserna'),
 ('TRANS2012312814','2012-03-12 20:07:16','rblaserna'),
 ('TRANS201231287','2012-03-12 20:09:14','rblaserna'),
 ('TRANS2012313626','2012-03-13 13:58:58','rblaserna'),
 ('TRANS2012315192','2012-03-15 14:59:01','a'),
 ('TRANS2012315536','2012-03-15 14:57:20','a'),
 ('TRANS2012315565','2012-03-15 14:57:52','a'),
 ('TRANS2012315662','2012-03-15 14:33:36','a'),
 ('TRANS2012316233','2012-03-16 19:25:23','rblaserna'),
 ('TRANS2012316251','2012-03-16 20:33:06','rblaserna'),
 ('TRANS2012316338','2012-03-16 19:07:22','rblaserna'),
 ('TRANS201231637','2012-03-16 19:36:37','rblaserna'),
 ('TRANS2012316396','2012-03-16 20:30:49','rblaserna'),
 ('TRANS2012316473','2012-03-16 17:26:45','rblaserna'),
 ('TRANS20123166','2012-03-16 20:31:16','rblaserna'),
 ('TRANS2012316642','2012-03-16 17:27:33','rblaserna'),
 ('TRANS2012316819','2012-03-16 20:31:00','rblaserna'),
 ('TRANS201231682','2012-03-16 19:09:03','rblaserna'),
 ('TRANS2012317565','2012-03-17 08:14:50','rblaserna'),
 ('TRANS2012317937','2012-03-17 22:48:25','a'),
 ('TRANS2012319266','2012-03-19 21:50:34','a'),
 ('TRANS201231979','2012-03-19 22:05:24','a'),
 ('TRANS2012319813','2012-03-19 21:31:04','a'),
 ('TRANS2012320452','2012-03-20 13:40:37','a'),
 ('TRANS2012320528','2012-03-20 13:52:06','a'),
 ('TRANS2012320547','2012-03-20 13:25:22','a');
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;


--
-- Definition of table `unittable`
--

DROP TABLE IF EXISTS `unittable`;
CREATE TABLE `unittable` (
  `unit_id` varchar(100) NOT NULL,
  `unit_name` varchar(100) NOT NULL,
  PRIMARY KEY (`unit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `unittable`
--

/*!40000 ALTER TABLE `unittable` DISABLE KEYS */;
INSERT INTO `unittable` (`unit_id`,`unit_name`) VALUES 
 ('3S','YARD'),
 ('Bundle','BUNDLES'),
 ('DOZEN','DOZEN'),
 ('PCS','PCS'),
 ('SET','SET');
/*!40000 ALTER TABLE `unittable` ENABLE KEYS */;


--
-- Definition of table `voidtable`
--

DROP TABLE IF EXISTS `voidtable`;
CREATE TABLE `voidtable` (
  `trans_id` varchar(100) NOT NULL,
  `trans_item_id` varchar(100) NOT NULL,
  `item_name` varchar(300) NOT NULL,
  `quanvoid` int(10) unsigned NOT NULL,
  `time_void` datetime NOT NULL,
  `type` varchar(50) NOT NULL,
  PRIMARY KEY (`trans_item_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `voidtable`
--

/*!40000 ALTER TABLE `voidtable` DISABLE KEYS */;
INSERT INTO `voidtable` (`trans_id`,`trans_item_id`,`item_name`,`quanvoid`,`time_void`,`type`) VALUES 
 ('VOID2012310185723469:TRANS2012310231','ITEM2012310182417313','WRITING AND REPORTING NEWS',7,'2012-03-10 00:00:00','Void'),
 ('VOID2012310182526250:TRANS2012310231','ITEM2012310182417364','SKIN WHITE SPF 20',1,'2012-03-10 00:00:00','Void'),
 ('VOID2012310182826603:TRANS2012310231','ITEM2012310182417389','SAKKAKU',5,'2012-03-10 00:00:00','Void'),
 ('VOID201231019101982:TRANS2012310865','ITEM201231019145899','CRAYOLA 16S',6,'2012-03-10 00:00:00','Void'),
 ('VOID201231019217270:TRANS2012310865','ITEM201231019145969','SEABISCUIT A. LEGEND  L HILLENBRAND',4,'2012-03-10 00:00:00','Void'),
 ('VOID2012310195259926:TRANS201231027','ITEM2012310195224110','SASA',10,'2012-03-10 00:00:00','Void'),
 ('VOID2012310202042338:TRANS201231027','ITEM2012310195224136','SAKKAKU',5,'2012-03-10 00:00:00','Void'),
 ('VOID2012310201319420:TRANS201231027','ITEM201231019522460','SEABISCUIT A. LEGEND  L HILLENBRAND',10,'2012-03-10 00:00:00','Void'),
 ('VOID2012310202721401:TRANS2012310292','ITEM2012310202634327','SEABISCUIT A. LEGEND  L HILLENBRAND',10,'2012-03-10 00:00:00','Void'),
 ('VOID2012310213940516:TRANS2012310963','ITEM20123102139859','CRAYOLA 16S',2,'2012-03-10 00:00:00','Void'),
 ('VOID2012320131258581:TRANS2012312122','ITEM201231211310325','SASA',1,'2012-03-20 00:00:00','Void'),
 ('VOID20123121640544:trans2012312387','ITEM2012312163814492','BOND PAPER',3,'2012-03-12 00:00:00','Void'),
 ('VOID2012320131623718:TRANS2012312214','ITEM201231220551307','MINI NOTEBOOK',1,'2012-03-20 00:00:00','Void'),
 ('VOID2012320131039500:TRANS2012313626','ITEM2012313135858782','TOM PALO',1,'2012-03-20 00:00:00','Void'),
 ('VOID2012316195744103:TRANS201231682','ITEM20123161993113','DAMET',1,'2012-03-16 00:00:00','Void'),
 ('VOID2012320132415490:TRANS2012316819','ITEM201231620310849','POTIE PEN',1,'2012-03-20 00:00:00','Void'),
 ('VOID2012320132248118:TRANS2012316819','ITEM201231620310977','BUDDHA BEAD 1',1,'2012-03-20 00:00:00','Void'),
 ('VOID201231781827877:TRANS2012317565','ITEM201231781450705','J BLUME SMART WOMEN',1,'2012-03-17 00:00:00','Void'),
 ('VOID201232013205634:TRANS2012317565','ITEM201231781450736','GERALDS GAME S KING',1,'2012-03-20 00:00:00','Void'),
 ('VOID201232013383765:TRANS2012320547','ITEM2012320132522613','CHELSEA LAADIES SANDALS BLUE',1,'2012-03-20 00:00:00','Void'),
 ('VOID2012320132556409:TRANS2012320547','ITEM2012320132522638','WRITING AND REPORTING NEWS',2,'2012-03-20 00:00:00','Void'),
 ('VOID201232013270591:TRANS2012320547','ITEM2012320132522662','STABILO BOSS',1,'2012-03-20 00:00:00','Void'),
 ('VOID2012320134126636:TRANS2012320452','ITEM2012320134037554','STABILO BOSS',6,'2012-03-20 00:00:00','Void'),
 ('VOID2012320134232173:TRANS2012320452','ITEM2012320134037582','CHELSEA LAADIES SANDALS BLUE',2,'2012-03-20 00:00:00','Void');
/*!40000 ALTER TABLE `voidtable` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
