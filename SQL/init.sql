USE contabancaria;

CREATE TABLE IF NOT EXISTS contas (
    numero INT PRIMARY KEY,
    agencia INT NOT NULL,
    tipo INT NOT NULL,
    titular VARCHAR(100) NOT NULL,
    saldo FLOAT DEFAULT 0,
    limite FLOAT NULL,
    aniversario INT NULL
);


INSERT INTO contas (numero, agencia, tipo, titular, saldo, limite, aniversario)
VALUES 
(1001, 1, 1, 'Jon Snow', 1500.00, 500.00, NULL),
(1002, 1, 2, 'Daenerys Targaryen', 2000.00, NULL, 15),
(1003, 2, 1, 'Tyrion Lannister', 500.00, 300.00, NULL),
(1004, 2, 2, 'Arya Stark', 1200.00, NULL, 10),
(1005, 3, 1, 'Cersei Lannister', 3000.00, 1000.00, NULL);