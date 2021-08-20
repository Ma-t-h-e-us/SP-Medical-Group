--DML
use SpMedicalGroup
go

--situacao
insert into situacao(descricao)
values ('Realizada'),('Cancelada'),('Agendada');
go

--areaMedico
insert into areaMedico(descricao)
values ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia de Mão'),
('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),
('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
go

--tipoDeUsuario
insert into tipoDeUsuario(descricao)
values ('Administrador'),('Médico'),('Paciente')
go

--clinica
insert into clinica(endereco, horarioInicioFuncionamento, horarioFimFuncionamento, CNPJ, nomeFantasia, razaoSocial)
values ('Av. Barão Limeira, 532', '2021-08-01 05:00', '2021-08-01 23:30', '86.400.902/0001-30', 'Clinica Possarle', 'SP Médical Group')
go

--usuario
insert into usuario(idTipoDeUsuario, email, senha)
values (2, 'ricardo.lemos@spmedicalgroup.com.br', '123456'),
	   (2, 'roberto.possarle@spmedicalgroup.com.br', '123456'),
	   (2, 'helena.souza@spmedicalgroup.com.br', '123456'),
	   (3, 'ligia@gmail.com', '123456'),
	   (3, 'alexandre@gmail.com', '123456'),
	   (3, 'fernando@gmail.com', '123456'),
	   (3, 'henrique@gmail.com', '123456'),
	   (3, 'joao@gmail.com', '123456'),
	   (3, 'bruno@gmail.com', '123456'),
	   (3, 'mariana@outlook.com', '123456')
go

--medico
insert into medico(idUsuario, idAreaMedico, idClinica, nome, CRM)
values (1, 2, 1, 'Ricardo Lemos', '54356-SP'),
	   (2, 17, 1, 'Roberto Possarle', '53452-SP'),
	   (3, 16, 1, 'Helena Strada', '65463-SP')
go

--paciente
insert into paciente(idUsuario, nomePaciente, RG, CPF, endereco, dataNascimento, telefone)
values (4, 'Ligia', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000', '03/10/1983', '113456-7654'),
	   (5, 'Alexandre', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200', '03/07/2001', '1198765-6543'),
	   (6, 'Fernando', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200', '10/10/1978', '1197208-4453'),
	   (7, 'Henrique', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '13/10/1985', '113456-6543'),
	   (8, 'João', '532544444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380', '27/08/1975', '117656-6377'),
	   (9, 'Bruno', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001', '21/03/1972', '1195436-8769'),
	   (10, 'Mariana', '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '05/03/2018','')
go

--consulta
insert into consulta(idMedico, idPaciente, idSituacao, dataConsulta, descricao)
values (3,12,1,'1/2/2021 15:00',''),
	   (2,7,2,'1/6/2021 10:00',''),
	   (2,8,1,'2/7/2021 11:00',''),
	   (2,7,1,'2/6/2018 10:00',''),
	   (1,9,2,'2/7/2019 11:00',''),
	   (3,12,3,'3/8/2021 15:00',''),
	   (1,9,3,'3/9/2021 11:00','')
go