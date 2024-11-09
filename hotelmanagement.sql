-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 04, 2024 at 01:41 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotelmanagement`
--

-- --------------------------------------------------------

--
-- Table structure for table `guestaccounts`
--

CREATE TABLE `guestaccounts` (
  `unique_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guestaccounts`
--

INSERT INTO `guestaccounts` (`unique_id`, `username`, `password`, `email`) VALUES
(1, 'guest1', 'guest', 'guest@gmail.com'),
(3, 'Zheng47', 'legendary', 'sen.alexanderjonard.deslate@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `guestroominformation`
--

CREATE TABLE `guestroominformation` (
  `unique_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `room_number` int(11) NOT NULL,
  `chk_in_date` date NOT NULL,
  `chk_out_date` date NOT NULL,
  `room_type` varchar(100) NOT NULL,
  `occupancy` varchar(100) NOT NULL,
  `amenities` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guestroominformation`
--

INSERT INTO `guestroominformation` (`unique_id`, `username`, `password`, `email`, `room_number`, `chk_in_date`, `chk_out_date`, `room_type`, `occupancy`, `amenities`) VALUES
(1, 'guest1', 'guest', 'guest@gmail.com', 303, '2024-10-24', '2024-10-26', 'Premium ', '2 adult', 'WiFI, Queen-Size Bed, Karaoke '),
(3, 'Zheng47', 'legendary', 'sen.alexanderjonard.deslate@gmail.com', 101, '2024-10-24', '2024-10-26', 'Deluxe Suite', 'Couple ', 'King-size bed, Wi-Fi, ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `guestaccounts`
--
ALTER TABLE `guestaccounts`
  ADD PRIMARY KEY (`unique_id`);

--
-- Indexes for table `guestroominformation`
--
ALTER TABLE `guestroominformation`
  ADD PRIMARY KEY (`unique_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `guestaccounts`
--
ALTER TABLE `guestaccounts`
  MODIFY `unique_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `guestroominformation`
--
ALTER TABLE `guestroominformation`
  MODIFY `unique_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
