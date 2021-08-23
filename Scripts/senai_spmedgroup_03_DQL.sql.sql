--DQL
use SpMedicalGroup
go

select * from clinica
go
select * from areaMedico
go
select * from consulta
go
select * from medico
go
select * from paciente
go
select * from situacao
go
select * from tipoDeUsuario
go
select * from usuario
go

--Consultas
select nomePaciente Paciente, m.nome M�dico, convert(varchar, dataConsulta, 103) [Data da consulta], s.descricao [Situa��o]
from Paciente inner join Consulta c on Paciente.idPaciente = c.idPaciente
inner join Medico m on m.idMedico = c.idMedico
inner join Situacao s on s.idSituacao = c.idSituacao;
go

--Quantidade de usu�rios
select count(idUsuario) [Quantidade de Usuarios] from usuario
go

--data de nascimento do usu�rio para o formato (dd-mm-yyyy) e (mm-dd-yyyy)
select convert(varchar, dataNascimento, 103) as dd_mm_yyyy, convert(varchar, dataNascimento, 101) as mm_dd_yyyy from paciente
go

--idade paciente
select nomePaciente, datediff(YEAR,dataNascimento, GETDATE()) [Idade dos pacientes] from paciente
go

--fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
create function MediQ (@nomeArea Varchar(50))
returns table as return (
	select @nomeArea as MQ, count(areaMedico.descricao) [Numero de m�dicos] from areaMedico 
	where areaMedico.descricao like '%' + @nomeArea + '%'
);
go

select * from MediQ('Anestesiologia')
go

--fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure
create procedure IdadePaciente @paciente varchar(30)
as begin 
	select paciente.nomePaciente, DATEDIFF(year, paciente.dataNascimento, GETDATE()) Idade from paciente
	where paciente.nomePaciente = @paciente
end;

exec IdadePaciente 'Alexandre';
go

