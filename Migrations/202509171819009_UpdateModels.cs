namespace LoanManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Borrowers", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Borrowers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Borrowers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Borrowers", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Borrowers", "IdentificationNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Loans", "LoanType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contracts", "ContractFileName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Transactions", "TransactionType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transactions", "Description", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Description", c => c.String());
            AlterColumn("dbo.Transactions", "TransactionType", c => c.String());
            AlterColumn("dbo.Contracts", "ContractFileName", c => c.String());
            AlterColumn("dbo.Loans", "LoanType", c => c.String());
            AlterColumn("dbo.Borrowers", "IdentificationNumber", c => c.String());
            AlterColumn("dbo.Borrowers", "Address", c => c.String());
            AlterColumn("dbo.Borrowers", "Email", c => c.String());
            AlterColumn("dbo.Borrowers", "Phone", c => c.String());
            AlterColumn("dbo.Borrowers", "FullName", c => c.String());
        }
    }
}
