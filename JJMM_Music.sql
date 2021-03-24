create database BandasDB;

use BandasDB;
create table Genero (
id_genero int IDENTITY (1, 1) not null PRIMARY KEY,
nome_genero varchar(20),
descricao text,
)

create table Banda (
id_banda int IDENTITY(1,1) not null primary key,
nomeBanda varchar(30),
id_genero int foreign key references Genero(id_genero)
)

create table Artista (
id_artista int IDENTITY(1,1) not null primary key,
nome varchar(40),
instrumento varchar(10),
idade smallint,
pais varchar(20),
descricao text,
id_banda int foreign key references Banda(id_banda)
)

create table Album (
id_album int IDENTITY(1,1) not null primary key,
titulo varchar(30),
ano char(4),
id_banda int foreign key references Banda(id_banda)
)

create table Musica (
id_musica int IDENTITY(1,1) not null primary key,
titulo varchar(30),
ano char(4),
duracao smallint,
link text,
id_album int foreign key references Album(id_album)
)

create table Show (
id_show int IDENTITY(1,1) not null primary key,
data datetime,
local varchar(100),
id_banda int foreign key references Banda(id_banda)
)

create table Ingresso (
id_ingresso int IDENTITY(1,1) not null primary key,
setor varchar(20),
valor real,
descricao text default null,
id_show int foreign key references Show(id_Show)
)
