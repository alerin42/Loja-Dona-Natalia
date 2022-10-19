create database lojinha;
use lojinha;

create database lojaDN;
use lojaDN;

create table roupas ( cod_roupas int AUTO_INCREMENT , modelo varchar(50) , tamanho varchar (5) , cor varchar (30) , qtd int , PRIMARY key (cod_roupas));
select * from roupas;
drop table roupas;
