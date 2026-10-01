create database papelaria1;
use papelaria1;


create table funcionario (
    id_fun int auto_increment primary key,
    nome_fun varchar(150) not null,
    cpf_fun varchar(20) not null,
    senha_fun varchar(255) not null,
    telefone_fun varchar(30),
    sexo_fun varchar(100),
    endereco_fun varchar (100),
    email_fun varchar (100)
);

insert into Funcionario values (null, 'Armando Santos', '546.678.876-67', '123456', '(11) 98888-1111', 'Masculino', 'Rua A, 100', 'armando.fun@email.com');
insert into Funcionario values (null, 'Fernanda Godoy', '546.348.876-61', '123456', '(11) 98888-2222', 'Feminino', 'Rua B, 200', 'fernanda.fun@email.com');
insert into Funcionario values (null, 'Carlos Silva', '546.678.456-62', '123456', '(11) 98888-3333', 'Masculino', 'Rua C, 300', 'carlos.fun@email.com');
insert into Funcionario values (null, 'Mariana Souza', '546.678.566-69', '123456', '(11) 98888-4444', 'Feminino', 'Rua D, 400', 'mariana.fun@email.com');
insert into Funcionario values (null, 'Lucas Oliveira', '546.678.876-68', '123456', '(11) 98888-5555', 'Masculino', 'Rua E, 500', 'lucas.fun@email.com');


create table cliente (
    id_cli int auto_increment primary key,
    nome_cli varchar(150) not null,
    telefone_cli varchar(30),
    sexo_cli varchar(100),
    endereco_cli varchar (100),
    cpf_cli varchar(20),
    email_cli varchar (100)
);

insert into cliente values (null, 'Pedro Santos', '(66) 3010-7459', 'Masculino', 'Rua Nova Brasília, 2314', '096.789.098-68', 'pedro@gmail.com');
insert into cliente values (null, 'Beatriz Lima', '(86) 3576-7739', 'Feminino', 'Av. Central, 12', '123.456.789-00', 'beatriz@gmail.com');
insert into cliente values (null, 'João Pereira', '(11) 99876-5432', 'Masculino', 'Rua das Flores, 55', '234.567.890-11', 'joao@gmail.com');
insert into cliente values (null, 'Ana Carolina', '(21) 98765-4321', 'Feminino', 'Rua dos Pinheiros, 88', '345.678.901-22', 'ana@gmail.com');
insert into cliente values (null, 'Pedro Henrique', '(31) 97654-3210', 'Masculino', 'Av. Brasil, 500', '456.789.012-33', 'pedro@gmail.com');



create table fornecedor(
    id_for int auto_increment primary key,
    nome_fantasia_for varchar(150) not null,
    telefone_for varchar(30),
    endereco_for varchar (100),
    cnpj_for varchar(20),
    email_for varchar (100)
);

insert into fornecedor values (null, 'Caderno e Cia', '(76) 7654-8978', 'Rua das Flores, 10', '34.345.675/0001-09', 'cadernoecia@gmail.com');
insert into fornecedor values (null, 'Distribuidora Bic', '(11) 4004-1122', 'Av. Industrial, 500', '12.345.678/0001-99', 'contato@bic.com');
insert into fornecedor values (null, 'Faber-Castell Brasil', '(15) 3219-0000', 'Rua Pratinha, 100', '61.064.938/0001-41', 'vendas@faber.com');
insert into fornecedor values (null, 'Tilibra Produtos', '(14) 3235-4000', 'Rua Luso Brasileira, 4-44', '44.990.901/0001-23', 'comercial@tilibra.com');
insert into fornecedor values (null, 'Chamex Papéis', '(19) 3801-9000', 'Rodovia SP-332, Km 3', '56.789.123/0001-55', 'atendimento@chamex.com');



create table categoria (
    id_cate int auto_increment primary key,
    nome_cate varchar(100)
);

insert into categoria  values (null ,'Canetas');
insert into categoria  values (null, 'Cadernos');
insert into categoria  values (null, 'Lápis');
insert into categoria  values (null, 'Mochilas');
insert into categoria  values (null, 'Acessórios');


create table produto (
     id_pro int auto_increment primary key,
     nome_pro varchar(150) not null,
     preco_pro float not null,
     
     id_cate_fk int not null,
     foreign key(id_cate_fk) references Categoria(id_cate)
);

insert into produto values (null,'Caneta Azul', 3.00, 1);
insert into produto values (null, 'Caderno 10 Matérias', 28.50, 2);
insert into produto values (null, 'Lápis Preto HB', 2.00, 3);
insert into produto values (null, 'Mochila Escolar', 120.00, 4);
insert into produto values (null, 'Borracha Branca', 1.50, 5);

create table estoque(
	 id_est int auto_increment primary key,
     quantidade_inicial_est int not null,
     quantidade_final_est int not null,

     Id_pro_fk int not null, 
     foreign key (id_pro_fk) references Produto(id_pro)
);

insert into estoque values (null,100, 80, 1);
insert into estoque values (null, 50, 42, 2);
insert into estoque values (null, 200, 150, 3);
insert into estoque values (null, 20, 15, 4);
insert into estoque values (null, 150, 110, 5);

Create Table Venda (
Id_vend int auto_increment primary key, 
Data_vend date, 
valor_vend float,
quantidade_vend int,

id_pro_fk int not null,
foreign key(id_pro_fk) references Produto(id_pro),

id_fun_fk int not null,
foreign key(id_fun_fk) references Funcionario(id_fun),

id_cli_fk int not null,
foreign key(id_cli_fk) references Cliente(id_cli)
);

insert into venda values (null, '2026-09-22', 6.00, 2, 1, 1, 1);
insert into venda values (null, '2026-09-22', 28.50, 1, 2, 2, 2);
insert into venda values (null, '2026-09-21', 10.00, 5, 3, 3, 3);
insert into venda values (null, '2026-09-20', 120.00, 1, 4, 4, 4);
insert into venda values (null, '2026-09-19', 4.50, 3, 5, 5, 5);


Create Table Financeiro(
id_fin int auto_increment primary key,
tipo_fin varchar(100),
valor_fin float,
data_fin date,

id_fun_fk int not null,
foreign key (id_fun_fk) references Funcionario(id_fun),

id_vend_fk int not null,
foreign key (id_vend_fk) references Venda(id_vend)
);

insert into Financeiro values (null, 'Pix', 6.00, '2026-09-22', 1, 1);
insert into Financeiro values (null, 'Cartão de Crédito', 28.50, '2026-09-22', 2, 2);
insert into Financeiro values (null, 'Dinheiro', 10.00, '2026-09-21', 3, 3);
insert into Financeiro values (null, 'Cartão de Débito', 120.00, '2026-09-20', 4, 4);
insert into Financeiro values (null, 'Pix', 4.50, '2026-09-19', 5, 5);


Create Table Caixa(
id_cai int auto_increment primary key,
data_abertura_cai date,
data_fechamento_cai date,
valor_inicial_cai float,
valor_final_cai float,

id_fun_fk int not null,
foreign key (id_fun_fk) references Funcionario(id_fun)
);

insert into Caixa values (null, '2026-09-18', '2026-09-18', 100.00, 200.00, 1);
insert into Caixa values (null, '2026-09-19', '2026-09-19', 150.00, 320.00, 2);
insert into Caixa values (null, '2026-09-20', '2026-09-20', 100.00, 450.00, 3);
insert into Caixa values (null, '2026-09-21', '2026-09-21', 200.00, 510.00, 4);
insert into Caixa values (null, '2026-09-22', '2026-09-22', 150.00, 600.00, 5);
