
CREATE TABLE tbl_Setor(
 Id serial CONSTRAINT pk_id_setor PRIMARY KEY,
 nome varchar(150) NOT NULL
);

CREATE TABLE tbl_Sala(
 Id serial CONSTRAINT pk_id_sala PRIMARY KEY,
 nome varchar(100) NOT NULL
);

CREATE TABLE tbl_Usuario(
 Id serial CONSTRAINT pk_id_Usuario PRIMARY KEY,
 nome varchar(150) NOT NULL, 
 email varchar(150) NOT NULL, 
 senha varchar(10) NOT NULL,
 tipo_Usuario varchar(15) NOT NULL, 
 idSetor int NOT NULL,
 FOREIGN KEY (idSetor) REFERENCES tbl_Setor (Id)
);

CREATE TABLE tbl_Agendamento(
 Id serial CONSTRAINT pk_id_Agendamento PRIMARY KEY,
 data_Agendamento date NOT NULL, 
 hora_Inicial time NOT NULL, 
 hora_Final time NOT NULL,
 duracao time NOT NULL, 
 idSala int,
 idUsuario int,
 FOREIGN KEY (idSala) REFERENCES tbl_Sala (Id),
 FOREIGN KEY (idUsuario) REFERENCES tbl_Usuario (Id)
);