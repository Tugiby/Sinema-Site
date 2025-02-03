namespace proje1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKoltukVeSalon : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.satisharekets", "salonlar_salonid", "dbo.salonlars");
            //DropIndex("dbo.satisharekets", new[] { "salonlar_salonid" });
            //RenameColumn(table: "dbo.satisharekets", name: "salonlar_salonid", newName: "salonid");
            //AddColumn("dbo.satisharekets", "koltukno", c => c.String());
            //AddColumn("dbo.salonlars", "dolukoltuklar", c => c.String());
            //AlterColumn("dbo.satisharekets", "salonid", c => c.Int(nullable: false));
            //CreateIndex("dbo.satisharekets", "salonid");
            //AddForeignKey("dbo.satisharekets", "salonid", "dbo.salonlars", "salonid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.satisharekets", "salonid", "dbo.salonlars");
            //DropIndex("dbo.satisharekets", new[] { "salonid" });
            //AlterColumn("dbo.satisharekets", "salonid", c => c.Int());
            //DropColumn("dbo.salonlars", "dolukoltuklar");
            //DropColumn("dbo.satisharekets", "koltukno");
            //RenameColumn(table: "dbo.satisharekets", name: "salonid", newName: "salonlar_salonid");
            //CreateIndex("dbo.satisharekets", "salonlar_salonid");
            //AddForeignKey("dbo.satisharekets", "salonlar_salonid", "dbo.salonlars", "salonid");
        }
    }
}
