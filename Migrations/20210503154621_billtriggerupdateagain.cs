using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class billtriggerupdateagain : Migration
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
    roomid,
numberofnightstay,
    discount,
    paymentstatusid,
    datecreated,
    updateddate
)
select
    i.id,
    roomid,
    DATEDIFF(day,checkin,checkout),
    0,
    1,
    getdate(),
    getdate()

from inserted i
end 

begin
set nocount on;
update room 
set roomstatusid=1
where id =f.roomid
from inserted f
end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop trigger bill_trigger");

        }
    }
}
