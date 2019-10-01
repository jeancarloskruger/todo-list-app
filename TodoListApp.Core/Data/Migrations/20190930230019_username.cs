using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Core.Data.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoitem_todo_TodoId",
                table: "todoitem");

            migrationBuilder.AlterColumn<Guid>(
                name: "TodoId",
                table: "todoitem",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "todo",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_todoitem_todo_TodoId",
                table: "todoitem",
                column: "TodoId",
                principalTable: "todo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoitem_todo_TodoId",
                table: "todoitem");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "todo");

            migrationBuilder.AlterColumn<Guid>(
                name: "TodoId",
                table: "todoitem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_todoitem_todo_TodoId",
                table: "todoitem",
                column: "TodoId",
                principalTable: "todo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
