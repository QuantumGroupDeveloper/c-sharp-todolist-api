CREATE DATABASE classwork;

--DROP TABLE dbo."users";

CREATE TABLE dbo."users"(
	id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	user_id varchar(50) UNIQUE NOT NULL,
	last_name varchar(50) NOT NULL,
	first_name varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	password text NOT NULL,
	status tinyint NOT NULL DEFAULT 0,
	is_deleted bit NOT NULL DEFAULT 0,
	created_at datetime2(7) NOT NULL,
	updated_at datetime2(7) NULL,
	deleted_at datetime2(7) NULL
);

--DROP TABLE dbo."to_do_list";

CREATE TABLE dbo."to_do_list"(
	id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	user_id varchar(50),
	title text NOT NULL,
	detail text NULL,
	place varchar(50) NULL,
	deadline datetime2(7) NULL,
	remarks text NULL,
	status tinyint NOT NULL DEFAULT 0,
	is_deleted bit NOT NULL DEFAULT 0,
	created_at datetime2(7) NOT NULL,
	updated_at datetime2(7) NULL,
	deleted_at datetime2(7) NULL,
	FOREIGN KEY(user_id) REFERENCES users(user_id)
);


INSERT INTO dbo.users
  (user_id, last_name, first_name, email, password, created_at)
VALUES
   ('user_01', 'user', '01', 'user_01@example.com', 'test', SYSDATETIME())
  ,('user_02', 'user', '02', 'user_02@example.com', 'test', SYSDATETIME())
  ,('user_03', 'user', '03', 'user_03@example.com', 'test', SYSDATETIME())
;


INSERT INTO dbo.to_do_list
  (title, detail, place, deadline ,remarks, user_id, created_at)
VALUES
   ('title_01', 'detail_01', 'place_01', '2023/01/31 10:00:00', 'remarks_01', 'user_01', SYSDATETIME())
  ,('title_02', 'detail_02', 'place_02', '2022/01/31 10:00:00', 'remarks_02', 'user_01', SYSDATETIME())
  ,('title_01', 'detail_01', 'place_01', '2023/01/31 10:00:00', 'remarks_01', 'user_02', SYSDATETIME())
  ,('title_02', 'detail_02', 'place_02', '2022/01/31 10:00:00', 'remarks_02', 'user_02', SYSDATETIME())
  ,('title_01', 'detail_01', 'place_01', '2023/01/31 10:00:00', 'remarks_01', 'user_03', SYSDATETIME())
;

