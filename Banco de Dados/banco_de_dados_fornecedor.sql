create database app_papelaria1_fornecedor;
use  app_papelaria1_fornecedor;
drop table fornecedores;

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
