create database SantaGula;

use SantaGula;

create table Endereco(
codigoEndereco int not null auto_increment primary key,
numero int not null,
cidade varchar(45) not null,
estado varchar(45) not null,
pais varchar(45) not null,
cep varchar(45) not null
)engine = InnoDB;

create table Comida(
codigoComida int not null auto_increment primary key,
nome varchar(100) not null,
tipo varchar(50) not null,
dt_validacao date not null,
quantidade int not null
)engine = InnoDB;

create table Cardapio(
codigoCardapio int not null auto_increment primary key,
nome varchar(50) not null,
preco decimal(4,2) not null,
descricao varchar(100) not null,
tipo varchar(50) not null
)engine = InnoDB;

alter table Cardapio modify preco decimal not null; 
alter table Cardapio add FuncionarioCodigo int not null;
select * from Funcionario;

create table Funcionario (
codigoFuncionario int not null auto_increment primary key,
nome varchar(100) not null,
cpf bigint not null,
email varchar(120) not null,
senha varchar(50) not null,
cargo varchar(20) not null,
telefone varchar(16) null,
turno varchar(20) not null,
salario decimal(10,2) not null,
EnderecoCodigo int not null
) engine = InnoDB;

ALTER TABLE Funcionario MODIFY salario DECIMAL(10,2);

alter table Funcionario modify salario decimal(6,2) not null;

create table Estoque (
codigoEstoque int not null auto_increment primary key,
quantidade_total int not null,
SalaCodigo int not null,
ComidaCodigo int not null
)engine = InnoDB;

select * from Funcionario where email = 'allan@gmail.com';
select * from Funcionario;

create table Sala(
codigoSala int not null auto_increment primary key,
equipamento varchar(200) not null,
FuncionarioCodigo int not null
)engine = InnoDB;
alter table Sala add nome varchar(100) not null;

-- RELACIONANDO TABELAS
alter table Funcionario add constraint FuncionarioEndereco foreign key(EnderecoCodigo) references Endereco(codigoEndereco);
alter table Estoque add constraint EstoqueSala foreign key(SalaCodigo) references Sala(codigoSala);
alter table Estoque add constraint EstoqueComida foreign key(ComidaCodigo) references Comida(codigoComida);
alter table Sala add constraint SalaFuncionario foreign key(FuncionarioCodigo) references Funcionario(codigoFuncionario); 

-- ADICIONANDO ADMINISTRADOR
insert into Endereco(codigoEndereco,numero,cidade,estado,pais,cep) values ('','98','São Bernardo','São Paulo','Brasil','2313213123123');
insert into Funcionario(codigoFuncionario,nome,cpf,email,senha,cargo,telefone,turno,salario,EnderecoCodigo) values ('', 'Allan Sobral', '4123123123123','allan@gmail.com','1234','admin','1199445124','tarde','19900','1')