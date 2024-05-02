-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-02-2023 a las 19:20:06
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dealer`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `authorizations`
--

CREATE TABLE `authorizations` (
  `id` bigint(20) NOT NULL,
  `token` varchar(255) NOT NULL,
  `idcompanie` bigint(20) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `authorizations`
--

INSERT INTO `authorizations` (`id`, `token`, `idcompanie`, `created_at`, `updated_at`) VALUES
(1, 'c2yc10cyNLZDe9xVV6n9QM4YSTT/.nzvXczFAIY4tICkwzxOzjy7X5UPhH4K', 1, '2023-02-13 02:00:08', '2023-02-13 02:08:23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `companies`
--

CREATE TABLE `companies` (
  `id` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `business_name` varchar(100) NOT NULL,
  `phone` varchar(10) NOT NULL,
  `email` varchar(50) NOT NULL,
  `enable` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `companies`
--

INSERT INTO `companies` (`id`, `name`, `business_name`, `phone`, `email`, `enable`, `created_at`, `updated_at`) VALUES
(1, 'DERMAEXPRESS', 'DERMAEXPRESS', '3318253863', 'sistemasdevjr@mepiel.com.mx', 1, '2023-02-13 01:55:13', '2023-02-13 03:15:48');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `directions_origin`
--

CREATE TABLE `directions_origin` (
  `id` bigint(20) NOT NULL,
  `name` varchar(100) NOT NULL,
  `no_ext` varchar(5) NOT NULL,
  `postalcode` int(5) NOT NULL,
  `neighborhood` varchar(100) NOT NULL,
  `city` varchar(100) NOT NULL,
  `state` varchar(100) NOT NULL,
  `country` varchar(15) NOT NULL,
  `reference` varchar(50) NOT NULL,
  `phone` bigint(10) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `employers`
--

CREATE TABLE `employers` (
  `id` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 1,
  `idrole` bigint(20) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `employers`
--

INSERT INTO `employers` (`id`, `name`, `lastname`, `username`, `password`, `status`, `idrole`, `created_at`, `updated_at`) VALUES
(2, 'CAROLINA', 'DIAZ RUIZ', 'cdiaz', '$2y$10$PWt9PCJuiECkIk.1DPJBAe1kXCV8EuF2MIyM/7VaPgabvVVUBlp6y', 1, 1, '2023-02-12 06:01:21', '2023-02-13 18:25:50'),
(14, 'ALEJANDRO', 'WALDO SALAZAR', 'awaldo', '$2y$10$tmc3xGr1KOYHFFbePreF3etfezsODA1ARi3gTF7pN/IMjxca6zDh6', 0, 1, '2023-02-13 03:13:54', '2023-02-13 18:43:11');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `packages`
--

CREATE TABLE `packages` (
  `id` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 1,
  `length` varchar(4) NOT NULL,
  `width` varchar(4) NOT NULL,
  `height` varchar(4) NOT NULL,
  `weight` varchar(4) NOT NULL,
  `volumetric` varchar(4) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `packages`
--

INSERT INTO `packages` (`id`, `name`, `description`, `status`, `length`, `width`, `height`, `weight`, `volumetric`, `created_at`, `updated_at`) VALUES
(1, 'Paquete 1', 'Primer paquete', 1, '5', '80', '80', '81', '6.4', '2023-02-06 04:51:57', '2023-02-13 22:53:22'),
(4, 'Paquete postan', 'Primer paquete', 1, '60', '50', '80', '80', '48', '2023-02-13 22:54:25', '2023-02-13 22:55:07'),
(5, 'Paquete postman', 'Seungo paquete', 1, '60', '50', '50', '50', '30', '2023-02-13 22:56:43', '2023-02-13 23:09:27');

--
-- Disparadores `packages`
--
DELIMITER $$
CREATE TRIGGER `VolumetricInsert` BEFORE INSERT ON `packages` FOR EACH ROW SET NEW.volumetric = CEILING(((NEW.length*NEW.width*NEW.height)/5000))
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `VolumetricUpdate` BEFORE UPDATE ON `packages` FOR EACH ROW SET NEW.volumetric = CEILING(((NEW.length*NEW.width*NEW.height)/5000))
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `id` bigint(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`id`, `name`, `status`, `created_at`, `updated_at`) VALUES
(1, 'ADMIN', 1, '2023-02-12 06:01:13', '2023-02-12 06:01:13');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `authorizations`
--
ALTER TABLE `authorizations`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `token` (`token`),
  ADD KEY `idcompanie` (`idcompanie`);

--
-- Indices de la tabla `companies`
--
ALTER TABLE `companies`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `directions_origin`
--
ALTER TABLE `directions_origin`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `employers`
--
ALTER TABLE `employers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idrole` (`idrole`);

--
-- Indices de la tabla `packages`
--
ALTER TABLE `packages`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `authorizations`
--
ALTER TABLE `authorizations`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `companies`
--
ALTER TABLE `companies`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `directions_origin`
--
ALTER TABLE `directions_origin`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `employers`
--
ALTER TABLE `employers`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de la tabla `packages`
--
ALTER TABLE `packages`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `authorizations`
--
ALTER TABLE `authorizations`
  ADD CONSTRAINT `authorizations_ibfk_1` FOREIGN KEY (`idcompanie`) REFERENCES `companies` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `employers`
--
ALTER TABLE `employers`
  ADD CONSTRAINT `employers_ibfk_1` FOREIGN KEY (`idrole`) REFERENCES `roles` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
