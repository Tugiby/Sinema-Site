namespace proje1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaldirdogum : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.personels", "personeldogum");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.personels", "personeldogum", c => c.DateTime(nullable: false));
        }
    }
}
