using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class createe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categories (Name, Description, Status) values ('Camera', 'Nullam sit amet turpis elementum ligula vehicula consequat.', 0);insert into Categories (Name, Description, Status) values ('Accessory', 'Nullam sit amet turpis elementum ligula vehicula consequat.', 1);insert into Categories (Name, Description, Status) values ('Mopile', 'Fusce consequat.', 0);insert into Categories (Name, Description, Status) values ('Mopile', 'Suspendisse potenti.', 1);insert into Categories (Name, Description, Status) values ('Camera', 'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', 1);insert into Categories (Name, Description, Status) values ('Camera', 'Suspendisse potenti.', 0);insert into Categories (Name, Description, Status) values ('Camera', 'Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.', 1);insert into Categories (Name, Description, Status) values ('Accessory', 'Aenean lectus.', 1);insert into Categories (Name, Description, Status) values ('laptop', 'Nam dui.', 0);insert into Categories (Name, Description, Status) values ('Camera', 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi.', 1);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE From Categories");

        }
    }
}
