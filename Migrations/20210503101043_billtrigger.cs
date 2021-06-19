using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class billtrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create  or replace trigger bill_trigger
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

update room rm
set rm.roomstatusid=1
where rm.id =roomid
end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop trigger bill_trigger"); 
        }
    }
}
