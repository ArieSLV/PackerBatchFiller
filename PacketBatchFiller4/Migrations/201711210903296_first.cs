namespace PacketBatchFiller4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Long(nullable: false, identity: true),
                        Index = c.String(),
                        RegionType = c.String(),
                        RegionName = c.String(),
                        DistrictType = c.String(),
                        DistrictName = c.String(),
                        CityType = c.String(),
                        CityName = c.String(),
                        LocalityType = c.String(),
                        LocalityName = c.String(),
                        StreetType = c.String(),
                        StreetName = c.String(),
                        BuildingType = c.String(),
                        BuildingValue = c.String(),
                        SubBuildingType = c.String(),
                        SubBuildingValue = c.String(),
                        FlatType = c.String(),
                        FlatValue = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.BankDetails",
                c => new
                    {
                        BankDetailsId = c.Long(nullable: false, identity: true),
                        PersonalAccount = c.String(),
                        BankBranchName = c.String(),
                        MainAccount = c.String(),
                        CorrAccount = c.String(),
                        BankName = c.String(),
                        BIK = c.String(),
                        BankCity = c.String(),
                    })
                .PrimaryKey(t => t.BankDetailsId);
            
            CreateTable(
                "dbo.Citizenships",
                c => new
                    {
                        CitizenshipId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.CitizenshipId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                        Type = c.Int(nullable: false),
                        Comment = c.String(),
                        Unit_UnitId = c.Long(),
                    })
                .PrimaryKey(t => t.EmailId)
                .ForeignKey("dbo.Units", t => t.Unit_UnitId)
                .Index(t => t.Unit_UnitId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        PhoneNumberId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                        Type = c.Int(nullable: false),
                        Comment = c.String(),
                        Unit_UnitId = c.Long(),
                    })
                .PrimaryKey(t => t.PhoneNumberId)
                .ForeignKey("dbo.Units", t => t.Unit_UnitId)
                .Index(t => t.Unit_UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Long(nullable: false, identity: true),
                        DividentsPaymentWay = c.Int(nullable: false),
                        OnlyPersonalPresenceFlag = c.Boolean(nullable: false),
                        INN = c.String(),
                        MailingAddressEqualRegistrationAddressFlag = c.Boolean(nullable: false),
                        RoleIsShareHolderFlag = c.Boolean(nullable: false),
                        RoleIsFirstPersonOfTheCompany = c.Boolean(nullable: false),
                        TimeStamp = c.DateTime(precision: 7, storeType: "datetime2"),
                        AddressRegistration_AddressId = c.Long(),
                        BankDetails_BankDetailsId = c.Long(),
                        Citizenship_CitizenshipId = c.Long(),
                        MailingAddress_AddressId = c.Long(),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Addresses", t => t.AddressRegistration_AddressId)
                .ForeignKey("dbo.BankDetails", t => t.BankDetails_BankDetailsId)
                .ForeignKey("dbo.Citizenships", t => t.Citizenship_CitizenshipId)
                .ForeignKey("dbo.Addresses", t => t.MailingAddress_AddressId)
                .Index(t => t.AddressRegistration_AddressId)
                .Index(t => t.BankDetails_BankDetailsId)
                .Index(t => t.Citizenship_CitizenshipId)
                .Index(t => t.MailingAddress_AddressId);
            
            CreateTable(
                "dbo.ShareholderAccount",
                c => new
                    {
                        ShareholderAccountId = c.Long(nullable: false, identity: true),
                        Number = c.String(),
                        ShareholderAccountType = c.Int(nullable: false),
                        SecuritiesIssuer_UnitId = c.Long(),
                        Unit_UnitId = c.Long(),
                    })
                .PrimaryKey(t => t.ShareholderAccountId)
                .ForeignKey("dbo.LegalEntities", t => t.SecuritiesIssuer_UnitId)
                .ForeignKey("dbo.Units", t => t.Unit_UnitId)
                .Index(t => t.SecuritiesIssuer_UnitId)
                .Index(t => t.Unit_UnitId);
            
            CreateTable(
                "dbo.FormOfIncorporations",
                c => new
                    {
                        FormOfIncorporationId = c.Long(nullable: false, identity: true),
                        ShortForm = c.String(),
                        FullForm = c.String(),
                    })
                .PrimaryKey(t => t.FormOfIncorporationId);
            
            CreateTable(
                "dbo.IssuesOfSecurities",
                c => new
                    {
                        IssueOfSecuritiesId = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Number = c.String(),
                        LegalEntity_UnitId = c.Long(),
                    })
                .PrimaryKey(t => t.IssueOfSecuritiesId)
                .ForeignKey("dbo.LegalEntities", t => t.LegalEntity_UnitId)
                .Index(t => t.LegalEntity_UnitId);
            
            CreateTable(
                "dbo.RegistrationCertificates",
                c => new
                    {
                        RegistrationCertificateId = c.Long(nullable: false, identity: true),
                        Number = c.String(),
                        IssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RegistrationCertificateIssuer_RegistrationCertificateIssuerId = c.Long(),
                    })
                .PrimaryKey(t => t.RegistrationCertificateId)
                .ForeignKey("dbo.RegistrationCertificateIssuers", t => t.RegistrationCertificateIssuer_RegistrationCertificateIssuerId)
                .Index(t => t.RegistrationCertificateIssuer_RegistrationCertificateIssuerId);
            
            CreateTable(
                "dbo.RegistrationCertificateIssuers",
                c => new
                    {
                        RegistrationCertificateIssuerId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.RegistrationCertificateIssuerId);
            
            CreateTable(
                "dbo.LegalEntities",
                c => new
                    {
                        UnitId = c.Long(nullable: false),
                        FirstPersonOfCompany_UnitId = c.Long(),
                        FormOfIncorporation_FormOfIncorporationId = c.Long(),
                        RegistrationCertificate_RegistrationCertificateId = c.Long(),
                        KPP = c.String(),
                        OKPO = c.String(),
                        OKVED = c.String(),
                        RoleIsSecuritiesIssuerFlag = c.Boolean(nullable: false),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .ForeignKey("dbo.Units", t => t.FirstPersonOfCompany_UnitId)
                .ForeignKey("dbo.FormOfIncorporations", t => t.FormOfIncorporation_FormOfIncorporationId)
                .ForeignKey("dbo.RegistrationCertificates", t => t.RegistrationCertificate_RegistrationCertificateId)
                .Index(t => t.UnitId)
                .Index(t => t.FirstPersonOfCompany_UnitId)
                .Index(t => t.FormOfIncorporation_FormOfIncorporationId)
                .Index(t => t.RegistrationCertificate_RegistrationCertificateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LegalEntities", "RegistrationCertificate_RegistrationCertificateId", "dbo.RegistrationCertificates");
            DropForeignKey("dbo.LegalEntities", "FormOfIncorporation_FormOfIncorporationId", "dbo.FormOfIncorporations");
            DropForeignKey("dbo.LegalEntities", "FirstPersonOfCompany_UnitId", "dbo.Units");
            DropForeignKey("dbo.LegalEntities", "UnitId", "dbo.Units");
            DropForeignKey("dbo.ShareholderAccount", "Unit_UnitId", "dbo.Units");
            DropForeignKey("dbo.ShareholderAccount", "SecuritiesIssuer_UnitId", "dbo.LegalEntities");
            DropForeignKey("dbo.RegistrationCertificates", "RegistrationCertificateIssuer_RegistrationCertificateIssuerId", "dbo.RegistrationCertificateIssuers");
            DropForeignKey("dbo.IssuesOfSecurities", "LegalEntity_UnitId", "dbo.LegalEntities");
            DropForeignKey("dbo.PhoneNumbers", "Unit_UnitId", "dbo.Units");
            DropForeignKey("dbo.Units", "MailingAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Emails", "Unit_UnitId", "dbo.Units");
            DropForeignKey("dbo.Units", "Citizenship_CitizenshipId", "dbo.Citizenships");
            DropForeignKey("dbo.Units", "BankDetails_BankDetailsId", "dbo.BankDetails");
            DropForeignKey("dbo.Units", "AddressRegistration_AddressId", "dbo.Addresses");
            DropIndex("dbo.LegalEntities", new[] { "RegistrationCertificate_RegistrationCertificateId" });
            DropIndex("dbo.LegalEntities", new[] { "FormOfIncorporation_FormOfIncorporationId" });
            DropIndex("dbo.LegalEntities", new[] { "FirstPersonOfCompany_UnitId" });
            DropIndex("dbo.LegalEntities", new[] { "UnitId" });
            DropIndex("dbo.RegistrationCertificates", new[] { "RegistrationCertificateIssuer_RegistrationCertificateIssuerId" });
            DropIndex("dbo.IssuesOfSecurities", new[] { "LegalEntity_UnitId" });
            DropIndex("dbo.ShareholderAccount", new[] { "Unit_UnitId" });
            DropIndex("dbo.ShareholderAccount", new[] { "SecuritiesIssuer_UnitId" });
            DropIndex("dbo.Units", new[] { "MailingAddress_AddressId" });
            DropIndex("dbo.Units", new[] { "Citizenship_CitizenshipId" });
            DropIndex("dbo.Units", new[] { "BankDetails_BankDetailsId" });
            DropIndex("dbo.Units", new[] { "AddressRegistration_AddressId" });
            DropIndex("dbo.PhoneNumbers", new[] { "Unit_UnitId" });
            DropIndex("dbo.Emails", new[] { "Unit_UnitId" });
            DropTable("dbo.LegalEntities");
            DropTable("dbo.RegistrationCertificateIssuers");
            DropTable("dbo.RegistrationCertificates");
            DropTable("dbo.IssuesOfSecurities");
            DropTable("dbo.FormOfIncorporations");
            DropTable("dbo.ShareholderAccount");
            DropTable("dbo.Units");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Emails");
            DropTable("dbo.Citizenships");
            DropTable("dbo.BankDetails");
            DropTable("dbo.Addresses");
        }
    }
}
