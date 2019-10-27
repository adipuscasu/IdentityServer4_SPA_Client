using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer4.DataAccess.Migrations
{
    public partial class UserAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "AF", "Afghanistan" },
                    { 152, "NC", "New Caledonia" },
                    { 153, "NZ", "New Zealand" },
                    { 154, "NI", "Nicaragua" },
                    { 155, "NE", "Niger" },
                    { 156, "NG", "Nigeria" },
                    { 157, "NU", "Niue" },
                    { 158, "NF", "Norfolk Island" },
                    { 159, "MP", "Northern Mariana Islands" },
                    { 160, "NO", "Norway" },
                    { 161, "OM", "Oman" },
                    { 162, "PK", "Pakistan" },
                    { 163, "PW", "Palau" },
                    { 151, "AN", "Netherlands Antilles" },
                    { 164, "PS", "Palestinian Territory, Occupied" },
                    { 166, "PG", "Papua New Guinea" },
                    { 167, "PY", "Paraguay" },
                    { 168, "PE", "Peru" },
                    { 169, "PH", "Philippines" },
                    { 170, "PN", "Pitcairn" },
                    { 171, "PL", "Poland" },
                    { 172, "PT", "Portugal" },
                    { 173, "PR", "Puerto Rico" },
                    { 174, "QA", "Qatar" },
                    { 175, "RE", "Reunion" },
                    { 176, "RO", "Romania" },
                    { 177, "RU", "Russian Federation" },
                    { 165, "PA", "Panama" },
                    { 178, "RW", "Rwanda" },
                    { 150, "NL", "Netherlands" },
                    { 148, "NR", "Nauru" },
                    { 122, "LI", "Liechtenstein" },
                    { 123, "LT", "Lithuania" },
                    { 124, "LU", "Luxembourg" },
                    { 125, "MO", "Macao" },
                    { 126, "MK", "Macedonia, the Former Yugoslav Republic of" },
                    { 127, "MG", "Madagascar" },
                    { 128, "MW", "Malawi" },
                    { 129, "MY", "Malaysia" },
                    { 130, "MV", "Maldives" },
                    { 131, "ML", "Mali" },
                    { 132, "MT", "Malta" },
                    { 133, "MH", "Marshall Islands" },
                    { 149, "NP", "Nepal" },
                    { 134, "MQ", "Martinique" },
                    { 136, "MU", "Mauritius" },
                    { 137, "YT", "Mayotte" },
                    { 138, "MX", "Mexico" },
                    { 139, "FM", "Micronesia, Federated States of" },
                    { 140, "MD", "Moldova, Republic of" },
                    { 141, "MC", "Monaco" },
                    { 142, "MN", "Mongolia" },
                    { 143, "MS", "Montserrat" },
                    { 144, "MA", "Morocco" },
                    { 145, "MZ", "Mozambique" },
                    { 146, "MM", "Myanmar" },
                    { 147, "NA", "Namibia" },
                    { 135, "MR", "Mauritania" },
                    { 121, "LY", "Libyan Arab Jamahiriya" },
                    { 179, "SH", "Saint Helena" },
                    { 181, "LC", "Saint Lucia" },
                    { 212, "TL", "Timor-Leste" },
                    { 213, "TG", "Togo" },
                    { 214, "TK", "Tokelau" },
                    { 215, "TO", "Tonga" },
                    { 216, "TT", "Trinidad and Tobago" },
                    { 217, "TN", "Tunisia" },
                    { 218, "TR", "Turkey" },
                    { 219, "TM", "Turkmenistan" },
                    { 220, "TC", "Turks and Caicos Islands" },
                    { 221, "TV", "Tuvalu" },
                    { 222, "UG", "Uganda" },
                    { 223, "UA", "Ukraine" },
                    { 211, "TH", "Thailand" },
                    { 224, "AE", "United Arab Emirates" },
                    { 226, "US", "United States" },
                    { 227, "UM", "United States Minor Outlying Islands" },
                    { 228, "UY", "Uruguay" },
                    { 229, "UZ", "Uzbekistan" },
                    { 230, "VU", "Vanuatu" },
                    { 231, "VE", "Venezuela" },
                    { 232, "VN", "Viet Nam" },
                    { 233, "VG", "Virgin Islands, British" },
                    { 234, "VI", "Virgin Islands, US" },
                    { 235, "WF", "Wallis and Futuna" },
                    { 236, "EH", "Western Sahara" },
                    { 237, "YE", "Yemen" },
                    { 225, "GB", "United Kingdom" },
                    { 180, "KN", "Saint Kitts and Nevis" },
                    { 210, "TZ", "Tanzania, United Republic of" },
                    { 208, "TW", "Taiwan, Province of China" },
                    { 182, "PM", "Saint Pierre and Miquelon" },
                    { 183, "VC", "Saint Vincent and the Grenadines" },
                    { 184, "WS", "Samoa" },
                    { 185, "SM", "San Marino" },
                    { 186, "ST", "Sao Tome and Principe" },
                    { 187, "SA", "Saudi Arabia" },
                    { 188, "SN", "Senegal" },
                    { 189, "CS", "Serbia and Montenegro" },
                    { 190, "SC", "Seychelles" },
                    { 191, "SL", "Sierra Leone" },
                    { 192, "SG", "Singapore" },
                    { 193, "SK", "Slovakia" },
                    { 209, "TJ", "Tajikistan" },
                    { 194, "SI", "Slovenia" },
                    { 196, "SO", "Somalia" },
                    { 197, "ZA", "South Africa" },
                    { 198, "GS", "South Georgia and the South Sandwich Islands" },
                    { 199, "ES", "Spain" },
                    { 200, "LK", "Sri Lanka" },
                    { 201, "SD", "Sudan" },
                    { 202, "SR", "Suriname" },
                    { 203, "SJ", "Svalbard and Jan Mayen" },
                    { 204, "SZ", "Swaziland" },
                    { 205, "SE", "Sweden" },
                    { 206, "CH", "Switzerland" },
                    { 207, "SY", "Syrian Arab Republic" },
                    { 195, "SB", "Solomon Islands" },
                    { 238, "ZM", "Zambia" },
                    { 120, "LR", "Liberia" },
                    { 118, "LB", "Lebanon" },
                    { 32, "BN", "Brunei Darussalam" },
                    { 33, "BG", "Bulgaria" },
                    { 34, "BF", "Burkina Faso" },
                    { 35, "BI", "Burundi" },
                    { 36, "KH", "Cambodia" },
                    { 37, "CM", "Cameroon" },
                    { 38, "CA", "Canada" },
                    { 39, "CV", "Cape Verde" },
                    { 40, "KY", "Cayman Islands" },
                    { 41, "CF", "Central African Republic" },
                    { 42, "TD", "Chad" },
                    { 43, "CL", "Chile" },
                    { 31, "IO", "British Indian Ocean Territory" },
                    { 44, "CN", "China" },
                    { 46, "CC", "Cocos (Keeling) Islands" },
                    { 47, "CO", "Colombia" },
                    { 48, "KM", "Comoros" },
                    { 49, "CG", "Congo" },
                    { 50, "CD", "Congo, the Democratic Republic of the" },
                    { 51, "CK", "Cook Islands" },
                    { 52, "CR", "Costa Rica" },
                    { 53, "CI", "Cote D'Ivoire" },
                    { 54, "HR", "Croatia" },
                    { 55, "CU", "Cuba" },
                    { 56, "CY", "Cyprus" },
                    { 57, "CZ", "Czech Republic" },
                    { 45, "CX", "Christmas Island" },
                    { 58, "DK", "Denmark" },
                    { 30, "BR", "Brazil" },
                    { 28, "BW", "Botswana" },
                    { 2, "AL", "Albania" },
                    { 3, "DZ", "Algeria" },
                    { 4, "AS", "American Samoa" },
                    { 5, "AD", "Andorra" },
                    { 6, "AO", "Angola" },
                    { 7, "AI", "Anguilla" },
                    { 8, "AQ", "Antarctica" },
                    { 9, "AG", "Antigua and Barbuda" },
                    { 10, "AR", "Argentina" },
                    { 11, "AM", "Armenia" },
                    { 12, "AW", "Aruba" },
                    { 13, "AU", "Australia" },
                    { 29, "BV", "Bouvet Island" },
                    { 14, "AT", "Austria" },
                    { 16, "BS", "Bahamas" },
                    { 17, "BH", "Bahrain" },
                    { 18, "BD", "Bangladesh" },
                    { 19, "BB", "Barbados" },
                    { 20, "BY", "Belarus" },
                    { 21, "BE", "Belgium" },
                    { 22, "BZ", "Belize" },
                    { 23, "BJ", "Benin" },
                    { 24, "BM", "Bermuda" },
                    { 25, "BT", "Bhutan" },
                    { 26, "BO", "Bolivia" },
                    { 27, "BA", "Bosnia and Herzegovina" },
                    { 15, "AZ", "Azerbaijan" },
                    { 119, "LS", "Lesotho" },
                    { 59, "DJ", "Djibouti" },
                    { 61, "DO", "Dominican Republic" },
                    { 92, "HT", "Haiti" },
                    { 93, "HM", "Heard Island and Mcdonald Islands" },
                    { 94, "VA", "Holy See (Vatican City State)" },
                    { 95, "HN", "Honduras" },
                    { 96, "HK", "Hong Kong" },
                    { 97, "HU", "Hungary" },
                    { 98, "IS", "Iceland" },
                    { 99, "IN", "India" },
                    { 100, "ID", "Indonesia" },
                    { 101, "IR", "Iran, Islamic Republic of" },
                    { 102, "IQ", "Iraq" },
                    { 103, "IE", "Ireland" },
                    { 91, "GY", "Guyana" },
                    { 104, "IL", "Israel" },
                    { 106, "JM", "Jamaica" },
                    { 107, "JP", "Japan" },
                    { 108, "JO", "Jordan" },
                    { 109, "KZ", "Kazakhstan" },
                    { 110, "KE", "Kenya" },
                    { 111, "KI", "Kiribati" },
                    { 112, "KP", "Korea, Democratic People's Republic of" },
                    { 113, "KR", "Korea, Republic of" },
                    { 114, "KW", "Kuwait" },
                    { 115, "KG", "Kyrgyzstan" },
                    { 116, "LA", "Lao People's Democratic Republic" },
                    { 117, "LV", "Latvia" },
                    { 105, "IT", "Italy" },
                    { 60, "DM", "Dominica" },
                    { 90, "GW", "Guinea-Bissau" },
                    { 88, "GT", "Guatemala" },
                    { 62, "EC", "Ecuador" },
                    { 63, "EG", "Egypt" },
                    { 64, "SV", "El Salvador" },
                    { 65, "GQ", "Equatorial Guinea" },
                    { 66, "ER", "Eritrea" },
                    { 67, "EE", "Estonia" },
                    { 68, "ET", "Ethiopia" },
                    { 69, "FK", "Falkland Islands (Malvinas)" },
                    { 70, "FO", "Faroe Islands" },
                    { 71, "FJ", "Fiji" },
                    { 72, "FI", "Finland" },
                    { 73, "FR", "France" },
                    { 89, "GN", "Guinea" },
                    { 74, "GF", "French Guiana" },
                    { 76, "TF", "French Southern Territories" },
                    { 77, "GA", "Gabon" },
                    { 78, "GM", "Gambia" },
                    { 79, "GE", "Georgia" },
                    { 80, "DE", "Germany" },
                    { 81, "GH", "Ghana" },
                    { 82, "GI", "Gibraltar" },
                    { 83, "GR", "Greece" },
                    { 84, "GL", "Greenland" },
                    { 85, "GD", "Grenada" },
                    { 86, "GP", "Guadeloupe" },
                    { 87, "GU", "Guam" },
                    { 75, "PF", "French Polynesia" },
                    { 239, "ZW", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
