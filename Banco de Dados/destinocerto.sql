-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 20-Dez-2021 às 23:16
-- Versão do servidor: 10.4.21-MariaDB
-- versão do PHP: 7.3.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `destinocerto`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pacotesturisticos`
--

CREATE TABLE `pacotesturisticos` (
  `IdPacote` int(4) NOT NULL,
  `Imagem` varchar(200) DEFAULT NULL,
  `Nome` varchar(100) NOT NULL,
  `Origem` varchar(100) NOT NULL,
  `Destino` varchar(100) NOT NULL,
  `Atrativos` varchar(200) NOT NULL,
  `Saida` datetime DEFAULT NULL,
  `Retorno` datetime DEFAULT NULL,
  `Usuario` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `pacotesturisticos`
--

INSERT INTO `pacotesturisticos` (`IdPacote`, `Imagem`, `Nome`, `Origem`, `Destino`, `Atrativos`, `Saida`, `Retorno`, `Usuario`) VALUES
(4, 'Bonito_MS.jpg', 'Bonito', 'São Paulo', 'Mato Grosso do Sul', 'Grutas, cachoeiras, trilhas.', '2021-12-27 17:50:00', '2022-02-04 13:40:00', 1),
(7, 'JoaoPessoa_PB.jpg', 'João Pessoa', 'São Paulo', 'Paraíba', 'Praias, piscinas naturais, gastronomia típica.', '2021-12-27 10:30:00', '2022-01-07 15:50:00', 4),
(8, 'Brotas_SP.jpg', 'Brotas', 'São Paulo-SP', 'Brotas-SP', 'Cachoeiras, rafting, percursos em tirolesa, canoagem.', '2021-12-27 14:40:00', '2022-01-05 18:00:00', 4),
(9, 'Jericoacoara_CE.jpg', 'Jericoacoara', 'São Paulo', 'Ceará', 'Dunas, lagoas de águas cristalinas e ótimos restaurantes.', '2021-12-28 08:50:00', '2022-01-10 13:29:00', 2),
(10, 'SaoMigueldosMilagres_AL.jpg', 'Sao Miguel dos Milagres', 'São Paulo', 'Alagoas', 'Uma das melhores praias do Brasil, lugar pequeno e simples, longe do agito das grandes cidades. ', '2021-12-27 20:50:00', '2022-01-08 10:30:00', 5),
(11, 'OuroPreto_MG.jpg', 'Ouro Preto', 'São Paulo', 'Minas Gerais', 'Lugar cheio de história, com igrejas de grande valor cultural e uma ótima estrutura.', '2022-01-10 18:30:00', '2022-01-12 20:00:00', 3),
(12, 'Manaus_AM.jpg', 'Manaus', 'São Paulo', 'Amazonas', 'Teatro, contato com a natureza, encontro  entre o Rio Negro e o Rio Solimões.', '2021-12-27 16:20:00', '2022-01-10 09:30:00', 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `IdUsuario` int(11) NOT NULL,
  `Nome` varchar(200) NOT NULL,
  `Login` varchar(100) NOT NULL,
  `Senha` varchar(100) NOT NULL,
  `DataNascimento` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`IdUsuario`, `Nome`, `Login`, `Senha`, `DataNascimento`) VALUES
(1, 'Alana Silva', 'alana', '12345', '1981-01-01'),
(2, 'Melissa Souza', 'melissa', '12345', '1982-02-02'),
(3, 'Iris Ferreira', 'iris', '12345', '1983-03-03'),
(4, 'Joaquim Pereira', 'joaquim', '12345', '1984-04-04'),
(5, 'Saul Rodrigues', 'saul', '12345', '1985-05-05');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD PRIMARY KEY (`IdPacote`),
  ADD KEY `Usuario` (`Usuario`);

--
-- Índices para tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`IdUsuario`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  MODIFY `IdPacote` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `IdUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD CONSTRAINT `pacotesturisticos_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuarios` (`IdUsuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
