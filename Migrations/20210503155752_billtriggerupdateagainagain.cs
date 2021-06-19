using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class billtriggerupdateagainagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql(@"alter trigger bill_trigger
on reservation
after insert
as
begin
set nocount on;
insert into bill(
    reservationid,
numberofnightstay,
    discount,
    paymentstatusid,
    datecreated,
    updateddate
)
select
    i.id,
    DATEDIFF(day,checkin,checkout),
    0,
    1,
    getdate(),
    getdate()
    
from inserted i
end 

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
