-- Criação do banco de dados
-- CREATE DATABASE lp1;
-- GO

-- Utilizando o banco de dados
USE lp1;
GO

-- Criação da tabela Usuario
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeUsuario VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL,
    IsAdmin BIT NOT NULL
);
GO

-- Criação da tabela Barbeiro
CREATE TABLE Barbeiro (
    IdBarbeiro INT IDENTITY(1,1) PRIMARY KEY,
    NomeBarbeiro VARCHAR(100) NOT NULL
);
GO

-- Criação da tabela Reserva
CREATE TABLE Reserva (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdBarbeiro INT NOT NULL,
    DataHora DATETIME NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
    FOREIGN KEY (IdBarbeiro) REFERENCES Barbeiro(IdBarbeiro)
);
GO

-- Stored procedures para a tabela Usuario
CREATE PROCEDURE AdicionarUsuario
    @NomeUsuario VARCHAR(100),
    @Email VARCHAR(100),
    @Senha VARCHAR(100),
    @IsAdmin BIT
AS
BEGIN
    INSERT INTO Usuario (NomeUsuario, Email, Senha, IsAdmin)
    VALUES (@NomeUsuario, @Email, @Senha, @IsAdmin);
END;
GO

CREATE PROCEDURE AtualizarUsuario
    @Id INT,
    @NomeUsuario VARCHAR(100),
    @Email VARCHAR(100),
    @Senha VARCHAR(100),
    @IsAdmin BIT
AS
BEGIN
    UPDATE Usuario
    SET NomeUsuario = @NomeUsuario, Email = @Email, Senha = @Senha, IsAdmin = @IsAdmin
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ExcluirUsuario
    @Id INT
AS
BEGIN
    DELETE FROM Usuario
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ListarUsuarios
AS
BEGIN
    SELECT * FROM Usuario;
END;
GO

CREATE PROCEDURE BuscarUsuarioPorCredenciais
    @NomeUsuario VARCHAR(100),
    @Senha VARCHAR(100)
AS
BEGIN
    SELECT * FROM Usuario
    WHERE NomeUsuario = @NomeUsuario AND Senha = @Senha;
END;
GO

-- Stored procedures para a tabela Barbeiro
CREATE PROCEDURE AdicionarBarbeiro
    @NomeBarbeiro VARCHAR(100)
AS
BEGIN
    INSERT INTO Barbeiro (NomeBarbeiro)
    VALUES (@NomeBarbeiro);
END;
GO

CREATE PROCEDURE AtualizarBarbeiro
    @IdBarbeiro INT,
    @NomeBarbeiro VARCHAR(100)
AS
BEGIN
    UPDATE Barbeiro
    SET NomeBarbeiro = @NomeBarbeiro
    WHERE IdBarbeiro = @IdBarbeiro;
END;
GO

CREATE PROCEDURE ExcluirBarbeiro
    @IdBarbeiro INT
AS
BEGIN
    DELETE FROM Barbeiro
    WHERE IdBarbeiro = @IdBarbeiro;
END;
GO

CREATE PROCEDURE ListarBarbeiros
AS
BEGIN
    SELECT * FROM Barbeiro;
END;
GO

-- Stored procedures para a tabela Reserva
CREATE PROCEDURE AdicionarReserva
    @IdUsuario INT,
    @IdBarbeiro INT,
    @DataHora DATETIME
AS
BEGIN
    INSERT INTO Reserva (IdUsuario, IdBarbeiro, DataHora)
    VALUES (@IdUsuario, @IdBarbeiro, @DataHora);
END;
GO

CREATE PROCEDURE AtualizarReserva
    @IdReserva INT,
    @IdBarbeiro INT,
    @DataHora DATETIME
AS
BEGIN
    UPDATE Reserva
    SET IdBarbeiro = @IdBarbeiro, DataHora = @DataHora
    WHERE IdReserva = @IdReserva;
END;
GO

CREATE PROCEDURE ExcluirReserva
    @IdReserva INT
AS
BEGIN
    DELETE FROM Reserva
    WHERE IdReserva = @IdReserva;
END;
GO

CREATE PROCEDURE ListarReservas
AS
BEGIN
    SELECT * FROM Reserva;
END;
GO

CREATE PROCEDURE ListarReservasComInformacoes
AS
BEGIN
    SELECT 
        r.IdReserva,
        u.NomeUsuario,
        u.Email,
        b.NomeBarbeiro,
        r.DataHora
    FROM 
        Reserva r
    INNER JOIN 
        Usuario u ON r.IdUsuario = u.Id
    INNER JOIN 
        Barbeiro b ON r.IdBarbeiro = b.IdBarbeiro;
END;
GO
EXEC AdicionarUsuario 
    @NomeUsuario = 'test',
    @Email = 'test',
    @Senha = 'test',
    @IsAdmin = 0;
SELECT * FROM usuario 