namespace PacketBatchFiller4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardID",
                c => new
                    {
                        CardIDId = c.Long(nullable: false, identity: true),
                        Series = c.String(),
                        Number = c.String(),
                        IssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CardIDIssuer_CardIDIssuerId = c.Long(),
                        CardIDType_CardIDTypeId = c.Long(),
                    })
                .PrimaryKey(t => t.CardIDId)
                .ForeignKey("dbo.CardIDIssuers", t => t.CardIDIssuer_CardIDIssuerId)
                .ForeignKey("dbo.CardIDTypes", t => t.CardIDType_CardIDTypeId)
                .Index(t => t.CardIDIssuer_CardIDIssuerId)
                .Index(t => t.CardIDType_CardIDTypeId);
            
            CreateTable(
                "dbo.CardIDIssuers",
                c => new
                    {
                        CardIDIssuerId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.CardIDIssuerId);
            
            CreateTable(
                "dbo.CardIDTypes",
                c => new
                    {
                        CardIDTypeId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.CardIDTypeId);
            
            CreateTable(
                "dbo.PlaceOfBirths",
                c => new
                    {
                        PlaceOfBirthId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.PlaceOfBirthId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        UnitId = c.Long(nullable: false),
                        CardID_CardIDId = c.Long(),
                        PlaceOfBirth_PlaceOfBirthId = c.Long(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsOneOfPODFTFlag = c.Boolean(nullable: false),
                        GotBeneficialOwnerFlag = c.Boolean(nullable: false),
                        IsHeadNonComercialCompanyFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .ForeignKey("dbo.CardID", t => t.CardID_CardIDId)
                .ForeignKey("dbo.PlaceOfBirths", t => t.PlaceOfBirth_PlaceOfBirthId)
                .Index(t => t.UnitId)
                .Index(t => t.CardID_CardIDId)
                .Index(t => t.PlaceOfBirth_PlaceOfBirthId);
            
            AddColumn("dbo.Units", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persons", "PlaceOfBirth_PlaceOfBirthId", "dbo.PlaceOfBirths");
            DropForeignKey("dbo.Persons", "CardID_CardIDId", "dbo.CardID");
            DropForeignKey("dbo.Persons", "UnitId", "dbo.Units");
            DropForeignKey("dbo.CardID", "CardIDType_CardIDTypeId", "dbo.CardIDTypes");
            DropForeignKey("dbo.CardID", "CardIDIssuer_CardIDIssuerId", "dbo.CardIDIssuers");
            DropIndex("dbo.Persons", new[] { "PlaceOfBirth_PlaceOfBirthId" });
            DropIndex("dbo.Persons", new[] { "CardID_CardIDId" });
            DropIndex("dbo.Persons", new[] { "UnitId" });
            DropIndex("dbo.CardID", new[] { "CardIDType_CardIDTypeId" });
            DropIndex("dbo.CardID", new[] { "CardIDIssuer_CardIDIssuerId" });
            DropColumn("dbo.Units", "FullName");
            DropTable("dbo.Persons");
            DropTable("dbo.PlaceOfBirths");
            DropTable("dbo.CardIDTypes");
            DropTable("dbo.CardIDIssuers");
            DropTable("dbo.CardID");
        }
    }
}
