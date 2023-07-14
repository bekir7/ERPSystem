using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace alisanljoj.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BtRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    SystemName = table.Column<string>(type: "text", nullable: false),
                    AccessType = table.Column<string>(type: "text", nullable: false),
                    AccessType2 = table.Column<string[]>(type: "text[]", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BtRequest", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Duruşma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArchiveId = table.Column<int>(type: "integer", nullable: true),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientStatus = table.Column<string>(type: "text", nullable: true),
                    CaseStatus = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    CourtType = table.Column<string>(type: "text", nullable: true),
                    CaseType = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    County = table.Column<string>(type: "text", nullable: true),
                    Court = table.Column<string>(type: "text", nullable: true),
                    BasisNo = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CounterpartyStatus = table.Column<string>(type: "text", nullable: true),
                    CounterpartyName = table.Column<string>(type: "text", nullable: true),
                    TC = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<int>(type: "integer", nullable: true),
                    Time2 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duruşma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    RequestCategory = table.Column<string>(type: "text", nullable: true),
                    RequestDepot = table.Column<string>(type: "text", nullable: true),
                    RequestSupplier = table.Column<string>(type: "text", nullable: true),
                    RequestMaterial = table.Column<string>(type: "text", nullable: true),
                    RequestPaymentType = table.Column<string>(type: "text", nullable: false),
                    RequestPieces = table.Column<int>(type: "integer", nullable: false),
                    RequestDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "HukukSonuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArchiveId = table.Column<int>(type: "integer", nullable: true),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientStatus = table.Column<string>(type: "text", nullable: true),
                    CaseStatus = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    CourtType = table.Column<string>(type: "text", nullable: true),
                    CaseType = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    County = table.Column<string>(type: "text", nullable: true),
                    Court = table.Column<string>(type: "text", nullable: true),
                    BasisNo = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CounterpartyStatus = table.Column<string>(type: "text", nullable: true),
                    CounterpartyName = table.Column<string>(type: "text", nullable: true),
                    TC = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    result = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HukukSonuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    SystemName = table.Column<string>(type: "text", nullable: false),
                    AccessType = table.Column<string>(type: "text", nullable: false),
                    AccessType2 = table.Column<string[]>(type: "text[]", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItRequest", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Kargo",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    RequestCategory = table.Column<string>(type: "text", nullable: true),
                    RequestDepot = table.Column<string>(type: "text", nullable: true),
                    RequestSupplier = table.Column<string>(type: "text", nullable: true),
                    RequestMaterial = table.Column<string>(type: "text", nullable: true),
                    RequestPaymentType = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    RequestPieces = table.Column<int>(type: "integer", nullable: false),
                    RequestDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kargo", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "KargoYonetici",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    RequestCategory = table.Column<string>(type: "text", nullable: true),
                    RequestDepot = table.Column<string>(type: "text", nullable: true),
                    RequestSupplier = table.Column<string>(type: "text", nullable: true),
                    RequestMaterial = table.Column<string>(type: "text", nullable: true),
                    RequestPaymentType = table.Column<string>(type: "text", nullable: false),
                    RequestPieces = table.Column<int>(type: "integer", nullable: false),
                    RequestDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KargoYonetici", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "LawRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArchiveId = table.Column<int>(type: "integer", nullable: true),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientStatus = table.Column<string>(type: "text", nullable: true),
                    CaseStatus = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    CourtType = table.Column<string>(type: "text", nullable: true),
                    CaseType = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    County = table.Column<string>(type: "text", nullable: true),
                    Court = table.Column<string>(type: "text", nullable: true),
                    BasisNo = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CounterpartyStatus = table.Column<string>(type: "text", nullable: true),
                    CounterpartyName = table.Column<string>(type: "text", nullable: true),
                    TC = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<int>(type: "integer", nullable: true),
                    Time2 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    RequestCategory = table.Column<string>(type: "text", nullable: true),
                    RequestDepot = table.Column<string>(type: "text", nullable: true),
                    RequestSupplier = table.Column<string>(type: "text", nullable: true),
                    RequestMaterial = table.Column<string>(type: "text", nullable: true),
                    RequestPaymentType = table.Column<string>(type: "text", nullable: false),
                    RequestPieces = table.Column<int>(type: "integer", nullable: false),
                    RequestDescription = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DescriptionDeny = table.Column<string>(type: "text", nullable: true),
                    DescriptionDeny2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "RequestBt",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    SystemName = table.Column<string>(type: "text", nullable: false),
                    AccessType = table.Column<string>(type: "text", nullable: false),
                    AccessType2 = table.Column<string[]>(type: "text[]", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DescriptionDeny = table.Column<string>(type: "text", nullable: true),
                    DescriptionDenyIt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestBt", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Sipariş",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    RequestCategory = table.Column<string>(type: "text", nullable: true),
                    RequestDepot = table.Column<string>(type: "text", nullable: true),
                    RequestSupplier = table.Column<string>(type: "text", nullable: true),
                    RequestMaterial = table.Column<string>(type: "text", nullable: true),
                    RequestPaymentType = table.Column<string>(type: "text", nullable: false),
                    RequestPieces = table.Column<int>(type: "integer", nullable: false),
                    RequestDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sipariş", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Yonetici",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestNo = table.Column<int>(type: "integer", nullable: false),
                    Requestor = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<string>(type: "text", nullable: false),
                    RequestCategory = table.Column<string>(type: "text", nullable: true),
                    RequestDepot = table.Column<string>(type: "text", nullable: true),
                    RequestSupplier = table.Column<string>(type: "text", nullable: true),
                    RequestMaterial = table.Column<string>(type: "text", nullable: true),
                    RequestPaymentType = table.Column<string>(type: "text", nullable: false),
                    RequestPieces = table.Column<int>(type: "integer", nullable: false),
                    RequestDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetici", x => x.RequestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BtRequest");

            migrationBuilder.DropTable(
                name: "Duruşma");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "HukukSonuc");

            migrationBuilder.DropTable(
                name: "ItRequest");

            migrationBuilder.DropTable(
                name: "Kargo");

            migrationBuilder.DropTable(
                name: "KargoYonetici");

            migrationBuilder.DropTable(
                name: "LawRequest");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "RequestBt");

            migrationBuilder.DropTable(
                name: "Sipariş");

            migrationBuilder.DropTable(
                name: "Yonetici");
        }
    }
}
