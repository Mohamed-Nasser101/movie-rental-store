namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembership : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) values(1,'Pay as You Go',0,0,0)");
            Sql("insert into MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) values(2,'Monthly',30,1,10)");
            Sql("insert into MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) values(3,'Quarterly',90,3,15)");
            Sql("insert into MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) values(4,'Annual',300,12,20)");
        }

        public override void Down()
        {
        }
    }
}
