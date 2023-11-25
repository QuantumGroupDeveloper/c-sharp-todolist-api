# c-sharp-todolist-api
C#のAPI課題（ToDoList）

# 環境
- Visual Studio 2022
- .NET 8
- ASP.NET Web API
- Entity Framework
- SQL Server

# 実行方法
>前提\
SQL Serverをインストール済み

- DDLフォルダ内のsqlファイルをSQL Serverで実行する\
下記DBが作成される
  - データベース
    - classwork
  - テーブル
    - to_do_list

- appsettings.jsonの接続文字列を自分の環境に合わせるよう修正する

- Visual Studioから実行
  - Swagger UIが開かれる
  - UI上から各APIにリクエストを投げることができる
