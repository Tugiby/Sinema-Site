namespace proje1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesalon_kategori : DbMigration
    {
        public override void Up()
        {
        //    DropForeignKey("dbo.salonlars", "kategoris_Kategoriid", "dbo.Kategoris");
        //    DropIndex("dbo.salonlars", new[] { "kategoris_Kategoriid" });
        //    DropColumn("dbo.salonlars", "kategoris_Kategoriid");
        }
        
        public override void Down()
        {
        //    AddColumn("dbo.salonlars", "kategoris_Kategoriid", c => c.Int());
        //    CreateIndex("dbo.salonlars", "kategoris_Kategoriid");
        //    AddForeignKey("dbo.salonlars", "kategoris_Kategoriid", "dbo.Kategoris", "Kategoriid");
        }
    }
}
