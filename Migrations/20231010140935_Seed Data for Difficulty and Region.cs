using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalk.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataforDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4fdeccb7-8506-4621-881c-c10427072064"), "Dễ" },
                    { new Guid("b2a19d46-0439-41fd-bbb4-93b01a226ebf"), "Vừa" },
                    { new Guid("f61d66c1-13a1-4d7a-96c9-2d309939af55"), "Khó" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("05011613-2824-4e4b-ae26-f2c204220a6d"), "HA", "Hội An", null },
                    { new Guid("43e22194-6b1e-4622-bf01-8de512e090af"), "QN", "Quảng Ninh", null },
                    { new Guid("9d831acd-7bcb-44f5-a363-2940ab912c2a"), "DN", "Đà Nẵng", null },
                    { new Guid("e5e666ca-cd5e-4fc7-8c72-9907ee3d6323"), "TH", "Thanh Hóa", null },
                    { new Guid("ededd4e3-e398-4a91-95fe-d610151bd1f1"), "HN", "Hà Nội", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4fdeccb7-8506-4621-881c-c10427072064"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b2a19d46-0439-41fd-bbb4-93b01a226ebf"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f61d66c1-13a1-4d7a-96c9-2d309939af55"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("05011613-2824-4e4b-ae26-f2c204220a6d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("43e22194-6b1e-4622-bf01-8de512e090af"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9d831acd-7bcb-44f5-a363-2940ab912c2a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e5e666ca-cd5e-4fc7-8c72-9907ee3d6323"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ededd4e3-e398-4a91-95fe-d610151bd1f1"));
        }
    }
}
