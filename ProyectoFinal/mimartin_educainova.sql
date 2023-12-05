-- phpMyAdmin SQL Dump
-- version 4.9.11
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3306
-- Tiempo de generación: 20-11-2023 a las 16:35:31
-- Versión del servidor: 10.3.39-MariaDB-log
-- Versión de PHP: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `mimartin_educainova`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividades`
--

CREATE TABLE `actividades` (
  `id` int(11) NOT NULL,
  `pregunta` varchar(100) NOT NULL,
  `respuestav` varchar(100) NOT NULL,
  `respuesta2` varchar(100) NOT NULL,
  `respuesta3` varchar(100) NOT NULL,
  `puntos` int(11) NOT NULL,
  `tipo` varchar(2) NOT NULL,
  `tema` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `actividades`
--

INSERT INTO `actividades` (`id`, `pregunta`, `respuestav`, `respuesta2`, `respuesta3`, `puntos`, `tipo`, `tema`) VALUES
(89, '¿Dónde deben utilizar nuestros hijos las TIC?', 'En espacios compartidos con toda la familia', 'En el cuarto de baño', 'No importa donde los usen', 1, 'P', 38),
(90, '¿Qué mensaje debemos enviar a nuestros hijos respecto a las TIC?', 'Hacer un uso adecuado de las TIC', 'Responder mensajes mientras cenamos', 'Contestar el móvil mientras conducimos', 1, 'P', 38),
(91, '¿Cuáles son las pautas para educar en el buen uso de las tecnologías?', 'Las dos respuestas son correctas', 'Facilitar el sentido común', 'Establecer normas claras y firmes', 1, 'P', 38),
(93, '¿Qué herramienta podemos utilizar para planificar el tiempo libre de nuestros hijos?', 'Plan de consumo mediático', 'Teams', 'Ninguna de las respuestas es correcta', 1, 'P', 38),
(94, 'Crea un plan para el consumo de los disposivos en la Web que te indicamos y envianos una foto', 'https://www.healthychildren.org/Spanish/media/Paginas/default.aspx#wizard', '..', '..', 5, 'A', 38),
(95, 'Debes ver el siguiente video', 'https://www.youtube.com/watch?v=a7AsErdcy8o', '..', '..', 5, 'V', 38),
(96, '¿Dónde deben utilizar nuestros hijos las TIC?', 'En espacios compartidos con toda la familia', 'En el cuarto de baño', 'No importa donde los usen', 1, 'P', 37),
(97, '¿Qué mensaje debemos enviar a nuestros hijos respecto a las TIC?', 'Hacer un uso adecuado de las TIC', 'Responder mensajes mientras cenamos', 'Contestar el móvil mientras conducimos', 1, 'P', 37),
(98, '¿Cuáles son las pautas para educar en el buen uso de las tecnologías?', 'Las dos respuestas son correctas', 'Facilitar el sentido común', 'Establecer normas claras y firmes', 1, 'P', 37),
(99, 'A la hora de planificar el tiempo libre de nuestros hijos debemos:', 'Conseguir que establezcan prioridades para las actividades extraescolares, las tareas del colegio y ', 'Dejar que ello mismos elaboren su propio horario', 'Las dos respuestas son correctas', 1, 'P', 37),
(101, 'Crea un plan para el consumo de los disposivos en la Web que te indicamos y envianos una foto', 'https://www.healthychildren.org/Spanish/media/Paginas/default.aspx#wizard', '..', '..', 5, 'A', 37),
(102, 'Debes ver el siguiente video', 'https://www.youtube.com/watch?v=a7AsErdcy8o', '..', '..', 5, 'V', 37);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sessions`
--

CREATE TABLE `sessions` (
  `session_id` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `expires` int(11) UNSIGNED NOT NULL,
  `data` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `sessions`
--

INSERT INTO `sessions` (`session_id`, `expires`, `data`) VALUES
('DVXxSIkRhcvns4nQFh9tI0ZM-4Yf6xwj', 1626360623, '{\"cookie\":{\"originalMaxAge\":null,\"expires\":null,\"httpOnly\":true,\"path\":\"/\"},\"flash\":{},\"passport\":{}}');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tema`
--

CREATE TABLE `tema` (
  `id` int(11) NOT NULL,
  `nombretema` varchar(100) NOT NULL,
  `contenido` varchar(600) NOT NULL,
  `tiempo` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tema`
--

INSERT INTO `tema` (`id`, `nombretema`, `contenido`, `tiempo`) VALUES
(37, 'Uso basico del Ipad', 'decalogoipad.pdf', 10),
(38, 'Uso basico del Ipad 2', 'decalogoipad.pdf', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(16) NOT NULL,
  `password` varchar(60) NOT NULL,
  `email` varchar(100) NOT NULL,
  `puntos` int(11) NOT NULL DEFAULT 0,
  `rol` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `email`, `puntos`, `rol`) VALUES
(126, 'Juan Carlos', '1234', 'cdsvfdbg', 1234, ''),
(127, 'ADNET DEYRRI', 'PEPITO', 'adnetluna@gmail.com', 69, ''),
(134, 'ADNETTTTTT', 'PEPITOS', 'ASDA@GMAIL.COM', 78, ''),
(135, 'Denice', '1234', 'denice@gmail.com', 10, ''),
(136, 'Ruben', '1234', 'fdsgdhgj', 20, ''),
(137, 'Antonio', 'fascsaca', 'ascascs', 12, ''),
(138, 'adios', '123', 'sacds', 12, ''),
(139, 'Fernando', 'Fernando', 'Fernando', 1, ''),
(140, 'Conectado', '12345', 'mariolopezaparicio2002@gmail.com', 5432, ''),
(141, 'Conectado', '12345', 'mariolopezaparicio2002@gmail.com', 5432, ''),
(142, 'CesarREAL', 'AA', 'BB', 15, ''),
(143, 'dede', '1234', '234', 12, ''),
(144, 'sadf', '123', 'sdafs', 65, ''),
(145, 'Conectado', '5432', 'buenas', 765, ''),
(146, 'Dios', '10', '10', 10, ''),
(147, 'Dios', '100', '100', 100, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario_tema`
--

CREATE TABLE `usuario_tema` (
  `idusuario` int(11) NOT NULL,
  `idtema` int(11) NOT NULL,
  `totalpuntos` int(11) NOT NULL DEFAULT 0,
  `visto` varchar(2) NOT NULL DEFAULT 'NO'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `actividades`
--
ALTER TABLE `actividades`
  ADD PRIMARY KEY (`id`),
  ADD KEY `tema` (`tema`) USING BTREE;

--
-- Indices de la tabla `sessions`
--
ALTER TABLE `sessions`
  ADD PRIMARY KEY (`session_id`);

--
-- Indices de la tabla `tema`
--
ALTER TABLE `tema`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuario_tema`
--
ALTER TABLE `usuario_tema`
  ADD PRIMARY KEY (`idusuario`,`idtema`),
  ADD KEY `idtema` (`idtema`) USING BTREE,
  ADD KEY `idusuario` (`idusuario`) USING BTREE;

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `actividades`
--
ALTER TABLE `actividades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=117;

--
-- AUTO_INCREMENT de la tabla `tema`
--
ALTER TABLE `tema`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT de la tabla `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=153;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `actividades`
--
ALTER TABLE `actividades`
  ADD CONSTRAINT `lnk_tema_actividades` FOREIGN KEY (`tema`) REFERENCES `tema` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `usuario_tema`
--
ALTER TABLE `usuario_tema`
  ADD CONSTRAINT `lnk_tema_usuario_tema` FOREIGN KEY (`idtema`) REFERENCES `tema` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `lnk_users_usuario_tema` FOREIGN KEY (`idusuario`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
