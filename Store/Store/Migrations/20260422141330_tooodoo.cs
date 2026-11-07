using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class tooodoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone12', 'Nulla tellus.', '1.png', 13191.29, 26, 1, 1, 45.27, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone12 pro', 'Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci.', '2.png', 50278.86, 40, 0, 1, 70.02, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone13', 'Nam tristique tortor eu pede.', '3.png', 58111.55, 30, 3, 0, 46.75, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone13 pro', 'Nulla facilisi.', '4.png', 14747.27, 19, 1, 0, 56.96, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone14', 'Duis aliquam convallis nunc.', '5.png', 88434.58, 17, 0, 1, 27.19, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone14 pro', 'Quisque porta volutpat erat.', '4.png', 53337.93, 6, 0, 0, 12.16, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone15', 'Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo.', '3.png', 39087.28, 28, 3, 1, 18.3, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone15 pro', 'Nulla tellus.', '1.png', 29924.67, 26, 2, 1, 74.44, 3, 5);insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone16', 'Etiam vel augue.', '2.png', 64852.67, 21, 0, 1, 67.72, 3, 5)insert into Products (Name, Description, MainImg, Price, Quantity, Rate, Status, Discount, CategoryId, BrandId) values ('iphone16pro', 'Aenean auctor gravida sem.', '3.png', 70062.08, 26, 0, 0, 17.87, 3, 5);");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE From Products");
        }
    }
}
