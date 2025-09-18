namespace LoanManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInterestRate_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterestRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RatePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.Loans", "InterestRateId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Loans", "LoanType", c => c.String(nullable: false));
            //CreateIndex("dbo.Loans", "InterestRateId");
            //AddForeignKey("dbo.Loans", "InterestRateId", "dbo.InterestRates", "Id", cascadeDelete: true);
            //DropColumn("dbo.Loans", "InterestRate");


            AddColumn("dbo.Loans", "InterestRateId", c => c.Int());
            AlterColumn("dbo.Loans", "LoanType", c => c.String(nullable: false));
            CreateIndex("dbo.Loans", "InterestRateId");
            AddForeignKey("dbo.Loans", "InterestRateId", "dbo.InterestRates", "Id");
            DropColumn("dbo.Loans", "InterestRate");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "InterestRate", c => c.Double(nullable: false));
            DropForeignKey("dbo.Loans", "InterestRateId", "dbo.InterestRates");
            DropIndex("dbo.Loans", new[] { "InterestRateId" });
            AlterColumn("dbo.Loans", "LoanType", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Loans", "InterestRateId");
            DropTable("dbo.InterestRates");
        }
    }
}
