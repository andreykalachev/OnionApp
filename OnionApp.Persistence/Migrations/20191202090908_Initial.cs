using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionApp.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAddressType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code1 = table.Column<string>(nullable: true),
                    Code2 = table.Column<string>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    Code4 = table.Column<string>(nullable: true),
                    Code5 = table.Column<string>(nullable: true),
                    Code6 = table.Column<string>(nullable: true),
                    Value1 = table.Column<double>(nullable: true),
                    Value2 = table.Column<double>(nullable: true),
                    Value3 = table.Column<double>(nullable: true),
                    Value4 = table.Column<double>(nullable: true),
                    Flag1 = table.Column<bool>(nullable: true),
                    Flag2 = table.Column<bool>(nullable: true),
                    Flag3 = table.Column<bool>(nullable: true),
                    Flag4 = table.Column<bool>(nullable: true),
                    Timestamp1 = table.Column<DateTime>(nullable: true),
                    Timestamp2 = table.Column<DateTime>(nullable: true),
                    Timestamp3 = table.Column<DateTime>(nullable: true),
                    Timestamp4 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code1 = table.Column<string>(nullable: true),
                    Code2 = table.Column<string>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    Code4 = table.Column<string>(nullable: true),
                    Code5 = table.Column<string>(nullable: true),
                    Code6 = table.Column<string>(nullable: true),
                    Value1 = table.Column<double>(nullable: true),
                    Value2 = table.Column<double>(nullable: true),
                    Value3 = table.Column<double>(nullable: true),
                    Value4 = table.Column<double>(nullable: true),
                    Flag1 = table.Column<bool>(nullable: true),
                    Flag2 = table.Column<bool>(nullable: true),
                    Flag3 = table.Column<bool>(nullable: true),
                    Flag4 = table.Column<bool>(nullable: true),
                    Timestamp1 = table.Column<DateTime>(nullable: true),
                    Timestamp2 = table.Column<DateTime>(nullable: true),
                    Timestamp3 = table.Column<DateTime>(nullable: true),
                    Timestamp4 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ISO3166_2 = table.Column<string>(nullable: true),
                    ISO3166_3 = table.Column<string>(nullable: true),
                    DefaultVatId = table.Column<Guid>(nullable: true),
                    PostalCodeFormat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRelation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false),
                    ParentRelationId = table.Column<Guid>(nullable: true),
                    IsTemporary = table.Column<bool>(nullable: true),
                    IsMe = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DepartureName = table.Column<string>(nullable: true),
                    ArrivalName = table.Column<string>(nullable: true),
                    DefaultStreet = table.Column<string>(nullable: true),
                    DefaultPostalCode = table.Column<string>(nullable: true),
                    DefaultCity = table.Column<string>(nullable: true),
                    DefaultCountry = table.Column<string>(nullable: true),
                    EMailAddress = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IMAddress = table.Column<string>(nullable: true),
                    SkypeAddress = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    EmergencyNumber = table.Column<string>(nullable: true),
                    DepartureBetween = table.Column<DateTime>(nullable: true),
                    DepartureBetweenAnd = table.Column<DateTime>(nullable: true),
                    ArrivalBetween = table.Column<DateTime>(nullable: true),
                    ArrivalBetweenAnd = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CustomerCode = table.Column<string>(nullable: true),
                    DebtorNumber = table.Column<string>(nullable: true),
                    VendorNumber = table.Column<string>(nullable: true),
                    InvoiceTo = table.Column<string>(nullable: true),
                    InvoiceEMailAddress = table.Column<string>(nullable: true),
                    SendInvoiceDigital = table.Column<bool>(nullable: true),
                    VatId = table.Column<Guid>(nullable: true),
                    VatName = table.Column<string>(nullable: true),
                    PaymentTerm = table.Column<double>(nullable: true),
                    PaymentViaAutomaticDebit = table.Column<bool>(nullable: true),
                    VatNumber = table.Column<string>(nullable: true),
                    ChamberOfCommerce = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    BankBic = table.Column<string>(nullable: true),
                    CalculateMinimalPrice = table.Column<double>(nullable: true),
                    CalculatePriceManually = table.Column<bool>(nullable: true),
                    CalculatePriceByPriceList = table.Column<bool>(nullable: true),
                    PriceListId = table.Column<Guid>(nullable: true),
                    PriceListName = table.Column<string>(nullable: true),
                    CalculatePriceBasedOnPositions = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnAmount = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnWeight = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnDistance = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnTonne = table.Column<bool>(nullable: true),
                    CalculatePriceByFixed = table.Column<bool>(nullable: true),
                    CalculatePriceByDistance = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnEpq = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnLoadingMeters = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnVolume = table.Column<bool>(nullable: true),
                    CalculatePriceByFixedPrice = table.Column<double>(nullable: true),
                    CalculateMinimalPriceForCollecting = table.Column<double>(nullable: true),
                    CalculatePriceManuallyForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceByPriceListForCollecting = table.Column<bool>(nullable: true),
                    PriceListIdForCollecting = table.Column<Guid>(nullable: true),
                    PriceListNameForCollecting = table.Column<string>(nullable: true),
                    CalculatePriceBasedOnPositionsForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnAmountForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnWeightForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnDistanceForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnTonneForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceByFixedForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceByDistanceForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnEpqForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnLoadingMetersForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceBasedOnVolumeForCollecting = table.Column<bool>(nullable: true),
                    CalculatePriceByFixedPriceForCollecting = table.Column<double>(nullable: true),
                    GeographicalRegions = table.Column<string>(nullable: true),
                    SendDigitalFreightDocumentsByEMail = table.Column<bool>(nullable: true),
                    DigitalFreightDocumentEMailTemplateId = table.Column<Guid>(nullable: true),
                    SendFreightStatusUpdateByEMail = table.Column<bool>(nullable: true),
                    DepartureTimeSlotsAreAllEqual = table.Column<bool>(nullable: true),
                    DepartureTimeSlotIdOnSundays = table.Column<Guid>(nullable: true),
                    DepartureTimeSlotIdOnMondays = table.Column<Guid>(nullable: true),
                    DepartureTimeSlotIdOnTuesdays = table.Column<Guid>(nullable: true),
                    DepartureTimeSlotIdOnWednesdays = table.Column<Guid>(nullable: true),
                    DepartureTimeSlotIdOnThursdays = table.Column<Guid>(nullable: true),
                    DepartureTimeSlotIdOnFridays = table.Column<Guid>(nullable: true),
                    DepartureTimeSlotIdOnSaturdays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotsAreAllEqual = table.Column<bool>(nullable: true),
                    ArrivalTimeSlotIdOnSundays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotIdOnMondays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotIdOnTuesdays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotIdOnWednesdays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotIdOnThursdays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotIdOnFridays = table.Column<Guid>(nullable: true),
                    ArrivalTimeSlotIdOnSaturdays = table.Column<Guid>(nullable: true),
                    InvoiceDateGenerationOptions = table.Column<int>(nullable: true),
                    InvoiceGroupByOptions = table.Column<int>(nullable: true),
                    InvoiceGroupByTransportOrderColumnName = table.Column<string>(nullable: true),
                    GeneralLedgerAccount = table.Column<string>(nullable: true),
                    TransportUnitTransactionOverviewTextTemplateId = table.Column<Guid>(nullable: true),
                    SendFreightDocumentsAlongWithInvoice = table.Column<bool>(nullable: true),
                    CarrierCode = table.Column<string>(nullable: true),
                    SupplyNumber = table.Column<string>(nullable: true),
                    ThirdPartyToUseForInvoicing = table.Column<Guid>(nullable: true),
                    Flags = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRelation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRelationAddress",
                columns: table => new
                {
                    RelationId = table.Column<Guid>(nullable: false),
                    AddressTypeId = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: true),
                    NumberSuffix = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Building = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Latitude = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRelationAddress", x => x.RelationId);
                    table.ForeignKey(
                        name: "FK_tblRelationAddress_tblAddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "tblAddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRelationAddress_tblRelation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "tblRelation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRelationCategory",
                columns: table => new
                {
                    RelationId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRelationCategory", x => new { x.CategoryId, x.RelationId });
                    table.ForeignKey(
                        name: "FK_tblRelationCategory_tblCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRelationCategory_tblRelation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "tblRelation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblRelationAddress_AddressTypeId",
                table: "tblRelationAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRelationCategory_RelationId",
                table: "tblRelationCategory",
                column: "RelationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCountry");

            migrationBuilder.DropTable(
                name: "tblRelationAddress");

            migrationBuilder.DropTable(
                name: "tblRelationCategory");

            migrationBuilder.DropTable(
                name: "tblAddressType");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblRelation");
        }
    }
}
