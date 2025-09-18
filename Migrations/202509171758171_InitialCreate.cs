namespace LoanManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        IdentificationNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BorrowerId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanType = c.String(),
                        InterestRate = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Borrowers", t => t.BorrowerId, cascadeDelete: true)
                .Index(t => t.BorrowerId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanId = c.Int(nullable: false),
                        ContractFileName = c.String(),
                        SigningDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.LoanId, cascadeDelete: true)
                .Index(t => t.LoanId);
            
            CreateTable(
                "dbo.Repayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermMonths = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.LoanId, cascadeDelete: true)
                .Index(t => t.LoanId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanId = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.LoanId, cascadeDelete: true)
                .Index(t => t.LoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "BorrowerId", "dbo.Borrowers");
            DropForeignKey("dbo.Transactions", "LoanId", "dbo.Loans");
            DropForeignKey("dbo.Repayments", "LoanId", "dbo.Loans");
            DropForeignKey("dbo.Contracts", "LoanId", "dbo.Loans");
            DropIndex("dbo.Transactions", new[] { "LoanId" });
            DropIndex("dbo.Repayments", new[] { "LoanId" });
            DropIndex("dbo.Contracts", new[] { "LoanId" });
            DropIndex("dbo.Loans", new[] { "BorrowerId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Repayments");
            DropTable("dbo.Contracts");
            DropTable("dbo.Loans");
            DropTable("dbo.Borrowers");
        }
    }
}
