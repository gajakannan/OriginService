--Creating User

CREATE ROLE originator WITH
  LOGIN
  NOSUPERUSER
  INHERIT
  CREATEDB
  CREATEROLE
  NOREPLICATION;

--Creating Tablespace 

CREATE TABLESPACE originspace
  OWNER originator
  LOCATION 'C:\Program Files\PostgreSQL\13\data\origin';

ALTER TABLESPACE originspace
  OWNER TO originator;

--Creating Database 

CREATE DATABASE "Origindb"
    WITH 
    OWNER = originator
    ENCODING = 'UTF8'
    TABLESPACE = originspace
    CONNECTION LIMIT = -1;

ALTER DEFAULT PRIVILEGES
GRANT ALL ON TABLES TO originator;

--Creating Table 

CREATE TABLE public."Inputs"
(
 InputId INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
 Moniker Varchar(100) Not Null,
 Description Varchar(3000),
 Category Varchar(20),
 Active Varchar(50) Not Null
)

TABLESPACE originspace;

ALTER TABLE public."Inputs"
    OWNER to originator;