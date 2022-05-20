using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastPay.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CannotLoginUntilDateUtc",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "dbo",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailToRevalidate",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FailedLoginAttempts",
                schema: "dbo",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gander",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasShoppingCartItems",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSocialLogin",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivityDateUtc",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastIpAddress",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateUtc",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneCode",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireReLogin",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SocialAuthId",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialMediaType",
                schema: "dbo",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                schema: "dbo",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                schema: "dbo",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivationCode",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CodeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddField",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressAddField",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressAddField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userAddresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateProvinceId = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddFieldDateTime",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddFieldDateTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddFieldDateTime_UserAddField_UserAddFieldId",
                        column: x => x.UserAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddFieldFloat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddFieldFloat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddFieldFloat_UserAddField_UserAddFieldId",
                        column: x => x.UserAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddFieldInt",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddFieldInt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddFieldInt_UserAddField_UserAddFieldId",
                        column: x => x.UserAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddFieldOption",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddFieldId = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddFieldOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddFieldOption_UserAddField_UserAddFieldId",
                        column: x => x.UserAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddFieldString",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddFieldString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddFieldString_UserAddField_UserAddFieldId",
                        column: x => x.UserAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFormSetting",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddFieldId = table.Column<int>(type: "int", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHaveLabel = table.Column<bool>(type: "bit", nullable: false),
                    LabelText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlHint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLengthErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinLengthErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnique = table.Column<bool>(type: "bit", nullable: true),
                    UniqueErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationExpression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationExpressionErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    ControlType = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    GeneralDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: true),
                    AppliedFor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFormSetting_UserAddField_UserAddFieldId",
                        column: x => x.UserAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddressAddFieldDateTime",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressAddFieldDateTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressAddFieldDateTime_UserAddressAddField_UserAddressAddFieldId",
                        column: x => x.UserAddressAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddressAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressAddFieldFloat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressAddFieldFloat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressAddFieldFloat_UserAddressAddField_UserAddressAddFieldId",
                        column: x => x.UserAddressAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddressAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressAddFieldInt",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressAddFieldInt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressAddFieldInt_UserAddressAddField_UserAddressAddFieldId",
                        column: x => x.UserAddressAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddressAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressAddFieldOption",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressAddFieldId = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressAddFieldOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressAddFieldOption_UserAddressAddField_UserAddressAddFieldId",
                        column: x => x.UserAddressAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddressAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressAddFieldString",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressAddFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressAddFieldString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressAddFieldString_UserAddressAddField_UserAddressAddFieldId",
                        column: x => x.UserAddressAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddressAddField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressFormSettings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressAddFieldId = table.Column<int>(type: "int", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHaveLabel = table.Column<bool>(type: "bit", nullable: false),
                    LabelText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlHint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLengthErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinLengthErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnique = table.Column<bool>(type: "bit", nullable: true),
                    UniqueErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationExpression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationExpressionErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    ControlType = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    GeneralDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: true),
                    AppliedFor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressFormSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressFormSettings_UserAddressAddField_UserAddressAddFieldId",
                        column: x => x.UserAddressAddFieldId,
                        principalSchema: "dbo",
                        principalTable: "UserAddressAddField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddFieldDateTime_UserAddFieldId",
                schema: "dbo",
                table: "UserAddFieldDateTime",
                column: "UserAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddFieldFloat_UserAddFieldId",
                schema: "dbo",
                table: "UserAddFieldFloat",
                column: "UserAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddFieldInt_UserAddFieldId",
                schema: "dbo",
                table: "UserAddFieldInt",
                column: "UserAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddFieldOption_UserAddFieldId",
                schema: "dbo",
                table: "UserAddFieldOption",
                column: "UserAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddFieldString_UserAddFieldId",
                schema: "dbo",
                table: "UserAddFieldString",
                column: "UserAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressAddFieldDateTime_UserAddressAddFieldId",
                schema: "dbo",
                table: "UserAddressAddFieldDateTime",
                column: "UserAddressAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressAddFieldFloat_UserAddressAddFieldId",
                schema: "dbo",
                table: "UserAddressAddFieldFloat",
                column: "UserAddressAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressAddFieldInt_UserAddressAddFieldId",
                schema: "dbo",
                table: "UserAddressAddFieldInt",
                column: "UserAddressAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressAddFieldOption_UserAddressAddFieldId",
                schema: "dbo",
                table: "UserAddressAddFieldOption",
                column: "UserAddressAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressAddFieldString_UserAddressAddFieldId",
                schema: "dbo",
                table: "UserAddressAddFieldString",
                column: "UserAddressAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressFormSettings_UserAddressAddFieldId",
                schema: "dbo",
                table: "UserAddressFormSettings",
                column: "UserAddressAddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormSetting_UserAddFieldId",
                schema: "dbo",
                table: "UserFormSetting",
                column: "UserAddFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddFieldDateTime",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddFieldFloat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddFieldInt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddFieldOption",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddFieldString",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressAddFieldDateTime",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressAddFieldFloat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressAddFieldInt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressAddFieldOption",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressAddFieldString",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "userAddresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressFormSettings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserFormSetting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddressAddField",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddField",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "CannotLoginUntilDateUtc",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailToRevalidate",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FailedLoginAttempts",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gander",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasShoppingCartItems",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSocialLogin",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastActivityDateUtc",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastIpAddress",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDateUtc",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RequireReLogin",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SocialAuthId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SocialMediaType",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
