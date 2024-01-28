USE [LI4DB]

-- Povoar a tabela Utilizador
INSERT INTO [dbo].[Utilizador] ([Username], [Primeiro Nome], [Segundo Nome], [Email], [Password], [Contacto Telef�nico], [Morada], [Saldo])
VALUES
('joaosilva', 'Jo�o', 'Silva', 'joao.silva@email.com', 'password123', '912345678', 'Rua das Flores, n� 123', 500.00,150.00),
('mariasantos', 'Maria', 'Santos', 'maria.santos@email.com', 'maria456', '933333333', 'Avenida dos Aliados, n� 456', 1400.00,300.00),
('carlosfernandes', 'Carlos', 'Fernandes', 'carlos.fernandes@email.com', 'carlos789', '965432123', 'Rua do Sol, n� 789', 450.00, 200.00),
('anapereira', 'Ana', 'Pereira', 'ana.pereira@email.com', 'anapass987', '922222222', 'Rua das �rvores, n� 987', 430.00, 400.00),
('pedrooliveira', 'Pedro', 'Oliveira', 'pedro.oliveira@email.com', 'pedro123', '911111111', 'Rua das Pedras, n� 321', 800.00, 250.00);

-- Povoar a tabela Categoria
INSERT INTO [dbo].[Categoria] ([ID], [Nome])
VALUES
(1, 'Figuras de A��o'),
(2, 'Banda Desenhada'),
(3, 'Filmes e S�ries'),
(4, 'Jogos de Tabuleiro'),
(5, 'Video Jogos');

-- Povoar a tabela Leil�o
INSERT INTO [dbo].[Leil�o] ([Leil�oID], [Tipo do Leil�o], [Estado], [Nome do produto], [Categoria do produto], [Marca do Produto], [Username do Vendedor], [Descri��o], [TempoLimite], [Valor inicial], [Data de termino])
VALUES
(1, 'Ingl�s', 'Novo', 'Action Figura Spider-Man', 1, 0x456C656374726F6E696373, 'joaosilva', 'Figura super rara', '02:00:00', 1000.00, '2024-02-10 15:00:00'),
(2, 'Japon�s', 'Muito Bom', 'Edi��o Rara de Batman: The Dark Knight Returns', 2, 0x4265727279, 'mariasantos', 'Edi��o Rara de Batman: The Dark Knight Returns', '03:30:00', 200.00, '2024-02-15 18:30:00'),
(3, 'Ingl�s', 'Satisfaz', 'Harry Potter e a Pedra Filosofal', 3, 0x4861727279506F74746572, 'carlosfernandes', 'Livro de fic��o de J.K. Rowling', '01:45:00', 20.00, '2024-02-05 12:45:00'),
(4, 'Japon�s', 'Novo', 'Cluedo De Fortnite', 4, 0x4E6174757A7A69, 'anapereira', 'Jogo super raro tem�tico', '04:15:00', 50000.00, '2024-02-20 20:15:00'),
(5, 'Ingl�s', 'Novo', 'Clash Royale Super Deluxe', 5, 0x5370656369616C697A6564, 'pedrooliveira', 'Jogo super exclusivo', '02:30:00', 300.00, '2024-02-08 14:30:00');

-- Povoar a tabela Carregamentos
INSERT INTO [dbo].[Carregamentos] ([Username], [Data], [Valor], [IDCarregamento])
VALUES
('joaosilva', '2024-01-26 10:30:00', 50.00, 1),
('mariasantos', '2024-01-27 12:45:00', 100.00, 2),
('carlosfernandes', '2024-01-28 15:00:00', 75.00, 3),
('anapereira', '2024-01-29 17:15:00', 120.00, 4),
('pedrooliveira', '2024-01-30 19:30:00', 90.00, 5)

-- Povoar a tabela Licita��o
INSERT INTO [dbo].[Licita��o] ([Licita��oID], [Tempo], [Valor], [UserUsername], [IDLeil�o])
VALUES
(1, '2024-02-10 14:55:00', 1100.00, 'mariasantos', 1),
(2, '2024-02-15 18:00:00', 250.00, 'carlosfernandes', 2),
(3, '2024-02-05 12:30:00', 30.00, 'anapereira', 3),
(4, '2024-02-20 20:00:00', 550.00, 'pedrooliveira', 4),
(5, '2024-02-08 14:00:00', 350.00, 'joaosilva', 5);

-- Povoar a tabela Avalia��o
INSERT INTO [dbo].[Avalia��o] ([Avalia��oID], [UsernameClient], [UsernameUser], [Avalia��o], [Comentario])
VALUES
(1, 'joaosilva', 'mariasantos', 4, '�tima transa��o, r�pido e eficiente'),
(2, 'mariasantos', 'carlosfernandes', 5, 'Produto de qualidade, entrega no prazo'),
(3, 'carlosfernandes', 'anapereira', 3, 'Alguns danos no sof�, mas aceit�vel'),
(4, 'anapereira', 'pedrooliveira', 5, 'Bicicleta em perfeito estado, como descrito'),
(5, 'pedrooliveira', 'joaosilva', 4, 'Entrega r�pida, satisfeito com a compra');

-- Descartar a tabela Avalia��o
DROP TABLE IF EXISTS [dbo].[Avalia��o];

-- Descartar a tabela Carregamentos
DROP TABLE IF EXISTS [dbo].[Carregamentos];

-- Descartar a tabela Categoria
DROP TABLE IF EXISTS [dbo].[Categoria];

-- Descartar a tabela "Foto do produto"
DROP TABLE IF EXISTS [dbo].[Foto do produto];

-- Descartar a tabela Leil�o
DROP TABLE IF EXISTS [dbo].[Leil�o];

-- Descartar a tabela Licita��o
DROP TABLE IF EXISTS [dbo].[Licita��o];

-- Descartar a tabela Utilizador
DROP TABLE IF EXISTS [dbo].[Utilizador];
