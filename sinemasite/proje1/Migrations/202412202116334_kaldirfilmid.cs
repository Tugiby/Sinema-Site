namespace proje1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaldirfilmid : DbMigration
    {
        public override void Up()
        {
        //    //AddColumn("dbo.salonlars", "filmid", c => c.Int(nullable: false));
        //    AddColumn("dbo.salonlars", "kategoris_Kategoriid", c => c.Int());
        //    CreateIndex("dbo.salonlars", "kategoris_Kategoriid");
        //    AddForeignKey("dbo.salonlars", "kategoris_Kategoriid", "dbo.Kategoris", "Kategoriid");
        //    DropColumn("dbo.salonlars", "suankifilm");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.salonlars", "suankifilm", c => c.Int(nullable: false));
            //DropForeignKey("dbo.salonlars", "kategoris_Kategoriid", "dbo.Kategoris");
            //DropIndex("dbo.salonlars", new[] { "kategoris_Kategoriid" });
            //DropColumn("dbo.salonlars", "kategoris_Kategoriid");
            ////DropColumn("dbo.salonlars", "filmid");
        }
    }
}
