using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApps.Migrations
{
    public partial class Seedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make1')");
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make2')");
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make3')");

            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make1-ModelA', (Select Id from Makes where name = 'Make1'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make1-ModelB', (Select Id from Makes where name = 'Make1'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make1-ModelC', (Select Id from Makes where name = 'Make1'))");

            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make2-ModelA', (Select Id from Makes where name = 'Make2'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make2-ModelB', (Select Id from Makes where name = 'Make2'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make2-ModelC', (Select Id from Makes where name = 'Make2'))");

            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make3-ModelA', (Select Id from Makes where name = 'Make3'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make3-ModelB', (Select Id from Makes where name = 'Make3'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeID) Values ('Make3-ModelC', (Select Id from Makes where name = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Makes where name in ('Make1', 'Make2', 'Make3')"); 
        }
    }
}
