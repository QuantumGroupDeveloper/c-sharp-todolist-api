# c-sharp-todolist-api
C#のAPI課題（ToDoList）

# 環境
- Visual Studio 2022
- .NET 8
- ASP.NET Web API
- Entity Framework
- ~~SQL Server~~
- MySQL

# 実行方法
>前提\
~~SQL Serverをインストール済み~~ <br>
~~認証方法はSA認証~~
<br>
>MySQLをインストール済み

>MySQL版

- DDLフォルダ内のsqlファイルをMySQLで実行する\
下記DBが作成される
  - データベース
    - todolist
  - テーブル
    - to_do_list

- appsettings.jsonの接続文字列(mysql)を自分の環境に合わせるよう修正する

- Visual Studioから実行
  - Swagger UIが開かれる
  - UI上から各APIにリクエストを投げることができる

>VS Codeから実行する場合
- 拡張機能インストール
  - `C# Dev Kit`
- `実行とデバッグ` から `C#: ToDoListAPI[http]` を選択して実行

---


~~>SQL Server版~~

~~- DDLフォルダ内のsqlファイルをSQL Serverで実行する\
下記DBが作成される~~
  ~~- データベース~~
   ~~- todolist~~
  ~~- テーブル~~
    ~~- to_do_list~~

~~- appsettings.jsonの接続文字列を自分の環境に合わせるよう修正する~~

~~- Visual Studioから実行~~
  ~~- Swagger UIが開かれる~~
  ~~- UI上から各APIにリクエストを投げることができる~~


