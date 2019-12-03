using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionApp.Persistence.Migrations
{
    public partial class MadeAddresTypeIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRelationAddress_tblAddressType_AddressTypeId",
                table: "tblRelationAddress");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressTypeId",
                table: "tblRelationAddress",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_tblRelationAddress_tblAddressType_AddressTypeId",
                table: "tblRelationAddress",
                column: "AddressTypeId",
                principalTable: "tblAddressType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRelationAddress_tblAddressType_AddressTypeId",
                table: "tblRelationAddress");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressTypeId",
                table: "tblRelationAddress",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRelationAddress_tblAddressType_AddressTypeId",
                table: "tblRelationAddress",
                column: "AddressTypeId",
                principalTable: "tblAddressType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
