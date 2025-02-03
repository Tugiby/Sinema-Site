namespace proje1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaldirsalon : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.salonlars", "filmozellik_filmid", "dbo.filmozelliks");
            //DropIndex("dbo.salonlars", new[] { "filmozellik_filmid" });
            //AddColumn("dbo.satisharekets", "salonid", c => c.Int(nullable: false));
            //CreateIndex("dbo.satisharekets", "salonid");
            //AddForeignKey("dbo.satisharekets", "salonid", "dbo.salonlars", "salonid", cascadeDelete: true);
            //DropColumn("dbo.salonlars", "filmozellik_filmid");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.salonlars", "filmozellik_filmid", c => c.Int());
            //DropForeignKey("dbo.satisharekets", "salonid", "dbo.salonlars");
            //DropIndex("dbo.satisharekets", new[] { "salonid" });
            //DropColumn("dbo.satisharekets", "salonid");
            //CreateIndex("dbo.salonlars", "filmozellik_filmid");
            //AddForeignKey("dbo.salonlars", "filmozellik_filmid", "dbo.filmozelliks", "filmid");
        }
    }
}
