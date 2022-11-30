-- Database: teste

-- DROP DATABASE IF EXISTS teste;


CREATE TABLE tblRole(
 Id bigserial CONSTRAINT pk_id_role PRIMARY KEY,
 Name varchar(150) NOT NULL, 
 AcessType varchar(10) NOT NULL
);

CREATE TABLE tblUser(
 Id bigserial CONSTRAINT pk_id_User PRIMARY KEY,
 UserName varchar(150) NOT NULL, 
 Password varchar(10) NOT NULL,
 RoleId integer,
 FOREIGN KEY (RoleId) REFERENCES tblRole (Id)
);