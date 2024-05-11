CREATE DATABASE todolist;

--DROP TABLE dbo."to_do_list";

CREATE TABLE dbo."to_do_list"(
	id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	title text NOT NULL,
	detail text NULL,
	place varchar(50) NULL,
	deadline datetime2(7) NULL,
	remarks text NULL,
	created_at datetime2(7) NOT NULL,
	updated_at datetime2(7) NULL,
	deleted_at datetime2(7) NULL
);

INSERT INTO dbo.to_do_list
  (title, detail, place, deadline ,remarks, created_at)
VALUES
   ('title_01', 'detail_01', 'place_01', '2023/01/31 10:00:00', 'remarks_01', SYSDATETIME())
  ,('title_02', 'detail_02', 'place_01', '2022/01/31 10:00:00', 'remarks_02', SYSDATETIME())
  ,('title_03', 'detail_03', 'place_02', '2023/01/31 10:00:00', 'remarks_01', SYSDATETIME())
  ,('title_04', 'detail_04', 'place_03', '2024/01/31 10:00:00', 'remarks_02', SYSDATETIME())
  ,('title_05', 'detail_05', 'place_04', '2025/01/31 10:00:00', 'remarks_01', SYSDATETIME())
;

