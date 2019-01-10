namespace Otel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class computed2 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.ReservationBills DROP COLUMN SubTotal");
            Sql("ALTER TABLE dbo.ReservationBills ADD [SubTotal] as ([Quantity] * [UnitPrice])");
        }
        
        public override void Down()
        {
            DropTable("dbo.ReservationBills");
        }
    }
}
