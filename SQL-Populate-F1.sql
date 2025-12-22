USE F1SimulatorDBTeamManegementService
GO

--   >>>   Teams


INSERT INTO Teams (TeamId, [Name], NameAcronym, Country) VALUES
(NEWID(), 'Red Bull Racing', 'RBR', 'Austria'),
(NEWID(), 'Ferrari', 'FER', 'Italy'),
(NEWID(), 'Mercedes', 'MER', 'Germany'),
(NEWID(), 'McLaren', 'MCL', 'United Kingdom'),
(NEWID(), 'Aston Martin', 'AST', 'United Kingdom'),
(NEWID(), 'Alpine', 'ALP', 'France'),
(NEWID(), 'Williams', 'WIL', 'United Kingdom'),
(NEWID(), 'RB F1 Team', 'RBF', 'Italy'),
(NEWID(), 'Kick Sauber', 'SAU', 'Switzerland'),
(NEWID(), 'Haas', 'HAA', 'United States');
GO

--   >>>   Boss


INSERT INTO Boss VALUES
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'), 'Christian', 'Horner', 51),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'), 'Helmut', 'Marko', 81),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'), 'Frédéric', 'Vasseur', 56),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'), 'Laurent', 'Mekies', 47),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'), 'Toto', 'Wolff', 53),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'), 'James', 'Allison', 56),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'), 'Andrea', 'Stella', 53),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'), 'Zak', 'Brown', 53),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'), 'Mike', 'Krack', 52),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'), 'Andy', 'Cowell', 55),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'), 'Bruno', 'Famin', 62),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'), 'David', 'Sanchez', 45),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'), 'James', 'Vowles', 45),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'), 'Dave', 'Robson', 54),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'), 'Laurent', 'Mekies', 47),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'), 'Peter', 'Bayer', 52),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'), 'Alessandro', 'Alunni Bravi', 50),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'), 'Beat', 'Zehnder', 58),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'), 'Ayao', 'Komatsu', 48),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'), 'Gene', 'Haas', 72);
GO

--   >>>   Cars


INSERT INTO Cars (CarId, TeamId, Model, WeightKg, Speed, Ca, Cp) VALUES
-- Red Bull Racing
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'), 'RBR01', 798.00, 360, 0.980, 0.970),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'), 'RBR11', 798.00, 360, 0.975, 0.968),
-- Ferrari
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'), 'FER16', 800.00, 355, 0.960, 0.955),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'), 'FER55', 800.00, 355, 0.958, 0.954),
-- Mercedes
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'), 'MER44', 802.00, 352, 0.955, 0.950),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'), 'MER63', 802.00, 352, 0.952, 0.948),
-- McLaren
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'), 'MCL04', 801.00, 353, 0.957, 0.953),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'), 'MCL81', 801.00, 353, 0.956, 0.952),
-- Aston Martin
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'), 'AST14', 804.00, 350, 0.940, 0.935),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'), 'AST18', 804.00, 350, 0.938, 0.934),
-- Alpine
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'), 'ALP10', 805.00, 348, 0.935, 0.930),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'), 'ALP31', 805.00, 348, 0.933, 0.928),
-- Williams
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'), 'WIL23', 806.00, 347, 0.930, 0.925),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'), 'WIL02', 806.00, 347, 0.928, 0.923),
-- RB F1 Team (Visa Cash App RB)
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'), 'RBF22', 804.50, 349, 0.938, 0.933),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'), 'RBF03', 804.50, 349, 0.936, 0.932),
-- Kick Sauber
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'), 'SAU77', 807.00, 346, 0.928, 0.922),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'), 'SAU24', 807.00, 346, 0.926, 0.920),
-- Haas
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'), 'HAA20', 808.00, 345, 0.925, 0.918),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'), 'HAA27', 808.00, 345, 0.923, 0.916);
GO

--   >>>   Drivers


INSERT INTO Drivers
(DriverId, DriverNumber, TeamId, CarId, FirstName, FullName, ExperienceFactor, WeightKg, HandiCap)
VALUES
-- Red Bull Racing
(NEWID(), '01',
 (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Red Bull Racing')),
 'Max', 'Max Verstappen', 0.990, 72.0, 0.00),
(NEWID(), '11',
 (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Red Bull Racing') ORDER BY CarId DESC),
 'Sergio', 'Sergio Perez', 0.960, 74.0, 0.10),
-- Ferrari
(NEWID(), '16',
 (SELECT TeamId FROM Teams WHERE Name='Ferrari'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Ferrari')),
 'Charles', 'Charles Leclerc', 0.975, 69.0, 0.05),
(NEWID(), '55',
 (SELECT TeamId FROM Teams WHERE Name='Ferrari'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Ferrari') ORDER BY CarId DESC),
 'Carlos', 'Carlos Sainz', 0.965, 70.0, 0.07),
-- Mercedes
(NEWID(), '44',
 (SELECT TeamId FROM Teams WHERE Name='Mercedes'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Mercedes')),
 'Lewis', 'Lewis Hamilton', 0.980, 73.0, 0.05),
(NEWID(), '63',
 (SELECT TeamId FROM Teams WHERE Name='Mercedes'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Mercedes') ORDER BY CarId DESC),
 'George', 'George Russell', 0.965, 70.0, 0.08),
-- McLaren
(NEWID(), '04',
 (SELECT TeamId FROM Teams WHERE Name='McLaren'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='McLaren')),
 'Lando', 'Lando Norris', 0.970, 68.0, 0.06),
(NEWID(), '81',
 (SELECT TeamId FROM Teams WHERE Name='McLaren'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='McLaren') ORDER BY CarId DESC),
 'Oscar', 'Oscar Piastri', 0.960, 71.0, 0.08),
-- Aston Martin
(NEWID(), '14',
 (SELECT TeamId FROM Teams WHERE Name='Aston Martin'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Aston Martin')),
 'Fernando', 'Fernando Alonso', 0.985, 68.0, 0.04),
(NEWID(), '18',
 (SELECT TeamId FROM Teams WHERE Name='Aston Martin'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Aston Martin') ORDER BY CarId DESC),
 'Lance', 'Lance Stroll', 0.940, 75.0, 0.12),
-- Alpine
(NEWID(), '10',
 (SELECT TeamId FROM Teams WHERE Name='Alpine'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Alpine')),
 'Pierre', 'Pierre Gasly', 0.955, 70.0, 0.09),
(NEWID(), '31',
 (SELECT TeamId FROM Teams WHERE Name='Alpine'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Alpine') ORDER BY CarId DESC),
 'Esteban', 'Esteban Ocon', 0.950, 69.0, 0.10),
-- Williams
(NEWID(), '23',
 (SELECT TeamId FROM Teams WHERE Name='Williams'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Williams')),
 'Alexander', 'Alexander Albon', 0.955, 74.0, 0.08),
(NEWID(), '02',
 (SELECT TeamId FROM Teams WHERE Name='Williams'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Williams') ORDER BY CarId DESC),
 'Logan', 'Logan Sargeant', 0.920, 75.0, 0.15),
-- RB F1 Team
(NEWID(), '22',
 (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='RB F1 Team')),
 'Yuki', 'Yuki Tsunoda', 0.950, 54.0, 0.12),
(NEWID(), '03',
 (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='RB F1 Team') ORDER BY CarId DESC),
 'Daniel', 'Daniel Ricciardo', 0.955, 71.0, 0.10),
-- Kick Sauber
(NEWID(), '77',
 (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Kick Sauber')),
 'Valtteri', 'Valtteri Bottas', 0.960, 69.0, 0.09),
(NEWID(), '24',
 (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Kick Sauber') ORDER BY CarId DESC),
 'Zhou', 'Zhou Guanyu', 0.940, 71.0, 0.12),
-- Haas
(NEWID(), '20',
 (SELECT TeamId FROM Teams WHERE Name='Haas'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Haas')),
 'Kevin', 'Kevin Magnussen', 0.950, 74.0, 0.11),
(NEWID(), '27',
 (SELECT TeamId FROM Teams WHERE Name='Haas'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Haas') ORDER BY CarId DESC),
 'Nico', 'Nico Hulkenberg', 0.960, 75.0, 0.10);
 GO

 --   >>>   Engineers


 INSERT INTO Engineers
(EngineerId, TeamId, CarId, FirstName, LastName, ExperienceFactor, Specialization)
VALUES
-- ======================
-- Red Bull Racing
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Red Bull Racing')),
 'Lucas', 'Weber', 0.985, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Red Bull Racing')),
 'Mark', 'Schneider', 0.980, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Red Bull Racing') ORDER BY CarId DESC),
 'Thomas', 'Meyer', 0.975, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Red Bull Racing'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Red Bull Racing') ORDER BY CarId DESC),
 'Daniel', 'Fischer', 0.972, 'Cp'),
-- ======================
-- Ferrari
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Ferrari')),
 'Marco', 'Bianchi', 0.970, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Ferrari')),
 'Luca', 'Rossi', 0.968, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Ferrari') ORDER BY CarId DESC),
 'Gianni', 'Moretti', 0.965, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Ferrari'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Ferrari') ORDER BY CarId DESC),
 'Alessio', 'Conti', 0.962, 'Cp'),
-- ======================
-- Mercedes
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Mercedes')),
 'Stefan', 'Keller', 0.968, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Mercedes')),
 'Oliver', 'Brandt', 0.965, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Mercedes') ORDER BY CarId DESC),
 'Jan', 'Becker', 0.962, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Mercedes'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Mercedes') ORDER BY CarId DESC),
 'Felix', 'Wagner', 0.960, 'Cp'),
-- ======================
-- McLaren
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='McLaren')),
 'James', 'Turner', 0.965, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='McLaren')),
 'Ryan', 'Cooper', 0.962, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='McLaren') ORDER BY CarId DESC),
 'Oliver', 'Brown', 0.960, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='McLaren'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='McLaren') ORDER BY CarId DESC),
 'Daniel', 'Wilson', 0.958, 'Cp'),
-- ======================
-- Aston Martin
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Aston Martin')),
 'Robert', 'Green', 0.958, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Aston Martin')),
 'Andrew', 'Hill', 0.955, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Aston Martin') ORDER BY CarId DESC),
 'Matthew', 'Clark', 0.953, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Aston Martin'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Aston Martin') ORDER BY CarId DESC),
 'Simon', 'Wright', 0.950, 'Cp'),
-- ======================
-- Alpine
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Alpine')),
 'Pierre', 'Dubois', 0.952, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Alpine')),
 'Julien', 'Moreau', 0.950, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Alpine') ORDER BY CarId DESC),
 'Antoine', 'Leroy', 0.948, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Alpine'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Alpine') ORDER BY CarId DESC),
 'Mathieu', 'Roux', 0.945, 'Cp'),
-- ======================
-- Williams
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Williams')),
 'Chris', 'Taylor', 0.950, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Williams')),
 'David', 'Evans', 0.948, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Williams') ORDER BY CarId DESC),
 'Tom', 'Morgan', 0.946, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Williams'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Williams') ORDER BY CarId DESC),
 'Alex', 'Price', 0.944, 'Cp'),
-- ======================
-- RB F1 Team
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='RB F1 Team')),
 'Kenji', 'Sato', 0.948, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='RB F1 Team')),
 'Hiro', 'Tanaka', 0.946, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='RB F1 Team') ORDER BY CarId DESC),
 'Marco', 'Silva', 0.944, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='RB F1 Team'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='RB F1 Team') ORDER BY CarId DESC),
 'Rafael', 'Costa', 0.942, 'Cp'),
-- ======================
-- Kick Sauber
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Kick Sauber')),
 'Jonas', 'Muller', 0.945, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Kick Sauber')),
 'Patrick', 'Weiss', 0.943, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Kick Sauber') ORDER BY CarId DESC),
 'Lukas', 'Schmid', 0.940, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Kick Sauber'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Kick Sauber') ORDER BY CarId DESC),
 'Fabian', 'Koch', 0.938, 'Cp'),
-- ======================
-- Haas
-- ======================
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Haas')),
 'Michael', 'Anderson', 0.940, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Haas')),
 'Brian', 'Miller', 0.938, 'Cp'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Haas') ORDER BY CarId DESC),
 'Jason', 'Moore', 0.935, 'Ca'),
(NEWID(), (SELECT TeamId FROM Teams WHERE Name='Haas'),
 (SELECT TOP 1 CarId FROM Cars WHERE TeamId=(SELECT TeamId FROM Teams WHERE Name='Haas') ORDER BY CarId DESC),
 'Eric', 'Johnson', 0.933, 'Cp');