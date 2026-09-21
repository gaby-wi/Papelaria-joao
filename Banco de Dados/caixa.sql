create database Prime_Caixa;
use Prime_Caixa;

CREATE TABLE Caixa (
    id_cai INT PRIMARY KEY AUTO_INCREMENT,
    DataDabertura_cai DATE,
    DataDfechamento_cai DATE,
    ValorInicial_cai FLOAT,
    ValorFinal_cai FLOAT,
    status_cai VARCHAR(20)
);

INSERT INTO Caixa
(DataDabertura_cai, DataDfechamento_cai, ValorInicial_cai, ValorFinal_cai, status_cai)
VALUES
('2026-08-01', '2026-08-01', 100, 450, 'Fechado'),
('2026-08-02', '2026-08-02', 100, 520, 'Fechado'),
('2026-08-03', '2026-08-03', 150, 680, 'Fechado'),
('2026-08-04', '2026-08-04', 100, 390, 'Fechado'),
('2026-08-05', NULL, 100, NULL, 'Aberto');

select * from caixa;

CREATE TABLE Movimentacao_Caixa (
    id_movi INT PRIMARY KEY AUTO_INCREMENT,
    id_cai_fk INT NOT NULL,
    tipo_movi VARCHAR(20),
    valor_movi FLOAT,
    dataMovi DATE,
    descricao_movi VARCHAR(300),
    formaPagamento_movi VARCHAR(30),

    FOREIGN KEY (id_cai_fk) 
        REFERENCES Caixa(id_cai)
);

INSERT INTO Movimentacao_Caixa
(id_cai_fk, tipo_movi, valor_movi, dataMovi, descricao_movi, formaPagamento_movi)
VALUES
(1, 'Entrada', 50, '2026-08-01', 
'Venda de produtos', 'Dinheiro'),

(1, 'Entrada', 120, '2026-08-01', 
'Venda de produtos', 'PIX'),

(2, 'Saida', 80, '2026-08-02', 
'Pagamento fornecedor', 'PIX'),

(3, 'Entrada', 200, '2026-08-03', 
'Venda de produtos', 'Cartao'),

(4, 'Saida', 40, '2026-08-04', 
'Despesa da papelaria', 'Dinheiro');


