CREATE DATABASE schooldb
    WITH 
    OWNER = joel
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Spain.1252'
    LC_CTYPE = 'Spanish_Spain.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE SCHEMA public
    AUTHORIZATION postgres;

COMMENT ON SCHEMA public
    IS 'standard public schema';

GRANT ALL ON SCHEMA public TO PUBLIC;

GRANT ALL ON SCHEMA public TO postgres;


CREATE TABLE IF NOT EXISTS tb_rol(
    rolId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    name varchar(45) NOT NULL,
    description varchar(45)
);

CREATE TABLE IF NOT EXISTS tb_login(
    loginId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    username varchar(45) NOT NULL,
    passsword varchar(100) NOT NULL,
    rolId integer REFERENCES tb_rol(rolId),
    UNIQUE(username)
);

CREATE TABLE IF NOT EXISTS tb_person(
    personId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    nid integer NOT NULL,
    name varchar(45) NOT NULL,
    lastname varchar(45),
    address varchar(45) NOT NULL,
    phone_number varchar(45) NOT NULL,
    loginId integer REFERENCES tb_login(loginId),
    UNIQUE(nid)
);

CREATE TABLE IF NOT EXISTS tb_course_status(
    courseStatusId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    code varchar(45) NOT NULL,
    description varchar(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_course(
    courseId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    code varchar(45) NOT NULL,
    name varchar(45),
    courseStatusId integer REFERENCES tb_course_status(courseStatusId)
);

CREATE TABLE IF NOT EXISTS tb_student(
    studentId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    personId integer REFERENCES tb_person(personId),
    classroom varchar(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_teacher(
    teacherId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    personId integer REFERENCES tb_person(personId),
    subject varchar(45)
);

CREATE TABLE IF NOT EXISTS tb_gradebook(
    gradebookId integer GENERATED ALWAYS as IDENTITY PRIMARY KEY,
    studentId integer REFERENCES tb_student(studentId),
    Q1 decimal(3,2) not NULL,
    Q2 decimal(3,2) not NULL,
    Q3 decimal(3,2) not NULL,
    average decimal(3,2),
    teacherId integer REFERENCES tb_teacher(teacherId),
    courseId integer REFERENCES tb_course(courseId),
    status boolean
);