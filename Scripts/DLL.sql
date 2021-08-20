--DDL
create database SpMedicalGroup
go

use SpMedicalGroup
go

--situacao
create table situacao (
	idSituacao tinyint primary key identity(1,1),
	descricao varchar(30) unique not null
);
go

--areaMedico
create table areaMedico (
	idAreaMedico smallint primary key identity(1,1),
	descricao varchar(50) unique not null
);
go

--tipoDeUsuario
create table tipoDeUsuario (
	idTipoDeUsuario tinyint primary key identity(1,1),
	descricao varchar(50) unique not null
);
go

--clinica
create table clinica (
	idClinica smallint primary key identity(1,1),
	endereco varchar(50) unique not null,
	horarioInicioFuncionamento datetime not null, 
	horarioFimFuncionamento datetime not null,
	CNPJ varchar(18) unique not null,
	nomeFantasia varchar(150) not null,
	razaoSocial varchar(100) not null
);
go

--usuario
create table usuario(
	idUsuario int primary key identity(1,1),
	idTipoDeUsuario tinyint foreign key references tipoDeUsuario(idTipoDeUsuario),
	email varchar(256) unique not null,
	senha varchar(50) not null CHECK(len(senha) >= 6),
);
go

--medico
create table medico(
	idMedico int primary key identity(1,1),
	idUsuario int foreign key references usuario(idUsuario),
	idAreaMedico smallint foreign key references areaMedico(idAreaMedico),
	idClinica smallint foreign key references clinica(idClinica),
	nome varchar(100) not null,
	CRM varchar(10) unique not null 
);
go

--paciente
create table paciente (
	idPaciente int primary key identity(1,1),
	idUsuario int foreign key references usuario(idUsuario),
	nomePaciente varchar(150) not null,
	RG varchar(15) not null, 
	CPF varchar(14) unique not null, 
	endereco varchar(200) not null,
	dataNascimento date not null,
	telefone varchar(12)
);
go

--consulta
create table consulta (
	idConsulta bigint primary key identity(1,1),
	idMedico int foreign key references medico(idMedico),
	idPaciente int foreign key references paciente(idPaciente),
	idSituacao tinyint foreign key references situacao(idSituacao),
	dataConsulta datetime not null,
	descricao varchar(100) default('Sem motivo definido')
);
go
