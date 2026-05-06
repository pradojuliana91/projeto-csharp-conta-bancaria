USE contabancaria;

CREATE TABLE IF NOT EXISTS contas (
	id BIGINT PRIMARY KEY AUTO_INCREMENT,
	agencia INT NOT NULL,
    numero INT NOT NULL,    
    tipo INT NOT NULL,
    titular VARCHAR(100) NOT NULL,
    saldo FLOAT DEFAULT 0,
    limite FLOAT NULL,
    aniversario INT NULL
);

CREATE UNIQUE INDEX idx_agencia_numero
ON contas(agencia, numero);

INSERT INTO contas (numero, agencia, tipo, titular, saldo, limite, aniversario)
VALUES 
(1001, 1234, 1, 'Jon Snow', 1500.00, 500.00, NULL),
(1002, 1234, 2, 'Daenerys Targaryen', 2000.00, NULL, 15),
(1003, 2468, 1, 'Tyrion Lannister', 500.00, 300.00, NULL),
(1004, 2468, 2, 'Arya Stark', 1200.00, NULL, 10),
(1005, 3579, 1, 'Cersei Lannister', 3000.00, 1000.00, NULL);