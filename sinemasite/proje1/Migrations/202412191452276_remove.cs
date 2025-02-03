namespace proje1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.odemes", "rezervasyon_rezervasyonId", "dbo.rezervasyons");
            //DropForeignKey("dbo.satisharekets", "rezervasyon_rezervasyonId", "dbo.rezervasyons");
            //DropForeignKey("dbo.rezervasyons", "seansid", "dbo.seanslars");
            //DropIndex("dbo.satisharekets", new[] { "rezervasyon_rezervasyonId" });
            //DropIndex("dbo.odemes", new[] { "rezervasyon_rezervasyonId" });
            //DropIndex("dbo.rezervasyons", new[] { "seansid" });
            //DropColumn("dbo.satisharekets", "rezervasyon_rezervasyonId");
            //DropColumn("dbo.odemes", "rezervasyon_rezervasyonId");
            //DropTable("dbo.rezervasyons");
        }
        
        //public override void Down()
        //{
        //    CreateTable(
        //        "dbo.rezervasyons",
        //        c => new
        //            {
        //                rezervasyonId = c.Int(nullable: false, identity: true),
        //                rezervasyonTarihi = c.DateTime(nullable: false),
        //                koltukNumarasi = c.String(maxLength: 10, unicode: false),
        //                seansid = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.rezervasyonId);
            
        //    AddColumn("dbo.odemes", "rezervasyon_rezervasyonId", c => c.Int());
        //    AddColumn("dbo.satisharekets", "rezervasyon_rezervasyonId", c => c.Int());
        //    CreateIndex("dbo.rezervasyons", "seansid");
        //    CreateIndex("dbo.odemes", "rezervasyon_rezervasyonId");
        //    CreateIndex("dbo.satisharekets", "rezervasyon_rezervasyonId");
        //    AddForeignKey("dbo.rezervasyons", "seansid", "dbo.seanslars", "seansid", cascadeDelete: true);
        //    AddForeignKey("dbo.satisharekets", "rezervasyon_rezervasyonId", "dbo.rezervasyons", "rezervasyonId");
        //    AddForeignKey("dbo.odemes", "rezervasyon_rezervasyonId", "dbo.rezervasyons", "rezervasyonId");
        //}
    }
}
