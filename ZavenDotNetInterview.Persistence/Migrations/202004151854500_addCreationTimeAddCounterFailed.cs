namespace ZavenDotNetInterview.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreationTimeAddCounterFailed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "TryCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "TryCounter");
            DropColumn("dbo.Jobs", "CreationTime");
        }
    }
}
