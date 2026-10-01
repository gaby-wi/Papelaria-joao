create database Prime_Papelaria;
use Prime_Papelaria;
#Brayon, Eduarda Gabriely, Renata, Yasmim Lima, Yasmin Reis, Yhasmim Maia

create table usuarios( id int auto_increment primary key,
    nome varchar(150) not null,
    email varchar(150) not null,
    senha varchar(255) not null
);
insert into usuarios (nome, email, senha) values ('Armando Santos', 'sarmando@email.com', '123456'),
('Fernanda Godoy', 'fernanda@email.com', '123456'),
('Carlos Silva', 'carlos@email.com', '123456'), 
('Mariana Souza', 'mariana@email.com', '123456'),
('Lucas Oliveira', 'lucas@email.com', '123456');


CREATE TABLE categoria (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100)
);

INSERT INTO categoria (nome)
VALUES 
('Canetas'),
('Cadernos'),
('Lápis'),
('Mochilas'),
('Acessórios');



CREATE TABLE clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    telefone VARCHAR(30)
);

INSERT INTO clientes (nome, telefone)
VALUES 
('Armando Santos', '(66) 3010-7459'),
('Caderno Tilbra 12 matérias', '(86) 3576-7739'),
('João Pereira', '(11) 99876-5432'),
('Ana Carolina', '(21) 98765-4321'),
('Pedro Henrique', '(31) 97654-3210');



CREATE TABLE produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    categoria_id INT NOT NULL,
    estoque_inicial INT NOT NULL,
    estoque_minimo INT NOT NULL,

foreign key (categoria_id) 
references categoria(id)
);

INSERT INTO produtos 
(nome, categoria_id, estoque_inicial, estoque_minimo)
VALUES 
('Caneta azul', 1, 50, 30),
('Caderno Tilbra 12 matérias', 2, 60, 20),
('Lápis preto', 3, 100, 30),
('Mochila escolar', 4, 25, 10),
('Estojo escolar', 5, 40, 15);



CREATE TABLE vendas (
id INT AUTO_INCREMENT PRIMARY KEY,
cliente_vend INT NOT NULL,
vendedor_vend INT NOT NULL,
data_vend DATE NOT NULL,

FOREIGN KEY (cliente_vend) 
REFERENCES clientes(id),

FOREIGN KEY (vendedor_vend) 
REFERENCES usuarios(id)
);

INSERT INTO vendas 
(cliente_vend, vendedor_vend, data_vend)
VALUES 
(1, 1, '2026-01-05'),
(2, 2, '2026-01-06'),
(3, 3, '2026-01-07'),
(4, 4, '2026-01-08'),
(5, 5, '2026-01-09');



CREATE TABLE itens_venda (
id_itens INT AUTO_INCREMENT PRIMARY KEY,
venda_id INT NOT NULL,
produto_id INT NOT NULL,
quantidade_itens INT NOT NULL,
valor_unitario_itens DECIMAL(10,2) NOT NULL,

FOREIGN KEY (venda_id) 
REFERENCES vendas(id),

FOREIGN KEY (produto_id) 
REFERENCES produtos(id)
);

insert into itens_venda VALUES (null,1, 1, 3, 0.50);
insert into itens_venda VALUES (null,2, 2, 2, 10.00);
insert into itens_venda VALUES (null,3, 3, 5, 1.50);
insert into itens_venda VALUES (null,4, 4, 1, 80.00);
insert into itens_venda VALUES (null,5, 5, 2, 25.00);



CREATE TABLE movimentacoes_estoque (
id_movEst INT AUTO_INCREMENT PRIMARY KEY,
produto_id INT NOT NULL,
tipo_movEst VARCHAR(20) NOT NULL,
quantidade_movEst INT NOT NULL,
data_movimentacao_movEst DATE,
observacao_movEst VARCHAR(255),

FOREIGN KEY (produto_id) 
REFERENCES produtos(id)
);

INSERT INTO movimentacoes_estoque VALUES (null,1, 'ENTRADA', 20, '2026-01-02', 'Compra de canetas');
INSERT INTO movimentacoes_estoque VALUES (null,2, 'ENTRADA', 30, '2026-01-02', 'Compra de cadernos');
INSERT INTO movimentacoes_estoque VALUES (null,3, 'ENTRADA', 50, '2026-01-03', 'Compra de lápis');
INSERT INTO movimentacoes_estoque VALUES (null,4, 'ENTRADA', 10, '2026-01-04', 'Compra de mochilas');
INSERT INTO movimentacoes_estoque VALUES (null,5, 'ENTRADA', 20, '2026-01-04', 'Compra de estojos');



CREATE TABLE fornecedor (
id_for INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
nome_for VARCHAR(200),
cnpj_for VARCHAR(200),
telefone_for VARCHAR(200),
categoria_for VARCHAR(200),
observacoes_for VARCHAR(200)
);

INSERT INTO fornecedor 
(nome_for, cnpj_for, telefone_for, categoria_for, observacoes_for)
VALUES
('BR IMPORTS', '12.345.678/0001-01', '(69) 99999-1111', 
'Material Escolar', 'Fornecedor de cadernos'),

('DUDA STORE', '23.456.789/0001-02', '(69) 99999-2222', 
'Papelaria', 'Fornecedor de canetas e materiais'),

('PARAMANGUE', '34.567.890/0001-03', '(69) 99999-3333', 
'Material Escolar', 'Fornecedor de cadernos'),

('DONSHOP', '45.678.901/0001-04', '(69) 99999-4444', 
'Kits Escolares', 'Fornecedor de kits escolares'),

('ABC PAPERS', '56.789.012/0001-05', '(69) 99999-5555', 
'Papelaria', 'Fornecedor de estojos'),

('METEORS', '67.890.123/0001-06', '(69) 99999-6666', 
'Material Escolar', 'Fornecedor de cadernos'),

('FLOY SHOP', '78.901.234/0001-07', '(69) 99999-7777', 
'Papelaria', 'Fornecedor de canetas'),

('DANI BUY', '89.012.345/0001-08', '(69) 99999-8888', 
'Acessórios', 'Fornecedor de estojos');



CREATE TABLE produto (
    id_pro INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome_pro VARCHAR(200),
    quantidade_pro INT,
    id_for INT NOT NULL,

FOREIGN KEY (id_for) REFERENCES fornecedor(id_for)
);

INSERT INTO produto 
(nome_pro, quantidade_pro, id_for)
VALUES 
('Caderno Kwaii 200 Pg 10 Matérias', 32, 1),
('Kit Escolar Canetas Estilo Desenho', 12, 2),
('Caderno Kawaii 200 Pg 10 Matérias', 12, 3),
('Kit Escolar Completo com Acessórios', 54, 4),
('Estojo Moranguinho Madurinho', 23, 5),
('Caderno Dark Side 100 Pg 1 Matéria', 59, 6),
('Caneta Luxo Unicórnio Esferográfica', 64, 7),
('Estojo Minimalista Preto e Branco', 21, 8);



CREATE TABLE financeiro (
    id_fin INT PRIMARY KEY AUTO_INCREMENT,
    movimetacao_fin VARCHAR(30),
    descricao_fin VARCHAR(50),
    valor_fin FLOAT,
    pagamento_fin VARCHAR(100),
    data_fin DATE
);

ALTER TABLE financeiro 
ADD COLUMN observacao VARCHAR(500);

insert into financeiro values (null , 'Entrada', 'Venda de materiais escolares', 150.00, 'Dinheiro', '2026-08-01', 'Venda realizada no balcão');
insert into financeiro values (null, 'Entrada', 'Venda de cadernos e canetas', 280.50, 'Pix', '2026-08-02', 'Venda para cliente');
insert into financeiro values (null, 'Saída', 'Compra de mercadorias', 500.00, 'Pix', '2026-08-03', 'Reposição de estoque');
insert into financeiro values (null, 'Entrada', 'Venda de produtos de papelaria', 95.00, 'Cartão de Débito', '2026-08-04', 'Venda realizada na loja');
insert into financeiro values (null, 'Saída', 'Pagamento de fornecedor', 350.00, 'Boleto', '2026-08-05', 'Compra de materiais');
insert into financeiro values (null, 'Entrada', 'Venda de material escolar', 220.00, 'Cartão de Crédito', '2026-08-06', 'Venda parcelada');



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



CREATE TABLE RegistroVendas (
    id_regVen INT PRIMARY KEY AUTO_INCREMENT,
    cod_ven_regVen VARCHAR(30),
    nome_cli_regVen VARCHAR(100),
    produto_regVen VARCHAR(100),
    quant_regVen VARCHAR(30),
    valorUni_regVen FLOAT,
    forma_pagamento_regVen VARCHAR(100),
    observacoes_regVen VARCHAR(100)
);

INSERT INTO RegistroVendas
(cod_ven_regVen, nome_cli_regVen, produto_regVen, 
quant_regVen, valorUni_regVen, forma_pagamento_regVen, observacoes_regVen)
VALUES
('VEN001', 'João Silva', 'Caderno 10 matérias', 
'2', 25.90, 'Pix', 'Pagamento realizado no momento da compra'),

('VEN002', 'Maria Santos', 'Caneta azul', 
'5', 2.50, 'Dinheiro', 'Cliente solicitou embalagem para presente'),

('VEN003', 'Pedro Oliveira', 'Mochila escolar', 
'1', 89.90, 'Cartão de Crédito', 'Venda parcelada em 3 vezes'),

('VEN004', 'Ana Souza', 'Lápis de cor 12 cores', 
'3', 18.50, 'Cartão de Débito', 'Sem observações'),

('VEN005', 'Carlos Pereira', 'Estojo escolar', 
'2', 22.90, 'Pix', 'Cliente comprou junto com o caderno'),

('VEN006', 'Juliana Costa', 'Borracha branca', 
'10', 1.50, 'Dinheiro', 'Compra em quantidade');



CREATE TABLE CadastroProduto (
    id_cadPro INT PRIMARY KEY AUTO_INCREMENT,
    codigo_cadPro VARCHAR(100),
    nome_cadPro VARCHAR(100) NOT NULL,
    categoria_cadPro VARCHAR(100) NOT NULL,
    preco_cadPro FLOAT NOT NULL,
    quantidade_cadPro INT NOT NULL
);

INSERT INTO CadastroProduto
(codigo_cadPro, nome_cadPro, categoria_cadPro, preco_cadPro, quantidade_cadPro)
VALUES
('COD001', 'Caderno 10 matérias', 'Cadernos', 35.90, 20),
('COD002', 'Caneta azul', 'Canetas', 2.50, 100),
('COD003', 'Lápis HB', 'Lápis', 1.50, 80),
('COD004', 'Borracha branca', 'Borrachas', 1.00, 50),
('COD005', 'Papel A4', 'Papéis', 32.00, 15);



CREATE TABLE ControleEstoque (
    id_cadEst INT PRIMARY KEY AUTO_INCREMENT,
    codigo_venda_CadEst VARCHAR(100),
    tipo_movimentacao_cadEst VARCHAR(50) NOT NULL,
    quantidade_cadEst INT NOT NULL,
    estoque_minimo_cadEst INT NOT NULL,
    descricao_fornecedor_cadEst VARCHAR(255)
);