using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class SQLHMSRepo : IHMSRepo
    {
        private readonly HMSDbContext _context;

        public SQLHMSRepo(HMSDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void DisposeTransaction()
        {
            _context.Database.CurrentTransaction.Dispose();
        }



        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


        public User getUserByUserId(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);

        }

        public User getUserByToken(string token)
        {
            return _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
        }

        public void UpdateUser(User user)
        {

            _context.Update(user);
        }

        public RefreshToken getUserRefreshToken(User user, string token)
        {
            return user.RefreshTokens.Single(x => x.Token == token);
        }

        public User getUserbyUsernameAndPassword(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public IEnumerable<User> getUser()
        {
            return _context.Users.ToList();
        }

        public User getUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void createUser(User user)
        {
            var userExist = _context.Users.FirstOrDefault(u => u.Username == user.Username);
            if (userExist != null)
            {
                throw new Exception("Username Already Exists");

            }
            user.Username = user.Username.ToLower();
            _context.Users.Add(user);
        }

        public IEnumerable<Customer> getAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void createCustomer(Customer customer)
        {
            var customerExist= _context.Customers.FirstOrDefault(
                c =>c.Phone == customer.Phone
                ||c.Email ==customer.Email
                );

                if (customerExist !=null)
                {
                    throw new Exception("User Already Exist. Please update User");
                }
                customer.Email = customer.Email!=null? customer.Email.ToLower():"";
                _context.Add(customer);

        }

        public Customer getCustomerByNamePhoneEmail(string Phone)
        {
            return _context.Customers.FirstOrDefault(
                c=>c.Phone ==Phone
                );
        }

        public void createRoomType(RoomType roomType)
        {
            _context.RoomType.Add(roomType);
        }

        public IEnumerable<RoomType> getAllRoomTypes()
        {
            return _context.RoomType.ToList();
        }

        public RoomType getRoomType(int id)
        {
            return _context.RoomType.FirstOrDefault(rt =>rt.Id ==id);
        }

         public void createRoom(Room room)
        {
            var r = _context.Rooms.FirstOrDefault(r=>r.RoomNo==room.RoomNo);
            if(r!=null)
                throw new Exception("Room Number already exists");
            _context.Rooms.Add(room);
        }

         public IEnumerable<Room> getAllRooms()
        {
        //   var r=  _context.Rooms.Include(r => r.RoomType).ToList();
            return _context.Rooms.Include(r=>r.RoomType).ToList();
        }

             public Room getRoom(int id)
        {
            return _context.Rooms.FirstOrDefault(rt =>rt.Id ==id);
        }

        public Customer getCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(
                c=>c.Id ==id
                );
        }

        public void deleteCustomer(Customer customer)
        {
         if(customer ==null)
            throw new ArgumentNullException(nameof(customer));

            _context.Customers.Remove(customer);

            
        }

        public void updateCustomer(Customer customer)
        {
            //Nothing
        }

        public void createRoomStatus(RoomStatus roomStatus)
        {
           var rs = _context.RoomStatus.FirstOrDefault(r=>r.Name==roomStatus.Name);
            if(rs!=null)
                throw new Exception("Room Status already exists");
            _context.RoomStatus.Add(roomStatus);
        }

        public IEnumerable<RoomStatus> GetRoomStatus()
        {
          return  _context.RoomStatus.ToList();
        }

        public RoomStatus GetRoomStatus(int id)
        {
            return _context.RoomStatus.FirstOrDefault(rs=>rs.Id ==id);
        }

        public void deleteRoomType(RoomType roomType)
        {
                if(roomType ==null)
            throw new ArgumentNullException(nameof(roomType));

            _context.RoomType.Remove(roomType);
        }

        public void updateRoomType(RoomType roomtype)
        {
           //Do NOTHING 
        }

        public void updateRoom(Room room)
        {
            //DO NOTHING
        }

        public IEnumerable<Room> GetFreeRoom()
        {
            //seed the table for room status with bookedunpaid,bookedpaid,free,inuse 
          return  _context.Rooms.Where(c =>c.RoomStatusId==3).ToList();
        //_context.Rooms.Join
   
        }

        public void createReservation(Reservation reservation)
        {
          _context.Reservation.Add(reservation);
        }

        public IEnumerable<Reservation> GetReservations()
        {
          return  _context.Reservation.ToList();
        }

        public Reservation GetReservation(int id)
        {
           return _context.Reservation.Where(r =>r.Id ==id).FirstOrDefault();
        }

        public dynamic getreadRooms()
        {
            return  (from r in  _context.Rooms
      join rs in  _context.RoomStatus
      on r.RoomStatusId equals rs.Id
      join rt in _context.RoomType
      on r.RoomTypeId equals rt.Id
      select new
      {
          Id=r.Id,
    RoomNumber=r.RoomNo,
      Rate=r.Rate,
      RoomStatus=rs.Name,
      RoomType= rt.Name,
      }
       ).ToList();
        }
    }
}