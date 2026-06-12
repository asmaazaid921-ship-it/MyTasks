using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class todo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Brands (Name, Description, Status) values ('Samsung', 'Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.', 0);insert into Brands (Name, Description, Status) values ('Samsung', 'Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.', 0);insert into Brands (Name, Description, Status) values ('lg', 'Morbi ut odio.', 0);insert into Brands (Name, Description, Status) values ('lg', 'Etiam faucibus cursus urna.', 1);\r\ninsert into Brands (Name, Description, Status) values ('Apple', 'Nam nulla.', 1);\r\ninsert into Brands (Name, Description, Status) values ('lg', 'Etiam vel augue.', 1);insert into Brands (Name, Description, Status) values ('Apple', 'Fusce posuere felis sed lacus.', 0);insert into Brands (Name, Description, Status) values ('honor', 'Sed accumsan felis.', 1);insert into Brands (Name, Description, Status) values ('Apple', 'Integer ac leo.', 0);insert into Brands (Name, Description, Status) values ('honor', 'Proin at turpis a pede posuere nonummy.', 0);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE From Brands");
        }
    }
}
