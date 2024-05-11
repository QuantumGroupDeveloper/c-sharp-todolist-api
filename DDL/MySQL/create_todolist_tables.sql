CREATE DATABASE todolist;

--DROP TABLE dbo."to_do_list";

CREATE TABLE todolist.to_do_list(
	id int PRIMARY KEY auto_increment NOT NULL,
	title text NOT NULL,
	detail text NULL,
	place varchar(50) NULL,
	deadline datetime(6) NULL,
	remarks text NULL,
	created_at datetime(6) NOT NULL,
	updated_at datetime(6) NULL,
	deleted_at datetime(6) NULL
);

INSERT INTO todolist.to_do_list
  (title, detail, place, deadline ,remarks, created_at)
VALUES
   ('title_01', 'detail_01', 'place_01', '2023/01/31 10:00:00', 'remarks_01', NOW())
  ,('title_02', 'detail_02', 'place_01', '2022/01/31 10:00:00', 'remarks_02', NOW())
  ,('title_03', 'detail_03', 'place_02', '2023/01/31 10:00:00', 'remarks_01', NOW())
  ,('title_04', 'detail_04', 'place_03', '2024/01/31 10:00:00', 'remarks_02', NOW())
  ,('title_05', 'detail_05', 'place_04', '2025/01/31 10:00:00', 'remarks_01', NOW())
;

