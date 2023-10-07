using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JasperGreen.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(nullable: false),
                    EmployeeLastName = table.Column<string>(nullable: false),
                    SSN = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    CrewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewForeman = table.Column<int>(nullable: false),
                    CrewMember1 = table.Column<int>(nullable: false),
                    CrewMember2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.CrewID);
                    table.ForeignKey(
                        name: "FK_Crews_Employees_CrewForeman",
                        column: x => x.CrewForeman,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crews_Employees_CrewMember1",
                        column: x => x.CrewMember1,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crews_Employees_CrewMember2",
                        column: x => x.CrewMember2,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BillingAddress = table.Column<string>(nullable: false),
                    BillingCity = table.Column<string>(nullable: false),
                    StateID = table.Column<string>(nullable: false),
                    BillingZIP = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    PropertyAddress = table.Column<string>(nullable: false),
                    PropertyCity = table.Column<string>(nullable: false),
                    PropertyState = table.Column<string>(nullable: false),
                    PropertyZIP = table.Column<string>(nullable: false),
                    ServiceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_Properties_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedServices",
                columns: table => new
                {
                    ProvidedServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDate = table.Column<DateTime>(nullable: false),
                    ServiceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CrewID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    PropertyID = table.Column<int>(nullable: false),
                    PaymentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServices", x => x.ProvidedServiceID);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Crews_CrewID",
                        column: x => x.CrewID,
                        principalTable: "Crews",
                        principalColumn: "CrewID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[,]
                {
                    { 501, "Tony", "Stark", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.00m, "Crew Foreman", "111-00-2121" },
                    { 515, "Matt", "Murdock", new DateTime(2017, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "250-00-5678" },
                    { 514, "Scott", "Lang", new DateTime(2017, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "111-00-1234" },
                    { 512, "Peter", "Parker", new DateTime(2017, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "700-11-1111" },
                    { 511, "Wanda", "Maximoff", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "300-60-2222" },
                    { 510, "Loki", "Laufeyson", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "250-50-2525" },
                    { 509, "Bucky", "Barnes", new DateTime(2016, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "100-50-4200" },
                    { 513, "Stephen", "Strange", new DateTime(2017, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "300-11-0000" },
                    { 507, "Nick", "Fury", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "110-22-9999" },
                    { 506, "Clint", "Barton", new DateTime(2016, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "111-00-7777" },
                    { 505, "Natasha", "Romanoff", new DateTime(2016, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.00m, "Crew Foreman", "400-00-4444" },
                    { 504, "Bruce", "Banner", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.00m, "Crew Foreman", "111-11-3333" },
                    { 503, "Thor", "Odinson", new DateTime(2016, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.00m, "Crew Foreman", "110-11-8888" },
                    { 502, "Steve", "Rogers", new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.00m, "Crew Foreman", "400-00-1200" },
                    { 508, "Sam", "Wilson", new DateTime(2017, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.00m, "Crew Member", "600-11-5555" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[,]
                {
                    { "OH", "Ohio" },
                    { "ND", "North Dakota" },
                    { "NC", "North Carolina" },
                    { "NY", "New York" },
                    { "NV", "Nevada" },
                    { "NJ", "New Jersey" },
                    { "NH", "New Hampshire" },
                    { "NE", "Nebraska" },
                    { "OK", "Oklahoma" },
                    { "NM", "New Mexico" },
                    { "OR", "Oregon" },
                    { "UT", "Utah" },
                    { "RI", "Rhode Island" },
                    { "SC", "South Carolina" },
                    { "SD", "South Dakota" },
                    { "TN", "Tennessee" },
                    { "TX", "Texas" },
                    { "MT", "Montana" },
                    { "VT", "Vermont" },
                    { "VA", "Virginia" },
                    { "WA", "Washington" },
                    { "WV", "West Virginia" },
                    { "PA", "Pennsylvania" },
                    { "MO", "Missouri" },
                    { "KY", "Kentucky" },
                    { "MN", "Minnesota" },
                    { "AL", "Alabama" },
                    { "AK", "Alaska" },
                    { "AZ", "Arizona" },
                    { "AR", "Arkansas" },
                    { "CA", "California" },
                    { "CO", "Colorado" },
                    { "CT", "Connecticut" },
                    { "DE", "Delaware" },
                    { "DC", "District of Columbia" },
                    { "FL", "Florida" },
                    { "GA", "Georgia" },
                    { "HI", "Hawaii" },
                    { "ID", "Idaho" },
                    { "IL", "Illinois" },
                    { "IN", "Indiana" },
                    { "IA", "Iowa" },
                    { "KS", "Kansas" },
                    { "WI", "Wisconsin" },
                    { "LA", "Louisiana" },
                    { "ME", "Maine" },
                    { "MD", "Maryland" },
                    { "MA", "Massachusetts" },
                    { "MI", "Michigan" },
                    { "MS", "Mississippi" },
                    { "WY", "Wyoming" }
                });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "CrewID", "CrewForeman", "CrewMember1", "CrewMember2" },
                values: new object[,]
                {
                    { 701, 501, 506, 507 },
                    { 702, 502, 508, 509 },
                    { 703, 503, 510, 511 },
                    { 704, 504, 512, 513 },
                    { 705, 505, 514, 515 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BillingAddress", "BillingCity", "BillingZIP", "Name", "PhoneNumber", "StateID" },
                values: new object[,]
                {
                    { 101, "616 Avengers St", "College Station", "77840", "Steven Grant", "979-777-1111", "TX" },
                    { 102, "617 Avengers St", "College Station", "77840", "Marc Spector", "979-000-1212", "TX" },
                    { 103, "120 Marvel Rd", "College Station", "77843", "Kate Bishop", "979-123-4567", "TX" },
                    { 104, "124 Marvel Rd", "College Station", "77843", "Carol Danvers", "979-222-2222", "TX" },
                    { 105, "111 Hero Ln", "College Station", "77844", "James Rhodes", "979-555-4444", "TX" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[,]
                {
                    { 11101, 101, 200.00m, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11108, 105, 300.00m, new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11107, 105, 400.00m, new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11106, 104, 200.00m, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11104, 104, 300.00m, new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11103, 103, 300.00m, new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11110, 103, 500.00m, new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11109, 102, 200.00m, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11105, 102, 300.00m, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11102, 102, 200.00m, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZIP", "ServiceFee" },
                values: new object[,]
                {
                    { 2007, 102, "448 Knight St", "College Station", "TX", "77842", 200.00m },
                    { 2002, 102, "617 Avengers St", "College Station", "TX", "77840", 200.00m },
                    { 2005, 105, "111 Hero Ln", "College Station", "TX", "77844", 400.00m },
                    { 2003, 103, "120 Marvel Rd", "College Station", "TX", "77843", 300.00m },
                    { 2008, 103, "300 Arrow St", "College Station", "TX", "77841", 500.00m },
                    { 2004, 104, "124 Marvel Rd", "College Station", "TX", "77843", 300.00m },
                    { 2009, 104, "380 Cap Dr", "Bryan", "TX", "77806", 200.00m },
                    { 2001, 101, "616 Avengers St", "College Station", "TX", "77840", 200.00m },
                    { 2006, 102, "200 Moon St", "Bryan", "TX", "77801", 300.00m },
                    { 20010, 105, "888 Armor St", "Bryan", "TX", "77806", 300.00m }
                });

            migrationBuilder.InsertData(
                table: "ProvidedServices",
                columns: new[] { "ProvidedServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[,]
                {
                    { 4001, 701, 101, null, 2001, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m },
                    { 4002, 701, 102, null, 2002, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m },
                    { 4005, 703, 102, null, 2006, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.00m },
                    { 4009, 705, 102, null, 2007, new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m },
                    { 4003, 702, 103, null, 2003, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.00m },
                    { 4010, 705, 103, null, 2008, new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.00m },
                    { 4004, 702, 104, null, 2004, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.00m },
                    { 4006, 703, 104, null, 2009, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m },
                    { 4007, 704, 105, null, 2005, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.00m },
                    { 4008, 704, 105, null, 20010, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewForeman",
                table: "Crews",
                column: "CrewForeman");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewMember1",
                table: "Crews",
                column: "CrewMember1");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewMember2",
                table: "Crews",
                column: "CrewMember2");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StateID",
                table: "Customers",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerID",
                table: "Payments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CustomerID",
                table: "Properties",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_CrewID",
                table: "ProvidedServices",
                column: "CrewID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_CustomerID",
                table: "ProvidedServices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_PaymentID",
                table: "ProvidedServices",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_PropertyID",
                table: "ProvidedServices",
                column: "PropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidedServices");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
