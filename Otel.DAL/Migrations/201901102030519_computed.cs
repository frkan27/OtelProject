namespace Otel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class computed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationBills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id2 = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 11, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Id2 })
                .ForeignKey("dbo.Products", t => t.Id2, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Id2);
            
            AddColumn("dbo.ReservationDetails", "Room_Id", c => c.Int());
            CreateIndex("dbo.ReservationDetails", "Room_Id");
            AddForeignKey("dbo.ReservationDetails", "Room_Id", "dbo.Rooms", "Id");

          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationDetails", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.ReservationBills", "Id", "dbo.Reservations");
            DropForeignKey("dbo.ReservationBills", "Id2", "dbo.Products");
            DropIndex("dbo.ReservationDetails", new[] { "Room_Id" });
            DropIndex("dbo.ReservationBills", new[] { "Id2" });
            DropIndex("dbo.ReservationBills", new[] { "Id" });
            DropColumn("dbo.ReservationDetails", "Room_Id");
            DropTable("dbo.ReservationBills");
        }
    }
}
